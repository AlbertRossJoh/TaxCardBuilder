using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.RecordInterfaces.AddableRecords;

public interface IRecord6102BuilderAddable<TCurrent>
{
    public IRecord6102Builder<TCurrent> AddRecord6102(
        decimal beloeb,
        decimal feriedage,
        int ferieaar,
        DateTime fratraedelsesDato
    );
}
