using FileHelpers;

namespace TaxCardFormat.CustomConverters;

public class GuidConverter: ConverterBase
{
    public override object StringToField(string from)
    {
        from = 
            from
            .Insert(8, "-")
            .Insert(12, "-")
            .Insert(16, "-");
        return new Guid(from);
    }

    public override string FieldToString(object from)
    {
        if (from.GetType() != typeof(Guid))
            throw new ArgumentException("When using the guid converter a guid is expected");
        return ((Guid)from).ToString().Replace("-", "");
    }
}
