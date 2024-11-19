using TaxCardFormat.DataTypes;
using TaxCardFormat.Enums;
using TaxCardFormat.Records;
using TaxCardTests.Helpers;
using Xunit;

namespace TaxCardTests;

public class Record5000Test : RecordTestBase<Record5000<object>>
{
    [Fact]
    public void BuildTaxCard5000_ExpectDataPresent()
    {
        // Arrange
        var indberetningsId = new ShortId();
        var referenceId = new ShortId();
        const bool rettelserTidlPeriode = true;
        var loenperiodeStart = new DateTime(2023, 10, 1);
        var loenperiodeSlut = new DateTime(2023, 10, 31);
        const bool erLoenBagudBetalt = true;
        const IndkomstType indkomstType = IndkomstType.BIndkomst; 
        GroenlandKommune? groenlandKommune = null;

        // Act
        Sut.AddRecord5000(
            rettelserTidlPeriode,
            loenperiodeStart,
            loenperiodeSlut,
            erLoenBagudBetalt,
            indkomstType,
            indberetningsId,
            referenceId,
            groenlandKommune
        );
        var result = Sut.BuildString();

        // Assert
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record5000<object>.Lb_nr)], "0000001", result);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record5000<object>.Rec_nr)], "5000", result);
        HelpersAssert.PositionEquals(
            _fieldRanges.FieldNameToRange[nameof(Record5000<object>.Rettelse_tidl_periode)].Start.Value,
            rettelserTidlPeriode ? 'R' : '0', result);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record5000<object>.LoenperiodeStart)],
            loenperiodeStart.ToString("yyyyMMdd"), result);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record5000<object>.LoenperiodeSlut)],
            loenperiodeSlut.ToString("yyyyMMdd"), result);
        HelpersAssert.PositionEquals(_fieldRanges.FieldNameToRange[nameof(Record5000<object>.ForudElBagud)].Start.Value,
            erLoenBagudBetalt ? 'B' : 'F', result);
        var indkomstTypeRange = _fieldRanges.FieldNameToRange[nameof(Record5000<object>.Indkomsttype)];
        HelpersAssert.RangeEquals(indkomstTypeRange, Padding.ZeroPad((int)indkomstType, indkomstTypeRange), result); 
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record5000<object>.IndberetningsID)],
            indberetningsId.ToString(), result);
        HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record5000<object>.ReferenceId)],
            referenceId.ToString(), result);

        if (groenlandKommune.HasValue)
        {
            HelpersAssert.RangeEquals(_fieldRanges.FieldNameToRange[nameof(Record5000<object>.GroenlandskKommune)],
                groenlandKommune.Value.ToString("D3"), result);
        }
    }
}
