using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.RecordInterfaces.AddableRecords;

public interface IRecord6002BuilderAddable<TCurrent>
{
    public IRecord6002Builder<TCurrent> AddRecord6002(Vaerdisaet6002 indkomstFelt, string kodeFelt);
}
