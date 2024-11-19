using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.RecordInterfaces.AddableRecords;

public interface IRecord6003Addable<TCurrent>
{
    public IRecord6003<TCurrent> AddRecord6003(IndkomstFelt600X indkomstFelt);
}