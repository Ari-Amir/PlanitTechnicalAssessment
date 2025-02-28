using Xunit;

// Атрибут для отключения параллельности выполнения тестов
[CollectionDefinition("Sequential Tests", DisableParallelization = true)]
public class SequentialTestCollection { }
