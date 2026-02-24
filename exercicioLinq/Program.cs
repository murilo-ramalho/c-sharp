using exercicioLinq.entities;
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
        double price = double.Parse(fileds[1], CultureInfo.InvariantCulture);

        list.Add(new Products(name, price));
    }
}

var avg = list.Select(p => p.Price).DefaultIfEmpty(0.0).Average();
System.Console.WriteLine("Average price: ", avg.ToString("F2", CultureInfo.InvariantCulture));

var names = list.Where(p => p.Price < avg).OrderByDescending(p => p.Name).Select(p => p.Name);
foreach (string name in names)
{
    System.Console.WriteLine(name);
}
