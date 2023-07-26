namespace ValidatorMapper.Tests;

public sealed class ValidatorTests
{
    [Theory]
    [InlineData("foo", true)]
    [InlineData("", false)]
    public void Validates_And_Maps(string name, bool expected)
    {
        // Arrange
        MockValidator validator = new();
        MockEntity entity = new() { Name = name };

        // Act
        ValidationResult actual = validator.Validate(entity);
        bool wasMapped = entity.Name == Constants.MAPPED_NAME;

        // Assert
        Assert.Equal(expected, actual.IsValid);
        Assert.Equal(expected, wasMapped);
    }
}

internal sealed class MockEntity
{
    public required string Name { get; set; }
}

internal static class Constants
{
    internal const string MAPPED_NAME = "bar";
}

internal sealed class MockValidator : ValidatorBase<MockEntity>
{
    public MockValidator()
        => base.AddRule(
            e => string.IsNullOrEmpty(e.Name) ? "Name must be supplied" : null,
            e => e.Name = Constants.MAPPED_NAME);
}
