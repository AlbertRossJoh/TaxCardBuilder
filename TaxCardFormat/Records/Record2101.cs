using FileHelpers;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record2101 : TaxRecord
{
    [FieldFixedLength(10)]
    public required string personCpr;

    [FieldFixedLength(8)]
    private string filler1 = "";

    [FieldFixedLength(15)]
    private string medarbejderNrLetløn = "";

    [FieldFixedLength(8)]
    [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
    public required DateTime AnsættelsesDato;

    [FieldFixedLength(8)]
    [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
    [FieldAlign(AlignMode.Right, ' ')]
    public DateTime? FratrædelsesDato;

    [FieldFixedLength(24)]
    private string filler2 = "";

    [FieldFixedLength(1)]
    public required int SkattekortType;

    [FieldFixedLength(8)]
    [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
    public required DateTime SkaAnvendeFra;

    [FieldFixedLength(50)]
    [FieldAlign(AlignMode.Left, ' ')]
    public required string Suppl_opl_med_arbejdernr;

    [FieldFixedLength(1)]
    public required char GenRekvivering;
}

