using System;
using TaxCardFormat.Enums;
using TaxCardFormat.Records;
using TaxCardTests.Helpers;
using Xunit;

namespace TaxCardTests
{
    public class Record6004Test : RecordTestBase<Record6004>
    {
        [Fact]
        public void BuildTaxCard6004_ExpectDataPresent()
        {
            // Arrange
            var feltNummer = IndkomstFelt600X.LoenmodtagersPensionsandel;
            const string fritekstfelt = "Some free text that fits in the field";

            // Act
            Sut.AddRecord6004(feltNummer, fritekstfelt);
            var result = Sut.BuildString();

            // Assert
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6004.Lb_nr)], "0000001", result);
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6004.Rec_nr)], "6004", result);
            var feltNummerRange = _fieldRanges.FieldNameToRange[nameof(Record6004.FeltNummer)];
            HelpersAssert.RangeEquals(feltNummerRange, Padding.ZeroPad((int)feltNummer, feltNummerRange), result);
            var fritekstRange = _fieldRanges.FieldNameToRange[nameof(Record6004.Fritekstfelt)];
            HelpersAssert.RangeEquals(fritekstRange, Padding.WhiteSpacePad(fritekstfelt, fritekstRange), result);
        }
    }
}