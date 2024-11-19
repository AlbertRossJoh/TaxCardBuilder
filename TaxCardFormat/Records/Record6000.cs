using FileHelpers;
using TaxCardFormat.DataTypes.IPIndholdstype;
using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record6000<TPrevious> : Record6XXXBase<IRecord6000<TPrevious>, TPrevious>, IRecord6000<TPrevious>
{ 
    [FieldHidden] private TPrevious? _previous;
            
    public Record6000():this(default) {}
    
    public Record6000(TPrevious? previousRecord) : base(previousRecord)
    {
        _previous = previousRecord;
    }
    
    [FieldFixedLength(12)]
    public string filler1 = "";

    [FieldFixedLength(10)]
    public string? CPR;

    [FieldFixedLength(8)]
    public string? CVR_SE;

    [FieldFixedLength(15)]
    [FieldAlign(AlignMode.Right, ' ')]
    public string? MedarbejderNr;

    [FieldFixedLength(27)]
    [FieldAlign(AlignMode.Right, ' ')]
    public string? TIN;

    [FieldFixedLength(2)]
    public string? TIN_landekode;

    [FieldFixedLength(4)]
    [FieldAlign(AlignMode.Right, '0')]
    public required int Indtaegtsart;

    [FieldFixedLength(10)]
    [FieldAlign(AlignMode.Right, ' ')]
    public string? ProduktionEndhedsNummer;
    
    public IRecord6001<IRecord6000<TPrevious>> AddRecord6001(decimal beloeb, FeltNummer feltNummer)
    {
        return base.AddRecord6001(beloeb, feltNummer, this);
    }
    public IRecord6002<IRecord6000<TPrevious>> AddRecord6002(IndkomstFelt6002 indkomstFelt, string kodeFelt)
    {
        return base.AddRecord6002(indkomstFelt, kodeFelt, this);
    }

    public IRecord6003<IRecord6000<TPrevious>> AddRecord6003(IndkomstFelt600X indkomstFelt)
    {
        throw new NotImplementedException();
    }

    public IRecord6004<IRecord6000<TPrevious>> AddRecord6004(IndkomstFelt600X indkomstFelt, string fritekstFelt)
    {
        throw new NotImplementedException();
    }

    public IRecord6005<IRecord6000<TPrevious>> AddRecord6005(AntalsFelt6005 antalsFelt6005, decimal antal)
    {
        throw new NotImplementedException();
    }

    public IRecord6102<IRecord6000<TPrevious>> AddRecord6102(decimal beloeb, decimal feriedage, int ferieaar, DateTime fratraedelsesDato)
    {
        throw new NotImplementedException();
    }

    public IRecord6202<IRecord6000<TPrevious>> AddRecord6202(decimal beloeb, decimal feriedage, int ferieaar, DateTime fratraedelsesDato)
    {
        throw new NotImplementedException();
    }

    public IRecord6111<IRecord6000<TPrevious>> AddRecord6111(IPIndholdsType indholdsType, int antalEnheder, decimal beloeb)
    {
        throw new NotImplementedException();
    }

    public IRecord8001<IRecord6000<TPrevious>> AddRecord8001(DateTime foedselsdato, Koen koen, Landekoder landekoder, string navn, string adresse,
        string postnummer, string postby)
    {
        throw new NotImplementedException();
    }
}
