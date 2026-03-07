using xadrez;
using xadrez.tabuleiro;
using xadrez.jogo;
using xadrez.exceptions;
try
{
    Tabuleiro tabuleiro = new Tabuleiro(8,8);
    tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preto), new Posicao(0,0));
    tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preto), new Posicao(0,9));
    tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.Preto), new Posicao(0,0));
    Tela.imprimirTabuleiro(tabuleiro);
} catch (TabuleiroException e)
{
    System.Console.WriteLine(e.Message);
}


