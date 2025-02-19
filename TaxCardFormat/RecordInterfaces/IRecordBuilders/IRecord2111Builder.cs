using TaxCardFormat.RecordInterfaces.AddableRecords;

namespace TaxCardFormat.RecordInterfaces.IRecord;

public interface IRecord2111Builder<TPrevious> :
    IWalkBack<TPrevious>,
    IRecord2111BuilderAddable<TPrevious>;
