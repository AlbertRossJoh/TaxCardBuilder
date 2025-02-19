using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.RecordInterfaces.AddableRecords;

public interface IRecord6202BuilderAddable<TCurrent>
{
    public IRecord6202Builder<TCurrent> AddRecord6202(
        decimal beloeb,
        decimal feriedage,
        int ferieaar,
        DateTime fratraedelsesDato
    );
}
