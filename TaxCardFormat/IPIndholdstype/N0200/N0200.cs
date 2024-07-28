
namespace TaxCardFormat.IPIndholdstype.N0200;

public record N0200(N0200Enum? n0200Enum = null) : IPIndholdsType(200, (int?)n0200Enum);