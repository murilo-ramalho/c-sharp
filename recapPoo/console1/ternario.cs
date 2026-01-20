using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace console1
{
    public class Ternario
    {
        public void Ternario1 ()
        {
            var exemplo = Console.ReadLine();
            System.Console.WriteLine(exemplo == "A" ? 1 : 0);
        }
    }
}