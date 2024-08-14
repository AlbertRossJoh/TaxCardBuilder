using FileHelpers;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record6000: TaxRecord
{
    [FieldFixedLength(12)] private string filler1 = "";

    [FieldFixedLength(10)] public string? CPR;
    
    [FieldFixedLength(8)] public string? CVR_SE;
    
    [FieldFixedLength(15)] public string? MedarbejderNr;
    
    [FieldFixedLength(27)] public string? TIN;

    [FieldFixedLength(2)] public string? TIN_landekode;

    [FieldFixedLength(4)] public int Indtægtsart;

    [FieldFixedLength(10)] public string? ProduktionEndhedsNummer;
}
