using TaxCardFormat.Builders;
using TaxCardFormat.Records;
using TaxCardTests.Helpers;

namespace TaxCardTests;

public class RecordTestBase<T> where T : TaxRecord
{
        protected TaxFileBuilder Sut = new();
        protected FieldRanges _fieldRanges = new(typeof(T));
        protected string Lb_nr = "Lb_nr";
        protected string Rec_nr = "Rec_nr";
}