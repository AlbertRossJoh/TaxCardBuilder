using TaxCardFormat.Enums;
using TaxCardFormat.Records;
using TaxCardTests.Helpers;
using Xunit;

namespace TaxCardTests;

public class Record2101Test : RecordTestBase<Record2101>
{
    [Fact]
    public void BuildTaxCard2101_ExpectDataPresent()
    {
        // Arrange
        var cpr = "1234567890";
        var date = DateTime.Now;
        var skanvendeFra = DateTime.Now;
        var skatteKort = SkattekortType.Bikort;
        Sut.AddRecord2101(date, cpr, skatteKort, skanvendeFra);

        // Act
        var res = Sut.BuildString();

        // Assert
        var lbnr = _fieldRanges.FieldNameToRange[nameof(Record2101.Lb_nr)];
        HelpersAssert.RangeEquals(lbnr, Padding.ZeroPad(1, lbnr), res);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record2101.Rec_nr)], "2101", res);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record2101.PersonCpr)], cpr, res);
        HelpersAssert.RangeEquals(
            _fieldRanges.FieldNameToRange[nameof(Record2101.AnsaettelsesDato)],
            date.ToString("yyyyMMdd"),
            res
        );
        var taxRecordRange = _fieldRanges.FieldNameToRange[nameof(Record2101.SkattekortType)];
        HelpersAssert.RangeEquals(
            taxRecordRange,
            Padding.ZeroPad((int)skatteKort, taxRecordRange),
            res
        );
        HelpersAssert.RangeWhitespace(_fieldRanges.FieldNameToRange[nameof(Record2101.Suppl_opl_med_arbejdernr)], res);
        HelpersAssert.RangeWhitespace(_fieldRanges.FieldNameToRange[nameof(Record2101.FratraedelsesDato)], res);
        HelpersAssert.RangeWhitespace(_fieldRanges.FieldNameToRange[nameof(Record2101.GenRekvivering)], res);
        HelpersAssert.RangeWhitespace(_fieldRanges.FieldNameToRange[nameof(Record2101.medarbejderNrLetloen)], res);
    }
}