using xadrez;
using xadrez.tabuleiro;
using xadrez.xadrez;
using xadrez.exceptions;

try
{
    PartidaXadrex partida = new PartidaXadrex();
    
    Tela.imprimirTabuleiro(partida.Tabuleiro);
} catch (TabuleiroException e)
{
    System.Console.WriteLine(e.Message);
}


