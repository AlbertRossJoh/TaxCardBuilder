using FileHelpers;
using TaxCardFormat.CustomConverters;
using TaxCardFormat.DataTypes;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record3101 : TaxRecord
{
    [FieldFixedLength(1)]
    public required char ForudElBagud;

    [FieldFixedLength(16)]
    [FieldConverter(typeof(ShortIdConverter))]
    public required ShortId indberetningsId;

    [FieldFixedLength(16)]
    [FieldConverter(typeof(ShortIdConverter))]
    public ShortId? referenceId;

    [FieldFixedLength(8)]
    [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
    public required DateTime PeriodeIndberetStart;

    [FieldFixedLength(8)]
    [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
    public required DateTime PeriodeIndberetSlut;

    [FieldFixedLength(1)]
    public required char Nulangivelse;

    [FieldFixedLength(4)]
    public int? FeltNummer;

    [FieldFixedLength(10)]
    [FieldAlign(AlignMode.Right, '0')]
    public required int Amount;

    [FieldFixedLength(10)]
    [FieldAlign(AlignMode.Left, '0')]
    public required int Decimals;

    [FieldFixedLength(1)]
    public required char Sign;
}
