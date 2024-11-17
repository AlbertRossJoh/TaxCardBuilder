using TaxCardFormat.Records;

namespace TaxCardFormat.Validator;

public interface ITaxFileValidator
{
    bool Validate(List<TaxRecord> taxRecords);
}
