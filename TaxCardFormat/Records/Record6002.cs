using FileHelpers;
using TaxCardFormat.DataTypes.IPIndholdstype;
using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record6002<TPrevious> : Record6XXXBase<IRecord6002<TPrevious>, TPrevious>, IRecord6002<TPrevious>
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

    public IRecord6001<IRecord6002<TPrevious>> AddRecord6001(decimal beloeb, FeltNummer feltNummer)
    {
        throw new NotImplementedException();
    }

    public IRecord6002<IRecord6002<TPrevious>> AddRecord6002(IndkomstFelt6002 indkomstFelt, string kodeFelt)
    {
        throw new NotImplementedException();
    }

    public IRecord6003<IRecord6002<TPrevious>> AddRecord6003(IndkomstFelt600X indkomstFelt)
    {
        throw new NotImplementedException();
    }

    public IRecord6004<IRecord6002<TPrevious>> AddRecord6004(IndkomstFelt600X indkomstFelt, string fritekstFelt)
    {
        throw new NotImplementedException();
    }

    public IRecord6005<IRecord6002<TPrevious>> AddRecord6005(AntalsFelt6005 antalsFelt6005, decimal antal)
    {
        throw new NotImplementedException();
    }

    public IRecord6102<IRecord6002<TPrevious>> AddRecord6102(decimal beloeb, decimal feriedage, int ferieaar, DateTime fratraedelsesDato)
    {
        throw new NotImplementedException();
    }

    public IRecord6202<IRecord6002<TPrevious>> AddRecord6202(decimal beloeb, decimal feriedage, int ferieaar, DateTime fratraedelsesDato)
    {
        throw new NotImplementedException();
    }

    public IRecord6111<IRecord6002<TPrevious>> AddRecord6111(IPIndholdsType indholdsType, int antalEnheder, decimal beloeb)
    {
        throw new NotImplementedException();
    }
}
