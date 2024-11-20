using FileHelpers;
using TaxCardFormat.RecordInterfaces;

namespace TaxCardFormat.Records;

public class TaxRecordBase<TPrevious> : TaxRecord, IWalkBack<TPrevious>
{
    [FieldHidden] protected TPrevious? _previous;
    public TaxRecordBase(): this(default){}
    public TaxRecordBase(TPrevious? previous){_previous = previous;}
    public TPrevious GoBack() => _previous ?? throw new NullReferenceException("Previous record is null remember to set the previous record in the constructor");
}