var path = "TextFile1.csv";
var phoneBook = ReadFile(path);
var output = SearchCustomer(Console.ReadLine(), phoneBook);
Console.WriteLine(string.Join("\r\n", output));


static List<(string Id, string FirstName, string LastName, string PhoneNumber)> ReadFile(string path)
    {
        var phoneBook = new List<(string Id, string FirstName, string LastName, string PhoneNumber)> ();
        var textFile = File.ReadAllLines(path);
        foreach (var s in textFile)
        {
            var separate = s.Split(",");
            phoneBook.Add((separate[0], separate[1], separate[2], separate[3]));
        }
        return phoneBook;
    }

(string, string, string, string)[] SearchCustomer(
    string input,
    List<(string, string, string, string)> collection) =>
    collection.Where(person =>
    person.Item1.Contains(input) ||
    person.Item2.Contains(input, StringComparison.OrdinalIgnoreCase) ||
    person.Item3.Contains(input, StringComparison.OrdinalIgnoreCase) ||
    person.Item4.Contains(input)).ToArray();