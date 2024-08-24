using System.Text;

namespace TaxCardTests.Helpers;

public static class Padding
{
    public static string ZeroPad(int num, int len, bool leftPad = true)
    {
        return PadToLen(num, len, '0', leftPad);
    }
    
    public static string ZeroPad(int num, Range len, bool leftPad = true)
    {
        return PadToLen(num, len.End.Value - len.Start.Value, '0', leftPad);
    }
    public static string ZeroPad(string num, Range len, bool leftPad = true)
    {
        return PadToLen(num, len.End.Value - len.Start.Value, '0', leftPad);
    }
    
    public static string WhiteSpacePad(Range len)
    {
        return PadToLen(len.End.Value - len.Start.Value, ' ');
    }
    
    public static string WhiteSpacePad(string topad, Range len, bool leftPad = true)
    {
        return PadToLen(topad, len.End.Value - len.Start.Value, ' ', leftPad);
    }
    
    public static string PadToLen(string acc, int len, char paddingSym, bool leftPad = true)
    {
        while (acc.Length < len)
        {
            if (leftPad) acc = paddingSym + acc;
            else acc += paddingSym;
        }

        return acc;
    }
    
    public static string PadToLen(int len, char paddingSym, bool leftPad = true)
    {
        return PadToLen("", len, paddingSym, leftPad);
    }
    
    public static string PadToLen(int num,int len, char paddingSym, bool leftPad = true)
    {
        return PadToLen(Math.Abs(num).ToString(), len, paddingSym, leftPad);
    }
}