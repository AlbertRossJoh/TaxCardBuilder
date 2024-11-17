using TaxCardFormat.Enums;
using TaxCardFormat.Records;
using Xunit;
using TaxCardTests.Helpers;

namespace TaxCardTests
{
    public class Record8001Tests : RecordTestBase<Record8001>
    {
        [Fact]
        public void AddRecord8001_ShouldAddCorrectlyFormattedRecord()
        {
            // Arrange
            var foedselsdato = new DateTime(1990, 1, 1);
            var koen = Koen.Mand;
            var landekoder = Landekoder.DK;
            var navn = "Test Navn";
            var adresse = "Test Adresse 123";
            var postnummer = "1234";
            var postby = "Testby";

            Sut.AddRecord8001(foedselsdato, koen, landekoder, navn, adresse, postnummer, postby);

            var recordString = Sut.BuildString();

            // Assert
            var expectedLbNr = Padding.ZeroPad("1", _fieldRanges.FieldNameToRange[nameof(Record8001.Lb_nr)]);
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record8001.Lb_nr)], expectedLbNr, recordString);

            var expectedRecNr = Padding.ZeroPad("8001", _fieldRanges.FieldNameToRange[nameof(Record8001.Rec_nr)]);
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record8001.Rec_nr)], expectedRecNr, recordString);

            var expectedFoedselsdato = foedselsdato.ToString("yyyyMMdd");
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record8001.PersonFoedselsdato)], expectedFoedselsdato, recordString);

            var expectedKoen = ((int)koen).ToString();
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record8001.PersonKoen)], expectedKoen, recordString);

            var expectedLand = landekoder.ToString("G");
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record8001.PersonLand)], expectedLand, recordString);

            var expectedNavn = navn;
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record8001.PersonNavn)], Padding.WhiteSpacePad(expectedNavn, _fieldRanges.FieldNameToRange[nameof(Record8001.PersonNavn)]),recordString);

            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record8001.PersonGadeAdresse)], Padding.WhiteSpacePad(adresse, _fieldRanges.FieldNameToRange[nameof(Record8001.PersonGadeAdresse)]), recordString);

            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record8001.PersonPostnummer)], Padding.WhiteSpacePad(postnummer, _fieldRanges.FieldNameToRange[nameof(Record8001.PersonPostnummer)], false), recordString);

            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record8001.PersonPostby)], Padding.WhiteSpacePad(postby, _fieldRanges.FieldNameToRange[nameof(Record8001.PersonPostby)]), recordString);
        }
    }
}