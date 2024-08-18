using FileHelpers;
using TaxCardFormat.CustomConverters;
using TaxCardFormat.DataTypes;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record4101 : TaxRecord
{
    [FieldFixedLength(16)]
    [FieldConverter(typeof(ShortIdConverter))]
    public required ShortId indberetningsId;

    [FieldFixedLength(16)]
    [FieldConverter(typeof(ShortIdConverter))]
    public ShortId? referenceId;

    [FieldFixedLength(1)]
    private string filler1 = "";

    [FieldFixedLength(1)]
    public required char Tilbageførsel;

    [FieldFixedLength(10)]
    public string? cpr;
}

