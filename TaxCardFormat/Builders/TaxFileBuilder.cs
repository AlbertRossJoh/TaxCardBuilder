using FileHelpers;
using TaxCardFormat.DataTypes;
using TaxCardFormat.DataTypes.IPIndholdstype;
using TaxCardFormat.Enums;
using TaxCardFormat.IPIndholdstype;
using TaxCardFormat.Records;

namespace TaxCardFormat.Builders;

public class TaxFileBuilder
{
    private int Lb_nr = 1;
    private List<TaxRecord> Records = [];
    private MultiRecordEngine Engine = new MultiRecordEngine(
        typeof(TaxRecord),
        typeof(Record1000),
        typeof(Record2001),
        typeof(Record2101),
        typeof(Record2111),
        typeof(Record3101),
        typeof(Record4101),
        typeof(Record5000),
        typeof(Record6000),
        typeof(Record6001),
        typeof(Record6002),
        typeof(Record6003),
        typeof(Record6004),
        typeof(Record6005),
        typeof(Record6102),
        typeof(Record6202),
        typeof(Record6111),
        typeof(Record8001),
        typeof(Record9999)
    );

    public void AddRecord1000(
        string indberetterSeNummer,
        bool isTest,
        SystemUsage systemUsage,
        IndberetterType indberetterType,
        string? cvrNummer = null,
        DateTime? datoSendt = null,
        DateTime? klokSendt = null,
        string? edbSystem = null,
        ShortId hovedIndberetningsId = default
    )
    {
        Records.Add(
            new Record1000
            {
                Lb_nr = Lb_nr++,
                Rec_nr = 1000,
                Dato_sendt = datoSendt,
                Klok_sendt = klokSendt,
                Indberetter_SE_nummer = indberetterSeNummer,
                Indberetter_CVR_nummer = cvrNummer ?? "",
                IndberetterType = (int)indberetterType,
                Edb_System = edbSystem,
                HovedindberetingsID = hovedIndberetningsId,
                IsTest = isTest ? 'T' : 'P',
                EIndkomst_Letløn = GetSystem(systemUsage)
            }
        );
    }

    private static char GetSystem(SystemUsage systemUsage) =>
        systemUsage switch
        {
            SystemUsage.Eindkomst => 'E',
            SystemUsage.LetLøn => 'L',
            _
                => throw new ArgumentOutOfRangeException(
                    nameof(systemUsage),
                    systemUsage,
                    "Not a valid system"
                )
        };

    public void AddRecord2001(
        string virksomhedSE,
        bool ophørHosLSB,
        string valutakode = "DKK"
    )
    {
        Records.Add(
            new Record2001
            {
                Lb_nr = Lb_nr++,
                Rec_nr = 2001,
                Valutakode = valutakode,
                Virksomhed_SE_nummer = virksomhedSE,
                Virksomhed_Ophør_Hos_LSB = ophørHosLSB ? 'A' : ' '
            }
        );
    }

    public void AddRecord2101(
        DateTime AnsættelsesDato,
        string cpr,
        SkattekortType skattekortType,
        DateTime skaAndvendeFra,
        DateTime? fratrædelsesDato = null,
        bool genrevivering = false,
        string? medarbejderNr = null
    )
    {
        if (cpr.Length != 10)
            throw new ArgumentException("The CPR number should be 10 characters in length");
        Records.Add(
            new Record2101
            {
                Lb_nr = Lb_nr++,
                Rec_nr = 2101,
                medarbejderNrLetløn = medarbejderNr,
                SkaAnvendeFra = skaAndvendeFra,
                AnsættelsesDato = AnsættelsesDato,
                FratrædelsesDato = fratrædelsesDato,
                GenRekvivering = genrevivering ? 'R' : ' ',
                PersonCpr = cpr,
                SkattekortType = (int)skattekortType,
            }
        );
    }

    public void AddRecord2111(DateTime ikræftTrædelsesDato, IPIndholdsType ipIndholdsType)
    {
        Records.Add(
            new Record2111
            {
                Lb_nr = Lb_nr++,
                Rec_nr = 2111,
                ikræftrædelsesDato = ikræftTrædelsesDato,
                indholdstype = ipIndholdsType.Kode,
                medarbejderKode = ipIndholdsType.Indhold,
            }
        );
    }

    public void AddRecord3101(
        decimal beløb,
        bool forudBetalt,
        DateTime periodeIndberetStart,
        DateTime periodeIndberetSlut,
        FeltNummer feltNummer,
        ShortId indberetningsId = default,
        ShortId? referenceId = null
    )
    {
        switch (feltNummer)
        {
            case FeltNummer.NulAngivelse when beløb != 0:
                throw new ArgumentException(
                    "Man kan ikke angive nulangivelse for et beløb forskelligt fra 0."
                );
        }
        var absBeløb = Math.Abs(beløb);
        var decimals = (int)(absBeløb - Math.Truncate(absBeløb)) * 1_000_000;
        var amnt = (int)absBeløb;

        Records.Add(
            new Record3101
            {
                Lb_nr = Lb_nr++,
                Rec_nr = 3101,
                indberetningsId = indberetningsId,
                referenceId = referenceId,
                Amount = amnt,
                Decimals = decimals,
                Sign = beløb >= 0 ? '+' : '-',
                ForudElBagud = forudBetalt ? 'F' : 'B',
                PeriodeIndberetStart = periodeIndberetStart,
                PeriodeIndberetSlut = periodeIndberetSlut,
                FeltNummer = (int)feltNummer,
                Nulangivelse = feltNummer == FeltNummer.NulAngivelse ? 'N' : ' ',
            }
        );
    }

    public void AddRecord4101(
        bool tilbageførsel,
        ShortId indberetningId = default,
        ShortId? referenceId = null,
        string? cpr = null
    )
    {
        if (tilbageførsel && cpr == null)
            throw new ArgumentException("Man kan ikke angive en tilbageførsel uden cprnummer");

        Records.Add(
            new Record4101
            {
                Tilbageførsel = tilbageførsel ? 'J' : 'N',
                indberetningsId = indberetningId,
                referenceId = referenceId,
                cpr = cpr,
                Lb_nr = Lb_nr++,
                Rec_nr = 4101
            }
        );
    }

    public void AddRecord5000(
        bool rettelser_tidl_periode,
        DateTime lønperiodeStart,
        DateTime lønPeriodeSlut,
        bool erLønBagudBetalt,
        IndkomstType indkomstType,
        ShortId indberetningId = default,
        ShortId referenceId = default,
        GrønlandKommune? grønlandKommune = null
    )
    {
        Records.Add(
            new Record5000
            {
                Rettelse_tidl_periode = rettelser_tidl_periode ? 'R' : ' ',
                IndberetningsID = indberetningId,
                ReferenceId = referenceId,
                LønperiodeStart = lønperiodeStart,
                LønperiodeSlut = lønPeriodeSlut,
                ForudElBagud = erLønBagudBetalt ? 'B' : 'F',
                GrønlandskKommune = (int?)grønlandKommune,
                Indkomsttype = (int)indkomstType,
                Lb_nr = Lb_nr++,
                Rec_nr = 5000
            }
        );
    }

    public void AddRecord6000(
        string cpr,
        string cvr_se,
        string medarbejderNr,
        string tin,
        Landekoder tin_landekode,
        IndkomstArt indkomstArt,
        string? produktionEnhedsnummer = null
    )
    {
        Records.Add(
            new Record6000
            {
                CPR = cpr,
                CVR_SE = cvr_se,
                MedarbejderNr = medarbejderNr,
                TIN = tin,
                TIN_landekode = tin_landekode.ToString("G"),
                Indtægtsart = (int)indkomstArt,
                ProduktionEndhedsNummer = produktionEnhedsnummer,
                Lb_nr = Lb_nr++,
                Rec_nr = 6000,
            }
        );
    }

    public void AddRecord6001(decimal beløb, FeltNummer feltNummer)
    {
        var absBeløb = Math.Abs(beløb);
        var decimals = (int)(absBeløb - Math.Truncate(absBeløb)) * 1_000_000;
        var amnt = (int)absBeløb;

        Records.Add(
            new Record6001
            {
                Lb_nr = Lb_nr++,
                Rec_nr = 6001,
                Beløb = amnt,
                BeløbDecimal = decimals,
                FeltNummer = (int)feltNummer,
                Fortegn = beløb > 0 ? '+' : '-'
            }
        );
    }

    public void AddRecord6002(IndkomstFelt6002 indkomstFelt, string kodeFelt)
    {
        Records.Add(
            new Record6002
            {
                Lb_nr = Lb_nr++,
                Rec_nr = 6002,
                FeltNummer = (int)indkomstFelt,
                KodeFelt = kodeFelt,
            }
        );
    }

    public void AddRecord6003(IndkomstFelt600X indkomstFelt)
    {
        Records.Add(
            new Record6003
            {
                Lb_nr = Lb_nr++,
                Rec_nr = 6003,
                FeltNummer = (int)indkomstFelt,
                Krydsfelt = 'X',
            }
        );
    }

    public void AddRecord6004(IndkomstFelt600X indkomstFelt, string fritekstFelt)
    {
        if (fritekstFelt.Length > 58)
            throw new ArgumentException("Fritekstfeltet må maks være 58 bogstaver langt");
        Records.Add(
            new Record6004
            {
                Lb_nr = Lb_nr++,
                Rec_nr = 6004,
                FeltNummer = (int)indkomstFelt,
                Fritekstfelt = fritekstFelt
            }
        );
    }

    public void AddRecord6005(IndkomstFelt600X indkomstFelt, int antal)
    {
        Records.Add(
            new Record6005
            {
                Lb_nr = Lb_nr++,
                Rec_nr = 6005,
                FeltNummer = (int)indkomstFelt,
                Antal = Math.Abs(antal),
                Fortegn = antal > 0 ? '+' : '-'
            }
        );
    }

    public void AddRecord6102(
        decimal beløb,
        decimal feriedage,
        int ferieår,
        DateTime fratrædelsesDato
    )
    {
        var absBeløb = Math.Abs(beløb);
        var decimals = (int)(absBeløb - Math.Truncate(absBeløb)) * 1_000_000;
        var amnt = (int)absBeløb;

        var absFeriedage = Math.Abs(feriedage);
        var decimalsFeriedage = (int)(absFeriedage - Math.Truncate(absFeriedage)) * 1_000_000;
        var amntFeriedage = (int)absFeriedage;

        Records.Add(
            new Record6102
            {
                Lb_nr = Lb_nr++,
                Rec_nr = 6102,
                Beløb = amnt,
                BeløbDecimal = decimals,
                FortegnFeriepenge = Fortegn(beløb),
                FeriedageHeltal = amntFeriedage,
                FeriedageDecimal = decimalsFeriedage,
                FortegnFeiedage = Fortegn(feriedage),
                Ferieår = ferieår,
                FratrædelsesDato = fratrædelsesDato
            }
        );
    }

    public void AddRecord6202(
        decimal beløb,
        decimal feriedage,
        int ferieår,
        DateTime fratrædelsesDato
    )
    {
        var absBeløb = Math.Abs(beløb);
        var decimals = (int)(absBeløb - Math.Truncate(absBeløb)) * 1_000_000;
        var amnt = (int)absBeløb;

        var absFeriedage = Math.Abs(feriedage);
        var decimalsFeriedage = (int)(absFeriedage - Math.Truncate(absFeriedage)) * 1_000_000;
        var amntFeriedage = (int)absFeriedage;

        Records.Add(
            new Record6202
            {
                Lb_nr = Lb_nr++,
                Rec_nr = 6202,
                Beløb = amnt,
                BeløbDecimal = decimals,
                FortegnFeriepenge = Fortegn(beløb),
                FeriedageHeltal = amntFeriedage,
                FeriedageDecimal = decimalsFeriedage,
                FortegnFeiedage = Fortegn(feriedage),
                Ferieår = ferieår,
                FratrædelsesDato = fratrædelsesDato
            }
        );
    }

    public void AddRecord6111(IPIndholdsType indholdsType, int antalEnheder, decimal beløb)
    {
        var absBeløb = Math.Abs(beløb);
        var decimals = (int)(absBeløb - Math.Truncate(absBeløb)) * 1_000_000;
        var amnt = (int)absBeløb;

        Records.Add(
            new Record6111
            {
                Lb_nr = Lb_nr++,
                Rec_nr = 6111,
                IndholdsType = indholdsType.Kode,
                AntalEnheder = antalEnheder,
                FortegnAntalEnheder = Fortegn(antalEnheder),
                Beløb = amnt,
                BeløbDecimal = decimals,
                FortegnBeløb = Fortegn(beløb)
            }
        );
    }

    public void AddRecord8001(
        DateTime fødselsdato,
        Køn køn,
        Landekoder landekoder,
        string navn,
        string adresse,
        string postnummer,
        string postby
    )
    {
        Records.Add(
            new Record8001
            {
                Lb_nr = Lb_nr++,
                Rec_nr = 8001,
                PersonFødselsdato = fødselsdato,
                PersonKøn = (int)køn,
                PersonLand = landekoder.ToString("G"),
                PersonNavn = navn,
                PersonGadeAdresse = adresse,
                PersonPostnummer = postnummer,
                PersonPostby = postby,
            }
        );
    }

    public void AddRecord9999()
    {
        Records.Add(
            new Record9999
            {
                Lb_nr = Lb_nr++,
                Rec_nr = 9999,
                AntalRecords = Lb_nr,
            }
        );
    }

    private char Fortegn(decimal antal) => antal > 0 ? '+' : '-';

    private char Fortegn(int antal) => antal > 0 ? '+' : '-';

    public void Build(StreamWriter writer) => Engine.WriteStream(writer, Records);

    public Stream Build()
    {
        var ms = new MemoryStream();
        var sw = new StreamWriter(ms);
        Engine.WriteStream(sw, Records);
        sw.Flush();
        ms.Position = 0;
        return ms;
    }

    public string BuildString()
    {
        return Engine.WriteString(Records);
    }
    
    public void Build(Stream stream)
    {
        using var sw = new StreamWriter(stream);
        Engine.WriteStream(sw, Records);
    }

    public void Build(string filePath)
    {
        using var tw = File.CreateText(filePath);
        Engine.WriteStream(tw, Records);
    }
}
