namespace PersonsApp;

public class Program
{
    public static async Task Main()
    {
        var generator = new PersonsGenerator();
        var persons = generator.GeneratePersons(100).ToArray();
        foreach (var person in persons)
        {
            Console.WriteLine($"{person.Id}, {person.FirstName}, {person.DateOfBirth.Date.ToShortDateString()}");
        }

        Console.WriteLine("\n\n***************************************************\n\n");

        // TODO: Print the oldest person

        Console.WriteLine("\n\n***************************************************\n\n");

        // TODO: Print person statistics

        Console.WriteLine("\n\n***************************************************\n\n");

        // TODO: Send email to those that today is their nameday
        INameDayService nameDayService = new NameDayService();
        var connectionString = "Data Source=.;Initial Catalog=PersonsApp;Integrated Security=true";


    }
}
