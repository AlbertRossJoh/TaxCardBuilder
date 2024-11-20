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
        if (from is null) return string.Empty;
        if (from.GetType() != typeof(ShortId))
            throw new ArgumentException("When using the ShortId converter a ShortId is expected");
        return ((ShortId)from).Id ?? string.Empty;
    }
}
