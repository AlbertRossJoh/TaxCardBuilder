using TaxCardFormat.DataTypes;
using TaxCardFormat.Enums;
using TaxCardFormat.Records;

namespace TaxCardFormat.RecordInterfaces;

public interface IRecord2111<TPrevious>
{
    public TPrevious? GoBack();

    public IRecord3101<IRecord2111<TPrevious>> AddRecord3101(
        decimal beloeb,
        bool forudBetalt,
        DateTime periodeIndberetStart,
        DateTime periodeIndberetSlut,
        FeltNummer feltNummer,
        ShortId indberetningsId = default,
        ShortId? referenceId = null
    );

    public Record4101<IRecord2111<TPrevious>> AddRecord4101(
        bool tilbagefoersel,
        ShortId indberetningId = default,
        ShortId? referenceId = null,
        string? cpr = null
    );

    public Record5000<IRecord2111<TPrevious>> AddRecord5000(
        bool rettelser_tidl_periode,
        DateTime loenperiodeStart,
        DateTime loenPeriodeSlut,
        bool erLoenBagudBetalt,
        IndkomstType indkomstType,
        ShortId indberetningId = default,
        ShortId referenceId = default,
        GroenlandKommune? groenlandKommune = null
    );
}
