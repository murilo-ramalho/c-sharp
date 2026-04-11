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
    public bool isXeque { get; private set; }
    private HashSet<Peca> pecas;
    private HashSet<Peca> capturadas;

    public PartidaXadrex()
    {
        Tabuleiro = new Tabuleiro(8, 8);
        Turno = 1;
        jogadorAtual = Cor.Branco;
        isTerminado = false;
        isXeque = false;
        pecas = new HashSet<Peca>();
        capturadas = new HashSet<Peca>();
        colocarPecas();
    }

    public Peca executaMovimento(Posicao origem, Posicao destino)
    {
        Peca p = Tabuleiro.retiraPeca(origem);
        p.incrementarQtaMovimentos();
        Peca pecaCapturada = Tabuleiro.retiraPeca(destino);
        Tabuleiro.colocarPeca(p, destino);
        if (pecaCapturada != null)
            capturadas.Add(pecaCapturada);
        
        return pecaCapturada;
    }

    public void realizaJogada(Posicao origem, Posicao destino)
    {
        Peca pecaCapturada = executaMovimento(origem, destino);

        if (estaEmXeque(jogadorAtual))
        {
            desfazMovimento(origem, destino, pecaCapturada);
            throw new TabuleiroException("Não é possivel um movimento que deixe em xeque!");
        }

        if (estaEmXeque(adiversaria(jogadorAtual)))
            isXeque = true;
        else 
            isXeque = false;

        if (estaEmXequeMate(adiversaria(jogadorAtual)))
        {
            isTerminado = true;
        }
        else
        {
            Turno++;
            mudaJogador();
        }
    }

    public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
    {
        Peca p = Tabuleiro.retiraPeca(destino);
        p.decrementarQtaMovimentos();
        if (pecaCapturada != null)
        {
            Tabuleiro.colocarPeca(pecaCapturada, destino);
            capturadas.Remove(pecaCapturada);
        }
        Tabuleiro.colocarPeca(p, origem);
    }

    public bool estaEmXequeMate(Cor cor)
    {
        if (!estaEmXeque(cor))
            return false;
        
        foreach (Peca item in pecasEmJogo(cor))
        {
            bool[,] mat = item.MovimentoPossivel();
            for (int i = 0; i < Tabuleiro.Linhas; i++)
            {
                for (int j = 0; j < Tabuleiro.Colunas; j++)
                {
                    if (mat[i,j])
                    {
                        Posicao destino = new Posicao(i,j);
                        Posicao origem = item.Posicao;
                        Peca pecaCapturada = executaMovimento(origem, destino);
                        bool testeXeque = estaEmXeque(cor);
                        desfazMovimento(origem, destino, pecaCapturada);
                        if (!testeXeque)
                            return false;
                    }
                }
            }
        }

        return true;
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
        if (!Tabuleiro.peca(origem).movimentoPossivel(destino))
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

    private Cor adiversaria(Cor cor)
    {
        if (cor == Cor.Branco)
            return Cor.Preto;
        else 
            return Cor.Branco;
    }

    private Peca ehRei(Cor cor)
    {
        foreach (Peca item in pecasEmJogo(cor))
        {
            if (item is Rei)
                return item;

        }

        throw new TabuleiroException("Não possui Rei da cor " + cor);
        isTerminado = true;
    }

    public bool estaEmXeque(Cor cor)
    {
        Peca rei = ehRei(cor);

        foreach (Peca item in pecasEmJogo(adiversaria(cor)))
        {
            bool[,] mat = item.MovimentoPossivel();
            if (mat[rei.Posicao.Linha, rei.Posicao.Coluna])
            {
                return true;
            }
        }

        return false;
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
        colocarNovaPeca('b', 1, new Cavalo(Tabuleiro, Cor.Branco));
        colocarNovaPeca('c', 1, new Bispo(Tabuleiro, Cor.Branco));
        colocarNovaPeca('d', 1, new Dama(Tabuleiro, Cor.Branco));
        colocarNovaPeca('e', 1, new Rei(Tabuleiro, Cor.Branco));
        colocarNovaPeca('f', 1, new Bispo(Tabuleiro, Cor.Branco));
        colocarNovaPeca('g', 1, new Cavalo(Tabuleiro, Cor.Branco));
        colocarNovaPeca('h', 1, new Torre(Tabuleiro, Cor.Branco));

        colocarNovaPeca('a', 2, new Peao(Tabuleiro, Cor.Branco));
        colocarNovaPeca('b', 2, new Peao(Tabuleiro, Cor.Branco));
        colocarNovaPeca('c', 2, new Peao(Tabuleiro, Cor.Branco));
        colocarNovaPeca('d', 2, new Peao(Tabuleiro, Cor.Branco));
        colocarNovaPeca('e', 2, new Peao(Tabuleiro, Cor.Branco));
        colocarNovaPeca('f', 2, new Peao(Tabuleiro, Cor.Branco));
        colocarNovaPeca('g', 2, new Peao(Tabuleiro, Cor.Branco));
        colocarNovaPeca('h', 2, new Peao(Tabuleiro, Cor.Branco));

        colocarNovaPeca('a', 8, new Torre(Tabuleiro, Cor.Preto));
        colocarNovaPeca('b', 8, new Cavalo(Tabuleiro, Cor.Preto));
        colocarNovaPeca('c', 8, new Bispo(Tabuleiro, Cor.Preto));
        colocarNovaPeca('d', 8, new Dama(Tabuleiro, Cor.Preto));
        colocarNovaPeca('e', 8, new Rei(Tabuleiro, Cor.Preto));
        colocarNovaPeca('f', 8, new Bispo(Tabuleiro, Cor.Preto));
        colocarNovaPeca('g', 8, new Cavalo(Tabuleiro, Cor.Preto));
        colocarNovaPeca('h', 8, new Torre(Tabuleiro, Cor.Preto));

        colocarNovaPeca('a', 7, new Peao(Tabuleiro, Cor.Preto));
        colocarNovaPeca('b', 7, new Peao(Tabuleiro, Cor.Preto));
        colocarNovaPeca('c', 7, new Peao(Tabuleiro, Cor.Preto));
        colocarNovaPeca('d', 7, new Peao(Tabuleiro, Cor.Preto));
        colocarNovaPeca('e', 7, new Peao(Tabuleiro, Cor.Preto));
        colocarNovaPeca('f', 7, new Peao(Tabuleiro, Cor.Preto));
        colocarNovaPeca('g', 7, new Peao(Tabuleiro, Cor.Preto));
        colocarNovaPeca('h', 7, new Peao(Tabuleiro, Cor.Preto));
    }
}
