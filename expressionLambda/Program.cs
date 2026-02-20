using System;
using System.Collections.Generic;
using System.Linq;

Console.WriteLine("Exemplos simples de expressões lambda:\n");

// 1) Lambda com um parâmetro (Func)
Func<int, int> quadrado = x => x * x;
Console.WriteLine($"1) Quadrado de 5: {quadrado(5)}");

// 2) Lambda com dois parâmetros (Func)
Func<int, int, int> soma = (a, b) => a + b;
Console.WriteLine($"2) Soma de 10 + 20: {soma(10, 20)}");

// 3) Lambda sem retorno (Action)
Action<string> saudacao = nome => Console.WriteLine($"3) Olá, {nome}!");
saudacao("Murilo");

// 4) Lambda que retorna bool (Predicate)
Predicate<int> ehPar = numero => numero % 2 == 0;
Console.WriteLine($"4) 8 é par? {ehPar(8)}");
Console.WriteLine($"4) 7 é par? {ehPar(7)}");

// 5) Lambda com bloco de código
Func<int, int, int> maior = (x, y) =>
{
    if (x > y)
    {
        return x;
    }

    return y;
};
Console.WriteLine($"5) Maior entre 15 e 9: {maior(15, 9)}");

// 6) Usando lambda com LINQ (Where e Select)
List<int> numeros = new() { 1, 2, 3, 4, 5, 6 };
List<int> paresAoQuadrado = numeros
    .Where(n => n % 2 == 0)
    .Select(n => n * n)
    .ToList();

Console.WriteLine($"6) Pares ao quadrado: {string.Join(", ", paresAoQuadrado)}");

// 7) Ordenando com lambda
List<string> nomes = new() { "Carlos", "Ana", "Bruno", "Eduardo" };
nomes.Sort((n1, n2) => n1.Length.CompareTo(n2.Length));
Console.WriteLine($"7) Nomes por tamanho: {string.Join(", ", nomes)}");
