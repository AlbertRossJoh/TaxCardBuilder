using TaxCardFormat.DataTypes.IPIndholdstype;
using TaxCardFormat.Records;
using TaxCardTests.Helpers;
using Xunit;

namespace TaxCardTests;

public class Record6111Tests : RecordTestBase<Record6111<object>>
{
    [Fact]
    public void Test_AddRecord6111_BuildString()
    {
        // Arrange
        var indholdsType = new IPIndholdsType(123, null);
        int antalEnheder = 10;
        decimal beloeb = 1234.567m;
        var expectedIndholdsType = Padding.ZeroPad(123, _fieldRanges.FieldNameToRange[nameof(Record6111<object>.IndholdsType)]);
        var expectedAntalEnheder = Padding.ZeroPad(10, _fieldRanges.FieldNameToRange[nameof(Record6111<object>.AntalEnheder)]);
        var expectedFortegnAntalEnheder = "+";
        var (beloebIntegerPart, beloebDecimalPart) = ExtractDecimalParts(beloeb);
        var expectedBeloeb = Padding.ZeroPad(beloebIntegerPart, _fieldRanges.FieldNameToRange[nameof(Record6111<object>.Beloeb)]);
        var expectedBeloebDecimal = Padding.ZeroPad(beloebDecimalPart, _fieldRanges.FieldNameToRange[nameof(Record6111<object>.BeloebDecimal)], false);
        var expectedFortegnBeloeb = "+";

        // Act
        Sut.AddRecord6111(indholdsType, antalEnheder, beloeb);
        var recordString = Sut.BuildString();

        // Assert
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6111<object>.IndholdsType)], expectedIndholdsType, recordString);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6111<object>.AntalEnheder)], expectedAntalEnheder, recordString);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6111<object>.FortegnAntalEnheder)], expectedFortegnAntalEnheder, recordString);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6111<object>.Beloeb)], expectedBeloeb, recordString);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6111<object>.BeloebDecimal)], expectedBeloebDecimal, recordString);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6111<object>.FortegnBeloeb)], expectedFortegnBeloeb, recordString);
    }
        
    private (int integerPart, int decimalPart) ExtractDecimalParts(decimal amount, int decimalPlaces = 6)
    {
        var integerPart = (int)amount;
        var decimalPart = (int)((amount - integerPart) * (int)Math.Pow(10, decimalPlaces)); // 6 decimal precision
        return (integerPart, decimalPart);
    }
}
