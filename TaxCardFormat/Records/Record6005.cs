using FileHelpers;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record6005 : TaxRecord
{
    [FieldFixedLength(4)]
    [FieldAlign(AlignMode.Right, '0')]
    public required int FeltNummer;

    [FieldFixedLength(8)]
    [FieldAlign(AlignMode.Right, '0')]
    public required int Antal;

    [FieldFixedLength(1)]
    public required char Fortegn;
}
