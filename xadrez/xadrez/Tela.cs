using xadrez.exceptions;
using xadrez.tabuleiro;
using xadrez.xadrez;
using System.Collections.Generic;

namespace xadrez;

public class Tela
{
    public static void imprimirTabuleiro(Tabuleiro tabuleiro)
    {
        for (int i = 0; i < tabuleiro.Linhas; i++)
        {
            Console.Write(8 - i + " ");
            for (int j = 0; j < tabuleiro.Colunas; j++) 
            {
                ImprimirPeca(tabuleiro.peca(i, j));
            }
            Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h");
    }

    public static void imprimirPartida(PartidaXadrex partida)
    {
        imprimirTabuleiro(partida.Tabuleiro);
        Console.WriteLine();
        imprimirPecasCapturadas(partida);
        Console.WriteLine("Turno: " + partida.Turno);
        Console.WriteLine("Aguardando: " + partida.jogadorAtual);
        if (partida.isXeque)
        {
            Console.WriteLine();
            System.Console.WriteLine("Xeque!");
        }
    }

    public static void imprimirPecasCapturadas(PartidaXadrex partida)
    {
        System.Console.WriteLine("Pecas capturadas: ");
        System.Console.Write("Branco: ");
        imprimirConjunto(partida.pecasCapturadas(Cor.Branco));
        System.Console.WriteLine();
        System.Console.Write("Preto: ");
        imprimirConjunto(partida.pecasCapturadas(Cor.Preto));
        System.Console.WriteLine();
    }

    public static void imprimirConjunto(HashSet<Peca> conjunto)
    {
        System.Console.Write("[");
        foreach (Peca item in conjunto)
        {
            System.Console.Write(item + " ");            
        }
        System.Console.Write("]");
    }

    public static void imprimirTabuleiro(Tabuleiro tabuleiro, bool[,] posicaoPossiveil)
    {
        ConsoleColor fundoOriginal = Console.BackgroundColor;
        ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

        for (int i = 0; i < tabuleiro.Linhas; i++)
        {
            Console.Write(8 - i + " ");
            for (int j = 0; j < tabuleiro.Colunas; j++) 
            {
                if (posicaoPossiveil[i, j])
                    Console.BackgroundColor = fundoAlterado;
                else
                    Console.BackgroundColor = fundoOriginal;

                ImprimirPeca(tabuleiro.peca(i, j));
                Console.BackgroundColor = fundoOriginal;
            }
            Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h");
        Console.BackgroundColor = fundoOriginal;
    }

    public static void ImprimirPeca(Peca peca)
    {
        if (peca == null)
        {
            Console.Write("- ");
            return;
        }
        
        if (peca.Cor == Cor.Branco)
        {
            Console.Write(peca);
        }
        else
        {
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(peca);
            Console.ForegroundColor = aux;
        }
        
        Console.Write(" ");

    }

    public static PosicaoXadrez lerPosicaoXadrez()
    {
        string s = Console.ReadLine();

        if (s == null)
            throw new TabuleiroException("Insira uma posição");
        if (s.Length != 2)
            throw new TabuleiroException("Insira uma posição Válida");

        char col = s[0];
        int row = int.Parse(s[1] + "");
        
        if (!char.IsLetter(col) || char.ToLower(col) < 'a' || char.ToLower(col) > 'h')
            throw new TabuleiroException("Insira uma Coluna Válida");
        if (row < 1 || row > 8)
            throw new TabuleiroException("Insira uma Linha Válida");

        return new PosicaoXadrez(col, row);
    }
}
