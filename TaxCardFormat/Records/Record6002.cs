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
        return base.AddRecord6001(beloeb, feltNummer, this);
    }
    public IRecord6002<IRecord6002<TPrevious>> AddRecord6002(IndkomstFelt6002 indkomstFelt, string kodeFelt)
    {
        return base.AddRecord6002(indkomstFelt, kodeFelt, this);
    }

    public IRecord6003<IRecord6002<TPrevious>> AddRecord6003(IndkomstFelt600X indkomstFelt)
    {
        return base.AddRecord6003(indkomstFelt, this);
    }

    public IRecord6004<IRecord6002<TPrevious>> AddRecord6004(IndkomstFelt600X indkomstFelt, string fritekstFelt)
    {
        return base.AddRecord6004(indkomstFelt, fritekstFelt, this);
    }

    public IRecord6005<IRecord6002<TPrevious>> AddRecord6005(AntalsFelt6005 antalsFelt6005, decimal antal)
    {
        return base.AddRecord6005(antalsFelt6005, antal, this);
    }

    public IRecord6102<IRecord6002<TPrevious>> AddRecord6102(decimal beloeb, decimal feriedage, int ferieaar, DateTime fratraedelsesDato)
    {
        return base.AddRecord6102(beloeb, feriedage, ferieaar, fratraedelsesDato, this);
    }

    public IRecord6202<IRecord6002<TPrevious>> AddRecord6202(decimal beloeb, decimal feriedage, int ferieaar, DateTime fratraedelsesDato)
    {
        return base.AddRecord6202(beloeb, feriedage, ferieaar, fratraedelsesDato, this);
    }

    public IRecord6111<IRecord6002<TPrevious>> AddRecord6111(IPIndholdsType indholdsType, int antalEnheder, decimal beloeb)
    {
        return base.AddRecord6111(indholdsType, antalEnheder, beloeb, this);
    }
}
