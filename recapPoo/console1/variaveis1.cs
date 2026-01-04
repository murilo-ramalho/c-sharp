using System;
using System.Globalization;

namespace VariaveisBasicas
{
    class Variaveis1
    {
        public void consoleDestaque(int repeticao)
        {
            System.Console.Write('\n');
            for (int i = 0; i <= repeticao; i++)
            {
                if (i == repeticao) 
                {
                    System.Console.Write('\n');
                    break;
                }
                System.Console.Write("-");
            }
        }
        public void variaveis()
        {
            consoleDestaque(60);
            // regras
            // nunca começa com 5, adicionar prefixo de _
            // evite acentos
            // não tem espaço em brancos
            // nomes devem ter significado

            // convenções
            // Camel Case: lastName - parâmetros de funções, variaveis de funções
            // Pascal Case: LastName - namespaces, classes, propriedades e funções
            // _lastname - atributos internos de classes

            sbyte x = 100;
            bool completo = false;
            char genero = 'F';
            char letra= '\u0041';
            byte n1 = 123;
            int n2 = 1000;
            int n3 = 2147483647;
            long n4 = 214748368L;
            float n5 = 4.5f;
            double n6 = 4.5;
            string nome = "Maria Silva"; // string é imutávels, ao mudar o valor, cria-se uma nova string na memória
            object obj1 = "Alex Brown";
            object obj2 = 4.5f;

            
            Console.WriteLine(x);
            Console.WriteLine(completo);
            Console.WriteLine(genero);
            Console.WriteLine(letra);
            Console.WriteLine(n1);
            Console.WriteLine(n2);
            Console.WriteLine(n3);
            Console.WriteLine(n4);
            Console.WriteLine(n5);
            Console.WriteLine(n6);
            Console.WriteLine(nome);
            Console.WriteLine(obj1);
            Console.WriteLine(obj2);
        }
        public void variaveis2()
        {
            consoleDestaque(60);

            int n1 = int.MinValue;
            int n2 = int.MaxValue;
            sbyte n3 = sbyte.MinValue;
            sbyte n4 = sbyte.MaxValue;
            decimal n5 = decimal.MinValue;
            decimal n6 = decimal.MaxValue;

            Console.WriteLine(n1);
            Console.WriteLine(n2);
            Console.WriteLine(n3);
            Console.WriteLine(n4);
            Console.WriteLine(n5);
            Console.WriteLine(n6);

            double n7 = 22.1989;
            Console.WriteLine(n7.ToString("F2")); // aredonda e mostra as casas que deseja após a virgula
            System.Console.WriteLine(n7.ToString("F4", CultureInfo.InvariantCulture));
        }
        public void concatenacao()
        {
            consoleDestaque(60);
            float n1 = 4.5f;
            double n2 = 4.5777;
            string nome = "Maria Silva";

            System.Console.WriteLine("{0} tem saldo {1} e {2:F1}", nome, n1, n2);
            System.Console.WriteLine($"{nome} tem {n1} e {n2:F2}.");
            System.Console.WriteLine(nome + " tem " + n1 + " e " + n2.ToString("F3")); // , não funciona
        }
    }
}