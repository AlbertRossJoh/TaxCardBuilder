using TaxCardFormat.Enums;
using TaxCardFormat.Records;

namespace TaxCardFormat.Builders;

public class TaxFile4101Builder: TaxFileBuilderBase
{
    public TaxFile4101Builder(
        int lbnr, 
        List<TaxRecord> records, 
        bool tilbageførsel, 
        Guid indberetningId = default,
        Guid? referenceId = null,
        string? cpr = null) : base(lbnr, records)
    {
        if (tilbageførsel && cpr == null)
            throw new ArgumentException("If you need to revert the payment a cpr number must be present");
        Records.Add(new Record4101
        {
            Tilbageførsel = tilbageførsel
                ? 'J'
                : 'N',
            indberetningsId = indberetningId,
            referenceId = referenceId,
            cpr = cpr,
            Lb_nr = Lb_nr++,
            Rec_nr = 4101
        });
    }

    public TaxFile4101Builder AddRecord4101(
        bool tilbageførsel,
        Guid indberetningId = new(),
        Guid? referenceId = null,
        string? cpr = null)
    {
         if (tilbageførsel && cpr == null)
             throw new ArgumentException("If you need to revert the payment a cpr number must be present");
         Records.Add(new Record4101
         {
             Tilbageførsel = tilbageførsel
                 ? 'J'
                 : 'N',
             indberetningsId = indberetningId,
             referenceId = referenceId,
             cpr = cpr,
             Lb_nr = Lb_nr++,
             Rec_nr = 4101
         });
         return this;
    }
    
    public TaxFile2101Builder AddRecord2101(
        string cpr,
        DateTime AnsættelsesDato,
        SkattekortType skattekortType,
        DateTime? fratrædelsesDato = null,
        bool genrevivering = false)
    {
        return new TaxFile2101Builder(Lb_nr, Records, AnsættelsesDato, cpr, skattekortType, fratrædelsesDato, genrevivering);
    }
}