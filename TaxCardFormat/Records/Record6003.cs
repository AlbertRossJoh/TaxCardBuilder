using FileHelpers;
using TaxCardFormat.DataTypes.IPIndholdstype;
using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record6003<TPrevious> : Record6XXXBase<IRecord6003<TPrevious>, TPrevious>, IRecord6003<TPrevious>
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

    public IRecord6001<IRecord6003<TPrevious>> AddRecord6001(decimal beloeb, FeltNummer feltNummer)
    {
        throw new NotImplementedException();
    }

    public IRecord6002<IRecord6003<TPrevious>> AddRecord6002(IndkomstFelt6002 indkomstFelt, string kodeFelt)
    {
        throw new NotImplementedException();
    }

    public IRecord6003<IRecord6003<TPrevious>> AddRecord6003(IndkomstFelt600X indkomstFelt)
    {
        throw new NotImplementedException();
    }

    public IRecord6004<IRecord6003<TPrevious>> AddRecord6004(IndkomstFelt600X indkomstFelt, string fritekstFelt)
    {
        throw new NotImplementedException();
    }

    public IRecord6005<IRecord6003<TPrevious>> AddRecord6005(AntalsFelt6005 antalsFelt6005, decimal antal)
    {
        throw new NotImplementedException();
    }

    public IRecord6102<IRecord6003<TPrevious>> AddRecord6102(decimal beloeb, decimal feriedage, int ferieaar, DateTime fratraedelsesDato)
    {
        throw new NotImplementedException();
    }

    public IRecord6202<IRecord6003<TPrevious>> AddRecord6202(decimal beloeb, decimal feriedage, int ferieaar, DateTime fratraedelsesDato)
    {
        throw new NotImplementedException();
    }

    public IRecord6111<IRecord6003<TPrevious>> AddRecord6111(IPIndholdsType indholdsType, int antalEnheder, decimal beloeb)
    {
        throw new NotImplementedException();
    }
}
