using System;

namespace console1
{
    class exercicio2
    {
        public void Exercicio2()
        {
            Console.WriteLine("Entre com seu nome: ");
            string? nomeInput = Console.ReadLine();
            string nome = nomeInput ?? string.Empty;

            Console.WriteLine("Quantos quartos tem na sua casa? ");
            string? quartosInput = Console.ReadLine();
            int quartos = int.TryParse(quartosInput, out int q) ? q : 0;

            Console.WriteLine("Entre com o preço de um produto: ");
            string? precoInput = Console.ReadLine();
            double preco = double.TryParse(precoInput, out double p) ? p : 0.0;

            Console.WriteLine("Entre com seu último nome, idade e altura (mesma linha): ");
            string? vetorInput = Console.ReadLine();
            string[] vetor = (vetorInput ?? string.Empty).Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string sobrenome = vetor.Length > 0 ? vetor[0] : string.Empty;
            int idade = vetor.Length > 1 && int.TryParse(vetor[1], out int i) ? i : 0;
            double altura = vetor.Length > 2 && double.TryParse(vetor[2], out double a) ? a : 0.0;

            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Quartos na casa: {quartos}");
            Console.WriteLine($"Preço do produto: {preco:F2}");
            Console.WriteLine($"Sobrenome: {sobrenome}");
            Console.WriteLine($"Idade: {idade}");
            Console.WriteLine($"Altura: {altura:F2}");
        }
    }
}