using FileHelpers;
using TaxCardFormat.CustomConverters;
using TaxCardFormat.DataTypes;
using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record5000<TPrevious> : TaxRecordBase<TPrevious>, IRecord5000<TPrevious>
{
    public Record5000():this(default) {}
    public Record5000(TPrevious? previousRecord): base(previousRecord) {}
    
        
    [FieldFixedLength(1)]
    public char Rettelse_tidl_periode = ' ';

    [FieldFixedLength(16)]
    [FieldConverter(typeof(ShortIdConverter))]
    public required ShortId IndberetningsID;

    [FieldFixedLength(16)]
    [FieldConverter(typeof(ShortIdConverter))]
    public required ShortId ReferenceId;

    [FieldFixedLength(8)]
    [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
    public required DateTime LoenperiodeStart;

    [FieldFixedLength(8)]
    [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
    [FieldAlign(AlignMode.Right, ' ')]
    public required DateTime LoenperiodeSlut;

    [FieldFixedLength(8)]
    [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
    [FieldAlign(AlignMode.Right, ' ')]
    public DateTime? DispensationsDato;

    [FieldFixedLength(1)]
    public char filler1 = ' ';

    [FieldFixedLength(1)]
    public char ForudElBagud = ' ';

    [FieldFixedLength(3)]
    [FieldAlign(AlignMode.Right, '0')]
    public int? GroenlandskKommune;

    [FieldFixedLength(2)]
    [FieldAlign(AlignMode.Right, '0')]
    public int? Indkomsttype;
    
    public TPrevious GoBack() => _previous ?? throw new NullReferenceException("Previous record is null remember to set the previous record in the constructor");

    public IRecord6000<IRecord5000<TPrevious>> AddRecord6000(
        string cpr, 
        string cvr_se, 
        string medarbejderNr, 
        string tin, 
        Landekoder tin_landekode,
        IndkomstArt indkomstArt, 
        string? produktionEnhedsnummer = null)
    {
        if (cpr.Length != 10)
            throw new ArgumentException("Cpr length must be 10");
        if (cvr_se.Length != 8)
            throw new ArgumentException("Cvr se length must be 8");
        var child = new Record6000<IRecord5000<TPrevious>>(this)
        {
            CPR = cpr,
            CVR_SE = cvr_se,
            MedarbejderNr = medarbejderNr,
            TIN = tin,
            TIN_landekode = tin_landekode.ToString("G"),
            Indtaegtsart = (int)indkomstArt,
            ProduktionEndhedsNummer = produktionEnhedsnummer,
            Lb_nr = Lb_nr++,
            Rec_nr = 6000,
        };
        Children.Add(child);
        return child;
    }
}
