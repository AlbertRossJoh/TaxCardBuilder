namespace TaxCardFormat.Validator.Rules.Exceptions;

/// <summary>
/// Is thrown when the tax file is not in compliance with the rule set.
/// </summary>
public class NonComplianceException(string? message) : Exception(message);
