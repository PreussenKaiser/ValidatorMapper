namespace ValidatorMapper;

public abstract class ValidatorBase<T> where T : notnull
{
    private readonly IDictionary<ValidationDelegate<T>, MapperDelegate<T>?> rules = new Dictionary<ValidationDelegate<T>, MapperDelegate<T>?>();

    public ValidationResult Validate(T value)
    {
        throw new NotImplementedException();
    }

    protected void AddRule(ValidationDelegate<T> validation, MapperDelegate<T>? mapping = null)
    {
        this.rules.Add(validation, mapping);
    }
}
