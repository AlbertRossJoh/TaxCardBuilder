using TaxCardFormat.RecordInterfaces.AddableRecords;

namespace TaxCardFormat.RecordInterfaces.IRecord;

public interface IRecord5000<TPrevious> :
    IWalkBack<TPrevious>,
    IRecord6000Addable<IRecord5000<TPrevious>>;
