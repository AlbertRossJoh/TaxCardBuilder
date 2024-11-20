namespace TaxCardFormat.DataTypes.IPIndholdstype;

public record IP0630(N0630Enum? N0630Enum = null):IPIndholdsType(630,(int?)N0630Enum);

public enum N0630Enum
{
    ToGangeaarligt = 1,
    HverLoenperiode = 2,
    ILoennen = 3,
    IkkeBerettiget = 4
}
