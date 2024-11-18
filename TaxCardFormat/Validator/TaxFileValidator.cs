using FluentValidation;
using TaxCardFormat.Builder;
using TaxCardFormat.Records;

namespace TaxCardFormat.Validator;

public class TaxFileValidator : AbstractValidator<TaxFileBuilder>
{
    public TaxFileValidator()
    {
        RuleFor(x => x.Records.Select(taxRecord => taxRecord.GetType()))
            .Must(list => list.Count(type => type == typeof(Record1000)) == 1)
            .Must(list => list.Any(type => type == typeof(Record2001<object>)));
    }
}