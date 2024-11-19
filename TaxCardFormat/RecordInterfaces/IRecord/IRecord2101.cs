using TaxCardFormat.RecordInterfaces.AddableRecords;

namespace TaxCardFormat.RecordInterfaces.IRecord;

public interface IRecord2101<TPrevious> :
    IWalkBack<TPrevious>,
    IRecord2101Addable<TPrevious>,
    IRecord2111Addable<IRecord2101<TPrevious>>,
    IRecord3101Addable<IRecord2101<TPrevious>>,
    IRecord4101Addable<IRecord2101<TPrevious>>,
    IRecord5000Addable<IRecord2101<TPrevious>>,
    IRecord8001Addable<IRecord2101<TPrevious>>;
