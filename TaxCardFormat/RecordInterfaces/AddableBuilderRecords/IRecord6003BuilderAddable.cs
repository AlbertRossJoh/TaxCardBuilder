using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.RecordInterfaces.AddableRecords;

public interface IRecord6003BuilderAddable<TCurrent>
{
    public IRecord6003Builder<TCurrent> AddRecord6003(Vaerdisaet6003 indkomstFelt);
}
