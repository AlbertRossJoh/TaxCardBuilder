using TaxCardFormat.RecordInterfaces.AddableRecords;

namespace TaxCardFormat.RecordInterfaces.IRecord;

public interface IRecord2111<TPrevious> :
    IWalkBack<TPrevious>,
    IRecord3101Addable<IRecord2111<TPrevious>>,
    IRecord4101Addable<IRecord2111<TPrevious>>,
    IRecord5000Addable<IRecord2111<TPrevious>>;
