using FileHelpers;
using TaxCardFormat.DataTypes.IPIndholdstype;
using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record6004<TPrevious> : Record6XXXBase<TPrevious>, IRecord6004<TPrevious>
{
    [FieldFixedLength(4)]
    [FieldAlign(AlignMode.Right, '0')]
    public required int FeltNummer;

    [FieldFixedLength(58)]
    [FieldAlign(AlignMode.Right, ' ')]
    public required string Fritekstfelt;
    
    public Record6004(): this(default){}
        
    public Record6004(TPrevious? previousRecord) : base(previousRecord)
    {
    }
}
