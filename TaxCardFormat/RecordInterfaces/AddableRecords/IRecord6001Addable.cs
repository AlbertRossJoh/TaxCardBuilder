using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.RecordInterfaces.AddableRecords;

public interface IRecord6001Addable<TCurrent>
{
    public IRecord6001<TCurrent> AddRecord6001(decimal beloeb, FeltNummer feltNummer);
}
