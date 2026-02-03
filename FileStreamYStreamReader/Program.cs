using System.IO;

string path = @"C:\Users\Murilo\Documents\Projects\c-sharp\FileStreamYStreamReader\archive.txt";
FileStream fs = null;
StreamReader sr = null;

try
{
    sr = File.OpenText(path);
    while (!sr.EndOfStream)
    {
        string line = sr.ReadLine();
        System.Console.WriteLine(line);
    }
}
catch (IOException e)
{
    System.Console.WriteLine($"error: {e}");
}
finally
{
    if (sr != null) sr.Close();
    if (fs != null) fs.Close();
}


// using
try
{
    using (StreamReader sr2 = File.OpenText(path))
    {
        while (!sr2.EndOfStream)
        {
            string line = sr2.ReadLine();
            System.Console.WriteLine(line);
        }
    }
}
catch (IOException e)
{
    System.Console.WriteLine($"error: {e}");
}
