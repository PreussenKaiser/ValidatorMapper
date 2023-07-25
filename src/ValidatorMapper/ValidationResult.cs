namespace ValidatorMapper;

public sealed class ValidationResult
{
    private readonly List<string> errors = new();

    public bool IsValid => this.errors.Count == 0;

    public IReadOnlyCollection<string> Errors => this.errors.AsReadOnly();

    public void AddError(string message) => this.errors.Add(message);
}
