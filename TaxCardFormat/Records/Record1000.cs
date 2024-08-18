using FileHelpers;
using TaxCardFormat.CustomConverters;
using TaxCardFormat.DataTypes;

namespace TaxCardFormat.Records;

[FixedLengthRecord]
public class Record1000 : TaxRecord
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
    private string filler1 = "";

    [FieldFixedLength(1)]
    private int indberetningmetode_navn = 0;

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
    private string eIndkomst_version = "2.0";

    [FieldFixedLength(1)]
    public required char IsTest;

    [FieldFixedLength(32)]
    private string filler2 = "";

    [FieldFixedLength(1)]
    public required char EIndkomst_Letløn;
}

