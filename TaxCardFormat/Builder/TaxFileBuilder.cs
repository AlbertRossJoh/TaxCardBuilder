using FileHelpers;
using TaxCardFormat.DataTypes;
using TaxCardFormat.DataTypes.IPIndholdstype;
using TaxCardFormat.Enums;
using TaxCardFormat.Records;

namespace TaxCardFormat.Builder;

/// <summary>
/// TaxFileBuilder is a wrapper class for building tax cards for reporting to the Danish tax ministry.
/// <br/>
/// There is not any documentation on each individual method, as the documentation can be found here: https://info.skat.dk/data.aspx?oid=1745538
/// </summary>
public class TaxFileBuilder
{
    private int Lb_nr = 1;
    public List<TaxRecord> Records { get; set; }= [];
    private MultiRecordEngine Engine = new(
        typeof(TaxRecord),
        typeof(Record1000),
        typeof(Record2001<object>),
        typeof(Record2101<object>),
        typeof(Record2111<object>),
        typeof(Record3101<object>),
        typeof(Record4101<object>),
        typeof(Record5000<object>),
        typeof(Record6000<object>),
        typeof(Record6001<object>),
        typeof(Record6002<object>),
        typeof(Record6003<object>),
        typeof(Record6004),
        typeof(Record6005),
        typeof(Record6102),
        typeof(Record6202),
        typeof(Record6111),
        typeof(Record8001<object>),
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
                EIndkomst_Letloen = GetSystem(systemUsage)
            }
        );
    }

    private static char GetSystem(SystemUsage systemUsage) =>
        systemUsage switch
        {
            SystemUsage.Eindkomst => 'E',
            SystemUsage.LetLoen => 'L',
            _
                => throw new ArgumentOutOfRangeException(
                    nameof(systemUsage),
                    systemUsage,
                    "Not a valid system"
                )
        };

    public void AddRecord2001(
        string virksomhedSE,
        bool ophoerHosLSB,
        string valutakode = "DKK"
    )
    {
        Records.Add(
            new Record2001<object>
            {
                Lb_nr = Lb_nr++,
                Rec_nr = 2001,
                Valutakode = valutakode,
                Virksomhed_SE_nummer = virksomhedSE,
                Virksomhed_Ophoer_Hos_LSB = ophoerHosLSB ? 'A' : ' '
            }
        );
    }

    public void AddRecord2101(
        DateTime AnsaettelsesDato,
        string cpr,
        SkattekortType skattekortType,
        DateTime skaAndvendeFra,
        DateTime? fratraedelsesDato = null,
        bool genrevivering = false,
        string? medarbejderNr = null
    )
    {
        if (cpr.Length != 10)
            throw new ArgumentException("The CPR number should be 10 characters in length");
        Records.Add(
            new Record2101<object>
            {
                Lb_nr = Lb_nr++,
                Rec_nr = 2101,
                medarbejderNrLetloen = medarbejderNr,
                SkaAnvendeFra = skaAndvendeFra,
                AnsaettelsesDato = AnsaettelsesDato,
                FratraedelsesDato = fratraedelsesDato,
                GenRekvivering = genrevivering ? 'R' : ' ',
                PersonCpr = cpr,
                SkattekortType = (int)skattekortType,
            }
        );
    }

    public void AddRecord2111(IPIndholdsType ipIndholdsType, DateTime? ikraeftTraedelsesDato = null)
    {
        Records.Add(
            new Record2111<object>
            {
                Lb_nr = Lb_nr++,
                Rec_nr = 2111,
                ikraeftraedelsesDato = ikraeftTraedelsesDato,
                indholdstype = ipIndholdsType.Kode,
                medarbejderKode = ipIndholdsType.Indhold,
            }
        );
    }

    public void AddRecord3101(
        decimal beloeb,
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
            case FeltNummer.NulAngivelse when beloeb != 0:
                throw new ArgumentException(
                    "Man kan ikke angive nulangivelse for et beloeb forskelligt fra 0."
                );
        }
        var (amnt, decimals) = ExtractDecimalParts(beloeb);
        Records.Add(
            new Record3101<object>
            {
                Lb_nr = Lb_nr++,
                Rec_nr = 3101,
                indberetningsId = indberetningsId,
                referenceId = referenceId,
                Amount = amnt,
                Decimals = decimals,
                Sign = beloeb >= 0 ? '+' : '-',
                ForudElBagud = forudBetalt ? 'F' : 'B',
                PeriodeIndberetStart = periodeIndberetStart,
                PeriodeIndberetSlut = periodeIndberetSlut,
                FeltNummer = (int)feltNummer,
                Nulangivelse = feltNummer == FeltNummer.NulAngivelse ? 'N' : ' ',
            }
        );
    }

    public void AddRecord4101(
        bool tilbagefoerselSe,
        ShortId indberetningId = default,
        ShortId? referenceId = null,
        string? cpr = null
    )
    {
        if (tilbagefoerselSe && cpr == null)
            throw new ArgumentException("Man kan ikke angive en tilbagefoersel uden cprnummer");

        Records.Add(
            new Record4101<object>
            {
                Tilbagefoersel = tilbagefoerselSe ? 'J' : 'N',
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
        DateTime loenperiodeStart,
        DateTime loenPeriodeSlut,
        bool erLoenBagudBetalt,
        IndkomstType indkomstType,
        ShortId indberetningId = default,
        ShortId referenceId = default,
        GroenlandKommune? groenlandKommune = null
    )
    {
        Records.Add(
            new Record5000<object>
            {
                Rettelse_tidl_periode = rettelser_tidl_periode ? 'R' : ' ',
                IndberetningsID = indberetningId,
                ReferenceId = referenceId,
                LoenperiodeStart = loenperiodeStart,
                LoenperiodeSlut = loenPeriodeSlut,
                ForudElBagud = erLoenBagudBetalt ? 'B' : 'F',
                GroenlandskKommune = (int?)groenlandKommune,
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
        if (cpr.Length != 10)
            throw new ArgumentException("Cpr length must be 10");
        if (cvr_se.Length != 8)
            throw new ArgumentException("Cvr se length must be 8");
        Records.Add(
            new Record6000<object>
            {
                CPR = cpr,
                CVR_SE = cvr_se,
                MedarbejderNr = medarbejderNr,
                TIN = tin,
                TIN_landekode = tin_landekode.ToString("G"),
                Indtaegtsart = (int)indkomstArt,
                ProduktionEndhedsNummer = produktionEnhedsnummer,
                Lb_nr = Lb_nr++,
                Rec_nr = 6000,
            }
        );
    }

    public void AddRecord6001(decimal beloeb, FeltNummer feltNummer)
    {
        var (amnt, decimals) = ExtractDecimalParts(beloeb);
        Records.Add(
            new Record6001<object>
            {
                Lb_nr = Lb_nr++,
                Rec_nr = 6001,
                Beloeb = amnt,
                BeloebDecimal = decimals,
                FeltNummer = (int)feltNummer,
                Fortegn = beloeb > 0 ? '+' : '-'
            }
        );
    }

    public void AddRecord6002(IndkomstFelt6002 indkomstFelt, string kodeFelt)
    {
        Records.Add(
            new Record6002<object>
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
            new Record6003<object>
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
            throw new ArgumentException("Fritekstfeltet maa maks vaere 58 bogstaver langt");
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

    public void AddRecord6005(AntalsFelt6005 antalsFelt6005, decimal antal)
    {
        var (amnt, decimals) = ExtractDecimalParts(antal);
        Records.Add(
            new Record6005
            {
                Lb_nr = Lb_nr++,
                Rec_nr = 6005,
                FeltNummer = (int)antalsFelt6005,
                Antal = amnt,
                AntalDecimal = decimals,
                Fortegn = antal > 0 ? '+' : '-'
            }
        );
    }

    public void AddRecord6102(
        decimal beloeb,
        decimal feriedage,
        int ferieaar,
        DateTime fratraedelsesDato
    )
    {
        var (amnt, decimals) = ExtractDecimalParts(beloeb);
        var (amntFeriedage, decimalsFeriedage) = ExtractDecimalParts(feriedage);
        
        Records.Add(
            new Record6102
            {
                Lb_nr = Lb_nr++,
                Rec_nr = 6102,
                Beloeb = amnt,
                BeloebDecimal = decimals,
                FortegnFeriepenge = Fortegn(beloeb),
                FeriedageHeltal = amntFeriedage,
                FeriedageDecimal = decimalsFeriedage,
                FortegnFeiedage = Fortegn(feriedage),
                Ferieaar = ferieaar,
                FratraedelsesDato = fratraedelsesDato
            }
        );
    }

    public void AddRecord6202(
        decimal beloeb,
        decimal feriedage,
        int ferieaar,
        DateTime fratraedelsesDato
    )
    {
        var (amnt, decimals) = ExtractDecimalParts(beloeb);
        var (amntFeriedage, decimalsFeriedage) = ExtractDecimalParts(feriedage);

        Records.Add(
            new Record6202
            {
                Lb_nr = Lb_nr++,
                Rec_nr = 6202,
                Beloeb = amnt,
                BeloebDecimal = decimals,
                FortegnFeriepenge = Fortegn(beloeb),
                FeriedageHeltal = amntFeriedage,
                FeriedageDecimal = decimalsFeriedage,
                FortegnFeiedage = Fortegn(feriedage),
                Ferieaar = ferieaar,
                FratraedelsesDato = fratraedelsesDato
            }
        );
    }

    public void AddRecord6111(IPIndholdsType indholdsType, int antalEnheder, decimal beloeb)
    {
        var (amnt, decimals) = ExtractDecimalParts(beloeb);
        Records.Add(
            new Record6111
            {
                Lb_nr = Lb_nr++,
                Rec_nr = 6111,
                IndholdsType = indholdsType.Kode,
                AntalEnheder = antalEnheder,
                FortegnAntalEnheder = Fortegn(antalEnheder),
                Beloeb = amnt,
                BeloebDecimal = decimals,
                FortegnBeloeb = Fortegn(beloeb)
            }
        );
    }

    public void AddRecord8001(
        DateTime foedselsdato,
        Koen koen,
        Landekoder landekoder,
        string navn,
        string adresse,
        string postnummer,
        string postby
    )
    {
        Records.Add(
            new Record8001<object>
            {
                Lb_nr = Lb_nr++,
                Rec_nr = 8001,
                PersonFoedselsdato = foedselsdato,
                PersonKoen = (int)koen,
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

    private static char Fortegn(decimal antal) => antal > 0 ? '+' : '-';

    private static char Fortegn(int antal) => antal > 0 ? '+' : '-';

    private static (int integerPart, int decimalPart) ExtractDecimalParts(decimal amount)
    {
        var amountAbs = Math.Abs(amount); 
        var truncate = (int)Math.Truncate(amountAbs);
        var decimals = (int)((amountAbs - truncate) * 1_000_000);
        return (truncate, decimals);
    }
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
