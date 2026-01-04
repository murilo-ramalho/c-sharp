using System;

namespace console1
{
    class Numeros
    {
        public void Atribuicao1()
        {
            int a = 10;
            System.Console.WriteLine(a);

            a += 2;
            System.Console.WriteLine(a);

            a *= 3;
            System.Console.WriteLine(a);

            a /= 2;
            System.Console.WriteLine(a);

            a -= 5;
            System.Console.WriteLine(a);

            a %= 3;
            System.Console.WriteLine(a);
        }

        public void incrementacao()
        {
            int b = 5;
            System.Console.WriteLine(b);

            b++;
            System.Console.WriteLine(b);

            ++b;
            System.Console.WriteLine(b);

            b--;
            System.Console.WriteLine(b);

            --b;
            System.Console.WriteLine(b);
        }
        public void convesao()
        {
            double x = 4.5;
            int y = (int)x;
            float z = (float)x;
            System.Console.WriteLine(y);
            System.Console.WriteLine(z);

            int a = 5;
            int b = 2;
            double resultado = (double)a / b;
            System.Console.WriteLine(resultado);
        }
    }
}