using TaxCardFormat.Enums;
using TaxCardFormat.Records;
using TaxCardTests.Helpers;
using Xunit;

namespace TaxCardTests;

public class Record2101Test : RecordTestBase<Record2101<object>>
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
        var lbnr = _fieldRanges.FieldNameToRange[nameof(Record2101<object>.Lb_nr)];
        HelpersAssert.RangeEquals(lbnr, Padding.ZeroPad(1, lbnr), res);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record2101<object>.Rec_nr)], "2101", res);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record2101<object>.PersonCpr)], cpr, res);
        HelpersAssert.RangeEquals(
            _fieldRanges.FieldNameToRange[nameof(Record2101<object>.AnsaettelsesDato)],
            date.ToString("yyyyMMdd"),
            res
        );
        var taxRecordRange = _fieldRanges.FieldNameToRange[nameof(Record2101<object>.SkattekortType)];
        HelpersAssert.RangeEquals(
            taxRecordRange,
            Padding.ZeroPad((int)skatteKort, taxRecordRange),
            res
        );
        HelpersAssert.RangeWhitespace(_fieldRanges.FieldNameToRange[nameof(Record2101<object>.Suppl_opl_med_arbejdernr)], res);
        HelpersAssert.RangeWhitespace(_fieldRanges.FieldNameToRange[nameof(Record2101<object>.FratraedelsesDato)], res);
        HelpersAssert.RangeWhitespace(_fieldRanges.FieldNameToRange[nameof(Record2101<object>.GenRekvivering)], res);
        HelpersAssert.RangeWhitespace(_fieldRanges.FieldNameToRange[nameof(Record2101<object>.medarbejderNrLetloen)], res);
    }
}