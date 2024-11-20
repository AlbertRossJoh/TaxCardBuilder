using TaxCardFormat.RecordInterfaces;
using TaxCardFormat.RecordInterfaces.IRecord;
using TaxCardFormat.Records;

namespace TaxCardFormat.Utilities;

public static class TaxRecordExtensions
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

    public static void Flatten(
        this TaxRecord record,
        List<TaxRecord> acc, 
        Action<TaxRecord, int>? action = null)
    {
        var a = action ?? ((_, _) => {});
        acc.Add(record);
        foreach (var child in record.ChildrenList)
        {
            child.Flatten(acc, action);
        }
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

    public static T? GoBackUntil<T>(this IWalkBack<object> record)
    {
        while (record is not T)
        {
            var curr = record.GoBack();
            try
            {
                record = (IWalkBack<object>)curr;
            }
            catch (InvalidCastException)
            {
                var isEndRecord = curr is Record1000 or IRecord1000;
                var isGenericTypeEndrecord = (typeof(T) == typeof(Record1000) || typeof(T) == typeof(IRecord1000));
                if (isEndRecord && isGenericTypeEndrecord) return (T)curr;
                return default;
            }
        }

        if (record is T res) return res;

        return default;
    }
    
    public static T? GoBackUntil<T>(this IWalkBack<object> record, Func<TaxRecord, bool> action) where T: TaxRecord
    {
        while (action((record as TaxRecord)!))
        {
            var curr = record.GoBack();
            try
            {
                record = (IWalkBack<object>)curr;
            }
            catch (InvalidCastException)
            {
                var isEndRecord = curr is Record1000 or IRecord1000;
                var isGenericTypeEndrecord = (typeof(T) == typeof(Record1000) || typeof(T) == typeof(IRecord1000));
                if (isEndRecord && isGenericTypeEndrecord) return (T)curr;
                return default;
            }
        }

        if (record is T res) return res;

        return default;
    }
}
