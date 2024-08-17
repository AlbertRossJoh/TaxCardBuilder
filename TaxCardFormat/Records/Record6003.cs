using FileHelpers;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record6003 : TaxRecord
{
    [FieldFixedLength(4)]
    [FieldAlign(AlignMode.Right, '0')]
    public required int FeltNummer;

    [FieldFixedLength(1)]
    public required char Krydsfelt;
}
