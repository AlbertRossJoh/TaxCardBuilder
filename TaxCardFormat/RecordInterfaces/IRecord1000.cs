namespace TaxCardFormat.RecordInterfaces;

public interface IRecord1000
{
    public IRecord2001<IRecord1000> AddRecord2001(
        string virksomhedSE,
        bool ophoerHosLSB,
        string valutakode = "DKK"
    );
}
