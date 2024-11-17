namespace TaxCardFormat.DataTypes.IPIndholdstype;

public record N0800(N0800Enum? N0800Enum = null):IPIndholdsType(800, (int?)N0800Enum);

public enum N0800Enum
{
    Timeloen = 1,
    Timeloen_Praestation = 2,
    FastLoen_med_overbetaling = 3,
    FastLoen_uden_overbetaling = 4,
    FastLoen_med_provision = 5,
    IkkeFastLoen_uden_tidsfaktor = 81,
    IkkeFastLoen_med_tidsfaktor = 82,
    FleksJob = 83,
    HjemmeArbejdende = 84,
    Indehaver_bestyrede = 91,
    SaerligtBeskattetMedarbejder = 92,
}
