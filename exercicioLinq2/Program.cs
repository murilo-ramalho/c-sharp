using exercicioLinq2.Entities;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

System.Console.WriteLine("Enter full file path: ");
string path = Console.ReadLine();

List<Products> list = new List<Products>();

using (StreamReader sr = File.OpenText(path))
{
    while (!sr.EndOfStream)
    {
        string[] fileds = sr.ReadLine().Split(',');
        string name = fileds[0];
        string email = fileds[1];
        double price = double.Parse(fileds[2], CultureInfo.InvariantCulture);

        list.Add(new Products(name, email, price));
    }
}

var emails = (from email in list
    where email.Price > 2000
    select email.Email).DefaultIfEmpty("none");
System.Console.WriteLine("Email of People whose salary is more than 2000.0:");
foreach(string email in emails)
{
    System.Console.WriteLine(email);
}

var sum = list.Where(p => p.Name[0] == 'M').Select(p => p.Price).Sum();
System.Console.WriteLine("Sum oof salary of people whose name starts with 'M': "+ sum.ToString("F2", CultureInfo.InvariantCulture));