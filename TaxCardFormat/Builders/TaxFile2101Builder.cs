using TaxCardFormat.Enums;
using TaxCardFormat.Records;
using IPIndholdsType = TaxCardFormat.IPIndholdstype.IPIndholdsType;

namespace TaxCardFormat.Builders;

public class TaxFile2101Builder : Record2101BuilderBase
{
    public TaxFile2101Builder(
        int lbnr,
        List<TaxRecord> records,
        DateTime AnsættelsesDato,
        string cpr,
        SkattekortType skattekortType,
        DateTime? fratrædelsesDato = null,
        bool genrevivering = false) : base(lbnr, records)
    {
        AddRecord2101_internal(AnsættelsesDato, cpr, skattekortType, fratrædelsesDato, genrevivering);
    }




    public TaxFile2111Builder AddRecord2111(DateTime ikræfttrædelsesDato, IPIndholdsType ipIndholdsType)
    {
        return new TaxFile2111Builder(Lb_nr, Records, ikræfttrædelsesDato, ipIndholdsType);
    }

    public TaxFile3101Builder AddRecord3101(
        decimal amount, 
        bool forudbetalt, 
        DateTime periodeIndberetStart,
        DateTime periodeIndberetSlut,
        FeltNummer feltNummer,
        bool nulangivelse,
        Guid indberetningsId = default,
        Guid? referenceId = null
        )
    {
        return new TaxFile3101Builder(
            Lb_nr, 
            Records, 
            amount, 
            forudbetalt, 
            periodeIndberetStart, 
            periodeIndberetSlut,
            feltNummer,
            nulangivelse,
            indberetningsId,
            referenceId);
    }
}