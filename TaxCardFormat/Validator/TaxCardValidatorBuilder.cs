using TaxCardFormat.Validator.Rules;

namespace TaxCardFormat.Validator;

public class TaxCardValidatorBuilder
{
    private List<ITaxFileRule> _rules = [];

    public TaxCardValidatorBuilder AddRule(ITaxFileRule rule)
    {
        _rules.Add(rule);
        return this;
    }

    public TaxCardValidatorBuilder AddExistsAnyRule<T>()
    {
        _rules.Add(new AnyRule<T>());
        return this;
    }

    public TaxCardValidatorBuilder AddAtIndexRule<T>(int index)
    {
        _rules.Add(new AtIndexRule<T>(index));
        return this;
    }

    public TaxCardValidatorBuilder AddInScopeRule<TScope>(params Type[] nested)
    {
        _rules.Add(new InScopeRule<TScope>(nested));
        return this;
    }

    public TaxCardValidatorBuilder AddSingleInScopeRule<TScope, TNested>()
    {
        _rules.Add(new SingleInScopeRule<TScope, TNested>());
        return this;
    }

    public TaxCardValidatorBuilder AddSingleRule<TNested>()
    {
        _rules.Add(new SingleRule<TNested>());
        return this;
    }

    public TaxCardValidator Build()
    {
        return new TaxCardValidator(_rules);
    }
}