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
        return base.AddRecord6001(beloeb, feltNummer, this);
    }
    public IRecord6002<IRecord6001<TPrevious>> AddRecord6002(IndkomstFelt6002 indkomstFelt, string kodeFelt)
    {
        return base.AddRecord6002(indkomstFelt, kodeFelt, this);
    }

    public IRecord6003<IRecord6001<TPrevious>> AddRecord6003(IndkomstFelt600X indkomstFelt)
    {
        return base.AddRecord6003(indkomstFelt, this);
    }

    public IRecord6004<IRecord6001<TPrevious>> AddRecord6004(IndkomstFelt600X indkomstFelt, string fritekstFelt)
    {
        return base.AddRecord6004(indkomstFelt, fritekstFelt, this);
    }

    public IRecord6005<IRecord6001<TPrevious>> AddRecord6005(AntalsFelt6005 antalsFelt6005, decimal antal)
    {
        return base.AddRecord6005(antalsFelt6005, antal, this);
    }

    public IRecord6102<IRecord6001<TPrevious>> AddRecord6102(decimal beloeb, decimal feriedage, int ferieaar, DateTime fratraedelsesDato)
    {
        return base.AddRecord6102(beloeb, feriedage, ferieaar, fratraedelsesDato, this);
    }

    public IRecord6202<IRecord6001<TPrevious>> AddRecord6202(decimal beloeb, decimal feriedage, int ferieaar, DateTime fratraedelsesDato)
    {
        return base.AddRecord6202(beloeb, feriedage, ferieaar, fratraedelsesDato, this);
    }

    public IRecord6111<IRecord6001<TPrevious>> AddRecord6111(IPIndholdsType indholdsType, int antalEnheder, decimal beloeb)
    {
        return base.AddRecord6111(indholdsType, antalEnheder, beloeb, this);
    }
}
