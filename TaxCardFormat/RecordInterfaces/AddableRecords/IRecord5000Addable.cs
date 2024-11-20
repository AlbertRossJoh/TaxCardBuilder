using TaxCardFormat.DataTypes;
using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.RecordInterfaces.AddableRecords;

public interface IRecord5000Addable<TCurrent>
{
    public IRecord5000<TCurrent> AddRecord5000(
        bool rettelser_tidl_periode,
        DateTime loenperiodeStart,
        DateTime loenPeriodeSlut,
        bool erLoenBagudBetalt,
        IndkomstType indkomstType,
        ShortId indberetningId,
        ShortId? referenceId = null,
        GroenlandKommune? groenlandKommune = null
    );

}
