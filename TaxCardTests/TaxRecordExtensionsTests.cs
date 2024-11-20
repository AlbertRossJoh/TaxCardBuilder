using FileHelpers;
using TaxCardFormat.DataTypes;
using TaxCardFormat.DataTypes.Loenoplysninger;
using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces.IRecord;
using TaxCardFormat.Records;
using TaxCardFormat.Utilities;
using Xunit;

namespace TaxCardTests;

public class TaxRecordExtensionsTests
{
    [Fact]
    public void FlattenTaxRecord_OrderIsPreserved()
    {
        // Arrange
        var FirstRecord = new Record1000
        {
            Lb_nr = 1,
            Rec_nr = 1000,
            Dato_sendt = DateTime.Now,
            Klok_sendt = DateTime.Now,
            Indberetter_SE_nummer = "12345678",
            Indberetter_CVR_nummer = "12345678",
            IndberetterType = (int)1,
            Edb_System = "hej",
            HovedindberetingsID = new ShortId(),
            IsTest = 'T',
            EIndkomst_Letloen = 'E'
        };

        FirstRecord.AddRecord2001("12345678", false)
            .AddRecord2101(DateTime.Now, "1234567890", SkattekortType.Bikort, DateTime.Now)
            .AddRecord8001(DateTime.Now, Koen.Mand, Landekoder.DK, "John Doe", "John Doe stræde", "0000", "by")
            .AddRecord3101(12, false, DateTime.Now, DateTime.Now, FeltNummer.AmBidrag)
            .AddRecord4101(false, new ShortId())
            .AddRecord5000(false, DateTime.Now, DateTime.Now, false, IndkomstType.Aindkomst, new ShortId())
            .AddRecord6000("1234567890", "12345678", "12345678910", "DBDKK", Landekoder.DK, IndkomstArt.aeldrecheck)
            .AddRecord6001(12, Vaerdisaet6001.Haedersgaver)
            .AddRecord6002(Vaerdisaet6002.Pinkode, "1234")
            .AddRecord6003(Vaerdisaet6003.Naturalieydelser)
            .AddRecord6004(Vaerdisaet6004.YderligereTekstoplysninger, "hej med dig")
            .AddRecord6005(AntalsFelt6005.AntalLoentimer, 2)
            .AddRecord6102(2000, 2.2m, 2024, DateTime.Now)
            .AddRecord6111(new IL0010(0, 1000))
            .GoBackUntil<IRecord1000>()!
            .AddRecord2001("12345678", false);
        
        var acc = new List<TaxRecord>();
        
        // Act
        FirstRecord.RecursiveFlatten(acc);
        var expected = acc.Select(t => t.GetType());
        var actual = FirstRecord.Flatten().Select(t => t.GetType());
        
        // Assert
        Assert.Equal(expected, actual);
    }
}