using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.RecordInterfaces.AddableRecords;

public interface IRecord6004Addable<TCurrent>
{
    public IRecord6004<TCurrent> AddRecord6004(Vaerdisaet6004 indkomstFelt, string fritekstFelt);
}
