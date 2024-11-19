using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.RecordInterfaces.AddableRecords;

public interface IRecord2001Addable<TCurrent>
{
     public IRecord2001<TCurrent> AddRecord2001(
         string virksomhedSE,
         bool ophoerHosLSB,
         string valutakode = "DKK"
     );
}