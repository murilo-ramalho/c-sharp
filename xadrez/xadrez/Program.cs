using xadrez;
using xadrez.tabuleiro;
using xadrez.xadrez;
using xadrez.exceptions;

try
{
    PartidaXadrex partida = new PartidaXadrex();

    while (!partida.isTerminado)
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Black;
        Tela.imprimirTabuleiro(partida.Tabuleiro);

        Console.WriteLine();
        Console.WriteLine("Origem: ");
        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
        
        Console.Clear();
        bool[,] posicaoPossiveis = partida.Tabuleiro.peca(origem).MovimentoPossivel();
        Tela.imprimirTabuleiro(partida.Tabuleiro, posicaoPossiveis);

        Console.WriteLine();
        Console.WriteLine("Destino: ");
        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

        partida.executaMovimento(origem, destino);
    }
    
    Tela.imprimirTabuleiro(partida.Tabuleiro);
} catch (TabuleiroException e)
{
    Console.WriteLine(e.Message);
}


