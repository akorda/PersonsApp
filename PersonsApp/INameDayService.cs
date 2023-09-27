namespace PersonsApp;

public interface INameDayService
{
    Task<string[]> GetAnniversariesAsync(DateTime day, CancellationToken cancellationToken = default);
}

internal sealed class NameDayService : INameDayService
{
    public Task<string[]> GetAnniversariesAsync(DateTime day, CancellationToken cancellationToken = default)
    {
        var index = day.Day % Names.FirstNames.Length / 2;
        var names = new[]
        {
            Names.FirstNames[index - 1],
            Names.FirstNames[index]
        };
        return Task.FromResult(names);
    }
}
