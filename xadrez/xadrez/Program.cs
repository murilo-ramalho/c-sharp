using xadrez;
using xadrez.tabuleiro;
using xadrez.jogo;

Tabuleiro tabuleiro = new Tabuleiro(8,8);
tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preto), new Posicao(0,0));
tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preto), new Posicao(0,7));
tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.Preto), new Posicao(0,3));


Tela.imprimirTabuleiro(tabuleiro);