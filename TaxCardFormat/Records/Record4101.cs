using FileHelpers;
using TaxCardFormat.CustomConverters;
using TaxCardFormat.DataTypes;
using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record4101<TPrevious> : TaxRecordBase<TPrevious>, IRecord4101<TPrevious>
{
    public Record4101():this(default) {}
    public Record4101(TPrevious? previousRecord): base(previousRecord) {}
    
    
    [FieldFixedLength(16)]
    [FieldConverter(typeof(ShortIdConverter))]
    public required ShortId indberetningsId;

    [FieldFixedLength(16)]
    [FieldConverter(typeof(ShortIdConverter))]
    public ShortId? referenceId;

    [FieldFixedLength(1)]
    public string filler1 = "";

    [FieldFixedLength(1)]
    public required char Tilbagefoersel;

    [FieldFixedLength(10)]
    public string? cpr;
    
    public IRecord4101<TPrevious> AddRecord4101(
        bool tilbagefoersel,
        ShortId indberetningId = default,
        ShortId? referenceId = null,
        string? cpr = null
    )
    {
        if (tilbagefoersel && cpr == null)
            throw new ArgumentException("Man kan ikke angive en tilbagefoersel uden cprnummer");
    
        var child = new Record4101<TPrevious>
        {
            Tilbagefoersel = tilbagefoersel ? 'J' : 'N',
            indberetningsId = indberetningId,
            referenceId = referenceId,
            cpr = cpr,
            Lb_nr = Lb_nr++,
            Rec_nr = 4101
        };
    
        Children.Add(child);
        return this;
    }
    
   public IRecord5000<IRecord4101<TPrevious>> AddRecord5000(
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
       var child = new Record5000<IRecord4101<TPrevious>>(this)
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
