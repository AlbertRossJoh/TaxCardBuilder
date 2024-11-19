using FileHelpers;
using TaxCardFormat.CustomConverters;
using TaxCardFormat.DataTypes;
using TaxCardFormat.RecordInterfaces;
using TaxCardFormat.RecordInterfaces.IRecord;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record1000 : TaxRecord, IRecord1000
{
    [FieldFixedLength(8)]
    [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
    [FieldAlign(AlignMode.Right, ' ')]
    public DateTime? Dato_sendt;

    [FieldFixedLength(6)]
    [FieldConverter(ConverterKind.Date, "HHmmss")]
    [FieldAlign(AlignMode.Right, ' ')]
    public DateTime? Klok_sendt;

    [FieldFixedLength(8)]
    public required string Indberetter_SE_nummer;

    [FieldFixedLength(8)]
    [FieldAlign(AlignMode.Right, '0')]
    public required string Indberetter_CVR_nummer;

    [FieldFixedLength(2)]
    [FieldAlign(AlignMode.Right, '0')]
    public required int IndberetterType;

    [FieldFixedLength(5)]
    public string filler1 = "";

    [FieldFixedLength(1)]
    public int indberetningmetode_navn = 0;

    [FieldFixedLength(20)]
    [FieldAlign(AlignMode.Right, ' ')]
    public string? Edb_System;

    [FieldFixedLength(20)]
    [FieldAlign(AlignMode.Right, ' ')]
    public string? Edb_System_Version;

    [FieldFixedLength(16)]
    [FieldConverter(typeof(ShortIdConverter))]
    public ShortId HovedindberetingsID;

    [FieldFixedLength(3)]
    public string eIndkomst_version = "2.0";

    [FieldFixedLength(1)]
    public required char IsTest;

    [FieldFixedLength(32)]
    public string filler2 = "";

    [FieldFixedLength(1)]
    public required char EIndkomst_Letloen;
    
    public IRecord2001<IRecord1000> AddRecord2001(
        string virksomhedSE,
        bool ophoerHosLSB,
        string valutakode = "DKK"
    )
    {
        var child = new Record2001<IRecord1000>(this)
        {
            Lb_nr = Lb_nr++,
            Rec_nr = 2001,
            Valutakode = valutakode,
            Virksomhed_SE_nummer = virksomhedSE,
            Virksomhed_Ophoer_Hos_LSB = ophoerHosLSB ? 'A' : ' '
        };
        Children.Add(child);
        return child;
    }
}
