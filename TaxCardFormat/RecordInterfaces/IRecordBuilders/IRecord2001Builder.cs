using TaxCardFormat.RecordInterfaces.AddableRecords;

namespace TaxCardFormat.RecordInterfaces.IRecord;

public interface IRecord2001Builder<TPrevious> :
    IRecord2101BuilderAddable<IRecord2001Builder<TPrevious>>,
    IRecord4101BuilderAddable<IRecord2001Builder<TPrevious>>,
    IRecord5000BuilderAddable<IRecord2001Builder<TPrevious>>,
    IWalkBack<TPrevious>;
