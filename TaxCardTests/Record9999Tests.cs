using TaxCardFormat.Builder;
using TaxCardFormat.Enums;
using Xunit;
using TaxCardTests.Helpers;
using TaxCardFormat.Records;

namespace TaxCardTests;

public class Record9999Tests : RecordTestBase<Record9999>
{
    [Fact]
    public void AddRecord9999_ShouldAddCorrectRecord()
    {
        // Arrange
        var sut = new TaxFileBuilder();
        sut.AddRecord9999();
        var expectedLbNr = 1;
        var expectedRecNr = 9999;
        var expectedAntalRecords = 2;
            
        // Act
        var resultString = sut.BuildString();
            
        // Assert
        HelpersAssert.RangeEquals(
            _fieldRanges.FieldNameToRange[nameof(Record9999.Lb_nr)], 
            Padding.ZeroPad(expectedLbNr, 7),
            resultString
        );
        HelpersAssert.RangeEquals(
            _fieldRanges.FieldNameToRange[nameof(Record9999.Rec_nr)],
            expectedRecNr.ToString(),
            resultString
        );
        HelpersAssert.RangeEquals(
            _fieldRanges.FieldNameToRange[nameof(Record9999.AntalRecords)], 
            Padding.ZeroPad(expectedAntalRecords, 7), 
            resultString
        );
    }

    [Fact]
    public void AddRecord9999_ShouldHaveCorrectLbNr()
    {
        // Arrange
        var sut = new TaxFileBuilder();
        var i = 0;
        for (; i < 9999; i++)
        {
            sut.AddRecord6001((decimal)Random.Shared.NextDouble(), FeltNummer.AmBidrag);
        }
        sut.AddRecord9999();
        var expectedLbNr = ++i;
        var expectedRecNr = 9999;
        var expectedAntalRecords = ++i;
            
            
        // Act
        var result = sut.BuildString();
        var resultString = result.Split()[^2];
        
        // Assert
        HelpersAssert.RangeEquals(
            _fieldRanges.FieldNameToRange[nameof(Record9999.Lb_nr)], 
            Padding.ZeroPad(expectedLbNr, 7),
            resultString
        );
        HelpersAssert.RangeEquals(
            _fieldRanges.FieldNameToRange[nameof(Record9999.Rec_nr)],
            expectedRecNr.ToString(),
            resultString
        );
        HelpersAssert.RangeEquals(
            _fieldRanges.FieldNameToRange[nameof(Record9999.AntalRecords)], 
            Padding.ZeroPad(expectedAntalRecords, 7), 
            resultString
        );
    }
}
