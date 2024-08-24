using FileHelpers;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record6102 : TaxRecord
{
    [FieldFixedLength(10)]
    [FieldAlign(AlignMode.Right, '0')]
    public required int Beløb;

    [FieldFixedLength(6)]
    [FieldAlign(AlignMode.Left, '0')]
    public required int BeløbDecimal;

    [FieldFixedLength(1)]
    public required char FortegnFeriepenge;

    [FieldFixedLength(2)]
    [FieldAlign(AlignMode.Right, '0')]
    public required int FeriedageHeltal;

    [FieldFixedLength(2)]
    [FieldAlign(AlignMode.Left, '0')]
    public required int FeriedageDecimal;

    [FieldFixedLength(1)]
    public required char FortegnFeiedage;

    [FieldFixedLength(4)]
    public required int Ferieår;

    [FieldFixedLength(8)]
    [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
    [FieldAlign(AlignMode.Right, ' ')]
    public required DateTime FratrædelsesDato;
}
