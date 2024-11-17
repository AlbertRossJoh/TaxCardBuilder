using FileHelpers;
using TaxCardFormat.CustomConverters;
using TaxCardFormat.DataTypes;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record5000 : TaxRecord
{
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
    private char filler1 = ' ';

    [FieldFixedLength(1)]
    public char ForudElBagud = ' ';

    [FieldFixedLength(3)]
    [FieldAlign(AlignMode.Right, '0')]
    public int? GroenlandskKommune;

    [FieldFixedLength(2)]
    [FieldAlign(AlignMode.Right, '0')]
    public int? Indkomsttype;
}
