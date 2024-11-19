using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.RecordInterfaces.AddableRecords;

public interface IRecord6102Addable<TCurrent>
{
    public IRecord6102<TCurrent> AddRecord6102(
        decimal beloeb,
        decimal feriedage,
        int ferieaar,
        DateTime fratraedelsesDato
    );
}
