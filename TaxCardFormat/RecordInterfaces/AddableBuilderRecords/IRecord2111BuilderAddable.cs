using TaxCardFormat.DataTypes.IPIndholdstype;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.RecordInterfaces.AddableRecords;

public interface IRecord2111BuilderAddable<TCurrent>
{
    public IRecord2111Builder<TCurrent> AddRecord2111(IPIndholdsType ipIndholdsType,
        DateTime? ikraeftTraedelsesDato = null);
}
