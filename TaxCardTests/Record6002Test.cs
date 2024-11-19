using TaxCardFormat.Enums;
using TaxCardFormat.Records;
using TaxCardTests.Helpers;
using Xunit;

namespace TaxCardTests;

public class Record6002Test: RecordTestBase<Record6002<object>>
{
    [Fact]
    public void BuildTaxCard6002_ExpectDataPresent()
    {
        // Arrange
        var indkomstFelt = IndkomstFelt6002.Pinkode;
        var kode = "12345678";

        // Act
        Sut.AddRecord6002(indkomstFelt, kode);
        var result = Sut.BuildString();
        
        // Assert
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6002<object>.Lb_nr)], "0000001", result);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6002<object>.Rec_nr)], "6002", result);
        var indkomstFeltRange = _fieldRanges.FieldNameToRange[nameof(Record6002<object>.FeltNummer)];
        HelpersAssert.RangeEquals(indkomstFeltRange, Padding.ZeroPad((int)indkomstFelt, indkomstFeltRange), result);
        var kodeFeltRange = _fieldRanges.FieldNameToRange[nameof(Record6002<object>.KodeFelt)];
        HelpersAssert.RangeEquals(kodeFeltRange, Padding.ZeroPad(kode, kodeFeltRange), result);
    }
}
