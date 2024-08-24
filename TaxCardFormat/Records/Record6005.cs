using FileHelpers;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record6005 : TaxRecord
{
    [FieldFixedLength(4)]
    [FieldAlign(AlignMode.Right, '0')]
    public required int FeltNummer;

    [FieldFixedLength(6)]
    [FieldAlign(AlignMode.Right, '0')]
    public required int Antal;
    
    [FieldFixedLength(2)]
    [FieldAlign(AlignMode.Left, '0')]
    public required int AntalDecimal;


    [FieldFixedLength(1)]
    public required char Fortegn;
}
