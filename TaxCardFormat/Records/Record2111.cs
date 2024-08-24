using FileHelpers;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record2111 : TaxRecord
{
    [FieldFixedLength(4)]
    [FieldAlign(AlignMode.Right, '0')]
    public required int indholdstype;

    [FieldFixedLength(12)]
    [FieldAlign(AlignMode.Right, '0')]
    public int? medarbejderKode;

    [FieldFixedLength(8)]
    [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
    public DateTime? ikræftrædelsesDato;
}

