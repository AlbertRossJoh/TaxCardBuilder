using TaxCardFormat.Enums;
using TaxCardFormat.Records;
using IPIndholdsType = TaxCardFormat.IPIndholdstype.IPIndholdsType;

namespace TaxCardFormat.Builders;

public class TaxFile2111Builder: Record2101BuilderBase
{
    public TaxFile2111Builder(
        int lbnr, 
        List<TaxRecord> records, 
        DateTime ikræftTrædelsesDato, 
        IPIndholdsType ipIndholdsType): base(lbnr, records)
    {
        Records.Add(new Record2111
        {
            ikræftrædelsesDato = ikræftTrædelsesDato,
            indholdstype = ipIndholdsType.Kode,
            medarbejderKode = ipIndholdsType.Indhold,
            Lb_nr = Lb_nr++,
            Rec_nr = 2111
        });
    }
    

    public TaxFile2111Builder AddRecord2111(DateTime ikræftTrædelsesDato, IPIndholdsType ipIndholdsType)
    {
         Records.Add(new Record2111
         {
             ikræftrædelsesDato = ikræftTrædelsesDato,
             indholdstype = ipIndholdsType.Kode,
             medarbejderKode = ipIndholdsType.Indhold,
             Lb_nr = Lb_nr++,
             Rec_nr = 2111
         });
         return this;
    }
}