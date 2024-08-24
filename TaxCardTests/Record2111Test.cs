using TaxCardFormat.IPIndholdstype.N0100;
using TaxCardFormat.Records;
using TaxCardTests.Helpers;
using Xunit;

namespace TaxCardTests;

public class Record2111Test : RecordTestBase<Record2111>
{
    [Fact]
    public void BuildTaxCard2111_ExpectDataPresent_ContainsDate()
    {
        // Arrange
        var date = DateTime.Now;
        Sut.AddRecord2111(new N0100(N0100Enum.IkkeTidsbegrænset), date);

        // Act
        var res = Sut.BuildString();

        // Assert
        var lbnr = _fieldRanges.FieldNameToRange[nameof(Record2111.Lb_nr)];
        HelpersAssert.RangeEquals(lbnr, Padding.ZeroPad(1, lbnr), res);
        var recnr = _fieldRanges.FieldNameToRange[nameof(Record2111.Rec_nr)];
        HelpersAssert.RangeEquals(recnr, Padding.ZeroPad(2111, recnr), res);
        var indholdtype = _fieldRanges.FieldNameToRange[nameof(Record2111.indholdstype)];
        HelpersAssert.RangeEquals(indholdtype, Padding.ZeroPad(100, indholdtype), res);
        var medarbejderkode = _fieldRanges.FieldNameToRange[nameof(Record2111.medarbejderKode)];
        HelpersAssert.RangeEquals(medarbejderkode, Padding.ZeroPad((int)N0100Enum.IkkeTidsbegrænset, medarbejderkode),
            res);
        var ikræftrædelsesdato = _fieldRanges.FieldNameToRange[nameof(Record2111.ikræftrædelsesDato)];
        HelpersAssert.RangeEquals(ikræftrædelsesdato, date.ToString("yyyyMMdd"), res);
    }

    [Fact]
    public void BuildTaxCard2111_ExpectDataPresent_NoDate()
    {
        // Arrange
        Sut.AddRecord2111(new N0100(N0100Enum.IkkeTidsbegrænset));

        // Act
        var res = Sut.BuildString();

        // Assert
        var lbnr = _fieldRanges.FieldNameToRange[nameof(Record2111.Lb_nr)];
        HelpersAssert.RangeEquals(lbnr, Padding.ZeroPad(1, lbnr), res);
        var recnr = _fieldRanges.FieldNameToRange[nameof(Record2111.Rec_nr)];
        HelpersAssert.RangeEquals(recnr, Padding.ZeroPad(2111, recnr), res);
        var indholdtype = _fieldRanges.FieldNameToRange[nameof(Record2111.indholdstype)];
        HelpersAssert.RangeEquals(indholdtype, Padding.ZeroPad(100, indholdtype), res);
        var medarbejderkode = _fieldRanges.FieldNameToRange[nameof(Record2111.medarbejderKode)];
        HelpersAssert.RangeEquals(medarbejderkode, Padding.ZeroPad((int)N0100Enum.IkkeTidsbegrænset, medarbejderkode),
            res);
        var ikræftrædelsesdato = _fieldRanges.FieldNameToRange[nameof(Record2111.ikræftrædelsesDato)];
        HelpersAssert.RangeEquals(ikræftrædelsesdato, Padding.WhiteSpacePad(ikræftrædelsesdato), res);
    }
}