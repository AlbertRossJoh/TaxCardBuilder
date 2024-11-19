using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.RecordInterfaces.AddableRecords;

public interface IRecord2101Addable<TCurrent>
{
        public IRecord2101<TCurrent> AddRecord2101(
            DateTime AnsaettelsesDato,
            string cpr,
            SkattekortType skattekortType,
            DateTime skaAndvendeFra,
            DateTime? fratraedelsesDato = null,
            bool genrevivering = false,
            string? medarbejderNr = null);
}
