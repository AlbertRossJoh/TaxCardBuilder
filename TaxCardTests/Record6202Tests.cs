using TaxCardTests.Helpers;
using TaxCardFormat.Records;
using Xunit;

namespace TaxCardTests;

public class Record6202Tests : RecordTestBase<Record6202>
{
    [Fact]
    public void AddRecord6202_ShouldAddRecordWithCorrectFields()
    {
        // Arrange
        decimal beloeb = 12345.678901m;
        decimal feriedage = 10.25m;
        int ferieaar = 2024;
        DateTime fratraedelsesDato = new DateTime(2024, 12, 31);

        // Act
        Sut.AddRecord6202(beloeb, feriedage, ferieaar, fratraedelsesDato);
        var resultString = Sut.BuildString();

        // Extract the integer and decimal parts
        var (amnt, decimals) = ExtractDecimalParts(beloeb);
        var (amntFeriedage, decimalsFeriedage) = ExtractDecimalParts(feriedage, 2);

        // Assert
        HelpersAssert.RangeEquals(
            _fieldRanges.FieldNameToRange[nameof(Record6202.Lb_nr)], 
            Padding.ZeroPad(1, _fieldRanges.FieldNameToRange[nameof(Record6202.Lb_nr)]), 
            resultString);

        HelpersAssert.RangeEquals(
            _fieldRanges.FieldNameToRange[nameof(Record6202.Rec_nr)], 
            "6202", 
            resultString);

        HelpersAssert.RangeEquals(
            _fieldRanges.FieldNameToRange[nameof(Record6202.Beloeb)], 
            Padding.ZeroPad(amnt, _fieldRanges.FieldNameToRange[nameof(Record6202.Beloeb)]), 
            resultString);

        HelpersAssert.RangeEquals(
            _fieldRanges.FieldNameToRange[nameof(Record6202.BeloebDecimal)], 
            Padding.ZeroPad(decimals, _fieldRanges.FieldNameToRange[nameof(Record6202.BeloebDecimal)], leftPad: false), 
            resultString);

        HelpersAssert.RangeEquals(
            _fieldRanges.FieldNameToRange[nameof(Record6202.FortegnFeriepenge)], 
            Fortegn(beloeb).ToString(), 
            resultString);

        HelpersAssert.RangeEquals(
            _fieldRanges.FieldNameToRange[nameof(Record6202.FeriedageHeltal)], 
            Padding.ZeroPad(amntFeriedage, _fieldRanges.FieldNameToRange[nameof(Record6202.FeriedageHeltal)]), 
            resultString);

        HelpersAssert.RangeEquals(
            _fieldRanges.FieldNameToRange[nameof(Record6202.FeriedageDecimal)], 
            Padding.ZeroPad(decimalsFeriedage, _fieldRanges.FieldNameToRange[nameof(Record6202.FeriedageDecimal)], leftPad: false), 
            resultString);

        HelpersAssert.RangeEquals(
            _fieldRanges.FieldNameToRange[nameof(Record6202.FortegnFeiedage)], 
            Fortegn(feriedage).ToString(), 
            resultString);

        HelpersAssert.RangeEquals(
            _fieldRanges.FieldNameToRange[nameof(Record6202.Ferieaar)], 
            Padding.ZeroPad(ferieaar, _fieldRanges.FieldNameToRange[nameof(Record6202.Ferieaar)]), 
            resultString);

        HelpersAssert.RangeEquals(
            _fieldRanges.FieldNameToRange[nameof(Record6202.FratraedelsesDato)], 
            fratraedelsesDato.ToString("yyyyMMdd"), 
            resultString);
    }

    private (int integerPart, int decimalPart) ExtractDecimalParts(decimal amount, int decimalPlaces = 6)
    {
        var integerPart = (int)amount;
        var decimalPart = (int)((amount - integerPart) * (int)Math.Pow(10, decimalPlaces)); // 6 decimal precision
        return (integerPart, decimalPart);
    }

    private char Fortegn(decimal value)
    {
        return value < 0 ? '-' : '+';
    }
}
