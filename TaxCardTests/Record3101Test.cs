using TaxCardFormat.DataTypes;
using TaxCardFormat.Enums;
using TaxCardFormat.Records;
using TaxCardTests.Helpers;
using Xunit;

namespace TaxCardTests;

public class Record3101Test : RecordTestBase<Record3101>
{
    [Fact]
    public void BuildTaxCard3101_ExpectDataPresent()
    {
        // Arrange
        var tmp = -123.321M;
        var dateStart = new DateTime(2020, 01, 01);
        var dateEnd = new DateTime(2020, 01, 02);
        var ambidrag = FeltNummer.AmBidrag;
        var indberetningsId = new ShortId();
        var referenceid = new ShortId();
        Sut.AddRecord3101(
            tmp, 
            false, 
            dateStart, 
            dateEnd,
            ambidrag, 
            indberetningsId,
            referenceid);

        // Act
        var res = Sut.BuildString();

        // Assert
        var lbnr = _fieldRanges.FieldNameToRange[nameof(Record3101.Lb_nr)];
        HelpersAssert.RangeEquals(lbnr, Padding.ZeroPad(1, lbnr), res);
        var recnr = _fieldRanges.FieldNameToRange[nameof(Record3101.Rec_nr)];
        HelpersAssert.RangeEquals(recnr, Padding.ZeroPad(3101, recnr), res);
        var forudElBagud = _fieldRanges.FieldNameToRange[nameof(Record3101.ForudElBagud)];
        HelpersAssert.PositionEquals(forudElBagud.Start.Value, 'B', res);
        var indberetningsIdRange = _fieldRanges.FieldNameToRange[nameof(Record3101.indberetningsId)];
        HelpersAssert.RangeEquals(indberetningsIdRange, indberetningsId.ToString(), res);
        var referenceIdRange = _fieldRanges.FieldNameToRange[nameof(Record3101.referenceId)];
        HelpersAssert.RangeEquals(referenceIdRange, referenceid.ToString(), res);
        var periodeIndberetStartRange = _fieldRanges.FieldNameToRange[nameof(Record3101.PeriodeIndberetStart)];
        HelpersAssert.RangeEquals(periodeIndberetStartRange, dateStart.ToString("yyyyMMdd"), res);
        var periodeIndberetSlutRange = _fieldRanges.FieldNameToRange[nameof(Record3101.PeriodeIndberetSlut)];
        HelpersAssert.RangeEquals(periodeIndberetSlutRange, dateEnd.ToString("yyyyMMdd"), res);
        var nulangivelse = _fieldRanges.FieldNameToRange[nameof(Record3101.Nulangivelse)];
        HelpersAssert.PositionEquals(nulangivelse.Start.Value, ' ', res);
        var feltNummerRange = _fieldRanges.FieldNameToRange[nameof(Record3101.FeltNummer)];
        HelpersAssert.RangeEquals(feltNummerRange, Padding.ZeroPad((int) ambidrag, feltNummerRange), res);
        var AmountRange = _fieldRanges.FieldNameToRange[nameof(Record3101.Amount)];
        HelpersAssert.RangeEquals(AmountRange, Padding.ZeroPad((int)tmp, AmountRange),res);
        var decimalsRange = _fieldRanges.FieldNameToRange[nameof(Record3101.Decimals)];
        HelpersAssert.RangeEquals(decimalsRange, Padding.ZeroPad(321, decimalsRange, false), res);
        var signRange = _fieldRanges.FieldNameToRange[nameof(Record3101.Sign)];
        HelpersAssert.PositionEquals(signRange.Start.Value, '-', res);
    }
}
