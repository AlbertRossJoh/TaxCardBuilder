namespace TaxCardFormat.RecordInterfaces;

public interface IWalkBack<out TPrevious>
{
    public TPrevious GoBack();
}
