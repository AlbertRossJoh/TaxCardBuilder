using TaxCardFormat.Enums;
using TaxCardFormat.Records;

namespace TaxCardFormat.Builders;

public class TaxFile2001Builder : TaxFileBuilderBase
{
    public TaxFile2001Builder(
        int lbnr, 
        List<TaxRecord> records, 
        string virksomhedSE, 
        string valutakode = "DKK", 
        bool ophørHosLSB = false) : base(lbnr, records)
    {
        Records.Add(new Record2001
        {
            Lb_nr = Lb_nr++,
            Rec_nr = 2001,
            Valutakode = valutakode,
            Virksomhed_SE_nummer = virksomhedSE,
            Virksomhed_Ophør_Hos_LSB = ophørHosLSB ? 'A' : ' '
        });
    }

    public TaxFile2101Builder AddRecord2101(
        string cpr, 
        DateTime ansættelsesDato, 
        SkattekortType skattekortType,
        DateTime? fratrædelsesDato = null,
        bool genrevivering = false
        )
    {
        return new TaxFile2101Builder(
            Lb_nr,
            Records,
            ansættelsesDato,
            cpr,
            skattekortType,
            fratrædelsesDato,
            genrevivering);
    }

    public TaxFile4101Builder AddRecord4101(
        bool tilbageførsel,
        Guid indberetningId = default,
        Guid? referenceId = null,
        string? cpr = null
    )
    {
        return new TaxFile4101Builder(
            Lb_nr,
            Records,
            tilbageførsel,
            indberetningId,
            referenceId,
            cpr);
    }
}