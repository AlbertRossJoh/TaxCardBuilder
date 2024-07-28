namespace TaxCardFormat.IPIndholdstype.N0400;

public record N0400(N0400Enum? n0400Enum = null) : IPIndholdsType(400, (int?)n0400Enum);
