using xadrez.tabuleiro;

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
                var peca = tabuleiro.peca(i, j);

                if (peca == null)
                {
                    Console.Write("-");
                }
                else
                {
                    ImprimirPeca(peca);
                }
                    
                Console.Write(" ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h");
    }

    public static void ImprimirPeca(Peca peca)
    {
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
    }
}
