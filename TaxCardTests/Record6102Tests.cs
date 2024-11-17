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
            var beloeb = 1234.56m;
            var feriedage = 1.23m;
            var ferieaar = 2023;
            var fratraedelsesDato = new DateTime(2023, 10, 10);

            // Act
            Sut.AddRecord6102(beloeb, feriedage, ferieaar, fratraedelsesDato);
            var result = Sut.BuildString();

            // Assert
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6102.Lb_nr)], "0000001", result);
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6102.Rec_nr)], "6102", result);
            var beloebRange = _fieldRanges.FieldNameToRange[nameof(Record6102.Beloeb)];
            HelpersAssert.RangeEquals(beloebRange, Padding.ZeroPad((int)beloeb, beloebRange), result);
            var beloebDecimalRange = _fieldRanges.FieldNameToRange[nameof(Record6102.BeloebDecimal)];
            HelpersAssert.RangeEquals(beloebDecimalRange, Padding.ZeroPad(56, beloebDecimalRange, false), result);
            HelpersAssert.PositionEquals(_fieldRanges.FieldNameToRange[nameof(Record6102.FortegnFeriepenge)].Start.Value, '+', result);
            var feriedageRange = _fieldRanges.FieldNameToRange[nameof(Record6102.FeriedageHeltal)];
            HelpersAssert.RangeEquals(feriedageRange, Padding.ZeroPad((int) feriedage, feriedageRange), result);
            var feriedageDecimalRange = _fieldRanges.FieldNameToRange[nameof(Record6102.FeriedageDecimal)];
            HelpersAssert.RangeEquals(feriedageDecimalRange, Padding.ZeroPad(23, feriedageDecimalRange, false), result);
            HelpersAssert.PositionEquals(_fieldRanges.FieldNameToRange[nameof(Record6102.FortegnFeiedage)].Start.Value, '+', result);
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6102.Ferieaar)], "2023", result);
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record6102.FratraedelsesDato)], fratraedelsesDato.ToString("yyyyMMdd"), result);
        }
    }
}