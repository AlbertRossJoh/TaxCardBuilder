using TaxCardFormat.Enums;
using TaxCardFormat.Records;
using TaxCardTests.Helpers;
using Xunit;

namespace TaxCardTests
{
    public class Record6003Test : RecordTestBase<Record6003>
    {
        [Fact]
        public void BuildTaxCard6003_ExpectDataPresent()
        {
            // Arrange
            var indkomstFelt = IndkomstFelt600X.Bruttoferiepenge;
            
            // Act
            Sut.AddRecord6003(indkomstFelt);
            var result = Sut.BuildString();

            // Assert
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6003.Lb_nr)], "0000001", result);
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6003.Rec_nr)], "6003", result);
            var indkomstFeltRange = _fieldRanges.FieldNameToRange[nameof(Record6003.FeltNummer)];
            HelpersAssert.RangeEquals(indkomstFeltRange, Padding.ZeroPad((int)indkomstFelt, indkomstFeltRange),result);
            HelpersAssert.PositionEquals(_fieldRanges.FieldNameToRange[nameof(Record6003.Krydsfelt)].Start.Value, 'X',
                result);
        }
    }
}