using TaxCardFormat.Records;

namespace TaxCardFormat.Utilities;

public static class ListExtensions
{
    public static List<TaxRecord> Flatten(this TaxRecord record, Action<TaxRecord, int>? action = null)
    {
        var a = action ?? ((_, _) => {});
        var s = new Stack<TaxRecord>();
        var acc = new List<TaxRecord>();
        s.Push(record);
        var i = 0;
        while (s.Count > 0)
        {
            var curr = s.Pop();
            a(curr, i++);
            acc.Add(curr);
            curr.ChildrenList.ForEach(s.Push);
        }
        return acc;
    }
    
    public static List<TaxRecord> Flatten(this TaxRecord record, Action<TaxRecord> action)
    {
        var s = new Stack<TaxRecord>();
        var acc = new List<TaxRecord>();
        s.Push(record);
        while (s.Count > 0)
        {
            var curr = s.Pop();
            action(curr);
            acc.Add(curr);
            curr.ChildrenList.ForEach(s.Push);
        }
        return acc;
    }
}