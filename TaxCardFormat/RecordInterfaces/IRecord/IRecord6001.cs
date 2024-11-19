using TaxCardFormat.RecordInterfaces.AddableRecords;

namespace TaxCardFormat.RecordInterfaces.IRecord;

public interface IRecord6001<TPrevious> :
    IWalkBack<TPrevious>,
    IRecord6001Addable<IRecord6001<TPrevious>>,
    IRecord6002Addable<IRecord6001<TPrevious>>,
    IRecord6003Addable<IRecord6001<TPrevious>>,
    IRecord6004Addable<IRecord6001<TPrevious>>,
    IRecord6005Addable<IRecord6001<TPrevious>>,
    IRecord6102Addable<IRecord6001<TPrevious>>,
    IRecord6202Addable<IRecord6001<TPrevious>>,
    IRecord6111Addable<IRecord6001<TPrevious>>;
    