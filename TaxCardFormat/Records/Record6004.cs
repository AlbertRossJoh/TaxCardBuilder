using FileHelpers;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record6004 : TaxRecord
{
    [FieldFixedLength(4)]
    [FieldAlign(AlignMode.Right, '0')]
    public required int FeltNummer;

    [FieldFixedLength(58)]
    [FieldAlign(AlignMode.Right, ' ')]
    public required string Fritekstfelt;
}
