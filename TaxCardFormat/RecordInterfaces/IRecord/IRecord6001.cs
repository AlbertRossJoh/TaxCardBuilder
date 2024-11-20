using TaxCardFormat.RecordInterfaces.AddableRecords;

namespace TaxCardFormat.RecordInterfaces.IRecord;

public interface IRecord6001<TPrevious> :
    IWalkBack<TPrevious>,
    IRecord6001Addable<TPrevious>,
    IRecord6002Addable<TPrevious>,
    IRecord6003Addable<TPrevious>,
    IRecord6004Addable<TPrevious>,
    IRecord6005Addable<TPrevious>,
    IRecord6102Addable<TPrevious>,
    IRecord6202Addable<TPrevious>,
    IRecord6111Addable<TPrevious>;
    