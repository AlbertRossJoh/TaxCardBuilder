using TaxCardFormat.RecordInterfaces.AddableRecords;

namespace TaxCardFormat.RecordInterfaces.IRecord;

public interface IRecord6004<TPrevious> :
    IWalkBack<TPrevious>,
    IRecord6001Addable<IRecord6004<TPrevious>>,
    IRecord6002Addable<IRecord6004<TPrevious>>,
    IRecord6003Addable<IRecord6004<TPrevious>>,
    IRecord6004Addable<IRecord6004<TPrevious>>,
    IRecord6005Addable<IRecord6004<TPrevious>>,
    IRecord6102Addable<IRecord6004<TPrevious>>,
    IRecord6202Addable<IRecord6004<TPrevious>>,
    IRecord6111Addable<IRecord6004<TPrevious>>;