using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.RecordInterfaces.AddableRecords;

public interface IRecord2001BuilderAddable<TCurrent>
{
     public IRecord2001Builder<TCurrent> AddRecord2001(
         string virksomhedSE,
         bool ophoerHosLSB,
         string valutakode = "DKK"
     );
}
