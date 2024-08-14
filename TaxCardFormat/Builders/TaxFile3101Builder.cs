using TaxCardFormat.Enums;
using TaxCardFormat.Records;

namespace TaxCardFormat.Builders;

public class TaxFile3101Builder: Record2101BuilderBase
{
    public TaxFile3101Builder(
        int lbnr, 
        List<TaxRecord> records, 
        decimal amount,
        bool forudBetalt,
        DateTime periodeIndberetStart,
        DateTime periodeIndberetSlut,
        FeltNummer feltNummer,
        bool nulangivelse,
        Guid indberetningsId = new(),
        Guid? referenceId = null) : base(lbnr, records)
    {
        switch (nulangivelse)
        {
            case true when amount != 0:
                throw new ArgumentException("You cannot have an amount when doing a zero report");
            case true when feltNummer != FeltNummer.NulAngivelse:
                throw new ArgumentException("You cannot have nulangivelse marked as true but the field number as anything else but nulangivelse");
        }

        var decimals =(int)(amount - Math.Truncate(amount))*1_000_000;
        var amnt = (int)amount;
        Records.Add(new Record3101
        {
            Lb_nr = Lb_nr++,
            Rec_nr = 3101,
            indberetningsId = indberetningsId,
            referenceId = referenceId,
            Amount = amnt,
            Decimals = decimals,
            Sign = amount >= 0 ? '+' : '-',
            ForudElBagud = forudBetalt
                ? 'F'
                : 'B',
            PeriodeIndberetStart = periodeIndberetStart,
            PeriodeIndberetSlut = periodeIndberetSlut,
            FeltNummer = (int)feltNummer,
            Nulangivelse = nulangivelse
                ? 'N'
                : ' ',

        });
    }
}