using TaxCardFormat.DataTypes.IPIndholdstype;
using TaxCardFormat.Records;
using TaxCardTests.Helpers;
using Xunit;

namespace TaxCardTests;

public class Record2111Test : RecordTestBase<Record2111<object>>
{
    [Fact]
    public void BuildTaxCard2111_ExpectDataPresent_ContainsDate()
    {
        // Arrange
        var date = DateTime.Now;
        Sut.AddRecord2111(new N0100(N0100Enum.IkkeTidsbegraenset), date);

        // Act
        var res = Sut.BuildString();

        // Assert
        var lbnr = _fieldRanges.FieldNameToRange[nameof(Record2111<object>.Lb_nr)];
        HelpersAssert.RangeEquals(lbnr, Padding.ZeroPad(1, lbnr), res);
        var recnr = _fieldRanges.FieldNameToRange[nameof(Record2111<object>.Rec_nr)];
        HelpersAssert.RangeEquals(recnr, Padding.ZeroPad(2111, recnr), res);
        var indholdtype = _fieldRanges.FieldNameToRange[nameof(Record2111<object>.indholdstype)];
        HelpersAssert.RangeEquals(indholdtype, Padding.ZeroPad(100, indholdtype), res);
        var medarbejderkode = _fieldRanges.FieldNameToRange[nameof(Record2111<object>.medarbejderKode)];
        HelpersAssert.RangeEquals(medarbejderkode, Padding.ZeroPad((int)N0100Enum.IkkeTidsbegraenset, medarbejderkode),
            res);
        var ikraeftraedelsesdato = _fieldRanges.FieldNameToRange[nameof(Record2111<object>.ikraeftraedelsesDato)];
        HelpersAssert.RangeEquals(ikraeftraedelsesdato, date.ToString("yyyyMMdd"), res);
    }

    [Fact]
    public void BuildTaxCard2111_ExpectDataPresent_NoDate()
    {
        // Arrange
        Sut.AddRecord2111(new N0100(N0100Enum.IkkeTidsbegraenset));

        // Act
        var res = Sut.BuildString();

        // Assert
        var lbnr = _fieldRanges.FieldNameToRange[nameof(Record2111<object>.Lb_nr)];
        HelpersAssert.RangeEquals(lbnr, Padding.ZeroPad(1, lbnr), res);
        var recnr = _fieldRanges.FieldNameToRange[nameof(Record2111<object>.Rec_nr)];
        HelpersAssert.RangeEquals(recnr, Padding.ZeroPad(2111, recnr), res);
        var indholdtype = _fieldRanges.FieldNameToRange[nameof(Record2111<object>.indholdstype)];
        HelpersAssert.RangeEquals(indholdtype, Padding.ZeroPad(100, indholdtype), res);
        var medarbejderkode = _fieldRanges.FieldNameToRange[nameof(Record2111<object>.medarbejderKode)];
        HelpersAssert.RangeEquals(medarbejderkode, Padding.ZeroPad((int)N0100Enum.IkkeTidsbegraenset, medarbejderkode),
            res);
        var ikraeftraedelsesdato = _fieldRanges.FieldNameToRange[nameof(Record2111<object>.ikraeftraedelsesDato)];
        HelpersAssert.RangeEquals(ikraeftraedelsesdato, Padding.WhiteSpacePad(ikraeftraedelsesdato), res);
    }
}