using TaxCardFormat.Builder;
using TaxCardFormat.Enums;
using TaxCardFormat.Records;
using TaxCardTests.Helpers;
using Xunit;

namespace TaxCardTests;

public class Record6005Test : RecordTestBase<Record6005<object>>
{
    [Fact]
    public void BuildTaxCard6005_ExpectDataPresent()
    {
        // Arrange
        var sut = new TaxFileBuilder();
        var feltNummer = AntalsFelt6005.AntalSoedage;
        var antal = -3.123M;

        // Act
        sut.AddRecord6005(feltNummer, antal);
        var result = sut.BuildString();

        // Assert
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6005<object>.Lb_nr)], "0000001", result);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6005<object>.Rec_nr)], "6005", result);
        var feltNummerRange = _fieldRanges.FieldNameToRange[nameof(Record6005<object>.FeltNummer)];
        HelpersAssert.RangeEquals(feltNummerRange, Padding.ZeroPad((int) feltNummer, feltNummerRange), result);
        var antalRange = _fieldRanges.FieldNameToRange[nameof(Record6005<object>.Antal)];
        HelpersAssert.RangeEquals(antalRange, Padding.ZeroPad((int) antal, antalRange), result);
        var antalDecimalRange = _fieldRanges.FieldNameToRange[nameof(Record6005<object>.AntalDecimal)];
        HelpersAssert.RangeEquals(antalDecimalRange, Padding.ZeroPad(12, antalDecimalRange, false), result);
    }
}
