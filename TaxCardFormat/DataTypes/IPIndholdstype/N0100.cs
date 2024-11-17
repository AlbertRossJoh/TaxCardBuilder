namespace TaxCardFormat.DataTypes.IPIndholdstype;

public record N0100(N0100Enum? n0100Enum = null): IPIndholdsType(100, (int?)n0100Enum);

public enum N0100Enum
{
    IkkeTidsbegraenset = 1,
    Tidsbegraenset = 2,
}
