using TaxCardFormat.RecordInterfaces.AddableRecords;

namespace TaxCardFormat.RecordInterfaces.IRecord;

public interface IRecord8001Builder<TPrevious> : IWalkBack<TPrevious>, IRecord2111Addable<TPrevious>;

