using FileHelpers;
using TaxCardFormat.DataTypes;
using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces;
using TaxCardFormat.Utilities;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record2111<TPrevious> : TaxRecord, IRecord2111<TPrevious>
{
    [FieldHidden] private TPrevious? _previous;
    public Record2111():this(default) {}

    public Record2111(TPrevious? previousRecord)
    {
        _previous = previousRecord;
    }   
    
    [FieldFixedLength(4)]
    [FieldAlign(AlignMode.Right, '0')]
    public required int indholdstype;

    [FieldFixedLength(12)]
    [FieldAlign(AlignMode.Right, '0')]
    public int? medarbejderKode;

    [FieldFixedLength(8)]
    [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
    public DateTime? ikraeftraedelsesDato;
    
    public TPrevious? GoBack() => _previous;
    
    public IRecord3101<IRecord2111<TPrevious>> AddRecord3101(
        decimal beloeb,
        bool forudBetalt,
        DateTime periodeIndberetStart,
        DateTime periodeIndberetSlut,
        FeltNummer feltNummer,
        ShortId indberetningsId = default,
        ShortId? referenceId = null
    )
    {
        if (feltNummer is FeltNummer.NulAngivelse && beloeb != 0)
            throw new ArgumentException("Man kan ikke angive nulangivelse for et beloeb forskelligt fra 0.");
        var (amnt, decimals) = NumberFormattingUtils.ExtractDecimalParts(beloeb);
        var child = new Record3101<IRecord2111<TPrevious>>
        {
            Lb_nr = Lb_nr++,
            Rec_nr = 3101,
            indberetningsId = indberetningsId,
            referenceId = referenceId,
            Amount = amnt,
            Decimals = decimals,
            Sign = beloeb >= 0 ? '+' : '-',
            ForudElBagud = forudBetalt ? 'F' : 'B',
            PeriodeIndberetStart = periodeIndberetStart,
            PeriodeIndberetSlut = periodeIndberetSlut,
            FeltNummer = (int)feltNummer,
            Nulangivelse = feltNummer == FeltNummer.NulAngivelse ? 'N' : ' ',
        };
        Children.Add(child);
        return child;
    }
    
    public Record4101<IRecord2111<TPrevious>> AddRecord4101(
        bool tilbagefoersel,
        ShortId indberetningId = default,
        ShortId? referenceId = null,
        string? cpr = null
    )
    {
        if (tilbagefoersel && cpr == null)
            throw new ArgumentException("Man kan ikke angive en tilbagefoersel uden cprnummer");
    
        var child = new Record4101<IRecord2111<TPrevious>>(this)
        {
            Tilbagefoersel = tilbagefoersel ? 'J' : 'N',
            indberetningsId = indberetningId,
            referenceId = referenceId,
            cpr = cpr,
            Lb_nr = Lb_nr++,
            Rec_nr = 4101
        };
    
        Children.Add(child);
        return child;
    }
    
    public Record5000<IRecord2111<TPrevious>> AddRecord5000(
        bool rettelser_tidl_periode,
        DateTime loenperiodeStart,
        DateTime loenPeriodeSlut,
        bool erLoenBagudBetalt,
        IndkomstType indkomstType,
        ShortId indberetningId = default,
        ShortId referenceId = default,
        GroenlandKommune? groenlandKommune = null
    )
    {
        var child = new Record5000<IRecord2111<TPrevious>>
        {
            Rettelse_tidl_periode = rettelser_tidl_periode ? 'R' : ' ',
            IndberetningsID = indberetningId,
            ReferenceId = referenceId,
            LoenperiodeStart = loenperiodeStart,
            LoenperiodeSlut = loenPeriodeSlut,
            ForudElBagud = erLoenBagudBetalt ? 'B' : 'F',
            GroenlandskKommune = (int?)groenlandKommune,
            Indkomsttype = (int)indkomstType,
            Lb_nr = Lb_nr++,
            Rec_nr = 5000
        };
        Children.Add(child);
        return child;
    }
}

