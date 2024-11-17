namespace TaxCardFormat.DataTypes.IPIndholdstype;

public record N0200(N0200Enum? n0200Enum = null) : IPIndholdsType(200, (int?)n0200Enum);

public enum N0200Enum
{
    Funktionaer = 1,
    ArbejderFunktionaerLign = 2,
    Arbejderoevrigt = 3,
}
