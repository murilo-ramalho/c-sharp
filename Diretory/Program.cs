using System.IO;
using System.Collections.Generic;

string path = @"C:\Users\Murilo\Documents\Projects\c-sharp\EmpresaExercicio01";


// FOLDERS
try
{
    IEnumerable<string> folders = Directory.EnumerateDirectories(path, "*.*", SearchOption.AllDirectories);
    System.Console.WriteLine("FOLDERS: ");
    foreach (string s in folders)
    {
        System.Console.WriteLine(s  );
    }
}
catch (IOException e)
{
    System.Console.WriteLine($"error {e}");
}

// FILES
try
{
    var files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
    System.Console.WriteLine("FILES: ");
    foreach (string f in files)
    {
        System.Console.WriteLine(f);
    }

    Directory.CreateDirectory(@"C:\Users\Murilo\Documents\Projects\c-sharp\Diretory" + "\\aaaa");
}
catch (IOException e)
{
    System.Console.WriteLine($"error {e}");
}