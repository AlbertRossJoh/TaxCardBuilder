using TaxCardFormat.RecordInterfaces.AddableRecords;

namespace TaxCardFormat.RecordInterfaces.IRecord;

public interface IRecord4101<TPrevious> :
    IWalkBack<TPrevious>,
    IRecord4101Addable<TPrevious>,
    IRecord5000Addable<IRecord4101<TPrevious>>;
