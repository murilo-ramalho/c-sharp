using System;
using xadrez.tabuleiro;

namespace xadrez;

public class Tela
{
    public static void imprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    var peca = tabuleiro.peca(i, j);

                    if (peca == null)
                        System.Console.Write("- ");
                    else
                        System.Console.Write(peca + " ");
                }
                System.Console.WriteLine();
            }
        }
}
