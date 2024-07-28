using TaxCardFormat.Enums;
using TaxCardFormat.Records;

namespace TaxCardFormat.Builders;

public class TaxFile1000Builder : TaxFileBuilderBase
{
    public TaxFile1000Builder(
        int lbnr, 
        List<TaxRecord> records,
        string indberetterSeNummer, 
        bool isTest,
        SystemUsage systemUsage, 
        IndberetterType indberetterType,
        string? cvrNummer = null,
        DateTime? datoSendt = null,
        DateTime? klokSendt = null,
        string? edbSystem = null,
        Guid hovedIndberetningsId = new()
    ): base(lbnr, records)
    {
        Records.Add(new Record1000
        {
            Lb_nr = Lb_nr++,
            Rec_nr = 1000,
            Dato_sendt = datoSendt,
            Klok_sendt = klokSendt,
            Indberetter_SE_nummer = indberetterSeNummer,
            Indberetter_CVR_nummer = cvrNummer ?? "",
            IndberetterType = (int)indberetterType,
            Edb_System = edbSystem,
            HovedindberetingsID = hovedIndberetningsId,
            IsTest = isTest ? 'T':'P',
            EIndkomst_Letløn = GetSystem(systemUsage)
        });
    }

    public TaxFile2001Builder AddRecord2001(string virksomhedSe, string valutakode = "DKK", bool ophørHosLSB = false)
    {
        return new TaxFile2001Builder(Lb_nr, Records, virksomhedSe, valutakode, ophørHosLSB);
    }
    
    private static char GetSystem(SystemUsage systemUsage) =>
        systemUsage switch
        {
            SystemUsage.Eindkomst => 'E',
            SystemUsage.LetLøn => 'L',
            _ => throw new ArgumentOutOfRangeException(nameof(systemUsage), systemUsage, "Not a valid system")
        };
}