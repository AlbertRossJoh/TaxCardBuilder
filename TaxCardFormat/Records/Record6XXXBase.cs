using FileHelpers;
using TaxCardFormat.DataTypes.IPIndholdstype;
using TaxCardFormat.DataTypes.Loenoplysninger;
using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces.IRecord;
using TaxCardFormat.Utilities;

namespace TaxCardFormat.Records;

public abstract class Record6XXXBase<TPrevious> : TaxRecord
{
    
    [FieldHidden] protected TPrevious? _previous;

    public Record6XXXBase(TPrevious? previousRecord)
    {
        _previous = previousRecord;
    }
    
    public TPrevious GoBack() => _previous ?? throw new NullReferenceException("Previous record is null remember to set the previous record in the constructor");
    
    public IRecord6001<TPrevious> AddRecord6001(
        decimal beloeb, 
        Vaerdisaet6001 feltNummer)
    {
        var (amnt, decimals) = NumberFormattingUtils.ExtractDecimalParts(beloeb);
        var child = new Record6001<TPrevious>(_previous)
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
    
    public IRecord6002<TPrevious> AddRecord6002(Vaerdisaet6002 indkomstFelt, string kodeFelt)
    {
        var child = new Record6002<TPrevious>(_previous)
            {
                Lb_nr = Lb_nr++,
                Rec_nr = 6002,
                FeltNummer = (int)indkomstFelt,
                KodeFelt = kodeFelt,
            };
        Children.Add(child);
        return child;
    }
    
    public IRecord6003<TPrevious> AddRecord6003(Vaerdisaet6003 indkomstFelt)
    {
        var child = new Record6003<TPrevious>(_previous)
            {
                Lb_nr = Lb_nr++,
                Rec_nr = 6003,
                FeltNummer = (int)indkomstFelt,
                Krydsfelt = 'X',
            };
        Children.Add(child);
        return child;
    }
    
    public IRecord6004<TPrevious> AddRecord6004(Vaerdisaet6004 indkomstFelt, string fritekstFelt)
    {
        var child = new Record6004<TPrevious>(_previous)
        {
            Lb_nr = Lb_nr++,
            Rec_nr = 6004,
            FeltNummer = (int)indkomstFelt,
            Fritekstfelt = fritekstFelt
        };
        Children.Add(child);
        return child;
    }
    
    public IRecord6005<TPrevious> AddRecord6005(AntalsFelt6005 antalsFelt6005, decimal antal)
    {
        var (amnt, decimals) = NumberFormattingUtils.ExtractDecimalParts(antal);
        var child = new Record6005<TPrevious>(_previous)
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
    
    public IRecord6102<TPrevious> AddRecord6102(decimal beloeb, decimal feriedage, int ferieaar, DateTime  fratraedelsesDato)
    {
        var (amnt, decimals) = NumberFormattingUtils.ExtractDecimalParts(beloeb);
        var (amntFeriedage, decimalsFeriedage) = NumberFormattingUtils.ExtractDecimalParts(feriedage);
                
        var child = new Record6102<TPrevious>(_previous)
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
    
    public IRecord6202<TPrevious> AddRecord6202(decimal beloeb, decimal feriedage, int ferieaar, DateTime  fratraedelsesDato)
    {
        var (amnt, decimals) = NumberFormattingUtils.ExtractDecimalParts(beloeb);
        var (amntFeriedage, decimalsFeriedage) = NumberFormattingUtils.ExtractDecimalParts(feriedage);

        var child = new Record6202<TPrevious>(_previous)
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
    
    public IRecord6111<TPrevious> AddRecord6111(Loenoplysninger loenoplysninger)
    {
        
        var (amnt, decimals) = NumberFormattingUtils.ExtractDecimalParts(loenoplysninger.Beloeb);
        var child = new Record6111<TPrevious>(_previous)
        {
            Lb_nr = Lb_nr++,
            Rec_nr = 6111,
            IndholdsType = loenoplysninger.Type,
            AntalEnheder = loenoplysninger.Enheder,
            FortegnAntalEnheder = NumberFormattingUtils.Fortegn(loenoplysninger.Enheder),
            Beloeb = amnt,
            BeloebDecimal = decimals,
            FortegnBeloeb = NumberFormattingUtils.Fortegn(loenoplysninger.Beloeb)
        };
        Children.Add(child);
        return child;
    }
    
    
}
