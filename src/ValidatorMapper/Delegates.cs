namespace ValidatorMapper;

public delegate string? ValidationDelegate<T>(T value) where T : notnull;
public delegate void MapperDelegate<T>(T value) where T : notnull;
