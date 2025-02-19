using TaxCardFormat.RecordInterfaces.AddableRecords;

namespace TaxCardFormat.RecordInterfaces.IRecord;

public interface IRecord3101Builder<TPrevious> :
    IWalkBack<TPrevious>,
    IRecord4101BuilderAddable<IRecord3101Builder<TPrevious>>,
    IRecord5000BuilderAddable<IRecord3101Builder<TPrevious>>;
