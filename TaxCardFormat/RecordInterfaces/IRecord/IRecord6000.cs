using TaxCardFormat.RecordInterfaces.AddableRecords;

namespace TaxCardFormat.RecordInterfaces.IRecord;

public interface IRecord6000<TPrevious> : 
    IWalkBack<TPrevious>,
    IRecord6001Addable<IRecord6000<TPrevious>>,
    IRecord6002Addable<IRecord6000<TPrevious>>,
    IRecord6003Addable<IRecord6000<TPrevious>>,
    IRecord6004Addable<IRecord6000<TPrevious>>,
    IRecord6005Addable<IRecord6000<TPrevious>>,
    IRecord6102Addable<IRecord6000<TPrevious>>,
    IRecord6202Addable<IRecord6000<TPrevious>>,
    IRecord6111Addable<IRecord6000<TPrevious>>,
    IRecord8001Addable<IRecord6000<TPrevious>>;