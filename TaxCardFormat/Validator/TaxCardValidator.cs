using TaxCardFormat.Records;
using TaxCardFormat.Validator.Rules;

namespace TaxCardFormat.Validator;

public class TaxCardValidator(List<ITaxFileRule>? rules = null) : ITaxFileValidator
{
    private List<ITaxFileRule> _rules = rules ?? [];

    public bool Validate(List<TaxRecord> taxRecords)
    {
        return _rules.All(rule => rule.CompliesWith(taxRecords));
    }
}
