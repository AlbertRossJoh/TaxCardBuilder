using TaxCardFormat.Enums;
using TaxCardFormat.Records;

namespace TaxCardFormat.Builders;

public class Record2101BuilderBase(int lbnr, List<TaxRecord> records)
    : TaxFileBuilderBase(lbnr, records)
{
    protected void AddRecord2101_internal(
        DateTime AnsættelsesDato,
        string cpr,
        SkattekortType skattekortType,
        DateTime? fratrædelsesDato = null,
        bool genrevivering = false
    )
    {
        if (cpr.Length != 10)
            throw new ArgumentException("The CPR number should be 10 characters in length");
        Records.Add(
            new Record2101
            {
                Lb_nr = Lb_nr++,
                Rec_nr = 2101,
                AnsættelsesDato = AnsættelsesDato,
                FratrædelsesDato = fratrædelsesDato,
                GenRekvivering = genrevivering ? 'R' : ' ',
                personCpr = cpr,
                SkattekortType = (int)skattekortType,
            }
        );
    }

    public TaxFile2101Builder AddRecord2101(
        string cpr,
        DateTime AnsættelsesDato,
        SkattekortType skattekortType,
        DateTime? fratrædelsesDato = null,
        bool genrevivering = false
    )
    {
        return new TaxFile2101Builder(
            Lb_nr,
            Records,
            AnsættelsesDato,
            cpr,
            skattekortType,
            fratrædelsesDato,
            genrevivering
        );
    }
}

