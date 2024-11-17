using TaxCardFormat.Validator.Rules.Exceptions;

namespace TaxCardFormat.Validator.Rules;

public class SingleInScopeRule<TScope, TNested>: ITaxFileRule
{
    public bool CompliesWith<TRecord>(List<TRecord> records) where TRecord : class
    {
        var scopeStarted = false;
        var foundSingle = false;
        var i = 0;
        foreach (var recordType in records.Select(record => record.GetType()))
        {
            if (recordType == typeof(TScope)) scopeStarted = true;
            if (recordType == typeof(TNested) && !scopeStarted) throw new NonComplianceException($"The nested type {typeof(TNested).Name}, at index {i} was expected to be inside scope {typeof(TScope).Name}.");
            if (recordType == typeof(TNested) && !foundSingle) foundSingle = true;
            else if (recordType == typeof(TNested) && foundSingle) throw new NonComplianceException($"Expected only a single element of type {typeof(TNested).Name} inside scope {typeof(TScope).Name}.");
            i++;
        }

        return true;
    }
}
