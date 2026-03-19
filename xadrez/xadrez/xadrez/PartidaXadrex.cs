using System;
using System.Runtime.CompilerServices;
using xadrez.tabuleiro;

namespace xadrez.xadrez;

public class PartidaXadrex
{
    public Tabuleiro Tabuleiro {get; private set;}
    private int Turno;
    private Cor jogadorAtual;

    public PartidaXadrex()
    {
        Tabuleiro = new Tabuleiro(8, 8);
        Turno = 1;
        jogadorAtual = Cor.Branco;
        colocarPecas();
    }

    public void executaMovimento(Posicao origem, Posicao destino)
    {
        Peca p = Tabuleiro.retiraPeca(origem);
        p.incrementarQtaMovimentos();
        Peca pecaCapturada = Tabuleiro.retiraPeca(destino);
        Tabuleiro.colocarPeca(p, destino);
    }

    private void colocarPecas()
    {
        Tabuleiro.colocarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('a', 1).toPosicao());
        Tabuleiro.colocarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('h', 1).toPosicao());
        Tabuleiro.colocarPeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('a', 8).toPosicao());
        Tabuleiro.colocarPeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('h', 8).toPosicao());
    }
}
