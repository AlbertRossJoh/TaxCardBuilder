using FileHelpers;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record9999 : TaxRecord
{
    [FieldFixedLength(7)]
    [FieldAlign(AlignMode.Right, '0')]
    public required int AntalRecords;
}
