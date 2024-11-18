using TaxCardFormat.DataTypes;
using TaxCardFormat.Enums;
using TaxCardFormat.Records;

namespace TaxCardFormat.RecordInterfaces;

public interface IRecord2001<TPrevious>
{
    public TPrevious? GoBack();
    
    public IRecord2101<IRecord2001<TPrevious>> AddRecord2101(
        DateTime AnsaettelsesDato,
        string cpr,
        SkattekortType skattekortType,
        DateTime skaAndvendeFra,
        DateTime? fratraedelsesDato = null,
        bool genrevivering = false,
        string? medarbejderNr = null);
    
    public Record4101<Record2001<TPrevious>> AddRecord4101(
        bool tilbagefoersel,
        ShortId indberetningId = default,
        ShortId? referenceId = null,
        string? cpr = null
    );

    public Record5000<Record2001<TPrevious>> AddRecord5000(
        bool rettelser_tidl_periode,
        DateTime loenperiodeStart,
        DateTime loenPeriodeSlut,
        bool erLoenBagudBetalt,
        IndkomstType indkomstType,
        ShortId indberetningId = default,
        ShortId referenceId = default,
        GroenlandKommune? groenlandKommune = null
    );
}
