using FileHelpers;
using TaxCardFormat.DataTypes;
using TaxCardFormat.DataTypes.IPIndholdstype;
using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces;
using TaxCardFormat.Records;

namespace TaxCardFormat.Builder;

public class TaxFileBuilder2
{
    
    private int Lb_nr = 1;
    public List<TaxRecord> Records { get; set; }= [];
    private Record1000? FirstRecord { get; set; }
    private MultiRecordEngine Engine = new(
        typeof(TaxRecord),
        typeof(Record1000),
        typeof(Record2001<object>),
        typeof(Record2101<object>),
        typeof(Record2111<object>),
        typeof(Record3101<object>),
        typeof(Record4101<object>),
        typeof(Record5000<object>),
        typeof(Record6000),
        typeof(Record6001),
        typeof(Record6002),
        typeof(Record6003),
        typeof(Record6004),
        typeof(Record6005),
        typeof(Record6102),
        typeof(Record6202),
        typeof(Record6111),
        typeof(Record8001),
        typeof(Record9999)
    );

    public IRecord1000 AddRecord1000(
        string indberetterSeNummer,
        bool isTest,
        SystemUsage systemUsage,
        IndberetterType indberetterType,
        string? cvrNummer = null,
        DateTime? datoSendt = null,
        DateTime? klokSendt = null,
        string? edbSystem = null,
        ShortId hovedIndberetningsId = default
    )
    {
        FirstRecord = new Record1000
        {
            Lb_nr = Lb_nr++,
            Rec_nr = 1000,
            Dato_sendt = datoSendt,
            Klok_sendt = klokSendt,
            Indberetter_SE_nummer = indberetterSeNummer,
            Indberetter_CVR_nummer = cvrNummer ?? "",
            IndberetterType = (int)indberetterType,
            Edb_System = edbSystem,
            HovedindberetingsID = hovedIndberetningsId,
            IsTest = isTest ? 'T' : 'P',
            EIndkomst_Letloen = GetSystem(systemUsage)
        };
        return FirstRecord;
    }

    private static char GetSystem(SystemUsage systemUsage) =>
        systemUsage switch
        {
            SystemUsage.Eindkomst => 'E',
            SystemUsage.LetLoen => 'L',
            _
                => throw new ArgumentOutOfRangeException(
                    nameof(systemUsage),
                    systemUsage,
                    "Not a valid system"
                )
        };

    private void RecurseBuildList(TaxRecord taxRecord)
    {
        Records.Add(taxRecord);
        foreach (var record in taxRecord.ChildrenList)
        {
            RecurseBuildList(record);
        }
    }
    public void Build_RecordList()
    {
        if (FirstRecord == null) 
            throw new NullReferenceException("First record is null please call AddRecord1000 before building");
        //Records = FirstRecord.ChildrenList.SelectMany(i => i.ChildrenList).ToList();
        RecurseBuildList(FirstRecord);
        var allTypes = Records.Select(s => s.GetType()).ToArray();
        Engine = new MultiRecordEngine(allTypes);
    }

    public void Build(StreamWriter writer) => Engine.WriteStream(writer, Records);

    public Stream Build()
    {
        var ms = new MemoryStream();
        var sw = new StreamWriter(ms);
        Engine.WriteStream(sw, Records);
        sw.Flush();
        ms.Position = 0;
        return ms;
    }

    public string BuildString()
    {
        return Engine.WriteString(Records);
    }
    
    public void Build(Stream stream)
    {
        using var sw = new StreamWriter(stream);
        Engine.WriteStream(sw, Records);
    }

    public void Build(string filePath)
    {
        using var tw = File.CreateText(filePath);
        Engine.WriteStream(tw, Records);
    }}