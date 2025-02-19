using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.RecordInterfaces.AddableRecords;

public interface IRecord9999BuilderAddable<TCurrent>
{
    public IRecord9999Builder<TCurrent> AddRecord9999(int antalRecords);
}
