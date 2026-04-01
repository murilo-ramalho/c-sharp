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
        try
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Tela.imprimirTabuleiro(partida.Tabuleiro);
            Console.WriteLine();
            Console.WriteLine("Aguardando: " + partida.jogadorAtual);

            Console.WriteLine();
            Console.WriteLine("Origem: ");

            Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
            partida.validarPosicaoOrigem(origem); 
            
            Console.Clear();
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
