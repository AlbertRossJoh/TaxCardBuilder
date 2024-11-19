using FileHelpers;
using TaxCardFormat.DataTypes.IPIndholdstype;
using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces.IRecord;
using TaxCardFormat.Utilities;

namespace TaxCardFormat.Records;

public abstract class Record6XXXBase<TBase, TPrevious> : TaxRecord
{
    
    [FieldHidden] private TPrevious? _previous;

    public Record6XXXBase(TPrevious? previousRecord)
    {
        _previous = previousRecord;
    }
    
    public TPrevious GoBack() => _previous ?? throw new NullReferenceException("Previous record is null remember to set the previous record in the constructor");
    
    protected IRecord6001<TBase> AddRecord6001(
        decimal beloeb, 
        FeltNummer feltNummer,
        TBase parent)
    {
        var (amnt, decimals) = NumberFormattingUtils.ExtractDecimalParts(beloeb);
        var child = new Record6001<TBase>(parent)
        {
            Lb_nr = Lb_nr++,
            Rec_nr = 6001,
            Beloeb = amnt,
            BeloebDecimal = decimals,
            FeltNummer = (int)feltNummer,
            Fortegn = beloeb > 0 ? '+' : '-'
        };
        Children.Add(child);
        return child;
    }
    
    protected IRecord6002<TBase> AddRecord6002(IndkomstFelt6002 indkomstFelt, string kodeFelt, TBase parent)
    {
        var child = new Record6002<TBase>(parent)
            {
                Lb_nr = Lb_nr++,
                Rec_nr = 6002,
                FeltNummer = (int)indkomstFelt,
                KodeFelt = kodeFelt,
            };
        Children.Add(child);
        return child;
    }
    
    public IRecord6003<TBase> AddRecord6003(IndkomstFelt600X indkomstFelt, TBase parent)
    {
        var child = new Record6003<TBase>(parent)
            {
                Lb_nr = Lb_nr++,
                Rec_nr = 6003,
                FeltNummer = (int)indkomstFelt,
                Krydsfelt = 'X',
            };
        Children.Add(child);
        return child;
    }
    
    public IRecord6004<IRecord6000<TPrevious>> AddRecord6004(IndkomstFelt600X indkomstFelt, string fritekstFelt)
    {
        throw new NotImplementedException();
    }
    
    public IRecord6005<IRecord6000<TPrevious>> AddRecord6005(AntalsFelt6005 antalsFelt6005, decimal antal)
    {
        throw new NotImplementedException();
    }
    
    public IRecord6102<IRecord6000<TPrevious>> AddRecord6102(decimal beloeb, decimal feriedage, int ferieaar, DateTime  fratraedelsesDato)
    {
        throw new NotImplementedException();
    }
    
    public IRecord6202<IRecord6000<TPrevious>> AddRecord6202(decimal beloeb, decimal feriedage, int ferieaar, DateTime  fratraedelsesDato)
    {
        throw new NotImplementedException();
    }
    
    public IRecord6111<IRecord6000<TPrevious>> AddRecord6111(IPIndholdsType indholdsType, int antalEnheder, decimal beloeb)
    {
        throw new NotImplementedException();
    }
    
    public IRecord8001<IRecord6000<TPrevious>> AddRecord8001(DateTime foedselsdato, Koen koen, Landekoder landekoder, string  navn, string adresse,
        string postnummer, string postby)
   {
       throw new NotImplementedException();
   }
}
