using TaxCardFormat.Records;
using TaxCardTests.Helpers;
using Xunit;

namespace TaxCardTests;

public class Record2001Test : RecordTestBase<Record2001>
{
    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void BuildTaxCard2001_ExpectDataPresent(bool ophoer)
    {
        // Arrange
        var seNr = "12345678";
        Sut.AddRecord2001(seNr, ophoerHosLSB: ophoer);

        // Act
        var res = Sut.BuildString();

        // Assert
        var lbnr = _fieldRanges.FieldNameToRange[nameof(Record2001.Lb_nr)];
        HelpersAssert.RangeEquals(lbnr, Padding.ZeroPad(1, lbnr), res);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record2001.Rec_nr)], "2001", res);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record2001.Virksomhed_SE_nummer)], seNr, res);
        HelpersAssert.PositionEquals(
            _fieldRanges.FieldNameToRange[nameof(Record2001.Virksomhed_Ophoer_Hos_LSB)].Start.Value,
            ophoer ? 'A' : ' ',
            res
        );
    }
}