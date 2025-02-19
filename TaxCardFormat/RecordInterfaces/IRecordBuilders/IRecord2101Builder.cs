using TaxCardFormat.RecordInterfaces.AddableRecords;

namespace TaxCardFormat.RecordInterfaces.IRecord;

public interface IRecord2101Builder<TPrevious> :
    IWalkBack<TPrevious>,
    IRecord2101BuilderAddable<TPrevious>,
    IRecord2111BuilderAddable<IRecord2101Builder<TPrevious>>,
    IRecord3101BuilderAddable<IRecord2101Builder<TPrevious>>,
    IRecord4101BuilderAddable<IRecord2101Builder<TPrevious>>,
    IRecord5000BuilderAddable<IRecord2101Builder<TPrevious>>,
    IRecord8001BuilderAddable<IRecord2101Builder<TPrevious>>;
