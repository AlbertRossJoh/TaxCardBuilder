using FileHelpers;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public abstract class TaxRecord
{
    [FieldFixedLength(7)] [FieldAlign(AlignMode.Right, '0')]
    public required int Lb_nr;

    [FieldFixedLength(4)] public required int Rec_nr;
}