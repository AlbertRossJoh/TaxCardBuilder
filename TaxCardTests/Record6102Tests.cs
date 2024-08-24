using TaxCardFormat.Records;
using TaxCardTests.Helpers;
using Xunit;

namespace TaxCardTests
{
    public class Record6102Tests : RecordTestBase<Record6102>
    {

        [Fact]
        public void AddRecord6102_ValidInput_BuildsCorrectString()
        {
            // Arrange
            var beløb = 1234.56m;
            var feriedage = 1.23m;
            var ferieår = 2023;
            var fratrædelsesDato = new DateTime(2023, 10, 10);

            // Act
            Sut.AddRecord6102(beløb, feriedage, ferieår, fratrædelsesDato);
            var result = Sut.BuildString();

            // Assert
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6102.Lb_nr)], "0000001", result);
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6102.Rec_nr)], "6102", result);
            var beløbRange = _fieldRanges.FieldNameToRange[nameof(Record6102.Beløb)];
            HelpersAssert.RangeEquals(beløbRange, Padding.ZeroPad((int)beløb, beløbRange), result);
            var beløbDecimalRange = _fieldRanges.FieldNameToRange[nameof(Record6102.BeløbDecimal)];
            HelpersAssert.RangeEquals(beløbDecimalRange, Padding.ZeroPad(56, beløbDecimalRange, false), result);
            HelpersAssert.PositionEquals(_fieldRanges.FieldNameToRange[nameof(Record6102.FortegnFeriepenge)].Start.Value, '+', result);
            var feriedageRange = _fieldRanges.FieldNameToRange[nameof(Record6102.FeriedageHeltal)];
            HelpersAssert.RangeEquals(feriedageRange, Padding.ZeroPad((int) feriedage, feriedageRange), result);
            var feriedageDecimalRange = _fieldRanges.FieldNameToRange[nameof(Record6102.FeriedageDecimal)];
            HelpersAssert.RangeEquals(feriedageDecimalRange, Padding.ZeroPad(23, feriedageDecimalRange, false), result);
            HelpersAssert.PositionEquals(_fieldRanges.FieldNameToRange[nameof(Record6102.FortegnFeiedage)].Start.Value, '+', result);
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6102.Ferieår)], "2023", result);
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6102.FratrædelsesDato)], fratrædelsesDato.ToString("yyyyMMdd"), result);
        }
    }
}