using TaxCardFormat.Enums;
using TaxCardFormat.Records;
using TaxCardTests.Helpers;
using Xunit;

namespace TaxCardTests
{
    public class Record6000Test : RecordTestBase<Record6000>
    {
        [Fact]
        public void BuildTaxCard6000_ExpectDataPresent()
        {
            // Arrange
            const string cpr = "1234567890";
            const string cvr_se = "09876543";
            const string medarbejderNr = "987654";
            const string tin = "TIN123";
            const Landekoder tin_landekode = Landekoder.DK; 
            const IndkomstArt indkomstArt = IndkomstArt.SygedagpengeA_Indkomst; 
            const string produktionEnhedsnummer = "12345";

            // Act
            Sut.AddRecord6000(cpr, cvr_se, medarbejderNr, tin, tin_landekode, indkomstArt, produktionEnhedsnummer);

            // Build the string representation of the records
            var result = Sut.BuildString();

            // Assert
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6000.Lb_nr)], "0000001", result);
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6000.Rec_nr)], "6000", result);
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6000.CPR)], cpr, result);
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6000.CVR_SE)], cvr_se, result);
            var medarbejderNrRange = _fieldRanges.FieldNameToRange[nameof(Record6000.MedarbejderNr)];
            HelpersAssert.RangeEquals(medarbejderNrRange, Padding.WhiteSpacePad(medarbejderNr, medarbejderNrRange),
                result);
            var tinRange = _fieldRanges.FieldNameToRange[nameof(Record6000.TIN)];
            HelpersAssert.RangeEquals(tinRange, Padding.WhiteSpacePad(tin, tinRange), result);
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6000.TIN_landekode)],
                tin_landekode.ToString("G"), result);
            var indkomstArtRange = _fieldRanges.FieldNameToRange[nameof(Record6000.Indtaegtsart)];
            HelpersAssert.RangeEquals(indkomstArtRange,
                Padding.ZeroPad((int)indkomstArt, indkomstArtRange), result); // assuming IndkomstArt has a ToString("D2") method
            var prodRange = _fieldRanges.FieldNameToRange[nameof(Record6000.ProduktionEndhedsNummer)];
            HelpersAssert.RangeEquals(prodRange, Padding.WhiteSpacePad(produktionEnhedsnummer, prodRange), result);
        }
    }
}