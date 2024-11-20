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
    
    public IRecord6004<TBase> AddRecord6004(IndkomstFelt600X indkomstFelt, string fritekstFelt, TBase parent)
    {
        var child = new Record6004<TBase>(parent)
        {
            Lb_nr = Lb_nr++,
            Rec_nr = 6004,
            FeltNummer = (int)indkomstFelt,
            Fritekstfelt = fritekstFelt
        };
        Children.Add(child);
        return child;
    }
    
    public IRecord6005<TBase> AddRecord6005(AntalsFelt6005 antalsFelt6005, decimal antal, TBase parent)
    {
        var (amnt, decimals) = NumberFormattingUtils.ExtractDecimalParts(antal);
        var child = new Record6005<TBase>(parent)
        {
            Lb_nr = Lb_nr++,
            Rec_nr = 6005,
            FeltNummer = (int)antalsFelt6005,
            Antal = amnt,
            AntalDecimal = decimals,
            Fortegn = antal > 0 ? '+' : '-'
        };
        Children.Add(child);
        return child;
    }
    
    public IRecord6102<TBase> AddRecord6102(decimal beloeb, decimal feriedage, int ferieaar, DateTime  fratraedelsesDato, TBase parent)
    {
        var (amnt, decimals) = NumberFormattingUtils.ExtractDecimalParts(beloeb);
        var (amntFeriedage, decimalsFeriedage) = NumberFormattingUtils.ExtractDecimalParts(feriedage);
                
        var child = new Record6102<TBase>(parent)
        {
            Lb_nr = Lb_nr++,
            Rec_nr = 6102,
            Beloeb = amnt,
            BeloebDecimal = decimals,
            FortegnFeriepenge = NumberFormattingUtils.Fortegn(beloeb),
            FeriedageHeltal = amntFeriedage,
            FeriedageDecimal = decimalsFeriedage,
            FortegnFeiedage = NumberFormattingUtils.Fortegn(feriedage),
            Ferieaar = ferieaar,
            FratraedelsesDato = fratraedelsesDato
        };
        Children.Add(child);
        return child;
    }
    
    public IRecord6202<TBase> AddRecord6202(decimal beloeb, decimal feriedage, int ferieaar, DateTime  fratraedelsesDato, TBase parent)
    {
        var (amnt, decimals) = NumberFormattingUtils.ExtractDecimalParts(beloeb);
        var (amntFeriedage, decimalsFeriedage) = NumberFormattingUtils.ExtractDecimalParts(feriedage);

        var child = new Record6202<TBase>(parent)
        {
            Lb_nr = Lb_nr++,
            Rec_nr = 6202,
            Beloeb = amnt,
            BeloebDecimal = decimals,
            FortegnFeriepenge = NumberFormattingUtils.Fortegn(beloeb),
            FeriedageHeltal = amntFeriedage,
            FeriedageDecimal = decimalsFeriedage,
            FortegnFeiedage = NumberFormattingUtils.Fortegn(feriedage),
            Ferieaar = ferieaar,
            FratraedelsesDato = fratraedelsesDato
        };
        Children.Add(child);
        return child;
    }
    
    public IRecord6111<TBase> AddRecord6111(IPIndholdsType indholdsType, int antalEnheder, decimal beloeb, TBase parent)
    {
        
        var (amnt, decimals) = NumberFormattingUtils.ExtractDecimalParts(beloeb);
        var child = new Record6111<TBase>(parent)
        {
            Lb_nr = Lb_nr++,
            Rec_nr = 6111,
            IndholdsType = indholdsType.Kode,
            AntalEnheder = antalEnheder,
            FortegnAntalEnheder = NumberFormattingUtils.Fortegn(antalEnheder),
            Beloeb = amnt,
            BeloebDecimal = decimals,
            FortegnBeloeb = NumberFormattingUtils.Fortegn(beloeb)
        };
        Children.Add(child);
        return child;
    }
    
    public TBase AddRecord8001(DateTime foedselsdato, Koen koen, Landekoder landekoder, string  navn, string adresse,
        string postnummer, string postby, TBase parent)
    {
        var child = new Record8001<TBase>(parent)
        {
            Lb_nr = Lb_nr++,
            Rec_nr = 8001,
            PersonFoedselsdato = foedselsdato,
            PersonKoen = (int)koen,
            PersonLand = landekoder.ToString("G"),
            PersonNavn = navn,
            PersonGadeAdresse = adresse,
            PersonPostnummer = postnummer,
            PersonPostby = postby,
        };
        Children.Add(child);
        return parent;
   }
}
