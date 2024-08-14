using TaxCardFormat.Enums;
using TaxCardFormat.Records;

namespace TaxCardFormat.Builders;

public class Record6001Builder: TaxFileBuilderBase
{
    public Record6001Builder(int lbnr, List<TaxRecord> records, decimal beløb, IndkomstFelt600X indkomstFelt600X) : base(lbnr, records)
    {
        var decimals =(int)(beløb - Math.Truncate(beløb))*1_000_000;
        var amnt = (int)beløb;
        Records.Add(new Record6001
        {
            Lb_nr = Lb_nr++,
            Rec_nr = 6001,
            Beløb = amnt,
            BeløbDecimal = decimals,
            FeltNummer = (int) indkomstFelt600X,
            Fortegn = beløb >= 0 ? '+' : '-'
        });
    }
}
