using TaxCardFormat.Builder;
using TaxCardFormat.DataTypes.IPIndholdstype;
using TaxCardFormat.Enums;
using Xunit;

namespace TaxCardTests;

public class BuildFileTest
{
    [Fact]
    public void BuildFile_ValidInput_BuildsFile()
    {
        var sut = new TaxFileBuilder2();
        sut
            .AddRecord1000("12345678", true, SystemUsage.Eindkomst, IndberetterType.Virksomhed)
            .AddRecord2001("12345678", false)
            .AddRecord2101(DateTime.Now, "1234567890", SkattekortType.Bikort, DateTime.Now)
            .AddRecord8001(DateTime.Now, Koen.Mand, Landekoder.DK, "John Doe", "John Doe stræde", "0000", "by")
            .AddRecord3101(12, false, DateTime.Now, DateTime.Now, FeltNummer.AmBidrag)
            .AddRecord4101(false)
            .AddRecord5000(false, DateTime.Now, DateTime.Now, false, IndkomstType.Aindkomst)
            .AddRecord6000("1234567890", "12345678", "12345678910", "DBDKK", Landekoder.DK, IndkomstArt.aeldrecheck)
            .AddRecord6001(12, Vaerdisaet6001.Haedersgaver)
            .AddRecord6002(Vaerdisaet6002.Pinkode, "1234")
            .AddRecord6003(Vaerdisaet6003.Naturalieydelser)
            .AddRecord6004(Vaerdisaet6004.YderligereTekstoplysninger, "hej med dig")
            .AddRecord6005(AntalsFelt6005.AntalLoentimer, 2)
            .AddRecord6102(2000, 2.2m, 2024, DateTime.Now)
            .AddRecord6111(new IP0100(N0100Enum.Tidsbegraenset), 2, 2)
            .AddRecord6111(new IP0610(2), 2, 2);
    }
}