using FileHelpers;
using TaxCardFormat.Enums;
using TaxCardFormat.Records;

namespace TaxCardFormat.Builders;

public class TaxFileBuilder
{
    protected List<TaxRecord> Records = [];

    public TaxFile1000Builder AddRecord1000(
       string indberetterSeNummer, 
       bool isTest,
       SystemUsage systemUsage, 
       IndberetterType indberetterType,
       string? cvrNummer = null,
       DateTime? datoSendt = null,
       DateTime? klokSendt = null,
       string? edbSystem = null,
       Guid hovedIndberetningsId = new())
    {
        return new TaxFile1000Builder(
            1,
            Records,
            indberetterSeNummer, 
            isTest, 
            systemUsage, 
            indberetterType,
            cvrNummer, 
            datoSendt, 
            klokSendt, 
            edbSystem, 
            hovedIndberetningsId);
    }

    public void Build()
    {
        var engine = new MultiRecordEngine(typeof(TaxRecord), typeof(Record1000));
        engine.WriteFile("test.txt", Records);
    }
}