using TaxCardFormat.RecordInterfaces.AddableRecords;

namespace TaxCardFormat.RecordInterfaces.IRecord;

public interface IRecord2111<TPrevious> :
    IWalkBack<TPrevious>,
    IRecord2111Addable<TPrevious>;
