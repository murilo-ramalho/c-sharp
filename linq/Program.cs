// é parecido um um sql, porém no código
using System.Linq;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int[] numbers = new int[] {1,2,3,4,5,6};

// consulta
IEnumerable<int> result = numbers.Where(x => x % 2 == 0).Select(x => x * 10);

// execurtar consulta
foreach (int x in result)
    System.Console.WriteLine(x);
