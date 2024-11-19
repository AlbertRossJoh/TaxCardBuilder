using TaxCardFormat.DataTypes.IPIndholdstype;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.RecordInterfaces.AddableRecords;

public interface IRecord6111Addable<TCurrent>
{
    public IRecord6111<TCurrent> AddRecord6111(IPIndholdsType indholdsType, int antalEnheder, decimal beloeb);
}