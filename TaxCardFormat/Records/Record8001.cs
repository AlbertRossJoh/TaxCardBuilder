using FileHelpers;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record8001 : TaxRecord
{
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
