using FileHelpers;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record2101 : TaxRecord
{
    [FieldFixedLength(10)]
    public required string PersonCpr;

    [FieldFixedLength(8)]
    private string filler1 = "";

    [FieldFixedLength(15)]
    public string? medarbejderNrLetloen;

    [FieldFixedLength(8)]
    [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
    public required DateTime AnsaettelsesDato;

    [FieldFixedLength(8)]
    [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
    [FieldAlign(AlignMode.Right, ' ')]
    public DateTime? FratraedelsesDato;

    [FieldFixedLength(24)]
    private string filler2 = "";

    [FieldFixedLength(1)]
    public required int SkattekortType;

    [FieldFixedLength(8)]
    [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
    public required DateTime SkaAnvendeFra;

    [FieldFixedLength(50)]
    [FieldAlign(AlignMode.Left, ' ')]
    public string? Suppl_opl_med_arbejdernr;

    [FieldFixedLength(1)]
    public char? GenRekvivering;
}

