using TaxCardFormat.RecordInterfaces.AddableRecords;

namespace TaxCardFormat.RecordInterfaces.IRecord;

public interface IRecord4101Builder<TPrevious> :
    IWalkBack<TPrevious>,
    IRecord4101BuilderAddable<TPrevious>,
    IRecord5000BuilderAddable<IRecord4101Builder<TPrevious>>;
