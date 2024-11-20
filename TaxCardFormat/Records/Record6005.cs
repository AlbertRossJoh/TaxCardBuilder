using FileHelpers;
using TaxCardFormat.DataTypes.IPIndholdstype;
using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record6005<TPrevious> : Record6XXXBase<TPrevious>, IRecord6005<TPrevious>
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

    
    public Record6005(): this(default){}
    
    public Record6005(TPrevious? previousRecord) : base(previousRecord)
    {
    }
}
