namespace PersonsApp;

internal static class Names
{
    public static readonly string[] FirstNames = new[]
    {
        "Nikos",
        "Nikoleta",
        "Giorgos",
        "Georgia",
        "Giannis",
        "Ioanna"
    };
}

internal sealed class PersonsGenerator
{
    private readonly Random Rnd = new Random(1236282027);

    public IEnumerable<Person> GeneratePersons(int count)
    {
        var persons = new List<Person>();

        for (var i = 0; i < count; i++)
        {
            var name = Names.FirstNames[Rnd.Next(0, Names.FirstNames.Length)];
            var person = new Person
            {
                Id = i,
                FirstName = name,
                LastName = Guid.NewGuid().ToString(),
                DateOfBirth = DateTime.Now.AddYears(-30 + Rnd.Next(-10, 10)).AddDays(Rnd.Next(365)),
                Email = $"{name.ToLowerInvariant()}.{i}@example.com"
            };
            persons.Add(person);
        }

        return persons;
    }
}
