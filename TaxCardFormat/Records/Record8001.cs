using FileHelpers;
using TaxCardFormat.DataTypes.IPIndholdstype;
using TaxCardFormat.Enums;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record8001<TPrevious> : TaxRecord, IRecord8001<TPrevious>
{
    [FieldHidden] private TPrevious? _previous;
    public Record8001():this(default) {}
    
    public Record8001(TPrevious? previousRecord)
    {
        _previous = previousRecord;
    }
    
    [FieldFixedLength(8)]
    [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
    public required DateTime PersonFoedselsdato;

    [FieldFixedLength(1)]
    public required int PersonKoen;

    [FieldFixedLength(2)]
    public required string PersonLand;

    [FieldFixedLength(40)]
    [FieldAlign(AlignMode.Right, ' ')]
    public required string PersonNavn;

    [FieldFixedLength(40)]
    [FieldAlign(AlignMode.Right, ' ')]
    public required string PersonGadeAdresse;

    [FieldFixedLength(9)]
    [FieldAlign(AlignMode.Left, ' ')]
    public required string PersonPostnummer;

    [FieldFixedLength(35)]
    [FieldAlign(AlignMode.Right, ' ')]
    public required string PersonPostby;

    public TPrevious GoBack() => _previous ?? throw new NullReferenceException("Previous record is null remember to set the previous record in the constructor");
    
    public IRecord2111<TPrevious> AddRecord2111(IPIndholdsType ipIndholdsType, DateTime? ikraeftTraedelsesDato = null)
    {
        var child = new Record2111<TPrevious>(_previous)
        {
            Lb_nr = Lb_nr++,
            Rec_nr = 2111,
            ikraeftraedelsesDato = ikraeftTraedelsesDato,
            indholdstype = ipIndholdsType.Type,
            medarbejderKode = ipIndholdsType.Indhold,
        };
        Children.Add(child);
        return child;
    }
}
