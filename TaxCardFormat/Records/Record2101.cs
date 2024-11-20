using FileHelpers;
using TaxCardFormat.DataTypes;
using TaxCardFormat.DataTypes.IPIndholdstype;
using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces;
using TaxCardFormat.RecordInterfaces.IRecord;
using TaxCardFormat.Utilities;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record2101<TPrevious> : TaxRecordBase<TPrevious>, IRecord2101<TPrevious>
{
    public Record2101():this(default) {}
    public Record2101(TPrevious? previousRecord) : base(previousRecord){}
    
    [FieldFixedLength(10)]
    public required string PersonCpr;

    [FieldFixedLength(8)]
    public string filler1 = "";

    [FieldFixedLength(15)]
    public string? medarbejderNrLetloen;

    [FieldFixedLength(8)]
    [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
    public required DateTime AnsaettelsesDato;

    [FieldFixedLength(8)]
    [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
    [FieldAlign(AlignMode.Right, ' ')]
    public DateTime? FratraedelsesDato;

    [FieldFixedLength(24)]
    public string filler2 = "";

    [FieldFixedLength(1)]
    public required int SkattekortType;

    [FieldFixedLength(8)]
    [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
    public required DateTime SkaAnvendeFra;

    [FieldFixedLength(50)]
    [FieldAlign(AlignMode.Left, ' ')]
    public string? Suppl_opl_med_arbejdernr;

    [FieldFixedLength(1)]
    public char? GenRekvivering;
    
    public IRecord2101<TPrevious> AddRecord2101(
            DateTime AnsaettelsesDato,
            string cpr,
            SkattekortType skattekortType,
            DateTime skaAndvendeFra,
            DateTime? fratraedelsesDato = null,
            bool genrevivering = false,
            string? medarbejderNr = null)
    {
        if (cpr.Length != 10)
            throw new ArgumentException("The CPR number should be 10 characters in length");
        var child = new Record2101<TPrevious>(_previous)
        {
            Lb_nr = Lb_nr++,
            Rec_nr = 2101,
            medarbejderNrLetloen = medarbejderNr,
            SkaAnvendeFra = skaAndvendeFra,
            AnsaettelsesDato = AnsaettelsesDato,
            FratraedelsesDato = fratraedelsesDato,
            GenRekvivering = genrevivering ? 'R' : ' ',
            PersonCpr = cpr,
            SkattekortType = (int)skattekortType,
        };
        Children.Add(child);
        return this;
    }
    
    public IRecord2111<IRecord2101<TPrevious>> AddRecord2111(IPIndholdsType ipIndholdsType, DateTime? ikraeftTraedelsesDato = null)
    {
        var child = new Record2111<IRecord2101<TPrevious>>(this)
        {
            Lb_nr = Lb_nr++,
            Rec_nr = 2111,
            ikraeftraedelsesDato = ikraeftTraedelsesDato,
            indholdstype = ipIndholdsType.Type,
            medarbejderKode = ipIndholdsType.Indhold,
        };
        Children.Add(child);
        return child;
    }
    
    public IRecord3101<IRecord2101<TPrevious>> AddRecord3101(
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
        var child = new Record3101<IRecord2101<TPrevious>>(this)
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
    
   public IRecord4101<IRecord2101<TPrevious>> AddRecord4101(
       bool tilbagefoersel,
       ShortId indberetningId = default,
       ShortId? referenceId = null,
       string? cpr = null
   )
   {
       if (tilbagefoersel && cpr == null)
           throw new ArgumentException("Man kan ikke angive en tilbagefoersel uden cprnummer");
   
       var child = new Record4101<IRecord2101<TPrevious>>(this)
       {
           Tilbagefoersel = tilbagefoersel ? 'J' : 'N',
           indberetningsId = indberetningId,
           referenceId = referenceId ?? new ShortId(),
           cpr = cpr,
           Lb_nr = Lb_nr++,
           Rec_nr = 4101
       };
   
       Children.Add(child);
       return child;
   }
   
   public IRecord5000<IRecord2101<TPrevious>> AddRecord5000(
       bool rettelser_tidl_periode,
       DateTime loenperiodeStart,
       DateTime loenPeriodeSlut,
       bool erLoenBagudBetalt,
       IndkomstType indkomstType,
       ShortId indberetningId,
       ShortId? referenceId = null,
       GroenlandKommune? groenlandKommune = null
   )
   {
       var child = new Record5000<IRecord2101<TPrevious>>(this)
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


   public IRecord2101<TPrevious> AddRecord8001(
       DateTime foedselsdato, 
       Koen koen, 
       Landekoder landekoder, 
       string navn, 
       string adresse,
       string postnummer, 
       string postby)
   {
       var child = new Record8001<IRecord2101<TPrevious>>(this)
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
       return this;
   }
}
