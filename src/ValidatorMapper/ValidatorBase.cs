namespace ValidatorMapper;

public abstract class ValidatorBase<T> where T : notnull
{
    private readonly IDictionary<ValidationDelegate<T>, MapperDelegate<T>?> rules = new Dictionary<ValidationDelegate<T>, MapperDelegate<T>?>();

    public ValidationResult Validate(T value)
    {
        ValidationResult validationResult = new();

        foreach (var rule in this.rules)
        {
            string? result = rule.Key.Invoke(value);

            if (result is null)
            {
                rule.Value?.Invoke(value);

                continue;
            }

            validationResult.AddError(result);
        }

        return validationResult;
    }

    protected void AddRule(ValidationDelegate<T> validation, MapperDelegate<T>? mapping = null)
    {
        this.rules.Add(validation, mapping);
    }
}
