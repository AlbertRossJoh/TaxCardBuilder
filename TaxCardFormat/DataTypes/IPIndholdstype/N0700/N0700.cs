using TaxCardFormat.DataTypes.IPIndholdstype;

namespace TaxCardFormat.IPIndholdstype.N0700;

public record N0700(N0700Enum? N0700Enum = null): IPIndholdsType(700, (int?)N0700Enum);