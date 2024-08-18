using System.Text;

namespace TaxCardTests.Helpers;

public static class Padding
{
    public static string ZeroPad(int num, int len)
    {
        return PadToLen(num, len, '0');
    }
    
    public static string ZeroPad(int num, Range len)
    {
        return PadToLen(num, len.End.Value - len.Start.Value, '0');
    }
    
    public static string WhiteSpacePad(Range len)
    {
        return PadToLen(len.End.Value - len.Start.Value, ' ');
    }
    
    public static string PadToLen(int num, int len, char paddingSym)
    {
        var acc = num.ToString();
        
        while (acc.Length < len)
        {
            acc = paddingSym + acc;
        }

        return acc;
    }
    
    public static string PadToLen(int len, char paddingSym)
    {
        var acc = "";
        
        while (acc.Length < len)
        {
            acc = paddingSym + acc;
        }

        return acc;
    }
}