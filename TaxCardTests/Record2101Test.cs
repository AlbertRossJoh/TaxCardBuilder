using TaxCardFormat.Builders;
using TaxCardFormat.Enums;
using TaxCardFormat.Records;
using TaxCardTests.Helpers;
using Xunit;

namespace TaxCardTests;

public class Record2101Test
{
    private TaxFileBuilder2 sut = new();
    private FieldRanges _fieldRanges = new(typeof(Record2101));
    private string Lb_nr = "Lb_nr";
    private string Rec_nr = "Rec_nr";
    private string Suppl_opl_med_arbejdernr = "Suppl_opl_med_arbejdernr";
    private string medarbejderNrLetløn = "medarbejderNrLetløn";
    private string GenRekvivering = "GenRekvivering";
    private string TaxRecord = "TaxRecord";
    private string PersonCpr = "PersonCpr";
    private string AnsættelsesDato = "AnsættelsesDato";
    private string FratrædelsesDato = "FratrædelsesDato";

    [Fact]
    public void BuildTaxCard2101_ExpectDataPresent()
    {
        // Arrange
        using var ms = new MemoryStream();
        using var sw = new StreamWriter(ms);

        var cpr = "1234567890";
        var date = DateTime.Now;
        var skanvendeFra = DateTime.Now;
        var skatteKort = SkattekortType.Bikort;
        sut.AddRecord2101(date, cpr, skatteKort, skanvendeFra);

        // Act
        sut.Build(sw);
        sw.Flush();
        ms.Position = 0;
        using var sr = new StreamReader(ms);
        var res = sr.ReadToEnd();

        // Assert
        var lbnr = _fieldRanges.FieldNameToRange[Lb_nr];
        HelpersAssert.RangeEquals(lbnr, Padding.ZeroPad(1, lbnr), res);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[Rec_nr], "2101", res);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[PersonCpr], cpr, res);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[AnsættelsesDato], date.ToString("yyyyMMdd"), res);
        var taxRecordRange = _fieldRanges.FieldNameToRange[TaxRecord];
        HelpersAssert.RangeEquals(taxRecordRange, Padding.ZeroPad((int) skatteKort, taxRecordRange), res);
        HelpersAssert.RangeWhitespace(_fieldRanges.FieldNameToRange[Suppl_opl_med_arbejdernr], res);
        HelpersAssert.RangeWhitespace(_fieldRanges.FieldNameToRange[FratrædelsesDato], res);
        HelpersAssert.RangeWhitespace(_fieldRanges.FieldNameToRange[GenRekvivering], res);
        HelpersAssert.RangeWhitespace(_fieldRanges.FieldNameToRange[medarbejderNrLetløn], res);
    }
}
