using System;

namespace console1
{
    class Math
    {
        public void OperacoesBasicas()
        {
            int a = 10;
            int b = 3;

            int soma = a + b;
            int subtracao = a - b;
            int multiplicacao = a * b;
            double divisao = (double)a / b;
            int modulo = a % b;

            System.Console.WriteLine("Soma: " + soma);
            System.Console.WriteLine("Subtração: " + subtracao);
            System.Console.WriteLine("Multiplicação: " + multiplicacao);
            System.Console.WriteLine("Divisão: " + divisao);
            System.Console.WriteLine("Módulo: " + modulo);

            //double potencia = Math.Pow(a, b);
            //double raizQuadrada = Math.Sqrt(a);

            //System.Console.WriteLine("Potência: " + potencia);
            //System.Console.WriteLine("Raiz Quadrada: " + raizQuadrada);
        }
    }
}