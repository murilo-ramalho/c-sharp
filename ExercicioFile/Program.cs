using System.IO;

string path = @"C:\Users\Murilo\Documents\Projects\c-sharp\ExercicioFile\archive.txt";
string target = @"C:\Users\Murilo\Documents\Projects\c-sharp\ExercicioFile\archive2.txt";

try
{
    string[] lines = File.ReadAllLines(path);

    using (StreamWriter sw = File.AppendText(target))
    {
        foreach (var line in lines)
        {
            var parts = line.Split(',');

            if (parts.Length == 3)
            {
                double price1 = double.Parse(parts[1]);
                double quantity1 = double.Parse(parts[2]);

                double result = price1 * quantity1;

                sw.WriteLine($"{parts[0]}, {result}");
            }
        }
    }
}
catch (IOException e)
{
    System.Console.WriteLine($"erroe: {e}");
}