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
        Tela.imprimirTabuleiro(partida.Tabuleiro);

        System.Console.WriteLine();
        System.Console.WriteLine("Origem: ");
        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
        System.Console.WriteLine("Destino: ");
        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

        partida.executaMovimento(origem, destino);
    }
    
    Tela.imprimirTabuleiro(partida.Tabuleiro);
} catch (TabuleiroException e)
{
    System.Console.WriteLine(e.Message);
}


