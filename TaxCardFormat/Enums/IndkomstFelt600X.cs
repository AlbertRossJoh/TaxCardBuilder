namespace TaxCardFormat.Enums;

public enum IndkomstFelt600X
{
    AIndkomstMedAMBidrag = 0013, // A-indkomst, hvoraf der skal betales arbejdsmarkedsbidrag - Am-bidragspligtig A-indkomst
    AIndkomstUdenAMBidrag = 0014, // A-indkomst, hvoraf der ikke skal betales arbejdsmarkedsbidrag - Am-bidragsfri A-indkomst
    IndeholdtASkat = 0015, // Indeholdt A-skat - A-skat, der er indeholdt i den angivne periode
    IndeholdtAMBidrag = 0016, // Indeholdt arbejdsmarkedsbidrag - Am-bidrag, der er indeholdt i den angivne periode
    FriBilVærdi = 0019, // Værdi af fri bil til rådighed - A-skattepligtigt personalegode
    FriTelefonVærdi = 0020, // Værdi af fri telefon mm. - A-skattepligtigt personalegode
    FriKostOgLogiVærdi = 0021, // Værdi af fri kost og logi - A-skattepligtigt personalegode
    PensionsIndskudUdland = 0022, // Indskud i arbejdsgiveradministreret pensionsordning i svensk pensionsselskab/-institut eller anden godkendt udenlandsk pensionsordning
    AMBidragAfPensionsIndskudUdland = 0023, // Am-bidrag (8 pct.) af indskud indberettet under felt 22
    GodkendelsesnummerForPensionsordning = 0024, // Godkendelsesnummer for anden godkendt udenlandsk pensionsordning
    SundhedsforsikringArbejdsgiverBetalt = 0026, // Værdi af arbejdsgiverbetalt sundhedsforsikring og -behandling
    BIndkomstMedAMBidrag = 0036, // B-indkomst, hvoraf der skal betales arbejdsmarkedsbidrag
    OffentligeTilskudOgGodtgørelser = 0037, // Offentlige tilskud og godtgørelser til virksomhed
    BIndkomstUdenAMBidrag = 0038, // B-indkomst, hvoraf der ikke skal betales arbejdsmarkedsbidrag
    Hædersgaver = 0039, // Hædersgaver
    MedarbejderInvesteringsselskabBruttoindskud = 0041, // Bruttoindskud i medarbejderinvesteringsselskab
    AMBidragAfMedarbejderInvesteringsselskabIndskud = 0042, // AM-bidrag af indskud i medarbejderinvesteringsselskab
    ATPSatsType = 0045, // Sats-type for ATP-bidrag
    ATPBidrag = 0046, // ATP-bidrag
    OPBidrag = 0047, // OP-bidrag
    SkattefriRejseOgBefordringsgodtgørelse = 0048, // Skattefri rejse- og befordringsgodtgørelse
    FriHelårsboligVærdi = 0050, // Værdi af fri helårsbolig
    FriSommerboligVærdi = 0051, // Værdi af fri sommerbolig
    FriLystbådVærdi = 0052, // Værdi af fri lystbåd
    FriMedieRadiolicensVærdi = 0053, // Værdi af fri medie-/radiolicens
    AndrePersonalegoderMedBundgrænse = 0055, // Værdi af andre personalegoder, der overstiger bundgrænse
    AndrePersonalegoderUdenBundgrænse = 0056, // Værdi af andre personalegoder, uden bundgrænse
    AIndkomstFraAldersopsparing = 0057, // A-indkomst fra aldersopsparing
    ASkatAfAldersopsparing = 0058, // A-skat af aldersopsparing
    JubilæumsgratialeOgFratrædelsesgodtgørelse = 0069, // Jubilæumsgratiale og fratrædelsesgodtgørelse
    PensionsIndbetalingAfJubilæumsgratiale = 0070, // Den del af 0069, der er indbetalt til pensionsordning
    TingsgaverAfJubilæumsgratiale = 0071, // Den del af 0069, der er tingsgaver
    UdenlandskSocialSikring = 0089, // Bidrag til obligatorisk udenlandsk social sikring
    Gruppelivsforsikring = 0091, // Gruppelivsforsikring i pensionsindskud
    SundhedsforsikringIPensionsindskud = 0096, // Sundhedsforsikring i pensionsindskud
    TilbagebetalingAfKontanthjælp = 0098, // Tilbagebetaling af kontanthjælp
    FeriepengeAIndkomst = 0113, // A-indkomst udbetalt som feriepenge
    LønmodtagersPensionsandel = 0147, // Lønmodtagers pensionsandel
    ArbejdsgiversPensionsandel = 0148, // Arbejdsgivers pensionsandel
    IkkeGrønlandskPensionsordningIndbetaling = 0157, // Indbetaling på ikke-grønlandsk pensionsordning
    SkatAfIkkeGrønlandskPensionsordning = 0158, // Skat af indbetaling på ikke-grønlandsk pensionsordning
    BruttoferiepengeTimelønnede = 0198, // Bruttoferiepenge - timelønnede
    Bruttoferiepenge = 0201, // Bruttoferiepenge
    NettoferiepengeTimelønnede = 0202, // Nettoferiepenge - timelønnede
    BruttoferiepengeFortsættendeFunktionær = 0210, // Bruttoferiepenge - fortsættende funktionær
    OpsparingTilSøgnOgHelligdagsBetaling = 0248, // Opsparing til søgne- og helligdags betaling
    OpsparingTilFeriefridage = 0249 // Opsparing til feriefridage
}
