using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.RecordInterfaces.AddableRecords;

public interface IRecord6000Addable<TCurrent>
{
    public IRecord6000<TCurrent> AddRecord6000(
        string cpr,
        string cvr_se,
        string medarbejderNr,
        string tin,
        Landekoder tin_landekode,
        IndkomstArt indkomstArt,
        string? produktionEnhedsnummer = null
    );
}