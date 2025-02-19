using TaxCardFormat.DataTypes;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.RecordInterfaces.AddableRecords;

public interface IRecord4101BuilderAddable<TCurrent>
{
    public IRecord4101Builder<TCurrent> AddRecord4101(
        bool tilbagefoersel,
        ShortId referenceId,
        ShortId indberetningId,
        string? cpr = null
    );
}
