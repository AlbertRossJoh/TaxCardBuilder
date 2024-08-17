using FileHelpers;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record8001 : TaxRecord
{
    [FieldFixedLength(8)]
    [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
    public required DateTime FratrædelsesDato;

    [FieldFixedLength(1)]
    public required int PersonKøn;

    [FieldFixedLength(2)]
    public required string PersonLand;

    [FieldFixedLength(40)]
    public required string PersonNavn;

    [FieldFixedLength(40)]
    public required string PersonGadeAdresse;

    [FieldFixedLength(9)]
    public required string PersonPostnummer;

    [FieldFixedLength(35)]
    public required string PersonPostby;
}
