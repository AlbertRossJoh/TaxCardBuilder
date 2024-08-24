using TaxCardFormat.Builders;
using TaxCardFormat.Records;
using TaxCardTests.Helpers;
using Xunit;

namespace TaxCardTests;

public class Record2001Test
{
    private TaxFileBuilder2 sut = new();
    private FieldRanges _fieldRanges = new(typeof(Record2001));
    private string Lb_nr = "Lb_nr";
    private string Rec_nr = "Rec_nr";
    private string Virksomhed_Ophør_Hos_LSB = "Virksomhed_Ophør_Hos_LSB";
    private string Valutakode = "Valutakode";
    private string Virksomhed_SE_nummer = "Virksomhed_SE_nummer";

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void BuildTaxCard2001_ExpectDataPresent(bool ophør)
    {
        // Arrange
        using var ms = new MemoryStream();
        using var sw = new StreamWriter(ms);

        var seNr = "12345678";
        sut.AddRecord2001(seNr, ophørHosLSB: ophør);

        // Act
        sut.Build(sw);
        sw.Flush();
        ms.Position = 0;
        using var sr = new StreamReader(ms);
        var res = sr.ReadToEnd();

        // Assert
        var lbnr = _fieldRanges.FieldNameToRange[Lb_nr];
        HelpersAssert.RangeEquals(lbnr, Padding.ZeroPad(1, lbnr), res);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[Rec_nr], "2001", res);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[Virksomhed_SE_nummer], seNr, res);
        HelpersAssert.PositionEquals(
            _fieldRanges.FieldNameToRange[Virksomhed_Ophør_Hos_LSB].Start.Value,
            ophør ? 'A' : ' ',
            res
        );
    }
}

