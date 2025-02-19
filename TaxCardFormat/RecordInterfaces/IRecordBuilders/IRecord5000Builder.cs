using TaxCardFormat.RecordInterfaces.AddableRecords;

namespace TaxCardFormat.RecordInterfaces.IRecord;

public interface IRecord5000Builder<TPrevious> :
    IWalkBack<TPrevious>,
    IRecord6000BuilderAddable<IRecord5000Builder<TPrevious>>;
