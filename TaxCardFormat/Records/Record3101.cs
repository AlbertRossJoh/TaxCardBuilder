using FileHelpers;
using TaxCardFormat.CustomConverters;
using TaxCardFormat.DataTypes;
using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record3101<TPrevious> : TaxRecordBase<TPrevious>, IRecord3101<TPrevious>
{
    public Record3101():this(default) {}
    public Record3101(TPrevious? previousRecord): base(previousRecord) {}
    
    [FieldFixedLength(1)]
    public required char ForudElBagud;

    [FieldFixedLength(16)]
    [FieldConverter(typeof(ShortIdConverter))]
    public required ShortId indberetningsId;

    [FieldFixedLength(16)]
    [FieldConverter(typeof(ShortIdConverter))]
    public ShortId? referenceId;

    [FieldFixedLength(8)]
    [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
    public required DateTime PeriodeIndberetStart;

    [FieldFixedLength(8)]
    [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
    public required DateTime PeriodeIndberetSlut;

    [FieldFixedLength(1)]
    public required char Nulangivelse;

    [FieldFixedLength(4)]
    [FieldAlign(AlignMode.Right, '0')]
    public int? FeltNummer;

    [FieldFixedLength(10)]
    [FieldAlign(AlignMode.Right, '0')]
    public required int Amount;

    [FieldFixedLength(6)]
    [FieldAlign(AlignMode.Left, '0')]
    public required int Decimals;

    [FieldFixedLength(1)]
    public required char Sign;
    
    public IRecord4101<IRecord3101<TPrevious>> AddRecord4101(
        bool tilbagefoersel,
        ShortId referenceId,
        ShortId? indberetningId = null,
        string? cpr = null
    )
    {
        if (tilbagefoersel && cpr == null)
            throw new ArgumentException("Man kan ikke angive en tilbagefoersel uden cprnummer");
    
        var child = new Record4101<IRecord3101<TPrevious>>(this)
        {
            Tilbagefoersel = tilbagefoersel ? 'J' : 'N',
            indberetningsId = indberetningId ?? new ShortId(),
            referenceId = referenceId,
            cpr = cpr,
            Lb_nr = Lb_nr++,
            Rec_nr = 4101
        };
    
        Children.Add(child);
        return child;
    }
    
    public IRecord5000<IRecord3101<TPrevious>> AddRecord5000(
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
        var child = new Record5000<IRecord3101<TPrevious>>(this)
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
