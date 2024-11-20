using FileHelpers;
using TaxCardFormat.DataTypes.IPIndholdstype;
using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record6003<TPrevious> : Record6XXXBase<TPrevious>, IRecord6003<TPrevious>
{
    [FieldFixedLength(4)]
    [FieldAlign(AlignMode.Right, '0')]
    public required int FeltNummer;

    [FieldFixedLength(1)]
    public required char Krydsfelt;

    public Record6003(): this(default){}
    
    public Record6003(TPrevious? previousRecord) : base(previousRecord)
    {
    }
}
