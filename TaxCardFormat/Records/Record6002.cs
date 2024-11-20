using FileHelpers;
using TaxCardFormat.DataTypes.IPIndholdstype;
using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record6002<TPrevious> : Record6XXXBase<TPrevious>, IRecord6002<TPrevious>
{
    [FieldFixedLength(4)]
    [FieldAlign(AlignMode.Right, '0')]
    public required int FeltNummer;

    [FieldFixedLength(10)]
    [FieldAlign(AlignMode.Right, '0')]
    public required string KodeFelt;

    [FieldHidden] private TPrevious? _previous;
    public Record6002() : this(default){}
    public Record6002(TPrevious? previousRecord) : base(previousRecord)
    {
        _previous = previousRecord;
    }
}
