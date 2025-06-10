using FileHelpers;
using TaxCardFormat.DataTypes;
using TaxCardFormat.DataTypes.IPIndholdstype;
using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces;
using TaxCardFormat.RecordInterfaces.IRecord;
using TaxCardFormat.Records;
using TaxCardFormat.Utilities;

namespace TaxCardFormat.Builder;

public class TaxFileBuilder2
{
    
    private int Lb_nr = 1;
    public List<TaxRecord> Records { get; set; }= [];
    private Record1000? FirstRecord { get; set; }
    private MultiRecordEngine? Engine;

    public IRecord1000 AddRecord1000(
        string indberetterSeNummer,
        bool isTest,
        SystemUsage systemUsage,
        IndberetterType indberetterType,
        string? cvrNummer = null,
        DateTime? datoSendt = null,
        DateTime? klokSendt = null,
        string? edbSystem = null,
        ShortId? hovedIndberetningsId = null
    )
    {
        FirstRecord = new Record1000
        {
            Lb_nr = Lb_nr++,
            Rec_nr = 1000,
            Dato_sendt = datoSendt,
            Klok_sendt = klokSendt,
            Indberetter_SE_nummer = indberetterSeNummer,
            Indberetter_CVR_nummer = cvrNummer ?? "00000000",
            IndberetterType = (int)indberetterType,
            Edb_System = edbSystem,
            HovedindberetingsID = hovedIndberetningsId ?? new ShortId(),
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

    
    private MultiRecordEngine Build_RecordList()
    {
        if (FirstRecord == null) 
            throw new NullReferenceException("First record is null please call AddRecord1000 before building");
        if (Records.Count > 0 && Engine != null) return Engine;
        Records = FirstRecord.Flatten((record, i) => record.Lb_nr = i + 1);
        var allTypes = Records.Select(s => s.GetType()).ToHashSet().ToArray();
        Engine = new MultiRecordEngine(allTypes);
        return Engine;
    }

    public void Build(StreamWriter writer)
    {
        Build_RecordList().WriteStream(writer, Records);   
    }

    public Stream Build()
    {
        var ms = new MemoryStream();
        var sw = new StreamWriter(ms);
        Build_RecordList().WriteStream(sw, Records);
        ms.Position = 0;
        return ms;
    }

    public string BuildString()
    {
        return Build_RecordList().WriteString(Records);
    }
    
    public void Build(Stream stream)
    {
        using var sw = new StreamWriter(stream);
        Build_RecordList().WriteStream(sw, Records);
    }

    public void Build(string filePath)
    {
        using var tw = File.CreateText(filePath);
        Build_RecordList().WriteStream(tw, Records);
    }
}
