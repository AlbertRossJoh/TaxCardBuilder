using TaxCardFormat.DataTypes;
using TaxCardFormat.Records;
using TaxCardTests.Helpers;
using Xunit;

namespace TaxCardTests;

public class Record4101Test: RecordTestBase<Record4101<object>>
{

    [Fact]
    public void BuildTaxCard4101_ExpectDataPresent()
    {
        // Arrange
        var indberetningsId = new ShortId();
        var referenceId = new ShortId();
        const char tilbagefoersel = 'J';
        const string cpr = "1234567890";
        
        // Act
        Sut.AddRecord4101(true, indberetningsId, referenceId, cpr);
        var result = Sut.BuildString();
        
        // Assert
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record4101<object>.Lb_nr)], "0000001", result);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record4101<object>.Rec_nr)], "4101", result);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record4101<object>.indberetningsId)], indberetningsId.ToString(), result);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record4101<object>.referenceId)], referenceId.ToString(), result);
        HelpersAssert.PositionEquals(_fieldRanges.FieldNameToRange[nameof(Record4101<object>.Tilbagefoersel)].Start.Value, tilbagefoersel, result);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record4101<object>.cpr)], cpr, result);
    }
}
