using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.RecordInterfaces.AddableRecords;

public interface IRecord9999Addable<TCurrent>
{
    public IRecord9999<TCurrent> AddRecord9999(int antalRecords);
}