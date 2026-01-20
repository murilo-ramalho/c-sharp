using System;
using System.Collections.Generic;

namespace Arranjos
{
    class Lista1
    {
        public static void lista1 ()
        {
            List<string> lista = new List<string>();

            lista.Add("1"); // adiciona ao final
            lista.Add("A"); // adiciona ao final
            lista.Add("B");
            lista.Add("C"); 
            lista.Insert(2,"D"); // adiciona apatir de um indice

            foreach (string item in lista)
            {
                Console.WriteLine(item);
            }

            System.Console.WriteLine("list: " + lista.Count);

            // função anonima e rápida, callback
            //string s1 = lista.Find(Exemplo); 
            string s1 = lista.Find(static x => x[0] == 'A') ?? "";
            System.Console.WriteLine(s1);

            int p1 = lista.FindIndex(x => x[0] == 'A');
            System.Console.WriteLine(p1);

            int p2 = lista.FindLastIndex(x => x[0] == 'A');
            System.Console.WriteLine(p2);

            List<string> lista2 = lista.FindAll(x => x.Length == 5);
            System.Console.WriteLine(lista2);

            lista.Remove("A");
            foreach (string x in lista)
            {
                System.Console.WriteLine(x);
            }
        }

        public static bool Exemplo(string s)
        {
            return s[0] == 'A';
        }
    }
}