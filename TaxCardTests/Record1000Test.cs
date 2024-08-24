using TaxCardFormat.Builders;
using TaxCardFormat.DataTypes;
using TaxCardFormat.Enums;
using TaxCardFormat.Records;
using TaxCardTests.Helpers;
using Xunit;

namespace TaxCardTests;

public class Record1000Test
{
    private TaxFileBuilder2 sut = new();
    private FieldRanges _fieldRanges = new(typeof(Record1000));
    private string Lb_nr = "Lb_nr";
    private string Rec_nr = "Rec_nr";
    private string Dato_sendt = "Dato_sendt";
    private string Klok_sendt = "Klok_sendt";
    private string Indberetter_SE_nummer = "Indberetter_SE_nummer";
    private string Indberetter_CVR_nummer = "Indberetter_CVR_nummer";
    private string IndberetterType_ = "IndberetterType";
    private string Edb_System = "Edb_System";
    private string Edb_System_Version = "Edb_System_Version";
    private string HovedindberetingsID = "HovedindberetingsID";
    private string IsTest = "IsTest";
    private string EIndkomst_Letløn = "EIndkomst_Letløn";

    [Fact]
    public void BuildTaxCard1000_ExpectDataPresent()
    {
        // Arrange
        using var ms = new MemoryStream();
        using var sw = new StreamWriter(ms);
        var id = new ShortId();
        var seNr = "12345678";
        var indberetterType = IndberetterType.Virksomhed;
        var system = SystemUsage.Eindkomst;
        sut.AddRecord1000(
            seNr,
            true,
            system,
            indberetterType,
            hovedIndberetningsId: id
        );

        // Act
        sut.Build(sw);
        sw.Flush();
        ms.Position = 0;
        using var sr = new StreamReader(ms);
        var res = sr.ReadToEnd();

        // Assert
        HelpersAssert.Length(143, res);
        var lbnrRange = _fieldRanges.FieldNameToRange[Lb_nr];
        HelpersAssert.RangeEquals(lbnrRange, Padding.ZeroPad(1, lbnrRange), res);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[Rec_nr], "1000", res);
        HelpersAssert.RangeWhitespace(_fieldRanges.FieldNameToRange[Dato_sendt], res);
        HelpersAssert.RangeWhitespace(_fieldRanges.FieldNameToRange[Klok_sendt], res);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[Indberetter_SE_nummer], seNr, res);
        var indberetterCvrNummerRange = _fieldRanges.FieldNameToRange[Indberetter_CVR_nummer];
        HelpersAssert.RangeEquals(
            indberetterCvrNummerRange,
            Padding.ZeroPad(0, indberetterCvrNummerRange),
            res
        );
        var indberetterTypeRange = _fieldRanges.FieldNameToRange[IndberetterType_];
        HelpersAssert.RangeEquals(
            indberetterTypeRange,
            Padding.ZeroPad((int)indberetterType, indberetterTypeRange),
            res
        );
        HelpersAssert.RangeEquals(
            _fieldRanges.FieldNameToRange[HovedindberetingsID],
            id.Id,
            res
        );
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[IsTest], "T", res);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[EIndkomst_Letløn], "E", res);
    }
}

