using FileHelpers;
using TaxCardFormat.DataTypes.IPIndholdstype;
using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record6001<TPrevious> : Record6XXXBase<IRecord6001<TPrevious>, TPrevious>, IRecord6001<TPrevious>
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

    public IRecord6001<IRecord6001<TPrevious>> AddRecord6001(decimal beloeb, FeltNummer feltNummer)
    {
        throw new NotImplementedException();
    }

    public IRecord6002<IRecord6001<TPrevious>> AddRecord6002(IndkomstFelt6002 indkomstFelt, string kodeFelt)
    {
        throw new NotImplementedException();
    }

    public IRecord6003<IRecord6001<TPrevious>> AddRecord6003(IndkomstFelt600X indkomstFelt)
    {
        throw new NotImplementedException();
    }

    public IRecord6004<IRecord6001<TPrevious>> AddRecord6004(IndkomstFelt600X indkomstFelt, string fritekstFelt)
    {
        throw new NotImplementedException();
    }

    public IRecord6005<IRecord6001<TPrevious>> AddRecord6005(AntalsFelt6005 antalsFelt6005, decimal antal)
    {
        throw new NotImplementedException();
    }

    public IRecord6102<IRecord6001<TPrevious>> AddRecord6102(decimal beloeb, decimal feriedage, int ferieaar, DateTime fratraedelsesDato)
    {
        throw new NotImplementedException();
    }

    public IRecord6202<IRecord6001<TPrevious>> AddRecord6202(decimal beloeb, decimal feriedage, int ferieaar, DateTime fratraedelsesDato)
    {
        throw new NotImplementedException();
    }

    public IRecord6111<IRecord6001<TPrevious>> AddRecord6111(IPIndholdsType indholdsType, int antalEnheder, decimal beloeb)
    {
        throw new NotImplementedException();
    }
}
