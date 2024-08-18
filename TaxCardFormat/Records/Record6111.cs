using FileHelpers;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record6111 : TaxRecord
{
    [FieldFixedLength(4)]
    [FieldAlign(AlignMode.Right, '0')]
    public required int IndholdsType;

    [FieldFixedLength(10)]
    [FieldAlign(AlignMode.Right, '0')]
    public required int AntalEnheder;

    [FieldFixedLength(1)]
    public required char FortegnAntalEnheder;

    [FieldFixedLength(10)]
    [FieldAlign(AlignMode.Right, '0')]
    public required int Beløb;

    [FieldFixedLength(6)]
    [FieldAlign(AlignMode.Left, '0')]
    public required int BeløbDecimal;

    [FieldFixedLength(1)]
    public required char FortegnBeløb;
}