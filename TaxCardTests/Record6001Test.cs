using TaxCardFormat.Enums;
using TaxCardFormat.Records;
using TaxCardTests.Helpers;
using Xunit;

namespace TaxCardTests
{
    public class Record6001Test : RecordTestBase<Record6001>
    {
        [Fact]
        public void BuildTaxCard6001_ExpectDataPresent()
        {
            // Arrange
            var amount = 789.123M;
            var amBidrag = FeltNummer.AmBidrag;
            
            // Act
            Sut.AddRecord6001(amount, amBidrag);
            var result = Sut.BuildString();
            
            // Assert
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6001.Lb_nr)], "0000001", result);
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6001.Rec_nr)], "6001", result);
            var beloebRange = _fieldRanges.FieldNameToRange[nameof(Record6001.Beloeb)];
            HelpersAssert.RangeEquals(beloebRange, Padding.ZeroPad((int)amount, beloebRange), result);
            var beloebDecimal = _fieldRanges.FieldNameToRange[nameof(Record6001.BeloebDecimal)];
            HelpersAssert.RangeEquals(beloebDecimal, Padding.ZeroPad(123, beloebDecimal, false), result);
            var ambidragRange = _fieldRanges.FieldNameToRange[nameof(Record6001.FeltNummer)];
            HelpersAssert.RangeEquals(ambidragRange, Padding.ZeroPad((int)amBidrag, ambidragRange), result);
        }
    }
}