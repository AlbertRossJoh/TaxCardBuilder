using TaxCardFormat.Records;
using TaxCardFormat.Validator.Rules.Exceptions;

namespace TaxCardFormat.Validator.Rules;

public class SingleRule<T>: ITaxFileRule
{
    public bool CompliesWith<TRecord>(List<TRecord> records) where TRecord : class
    {
        var count = records.Count(r => r.GetType() == typeof(T));
        return count == 1 ? true : throw new NonComplianceException($"There was only expected a single instance of type {typeof(T).Name} but {count} were found.");
    }
}
