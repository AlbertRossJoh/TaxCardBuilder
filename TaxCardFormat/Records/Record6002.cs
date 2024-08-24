using FileHelpers;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record6002 : TaxRecord
{
    [FieldFixedLength(4)]
    [FieldAlign(AlignMode.Right, '0')]
    public required int FeltNummer;

    [FieldFixedLength(10)]
    [FieldAlign(AlignMode.Right, '0')]
    public required string KodeFelt;
}
