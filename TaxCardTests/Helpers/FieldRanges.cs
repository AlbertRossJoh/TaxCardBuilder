using System.Reflection;
using FileHelpers;

namespace TaxCardTests.Helpers;

public class FieldRanges
{
    public readonly List<Range> FieldRange = [];
    public Dictionary<string, Range> FieldNameToRange { get; set; } = new();
    public int Total;

    public FieldRanges(Type t)
    {
        var tmp = t.GetFields(BindingFlags.Public | BindingFlags.Instance)
            .ToList();
        var propertyInfos = tmp[^2..];
        propertyInfos.AddRange(tmp[..^2]);
        Total = propertyInfos.Aggregate(
            0,
            (idx, prop) =>
            {
                if (prop.Name == "Children") return idx;
                var att = (FieldFixedLengthAttribute)
                    prop.GetCustomAttribute(typeof(FieldFixedLengthAttribute), false)!;
                var newpos = idx + att.Length;
                var range = new Range(idx, newpos);
                FieldRange.Add(range);
                FieldNameToRange[prop.Name] = range;
                return newpos;
            },
            i => i
        );
    }
}
