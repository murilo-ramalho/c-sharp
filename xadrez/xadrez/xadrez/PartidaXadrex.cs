using System;
using System.Runtime.CompilerServices;
using xadrez.exceptions;
using xadrez.tabuleiro;
using System.Collections.Generic;

namespace xadrez.xadrez;

public class PartidaXadrex
{
    public Tabuleiro Tabuleiro {get; private set; }
    public int Turno { get; private set; }
    public Cor jogadorAtual { get; private set; }
    public bool isTerminado { get; private set; }
    private HashSet<Peca> pecas;
    private HashSet<Peca> capturadas;

    public PartidaXadrex()
    {
        Tabuleiro = new Tabuleiro(8, 8);
        Turno = 1;
        jogadorAtual = Cor.Branco;
        isTerminado = false;
        pecas = new HashSet<Peca>();
        capturadas = new HashSet<Peca>();
        colocarPecas();
    }

    public void executaMovimento(Posicao origem, Posicao destino)
    {
        Peca p = Tabuleiro.retiraPeca(origem);
        p.incrementarQtaMovimentos();
        Peca pecaCapturada = Tabuleiro.retiraPeca(destino);
        Tabuleiro.colocarPeca(p, destino);
        if (pecaCapturada != null)
            capturadas.Add(pecaCapturada);
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

    public void colocarNovaPeca(char col, int lin, Peca peca)
    {
        Tabuleiro.colocarPeca(peca, new PosicaoXadrez(col, lin).toPosicao());
        pecas.Add(peca);
    }

    public HashSet<Peca> pecasCapturadas(Cor cor)
    {
        HashSet<Peca> aux = new HashSet<Peca>();
        foreach (Peca x in capturadas)
        {
            if (x.Cor == cor)
            {
                aux.Add(x);
            }
        }
        return aux;
    }
    
    public HashSet<Peca> pecasEmJogo(Cor cor)
    {
        HashSet<Peca> aux = new HashSet<Peca>();
        foreach (Peca x in pecas)
        {
            if (x.Cor == cor)
            {
                aux.Add(x);
            }
        }
        aux.ExceptWith(pecasCapturadas(cor));
        return aux;
    }

    private void colocarPecas()
    {
        colocarNovaPeca('a', 1, new Torre(Tabuleiro, Cor.Branco));
        colocarNovaPeca('h', 1, new Torre(Tabuleiro, Cor.Branco));
        colocarNovaPeca('a', 8, new Torre(Tabuleiro, Cor.Preto));
        colocarNovaPeca('h', 8, new Torre(Tabuleiro, Cor.Preto));
    }
}
