using TaxCardFormat.Enums;
using TaxCardFormat.Records;

namespace TaxCardFormat.Builders;

public class TaxFile5000Builder: TaxFileBuilderBase
{
    public TaxFile5000Builder(
        int lbnr, 
        List<TaxRecord> records,
        bool rettelser_tidl_periode,
        DateTime lønperiodeStart,
        DateTime lønPeriodeSlut,
        bool erLønBagudBetalt,
        Indkomsttype indkomsttype,
        Guid indberetningId = new(),
        Guid referenceId = new(),
        GrønlandKommune? grønlandKommune = null) : base(lbnr, records)
    {
        Records.Add(new Record5000
        {
            Rettelse_tidl_periode = rettelser_tidl_periode
                ? 'R'
                : ' ',
            IndberetningsID = indberetningId,
            ReferenceId = referenceId,
            LønperiodeStart = lønperiodeStart,
            LønperiodeSlut = lønPeriodeSlut,
            ForudElBagud = erLønBagudBetalt
                ? 'B'
                : 'F',
            GrønlandskKommune = (int?)grønlandKommune,
            Indkomsttype = (int)indkomsttype,
            Lb_nr = Lb_nr++,
            Rec_nr = 5000
        });
    }
}