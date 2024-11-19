using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.RecordInterfaces.AddableRecords;

public interface IRecord8001Addable<TCurrent>
{
    public IRecord8001<TCurrent> AddRecord8001(
        DateTime foedselsdato,
        Koen koen,
        Landekoder landekoder,
        string navn,
        string adresse,
        string postnummer,
        string postby
    );
}
