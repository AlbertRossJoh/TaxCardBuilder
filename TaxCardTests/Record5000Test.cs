using System;
using TaxCardFormat.DataTypes;
using TaxCardFormat.Enums;
using TaxCardFormat.Records;
using TaxCardTests.Helpers;
using Xunit;

namespace TaxCardTests
{
    public class Record5000Test : RecordTestBase<Record5000>
    {
        [Fact]
        public void BuildTaxCard5000_ExpectDataPresent()
        {
            // Arrange
            var indberetningsId = new ShortId();
            var referenceId = new ShortId();
            const bool rettelserTidlPeriode = true;
            var lønperiodeStart = new DateTime(2023, 10, 1);
            var lønperiodeSlut = new DateTime(2023, 10, 31);
            const bool erLønBagudBetalt = true;
            const IndkomstType indkomstType = IndkomstType.BIndkomst; 
            GrønlandKommune? grønlandKommune = null;

            // Act
            Sut.AddRecord5000(
                rettelserTidlPeriode,
                lønperiodeStart,
                lønperiodeSlut,
                erLønBagudBetalt,
                indkomstType,
                indberetningsId,
                referenceId,
                grønlandKommune
            );
            var result = Sut.BuildString();

            // Assert
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record5000.Lb_nr)], "0000001", result);
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record5000.Rec_nr)], "5000", result);
            HelpersAssert.PositionEquals(
                _fieldRanges.FieldNameToRange[nameof(Record5000.Rettelse_tidl_periode)].Start.Value,
                rettelserTidlPeriode ? 'R' : '0', result);
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record5000.LønperiodeStart)],
                lønperiodeStart.ToString("yyyyMMdd"), result);
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record5000.LønperiodeSlut)],
                lønperiodeSlut.ToString("yyyyMMdd"), result);
            HelpersAssert.PositionEquals(_fieldRanges.FieldNameToRange[nameof(Record5000.ForudElBagud)].Start.Value,
                erLønBagudBetalt ? 'B' : 'F', result);
            var indkomstTypeRange = _fieldRanges.FieldNameToRange[nameof(Record5000.Indkomsttype)];
            HelpersAssert.RangeEquals(indkomstTypeRange, Padding.ZeroPad((int)indkomstType, indkomstTypeRange), result); 
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record5000.IndberetningsID)],
                indberetningsId.ToString(), result);
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record5000.ReferenceId)],
                referenceId.ToString(), result);

            if (grønlandKommune.HasValue)
            {
                HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record5000.GrønlandskKommune)],
                    grønlandKommune.Value.ToString("D3"), result);
            }
        }
    }
}