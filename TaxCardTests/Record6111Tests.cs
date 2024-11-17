// Record6111_Tests.cs
using TaxCardFormat.Builder;
using TaxCardFormat.DataTypes.IPIndholdstype;
using TaxCardFormat.Records;
using TaxCardTests.Helpers;
using Xunit;

namespace TaxCardTests
{
    public class Record6111Tests : RecordTestBase<Record6111>
    {
        [Fact]
        public void Test_AddRecord6111_BuildString()
        {
            // Arrange
            var indholdsType = new IPIndholdsType(123, null);
            int antalEnheder = 10;
            decimal beloeb = 1234.567m;
            var expectedIndholdsType = Padding.ZeroPad(123, _fieldRanges.FieldNameToRange[nameof(Record6111.IndholdsType)]);
            var expectedAntalEnheder = Padding.ZeroPad(10, _fieldRanges.FieldNameToRange[nameof(Record6111.AntalEnheder)]);
            var expectedFortegnAntalEnheder = "+";
            var (beloebIntegerPart, beloebDecimalPart) = ExtractDecimalParts(beloeb);
            var expectedBeloeb = Padding.ZeroPad(beloebIntegerPart, _fieldRanges.FieldNameToRange[nameof(Record6111.Beloeb)]);
            var expectedBeloebDecimal = Padding.ZeroPad(beloebDecimalPart, _fieldRanges.FieldNameToRange[nameof(Record6111.BeloebDecimal)], false);
            var expectedFortegnBeloeb = "+";

            // Act
            Sut.AddRecord6111(indholdsType, antalEnheder, beloeb);
            var recordString = Sut.BuildString();

            // Assert
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6111.IndholdsType)], expectedIndholdsType, recordString);
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6111.AntalEnheder)], expectedAntalEnheder, recordString);
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6111.FortegnAntalEnheder)], expectedFortegnAntalEnheder, recordString);
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6111.Beloeb)], expectedBeloeb, recordString);
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6111.BeloebDecimal)], expectedBeloebDecimal, recordString);
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6111.FortegnBeloeb)], expectedFortegnBeloeb, recordString);
        }
        
        private (int integerPart, int decimalPart) ExtractDecimalParts(decimal amount, int decimalPlaces = 6)
        {
            var integerPart = (int)amount;
            var decimalPart = (int)((amount - integerPart) * (int)Math.Pow(10, decimalPlaces)); // 6 decimal precision
            return (integerPart, decimalPart);
        }
    }
}