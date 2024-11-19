using TaxCardFormat.RecordInterfaces.AddableRecords;

namespace TaxCardFormat.RecordInterfaces.IRecord;

public interface IRecord3101<TPrevious> :
    IWalkBack<TPrevious>,
    IRecord4101Addable<IRecord3101<TPrevious>>,
    IRecord5000Addable<IRecord3101<TPrevious>>;
