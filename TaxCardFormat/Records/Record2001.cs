using FileHelpers;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record2001 : TaxRecord
{
    [FieldFixedLength(16)]
    private string filler1 = "";

    [FieldFixedLength(8)]
    public required string Virksomhed_SE_nummer;

    [FieldFixedLength(1)]
    public required char Virksomhed_Ophør_Hos_LSB;

    [FieldFixedLength(3)]
    public required string Valutakode;
}

