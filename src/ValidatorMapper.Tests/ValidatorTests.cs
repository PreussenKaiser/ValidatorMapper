namespace ValidatorMapper.Tests;

public sealed class ValidatorTests
{
}

internal sealed class MockEntity
{
    public string Name { get; init; } = string.Empty;

    public string MutableName { get; set; } = string.Empty;
}

internal sealed class MockValidator : ValidatorBase<MockEntity>
{
    public MockValidator()
        => base.AddRule(e => string.IsNullOrEmpty(e.Name) ? "Name must be supplied" : null);
}
