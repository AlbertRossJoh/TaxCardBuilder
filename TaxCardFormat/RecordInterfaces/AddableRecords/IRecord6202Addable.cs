using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.RecordInterfaces.AddableRecords;

public interface IRecord6202Addable<TCurrent>
{
    public IRecord6202<TCurrent> AddRecord6202(
        decimal beloeb,
        decimal feriedage,
        int ferieaar,
        DateTime fratraedelsesDato
    );
}