using System;

namespace Arranjos
{
    public class Matriz
    {
        public static void Matriz1()
        {
            double [,] mat = new double[2,3];

            System.Console.WriteLine(mat.Length);
            System.Console.WriteLine(mat.Rank);
            System.Console.WriteLine(mat.GetLength(0));
            System.Console.WriteLine(mat.GetLength(1));
        }
        public static void Matriz1(int a){}
    }
}