using FileHelpers;
using TaxCardFormat.CustomConverters;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record4101: TaxRecord
{
    [FieldFixedLength(16)] [FieldConverter(typeof(GuidConverter))]
    public required Guid indberetningsId;
    
    [FieldFixedLength(16)] [FieldConverter(typeof(GuidConverter))]
    public Guid? referenceId;
    
    [FieldFixedLength(1)] private string filler1 = "";
    
    [FieldFixedLength(1)] 
    public required char Tilbageførsel;
    
    [FieldFixedLength(10)]
    public string? cpr;
}