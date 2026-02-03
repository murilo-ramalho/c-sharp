using System.IO;

string sourcePath = @"C:\Users\Murilo\Documents\Projects\c-sharp\StreamWriter\archive.txt";
string targetPath = @"C:\Users\Murilo\Documents\Projects\c-sharp\StreamWriter\archive2.txt";

try
{
    string[] lines = File.ReadAllLines(sourcePath);

    using(StreamWriter sw = File.AppendText(targetPath))
    {
        foreach (string line in lines)
        {
            sw.WriteLine(line.ToUpper());
        }
    }
}
catch (IOException e)
{
    System.Console.WriteLine($"error: {e}");
}