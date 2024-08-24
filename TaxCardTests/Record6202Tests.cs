using System;
using TaxCardTests.Helpers;
using TaxCardFormat.Records;
using Xunit;

namespace TaxCardTests
{
    public class Record6202Tests : RecordTestBase<Record6202>
    {
        [Fact]
        public void AddRecord6202_ShouldAddRecordWithCorrectFields()
        {
            // Arrange
            decimal beløb = 12345.678901m;
            decimal feriedage = 10.25m;
            int ferieår = 2024;
            DateTime fratrædelsesDato = new DateTime(2024, 12, 31);

            // Act
            Sut.AddRecord6202(beløb, feriedage, ferieår, fratrædelsesDato);
            var resultString = Sut.BuildString();

            // Extract the integer and decimal parts
            var (amnt, decimals) = ExtractDecimalParts(beløb);
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
                _fieldRanges.FieldNameToRange[nameof(Record6202.Beløb)], 
                Padding.ZeroPad(amnt, _fieldRanges.FieldNameToRange[nameof(Record6202.Beløb)]), 
                resultString);

            HelpersAssert.RangeEquals(
                _fieldRanges.FieldNameToRange[nameof(Record6202.BeløbDecimal)], 
                Padding.ZeroPad(decimals, _fieldRanges.FieldNameToRange[nameof(Record6202.BeløbDecimal)], leftPad: false), 
                resultString);

            HelpersAssert.RangeEquals(
                _fieldRanges.FieldNameToRange[nameof(Record6202.FortegnFeriepenge)], 
                Fortegn(beløb).ToString(), 
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
                _fieldRanges.FieldNameToRange[nameof(Record6202.Ferieår)], 
                Padding.ZeroPad(ferieår, _fieldRanges.FieldNameToRange[nameof(Record6202.Ferieår)]), 
                resultString);

            HelpersAssert.RangeEquals(
                _fieldRanges.FieldNameToRange[nameof(Record6202.FratrædelsesDato)], 
                fratrædelsesDato.ToString("yyyyMMdd"), 
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
}
