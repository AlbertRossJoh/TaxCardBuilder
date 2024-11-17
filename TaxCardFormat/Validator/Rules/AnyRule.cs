using TaxCardFormat.Validator.Rules.Exceptions;

namespace TaxCardFormat.Validator.Rules;

public class AnyRule<T>: ITaxFileRule
{
    public bool CompliesWith<TRecord>(List<TRecord> records) where TRecord : class
    {
        return records.Any(r => r.GetType() == typeof(T)) ? true : throw new NonComplianceException($"Expected one or more records of type {typeof(T).Name}");
    }
}
