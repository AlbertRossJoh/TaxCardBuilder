using System.Runtime.CompilerServices;
using FileHelpers;
using TaxCardFormat.CustomConverters;

namespace TaxCardFormat.Records;
[FixedLengthRecord]
public class Record5000: TaxRecord
{

    [FieldFixedLength(1)] public char Rettelse_tidl_periode = ' ';

    [FieldFixedLength(16)] [FieldConverter(typeof(GuidConverter))]
    public Guid IndberetningsID;
    
    [FieldFixedLength(16)] [FieldConverter(typeof(GuidConverter))]
    public Guid ReferenceId;
    
    [FieldFixedLength(8)]
    [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
    public DateTime LønperiodeStart;

    [FieldFixedLength(8)]
    [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
    [FieldAlign(AlignMode.Right, ' ')]
    public DateTime LønperiodeSlut;
    
    [FieldFixedLength(8)]
    [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
    [FieldAlign(AlignMode.Right, ' ')]
    public DateTime? DispensationsDato;
    
    [FieldFixedLength(1)] private char filler1 = ' ';
    
    [FieldFixedLength(1)] public char ForudElBagud = ' ';


    [FieldFixedLength(3)] [FieldAlign(AlignMode.Right, '0')]
    public int? GrønlandskKommune;
    
    [FieldFixedLength(2)]
    [FieldAlign(AlignMode.Right, '0')]
    public int? Indkomsttype;
}
