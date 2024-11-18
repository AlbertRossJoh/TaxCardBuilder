using FileHelpers;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record6000 : TaxRecord
{
    [FieldFixedLength(12)]
    public string filler1 = "";

    [FieldFixedLength(10)]
    public string? CPR;

    [FieldFixedLength(8)]
    public string? CVR_SE;

    [FieldFixedLength(15)]
    [FieldAlign(AlignMode.Right, ' ')]
    public string? MedarbejderNr;

    [FieldFixedLength(27)]
    [FieldAlign(AlignMode.Right, ' ')]
    public string? TIN;

    [FieldFixedLength(2)]
    public string? TIN_landekode;

    [FieldFixedLength(4)]
    [FieldAlign(AlignMode.Right, '0')]
    public required int Indtaegtsart;

    [FieldFixedLength(10)]
    [FieldAlign(AlignMode.Right, ' ')]
    public string? ProduktionEndhedsNummer;
}
