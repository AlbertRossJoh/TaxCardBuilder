using FileHelpers;
using TaxCardFormat.Records;

namespace TaxCardFormat.Builders;

public class TaxFileBuilderBase(int lbnr, List<TaxRecord> records)
{
    protected int Lb_nr = lbnr;
    protected List<TaxRecord> Records = records;
    public void Build()
    {
        var engine = new MultiRecordEngine(
            typeof(TaxRecord), 
            typeof(Record1000),
            typeof(Record2001),
            typeof(Record2101),
            typeof(Record2111),
            typeof(Record3101)
        );
        engine.WriteFile("test.txt", Records);
    }
}