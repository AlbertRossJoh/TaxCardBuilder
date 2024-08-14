using TaxCardFormat.Enums;
using TaxCardFormat.Records;

namespace TaxCardFormat.Builders;

public class TaxFile6000Builder: TaxFileBuilderBase
{
    public TaxFile6000Builder(
        int lbnr, 
        List<TaxRecord> records, 
        string cpr,
        string cvr_se,
        string medarbejderNr,
        string tin,
        CountryCodes tin_landekode,
        IndkomstArt indkomstArt,
        string? produktionEnhedsnummer = null) : base(lbnr, records)
    {
        Records.Add(new Record6000
        {
            CPR = cpr,
            CVR_SE = cvr_se,
            MedarbejderNr = medarbejderNr,
            TIN = tin,
            TIN_landekode = tin_landekode.ToString("G"),
            Indtægtsart = (int) indkomstArt,
            ProduktionEndhedsNummer = produktionEnhedsnummer,
            Lb_nr = Lb_nr++,
            Rec_nr = 6000,
        });
    }
}
