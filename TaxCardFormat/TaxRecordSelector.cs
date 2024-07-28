using FileHelpers;

namespace TaxCardFormat;

public class TaxRecordSelector
{
    private static Type CustomSelector(MultiRecordEngine engine, string recordLine)
    {
        if (recordLine.Length == 0)
            return null;

        return null;
    }
}