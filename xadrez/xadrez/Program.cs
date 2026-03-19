using xadrez;
using xadrez.tabuleiro;
using xadrez.xadrez;
using xadrez.exceptions;

try
{
    Tabuleiro tabuleiro = new Tabuleiro(8,8);
    tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Branco), new Posicao(0,0));
    tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Branco), new Posicao(0,7));
    tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.Branco), new Posicao(0,3));

    tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preto), new Posicao(7, 7));
    tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preto), new Posicao(7, 0));

    Tela.imprimirTabuleiro(tabuleiro);
} catch (TabuleiroException e)
{
    System.Console.WriteLine(e.Message);
}


