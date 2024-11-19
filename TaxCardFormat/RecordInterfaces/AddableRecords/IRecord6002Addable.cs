using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.RecordInterfaces.AddableRecords;

public interface IRecord6002Addable<TCurrent>
{
    public IRecord6002<TCurrent> AddRecord6002(IndkomstFelt6002 indkomstFelt, string kodeFelt);
}