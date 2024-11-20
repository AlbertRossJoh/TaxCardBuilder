using FileHelpers;
using TaxCardFormat.DataTypes.IPIndholdstype;
using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record6001<TPrevious> : Record6XXXBase<TPrevious>, IRecord6001<TPrevious>
{
    public Record6001():this(default) {}

    public Record6001(TPrevious? previousRecord) : base(previousRecord){}
     
    [FieldFixedLength(4)]
    [FieldAlign(AlignMode.Right, '0')]
    public required int FeltNummer;

    [FieldFixedLength(10)]
    [FieldAlign(AlignMode.Right, '0')]
    public required int Beloeb;

    [FieldFixedLength(6)]
    [FieldAlign(AlignMode.Left, '0')]
    public required int BeloebDecimal;

    [FieldFixedLength(1)]
    public required char Fortegn;
}
