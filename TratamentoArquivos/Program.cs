using System.IO;

string sourcePath = @"C:\Users\Murilo\Documents\Projects\c-sharp\TratamentoArquivos\archive.txt";
string targetPath = @"C:\Users\Murilo\Documents\Projects\c-sharp\TratamentoArquivos\archive2.txt";

try
{
    FileInfo fileInfo = new FileInfo(sourcePath);
    fileInfo.CopyTo(targetPath);

    string[] lines = File.ReadAllLines(sourcePath);
    foreach(string line in lines)
    {
        System.Console.WriteLine(line);
    }
}
catch (IOException e)
{
    System.Console.WriteLine($"error: {e}");
}