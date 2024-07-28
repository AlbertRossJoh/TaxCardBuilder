namespace TaxCardFormat.IPIndholdstype;

public record IPIndholdsType(int kode, int? indhold)
{
    public int? Indhold = indhold;
    public int Kode = kode;
}