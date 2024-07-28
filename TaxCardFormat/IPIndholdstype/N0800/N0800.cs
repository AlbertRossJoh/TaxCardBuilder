namespace TaxCardFormat.IPIndholdstype.N0800;

public record N0800(N0800Enum? N0800Enum = null):IPIndholdsType(800, (int?)N0800Enum);