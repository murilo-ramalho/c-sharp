using xadrez;
using xadrez.tabuleiro;
using xadrez.xadrez;
using xadrez.exceptions;
using System.IO;

static void SafeConsoleClear()
{
    // Console.Clear() may throw when there's no attached console (or output is redirected).
    try
    {
        if (!Console.IsOutputRedirected)
        {
            Console.Clear();
        }
    }
    catch (IOException)
    {
        System.Console.WriteLine("Brutal");
    }
}

try
{
    PartidaXadrex partida = new PartidaXadrex();

    while (!partida.isTerminado)
    {
        SafeConsoleClear();
        try
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Tela.imprimirPartida(partida);

            Console.WriteLine();
            Console.WriteLine("Origem: ");

            Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
            partida.validarPosicaoOrigem(origem); 
            
            SafeConsoleClear();
            bool[,] posicaoPossiveis = partida.Tabuleiro.peca(origem).MovimentoPossivel();
            Tela.imprimirTabuleiro(partida.Tabuleiro, posicaoPossiveis);

            Console.WriteLine();
            Console.WriteLine("Destino: ");
            Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
            partida.validarPosicaoDestino(origem, destino);

            partida.realizaJogada(origem, destino);
        } catch (TabuleiroException e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }
        Tela.imprimirTabuleiro(partida.Tabuleiro);
    }
    
} catch (TabuleiroException e)
{
    Console.WriteLine(e.Message);
}