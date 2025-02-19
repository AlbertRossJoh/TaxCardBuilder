using TaxCardFormat.DataTypes.IPIndholdstype;
using TaxCardFormat.DataTypes.Loenoplysninger;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.RecordInterfaces.AddableRecords;

public interface IRecord6111BuilderAddable<TCurrent>
{
    public IRecord6111Builder<TCurrent> AddRecord6111(Loenoplysninger loenoplysninger);
}
