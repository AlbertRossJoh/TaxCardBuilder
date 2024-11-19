using FileHelpers;
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
}
