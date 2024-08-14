using FileHelpers;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record6001: TaxRecord
{
    [FieldFixedLength(4)] [FieldAlign(AlignMode.Right, '0')]
    public int FeltNummer;

    [FieldFixedLength(10)] [FieldAlign(AlignMode.Right, '0')]
    public int Beløb;
    
    [FieldFixedLength(6)] [FieldAlign(AlignMode.Left, '0')]
    public int BeløbDecimal;

    [FieldFixedLength(1)] public char Fortegn;
}
