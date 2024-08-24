namespace TaxCardTests.Helpers;

public static class HelpersAssert
{
    public static void PositionEquals(int pos, char expected, string actual)
    {
        Xunit.Assert.Equal(expected, actual[pos]);
    }
    
    public static void RangeEquals(int start, int end, string expected, string actual)
    {
        RangeEquals(new Range(start, end), expected, actual);
    }
    
    public static void RangeEquals(Range range, string expected, string actual)
    {
        Xunit.Assert.Equal(expected, actual[range.Start..range.End]);
    }
    
    public static void RangeWhitespace(Range range, string actual)
    {
        Xunit.Assert.Equal(Padding.WhiteSpacePad(range), actual[range.Start..range.End]);
    }
    
    public static void Length(int expected, string actual)
    {
        Xunit.Assert.Equal(expected, actual.Length);
    }
}