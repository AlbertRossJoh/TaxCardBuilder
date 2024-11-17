namespace TaxCardFormat.DataTypes.IPIndholdstype;

public record N0400(N0400Enum? n0400Enum = null) : IPIndholdsType(400, (int?)n0400Enum);

public enum N0400Enum
{
    Elev_Laerling_Trainee = 1,
    Leder_Mellemleder = 3,
    Medarbejder_saerligt_ansvar = 5,
    oevrige_medarbejder = 9
}
