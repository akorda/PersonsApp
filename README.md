# Shiplex - PersonsApp

Έχουμε ένα console application σε C# & net6.0 και θεωρούμε ότι έχουμε έναν τρόπο να γεμίζουμε ένα collection από `Person` instances.

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

Αυτό γίνεται με κλήση των:

```csharp
var generator = new PersonsGenerator();
var persons = generator.GeneratePersons(100);
```
Ο πελάτης θα ήθελε να προσθέσουμε το παρακάτω functionality στο πρόγραμμά μας.

## 1. Εκτύπωση γηραιότερου

Να υλοποιηθεί μέθοδος που τυπώνει το όνομα και την ηλικία του γηραιότερου ατόμου από τη λίστα των `Person`. Π.χ. να φανεί σε console κάτι σαν:

> Giorgos Papanikolaou, 37

## 2. Στατιστικά

Να υλοποιηθεί μέθοδος που τυπώνει σε console το κάθε όνομα και το πλήθος εμφάνισης του ονόματος. Η σειρά εμφάνισης να είναι το πλήθος σε φθίνουσα και σε περίπτωση που δύο ονόματα έχουν το ίδιο πλήθος αύξουσα αλφαβητική. Κάτι σαν:

```
Giorgos     7
Nikoleta    6
Nikos       6
Kostas      3
```

## 3. Αποστολή ευχετήριου email

Έστω ότι έχουμε την υλοποίηση του service `INameDayProvider` που παρέχει για μία ημέρα τα ονόματα που γιορτάζουν.

```csharp
public interface INameDayService
{
    Task<string[]> GetAnniversariesAsync(DateTime day, CancellationToken cancellationToken = default);
}
```
Θεωρούμε ότι η αποστολή των email γίνεται χρησιμοποιώντας μία εξωτερική διαδικασία που διαβάζει εγγραφές από έναν πίνακα `EmailMessages` μίας βάσης δεδομένων σε SQL Server που έχουν `Status = Pending`. Η δομή του πίνακα είναι:

```
[Id] [nvarchar](50) NOT NULL PRIMARY KEY,
[Subject] [nvarchar](500) NULL,
[Body] [nvarchar](max) NULL,
[ToAddresses] [nvarchar](max) NULL,
[CcAddresses] [nvarchar](max) NULL,
[BccAddresses] [nvarchar](max) NULL,
[Status] [nvarchar](50) NOT NULL
```

Επομένως ο τρόπος που το πρόγραμμά μας θα στέλνει τα email, είναι να προσθέσει ένα ή περισσότερα rows στον πίνακα `EmailMessages`. Οι παραλήπτες (στο `ToAddresses`, `CcAddresses` ή `BccAddresses`) μπορεί να είναι πολλαπλοί χωρισμένοι με το χαρακτήρα `;` π.χ.:

> nikos2@example.com;nikoleta21@example.com

Να γραφτεί μέθοδος που να αποστέλνει email στους σημερινούς εορτάζοντες με θέμα `Χίλιες ευχές για τη γιορτή σου!` και περιεχόμενο `Σήμερα γιορτάζει ο Nikos. Χρόνια σου πολλά!`.

> ℹ️ Η λέξη 'Nikos' στο περιεχόμενο διαφέρει ανάλογα με το όνομα του παραλήπτη.
