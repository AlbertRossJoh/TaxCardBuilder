using TaxCardFormat.Validator.Rules.Exceptions;

namespace TaxCardFormat.Validator.Rules;

public class InScopeRule<TScope>(params Type[] nested): ITaxFileRule
{
    public bool CompliesWith<TRecord>(List<TRecord> records) where TRecord : class
    {
        var scopeStarted = false;
        foreach (var recordType in records.Select(record => record.GetType()))
        {
            if (recordType == typeof(TScope)) scopeStarted = true;
            else if (!nested.Contains(recordType) && scopeStarted) scopeStarted = false;
            else if (nested.Contains(recordType) && !scopeStarted) throw new NonComplianceException($"The {(nested.Length > 1 ? "types" : "type")} {string.Join(" ", nested.Select(n => n.Name))} was expected to be inside scope {typeof(TScope).Name}.");
        }

        return true;
    }
}
