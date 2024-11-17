using TaxCardFormat.Records;
using TaxCardFormat.Validator.Rules.Exceptions;

namespace TaxCardFormat.Validator.Rules;

public interface ITaxFileRule
{
    /// <summary>
    /// Verifies that the records given are in compliance with the rule defined, throw an exception when the assertion fails.
    /// </summary>
    /// <param name="records">The record set to be verified</param>
    /// <returns>True if successful</returns>
    /// <exception cref="NonComplianceException">Thrown if the assertion fails</exception>
    bool CompliesWith<TRecord>(List<TRecord> records) where TRecord : class;
}
