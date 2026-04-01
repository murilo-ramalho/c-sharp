using System;
using System.Runtime.CompilerServices;
using xadrez.exceptions;
using xadrez.tabuleiro;

namespace xadrez.xadrez;

public class PartidaXadrex
{
    public Tabuleiro Tabuleiro {get; private set; }
    public int Turno { get; private set; }
    public Cor jogadorAtual { get; private set; }
    public bool isTerminado { get; private set; }

    public PartidaXadrex()
    {
        Tabuleiro = new Tabuleiro(8, 8);
        Turno = 1;
        jogadorAtual = Cor.Branco;
        isTerminado = false;
        colocarPecas();
    }

    public void executaMovimento(Posicao origem, Posicao destino)
    {
        Peca p = Tabuleiro.retiraPeca(origem);
        p.incrementarQtaMovimentos();
        Peca pecaCapturada = Tabuleiro.retiraPeca(destino);
        Tabuleiro.colocarPeca(p, destino);
    }

    public void realizaJogada(Posicao origem, Posicao destino)
    {
        executaMovimento(origem, destino);
        Turno++;
        mudaJogador();
    }

    public void validarPosicaoOrigem(Posicao pos)
    {
        if (Tabuleiro.peca(pos) == null)
            throw new TabuleiroException("Não existe peça na posição escolhida");

        if (jogadorAtual != Tabuleiro.peca(pos).Cor)
            throw new TabuleiroException("A peça não é sua");

        if (!Tabuleiro.peca(pos).existeMovimentoPossiveis())
            throw new TabuleiroException("Não há movimentos possivéis");
    }

    public void validarPosicaoDestino(Posicao origem, Posicao destino)
    {
        if (!Tabuleiro.peca(origem).podeMover(destino))
            throw new TabuleiroException("Posição de jogada Invalida");    
    }

    private void mudaJogador()
    {
        if(jogadorAtual == Cor.Branco)
        {
            jogadorAtual = Cor.Preto;
            return;
        }

        jogadorAtual = Cor.Branco;
    }

    private void colocarPecas()
    {
        Tabuleiro.colocarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('a', 1).toPosicao());
        Tabuleiro.colocarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('h', 1).toPosicao());
        Tabuleiro.colocarPeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('a', 8).toPosicao());
        Tabuleiro.colocarPeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('h', 8).toPosicao());
    }
}
