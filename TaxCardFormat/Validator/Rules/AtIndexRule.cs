using TaxCardFormat.Records;
using TaxCardFormat.Validator.Rules.Exceptions;

namespace TaxCardFormat.Validator.Rules;

public class AtIndexRule<T>(int index): ITaxFileRule
{
    public bool CompliesWith<TRecord>(List<TRecord> records) where TRecord : class
    {
        return records[index].GetType() == typeof(T) ? true : throw new NonComplianceException($"Expected type {typeof(T)} at index {index}, but got {records[index].GetType()}");
    }
}
