using System;

namespace console1
{
    class ConsoleWrite
    {
        public void exercicio1()
        {
            string prod1 = "PC";
            string prod2 = "Mesa";

            byte idade = 30;
            int codigo = 5290;
            char genero = 'M';

            double preco1 = 2100;
            double preco2 = 650.50;
            double medida = 53.234567;

            Console.WriteLine($"Produtos: {prod1}, cujo preço é $ {preco1:F2} e {prod2}, cujo preço é $ {preco2:F2}");
            Console.WriteLine($"Registro: {idade} anos de idade, código {codigo} e gênero: {genero}");
            Console.WriteLine($"Medida com oito casas decimais: {medida:F8}");
            Console.WriteLine($"Arredondado (três casas decimais): {medida:F3}");
            Console.WriteLine("Separador decimal invariant culture: " + medida.ToString("F3 ", System.Globalization.CultureInfo.InvariantCulture));
        }
    }
}