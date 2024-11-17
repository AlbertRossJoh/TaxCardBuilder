namespace TaxCardFormat.Enums;

public enum IndkomstFelt600X
{
    AIndkomstMedAMBidrag = 0013, // A-indkomst, hvoraf der skal betales arbejdsmarkedsbidrag - Am-bidragspligtig A-indkomst
    AIndkomstUdenAMBidrag = 0014, // A-indkomst, hvoraf der ikke skal betales arbejdsmarkedsbidrag - Am-bidragsfri A-indkomst
    IndeholdtASkat = 0015, // Indeholdt A-skat - A-skat, der er indeholdt i den angivne periode
    IndeholdtAMBidrag = 0016, // Indeholdt arbejdsmarkedsbidrag - Am-bidrag, der er indeholdt i den angivne periode
    FriBilVaerdi = 0019, // Vaerdi af fri bil til raadighed - A-skattepligtigt personalegode
    FriTelefonVaerdi = 0020, // Vaerdi af fri telefon mm. - A-skattepligtigt personalegode
    FriKostOgLogiVaerdi = 0021, // Vaerdi af fri kost og logi - A-skattepligtigt personalegode
    PensionsIndskudUdland = 0022, // Indskud i arbejdsgiveradministreret pensionsordning i svensk pensionsselskab/-institut eller anden godkendt udenlandsk pensionsordning
    AMBidragAfPensionsIndskudUdland = 0023, // Am-bidrag (8 pct.) af indskud indberettet under felt 22
    GodkendelsesnummerForPensionsordning = 0024, // Godkendelsesnummer for anden godkendt udenlandsk pensionsordning
    SundhedsforsikringArbejdsgiverBetalt = 0026, // Vaerdi af arbejdsgiverbetalt sundhedsforsikring og -behandling
    BIndkomstMedAMBidrag = 0036, // B-indkomst, hvoraf der skal betales arbejdsmarkedsbidrag
    OffentligeTilskudOgGodtgoerelser = 0037, // Offentlige tilskud og godtgoerelser til virksomhed
    BIndkomstUdenAMBidrag = 0038, // B-indkomst, hvoraf der ikke skal betales arbejdsmarkedsbidrag
    Haedersgaver = 0039, // Haedersgaver
    MedarbejderInvesteringsselskabBruttoindskud = 0041, // Bruttoindskud i medarbejderinvesteringsselskab
    AMBidragAfMedarbejderInvesteringsselskabIndskud = 0042, // AM-bidrag af indskud i medarbejderinvesteringsselskab
    ATPSatsType = 0045, // Sats-type for ATP-bidrag
    ATPBidrag = 0046, // ATP-bidrag
    OPBidrag = 0047, // OP-bidrag
    SkattefriRejseOgBefordringsgodtgoerelse = 0048, // Skattefri rejse- og befordringsgodtgoerelse
    FriHelaarsboligVaerdi = 0050, // Vaerdi af fri helaarsbolig
    FriSommerboligVaerdi = 0051, // Vaerdi af fri sommerbolig
    FriLystbaadVaerdi = 0052, // Vaerdi af fri lystbaad
    FriMedieRadiolicensVaerdi = 0053, // Vaerdi af fri medie-/radiolicens
    AndrePersonalegoderMedBundgraense = 0055, // Vaerdi af andre personalegoder, der overstiger bundgraense
    AndrePersonalegoderUdenBundgraense = 0056, // Vaerdi af andre personalegoder, uden bundgraense
    AIndkomstFraAldersopsparing = 0057, // A-indkomst fra aldersopsparing
    ASkatAfAldersopsparing = 0058, // A-skat af aldersopsparing
    JubilaeumsgratialeOgFratraedelsesgodtgoerelse = 0069, // Jubilaeumsgratiale og fratraedelsesgodtgoerelse
    PensionsIndbetalingAfJubilaeumsgratiale = 0070, // Den del af 0069, der er indbetalt til pensionsordning
    TingsgaverAfJubilaeumsgratiale = 0071, // Den del af 0069, der er tingsgaver
    UdenlandskSocialSikring = 0089, // Bidrag til obligatorisk udenlandsk social sikring
    Gruppelivsforsikring = 0091, // Gruppelivsforsikring i pensionsindskud
    SundhedsforsikringIPensionsindskud = 0096, // Sundhedsforsikring i pensionsindskud
    TilbagebetalingAfKontanthjaelp = 0098, // Tilbagebetaling af kontanthjaelp
    FeriepengeAIndkomst = 0113, // A-indkomst udbetalt som feriepenge
    LoenmodtagersPensionsandel = 0147, // Loenmodtagers pensionsandel
    ArbejdsgiversPensionsandel = 0148, // Arbejdsgivers pensionsandel
    IkkeGroenlandskPensionsordningIndbetaling = 0157, // Indbetaling paa ikke-groenlandsk pensionsordning
    SkatAfIkkeGroenlandskPensionsordning = 0158, // Skat af indbetaling paa ikke-groenlandsk pensionsordning
    BruttoferiepengeTimeloennede = 0198, // Bruttoferiepenge - timeloennede
    Bruttoferiepenge = 0201, // Bruttoferiepenge
    NettoferiepengeTimeloennede = 0202, // Nettoferiepenge - timeloennede
    BruttoferiepengeFortsaettendeFunktionaer = 0210, // Bruttoferiepenge - fortsaettende funktionaer
    OpsparingTilSoegnOgHelligdagsBetaling = 0248, // Opsparing til soegne- og helligdags betaling
    OpsparingTilFeriefridage = 0249 // Opsparing til feriefridage
}
