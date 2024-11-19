using TaxCardFormat.DataTypes;
using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces.AddableRecords;
using TaxCardFormat.Records;

namespace TaxCardFormat.RecordInterfaces.IRecord;

public interface IRecord2001<TPrevious> : 
    IRecord2101Addable<IRecord2001<TPrevious>>, 
    IWalkBack<TPrevious>
{
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
