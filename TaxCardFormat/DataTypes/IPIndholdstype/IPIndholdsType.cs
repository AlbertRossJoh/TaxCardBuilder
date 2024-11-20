namespace TaxCardFormat.DataTypes.IPIndholdstype;

public record IPIndholdsType(int type, int? indhold)
{
    public int? Indhold = indhold;
    public int Type = type;
}
