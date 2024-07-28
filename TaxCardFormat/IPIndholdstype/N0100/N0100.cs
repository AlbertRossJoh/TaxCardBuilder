namespace TaxCardFormat.IPIndholdstype.N0100;

public record N0100(N0100Enum? n0100Enum = null): IPIndholdsType(100, (int?)n0100Enum);
