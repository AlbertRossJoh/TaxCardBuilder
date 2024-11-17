namespace TaxCardFormat.DataTypes.IPIndholdstype;

public record N0700(N0700Enum? N0700Enum = null): IPIndholdsType(700, (int?)N0700Enum);

public enum N0700Enum
{
    Maanedsloen = 1,
    HverAndenUge = 2,
    Ugentligt = 3,
    Dagligt = 4,
}
