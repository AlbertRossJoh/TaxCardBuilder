using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.RecordInterfaces.AddableRecords;

public interface IRecord6005BuilderAddable<TCurrent>
{
    public IRecord6005Builder<TCurrent> AddRecord6005(AntalsFelt6005 antalsFelt6005, decimal antal);
}
