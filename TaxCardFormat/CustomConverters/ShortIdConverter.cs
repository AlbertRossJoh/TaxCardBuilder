using FileHelpers;
using TaxCardFormat.DataTypes;

namespace TaxCardFormat.CustomConverters;

public class ShortIdConverter : ConverterBase
{
    public override object StringToField(string from)
    {
        return new ShortId(from);
    }

    public override string FieldToString(object? from)
    {
        return from switch
        {
            null => string.Empty,
            ShortId shortId => shortId.Id ?? string.Empty,
            _ => throw new ArgumentException("When using the ShortId converter a ShortId is expected")
        };
    }
}
