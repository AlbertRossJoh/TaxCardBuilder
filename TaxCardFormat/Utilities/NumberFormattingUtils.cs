namespace TaxCardFormat.Utilities;

public static class NumberFormattingUtils
{
    public static char Fortegn(decimal antal) => antal > 0 ? '+' : '-';
        
    public static char Fortegn(int antal) => antal > 0 ? '+' : '-';
        
    public static (int integerPart, int decimalPart) ExtractDecimalParts(decimal amount)
    {
        var amountAbs = Math.Abs(amount); 
        var truncate = (int)Math.Truncate(amountAbs);
        var decimals = (int)((amountAbs - truncate) * 1_000_000);
        return (truncate, decimals);
    }
}
