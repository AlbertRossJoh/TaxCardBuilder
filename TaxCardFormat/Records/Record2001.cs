using FileHelpers;
using TaxCardFormat.DataTypes;
using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record2001<TPrevious> : TaxRecord, IRecord2001<TPrevious>
{
    [FieldHidden] private TPrevious? _previous;
    public Record2001():this(default) {}

    public Record2001(TPrevious? previousRecord)
    {
        _previous = previousRecord;
    }
    
    [FieldFixedLength(16)]
    public string filler1 = "";

    [FieldFixedLength(8)]
    public required string Virksomhed_SE_nummer;

    [FieldFixedLength(1)]
    public required char Virksomhed_Ophoer_Hos_LSB;

    [FieldFixedLength(3)]
    public required string Valutakode;

    public TPrevious GoBack() => _previous ?? throw new NullReferenceException("Previous record is null remember to set the previous record in the constructor");
    
    public IRecord2101<IRecord2001<TPrevious>> AddRecord2101(
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
        var child = new Record2101<IRecord2001<TPrevious>>(this)
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
        return child;
    }
    
   public Record4101<Record2001<TPrevious>> AddRecord4101(
       bool tilbagefoersel,
       ShortId indberetningId = default,
       ShortId? referenceId = null,
       string? cpr = null
   )
   {
       if (tilbagefoersel && cpr == null)
           throw new ArgumentException("Man kan ikke angive en tilbagefoersel uden cprnummer");

       var child = new Record4101<Record2001<TPrevious>>(this)
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
   
   public Record5000<Record2001<TPrevious>> AddRecord5000(
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
       var child = new Record5000<Record2001<TPrevious>>(this)
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
