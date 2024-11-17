using TaxCardFormat.DataTypes;
using TaxCardFormat.Enums;
using TaxCardFormat.Records;
using TaxCardTests.Helpers;
using Xunit;

namespace TaxCardTests;

public class Record1000Test : RecordTestBase<Record1000>
{
    [Fact]
    public void BuildTaxCard1000_ExpectDataPresent()
    {
        // Arrange
        var id = new ShortId();
        var seNr = "12345678";
        var indberetterType = IndberetterType.Virksomhed;
        var system = SystemUsage.Eindkomst;
        Sut.AddRecord1000(
            seNr,
            true,
            system,
            indberetterType,
            hovedIndberetningsId: id
        );

        // Act
        var res = Sut.BuildString();

        // Assert
        HelpersAssert.Length(143, res);
        var lbnrRange = _fieldRanges.FieldNameToRange[nameof(Record1000.Lb_nr)];
        HelpersAssert.RangeEquals(lbnrRange, Padding.ZeroPad(1, lbnrRange), res);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record1000.Rec_nr)], "1000", res);
        HelpersAssert.RangeWhitespace(_fieldRanges.FieldNameToRange[nameof(Record1000.Dato_sendt)], res);
        HelpersAssert.RangeWhitespace(_fieldRanges.FieldNameToRange[nameof(Record1000.Klok_sendt)], res);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record1000.Indberetter_SE_nummer)], seNr, res);
        var indberetterCvrNummerRange = _fieldRanges.FieldNameToRange[nameof(Record1000.Indberetter_CVR_nummer)];
        HelpersAssert.RangeEquals(
            indberetterCvrNummerRange,
            Padding.ZeroPad(0, indberetterCvrNummerRange),
            res
        );
        var indberetterTypeRange = _fieldRanges.FieldNameToRange[nameof(Record1000.IndberetterType)];
        HelpersAssert.RangeEquals(
            indberetterTypeRange,
            Padding.ZeroPad((int)indberetterType, indberetterTypeRange),
            res
        );
        HelpersAssert.RangeEquals(
            _fieldRanges.FieldNameToRange[nameof(Record1000.HovedindberetingsID)],
            id.Id,
            res
        );
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record1000.IsTest)], "T", res);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record1000.EIndkomst_Letloen)], "E", res);
    }
}