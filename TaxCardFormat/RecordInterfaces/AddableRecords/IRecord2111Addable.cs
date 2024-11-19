using TaxCardFormat.DataTypes.IPIndholdstype;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.RecordInterfaces.AddableRecords;

public interface IRecord2111Addable<TCurrent>
{
    public IRecord2111<TCurrent> AddRecord2111(IPIndholdsType ipIndholdsType,
        DateTime? ikraeftTraedelsesDato = null);
}
