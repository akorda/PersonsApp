# Shiplex - PersonsApp

There is a console application written in `C#` & `net6.0` and lets suppose that there is a way to get a collection of `Person` instances:

```csharp
public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
}
```

We could "load" these persons using:

```csharp
var generator = new PersonsGenerator();
var persons = generator.GeneratePersons(100);
```

There is a new requirement to add the following functionality:

## 1. Print the oldest person

Implement a new method that prints out the name and the age of the *oldest* person. I.e. the following message should appear in the console:

> Giorgos Papanikolaou, 37

## 2. Statistics

Implement a new method that writes in the console the name of each person and the number of times that this name exists in the collection. The print order should be the count descending and in the special case of two or more person names having the same count, then sort in alphabetical order ascending. Something like:

```text
Giorgos     7
Nikoleta    6
Nikos       6
Kostas      3
```

## 3. Send emails

Suppose that there is an implementation of the `INameDayProvider` service that provides the celebrating names a given day.

```csharp
public interface INameDayService
{
    Task<string[]> GetAnniversariesAsync(DateTime day, CancellationToken cancellationToken = default);
}
```

Emails are sent using an external process that reads records from an SQL Server database table named `EmailMessages` with `Status = Pending`. The schema of this table is:

```text
[Id] [nvarchar](50) NOT NULL PRIMARY KEY,
[Subject] [nvarchar](500) NULL,
[Body] [nvarchar](max) NULL,
[ToAddresses] [nvarchar](max) NULL,
[CcAddresses] [nvarchar](max) NULL,
[BccAddresses] [nvarchar](max) NULL,
[Status] [nvarchar](50) NOT NULL
```

Therefore, the way that our program will send the emails is to add one or more rows in `EmailMessages` table. The recipients of an email (fields `ToAddresses`, `CcAddresses` and `BccAddresses`) could be more than one, separated using the `;` character. E.g.

```text
nikos2@example.com;nikoleta21@example.com
```

Implement a new method that send emails to all persons that celebrate **today** with subject `Happy Name Day` and body `Today is the name day of Nikos. Many wishes!`.

> ℹ️ The word 'Nikos' in the body of the email is the name of the email recipient.
