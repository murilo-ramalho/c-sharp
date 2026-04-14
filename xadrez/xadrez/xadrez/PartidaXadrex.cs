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
    public Peca vulneravelEnPassant {get; private set;}
    private HashSet<Peca> pecas;
    private HashSet<Peca> capturadas;
    private Stack<PromocaoInfo> promocoes;

    private class PromocaoInfo
    {
        public Peca Peao { get; set; }
        public Peca NovaPeca { get; set; }
        public Posicao Destino { get; set; }
    }

    public PartidaXadrex()
    {
        Tabuleiro = new Tabuleiro(8, 8);
        Turno = 1;
        jogadorAtual = Cor.Branco;
        isTerminado = false;
        isXeque = false;
        pecas = new HashSet<Peca>();
        capturadas = new HashSet<Peca>();
        promocoes = new Stack<PromocaoInfo>();
        vulneravelEnPassant = null;
        colocarPecas();
    }

    private bool devePromover(Peca peca, Posicao destino)
    {
        if (peca is not Peao)
            return false;

        return (peca.Cor == Cor.Branco && destino.Linha == 0) ||
               (peca.Cor == Cor.Preto && destino.Linha == 7);
    }

    private void promoverPeao(Posicao destino)
    {
        Peca peao = Tabuleiro.retiraPeca(destino);
        if (peao == null)
            return;

        pecas.Remove(peao);
        Peca novaPeca = new Dama(Tabuleiro, peao.Cor);
        Tabuleiro.colocarPeca(novaPeca, destino);
        pecas.Add(novaPeca);

        promocoes.Push(new PromocaoInfo
        {
            Peao = peao,
            NovaPeca = novaPeca,
            Destino = destino
        });
    }

    public Peca executaMovimento(Posicao origem, Posicao destino)
    {
        Peca p = Tabuleiro.retiraPeca(origem);
        p.incrementarQtaMovimentos();
        Peca pecaCapturada = Tabuleiro.retiraPeca(destino);
        Tabuleiro.colocarPeca(p, destino);
        if (pecaCapturada != null)
            capturadas.Add(pecaCapturada);

        // jogada especial en passant
        if (p is Peao && origem.Coluna != destino.Coluna && pecaCapturada == null)
        {
            Posicao posPeao;
            if (p.Cor == Cor.Branco)
                posPeao = new Posicao(destino.Linha + 1, destino.Coluna);
            else
                posPeao = new Posicao(destino.Linha - 1, destino.Coluna);

            pecaCapturada = Tabuleiro.retiraPeca(posPeao);
            if (pecaCapturada != null)
                capturadas.Add(pecaCapturada);
        }
        
        // jogada especial roque pequeno
        if(p is Rei && destino.Coluna == origem.Coluna + 2)
        {
            Posicao origemT = new Posicao(origem.Linha, origem.Coluna + 3);
            Posicao destinoT = new Posicao(origem.Linha, origem.Coluna + 1);
            Peca T = Tabuleiro.retiraPeca(origemT);
            T.incrementarQtaMovimentos();
            Tabuleiro.colocarPeca(T, destinoT);
        }

        // jogada especial roque grande
        if(p is Rei && destino.Coluna == origem.Coluna - 2)
        {
            Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
            Posicao destinoT = new Posicao(origem.Linha, origem.Coluna - 1);
            Peca T = Tabuleiro.retiraPeca(origemT);
            T.incrementarQtaMovimentos();
            Tabuleiro.colocarPeca(T, destinoT);
        }

        // promocao
        if (devePromover(p, destino))
        {
            promoverPeao(destino);
        }

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

        // en passant
        Peca p = Tabuleiro.peca(destino);
        if (p is Peao && (destino.Linha == origem.Linha -2 || 
            destino.Linha == origem.Linha +2))
        {
            vulneravelEnPassant = p;
        }
        else
        {
            vulneravelEnPassant = null;
        }

        // a pilha so eh usada para desfazer jogadas; em jogadas validas, descarta o registro
        promocoes.Clear();
    }

    public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
    {
        Peca p = Tabuleiro.retiraPeca(destino);

        // desfaz promocao
        if (promocoes.Count > 0)
        {
            PromocaoInfo promocao = promocoes.Peek();
            if (promocao.NovaPeca == p && promocao.Destino.Linha == destino.Linha && promocao.Destino.Coluna == destino.Coluna)
            {
                promocoes.Pop();
                pecas.Remove(p);
                p = promocao.Peao;
                pecas.Add(p);
            }
        }

        p.decrementarQtaMovimentos();
        // desfaz en passant (captura foi "ao lado", nao no destino)
        if (p is Peao && origem.Coluna != destino.Coluna && pecaCapturada != null && pecaCapturada == vulneravelEnPassant)
        {
            Posicao posPeao;
            if (p.Cor == Cor.Branco)
                posPeao = new Posicao(destino.Linha + 1, destino.Coluna);
            else
                posPeao = new Posicao(destino.Linha - 1, destino.Coluna);

            Tabuleiro.colocarPeca(pecaCapturada, posPeao);
            capturadas.Remove(pecaCapturada);
        }
        else if (pecaCapturada != null)
        {
            Tabuleiro.colocarPeca(pecaCapturada, destino);
            capturadas.Remove(pecaCapturada);
        }
        Tabuleiro.colocarPeca(p, origem);

        // jogada especial roque pequeno
        if(p is Rei && destino.Coluna == origem.Coluna + 2)
        {
            Posicao origemT = new Posicao(origem.Linha, origem.Coluna + 3);
            Posicao destinoT = new Posicao(origem.Linha, origem.Coluna + 1);
            Peca T = Tabuleiro.retiraPeca(destinoT);
            T.incrementarQtaMovimentos();
            Tabuleiro.colocarPeca(T, origemT);
        }

        // jogada especial roque grande
        if(p is Rei && destino.Coluna == origem.Coluna - 2)
        {
            Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
            Posicao destinoT = new Posicao(origem.Linha, origem.Coluna - 1);
            Peca T = Tabuleiro.retiraPeca(destinoT);
            T.incrementarQtaMovimentos();
            Tabuleiro.colocarPeca(T, origemT);
        }
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
        colocarNovaPeca('e', 1, new Rei(Tabuleiro, Cor.Branco, this));
        colocarNovaPeca('f', 1, new Bispo(Tabuleiro, Cor.Branco));
        colocarNovaPeca('g', 1, new Cavalo(Tabuleiro, Cor.Branco));
        colocarNovaPeca('h', 1, new Torre(Tabuleiro, Cor.Branco));

        colocarNovaPeca('a', 2, new Peao(Tabuleiro, Cor.Branco, this));
        colocarNovaPeca('b', 2, new Peao(Tabuleiro, Cor.Branco, this));
        colocarNovaPeca('c', 2, new Peao(Tabuleiro, Cor.Branco, this));
        colocarNovaPeca('d', 2, new Peao(Tabuleiro, Cor.Branco, this));
        colocarNovaPeca('e', 2, new Peao(Tabuleiro, Cor.Branco, this));
        colocarNovaPeca('f', 2, new Peao(Tabuleiro, Cor.Branco, this));
        colocarNovaPeca('g', 2, new Peao(Tabuleiro, Cor.Branco, this));
        colocarNovaPeca('h', 2, new Peao(Tabuleiro, Cor.Branco, this));

        colocarNovaPeca('a', 8, new Torre(Tabuleiro, Cor.Preto));
        colocarNovaPeca('b', 8, new Cavalo(Tabuleiro, Cor.Preto));
        colocarNovaPeca('c', 8, new Bispo(Tabuleiro, Cor.Preto));
        colocarNovaPeca('d', 8, new Dama(Tabuleiro, Cor.Preto));
        colocarNovaPeca('e', 8, new Rei(Tabuleiro, Cor.Preto, this));
        colocarNovaPeca('f', 8, new Bispo(Tabuleiro, Cor.Preto));
        colocarNovaPeca('g', 8, new Cavalo(Tabuleiro, Cor.Preto));
        colocarNovaPeca('h', 8, new Torre(Tabuleiro, Cor.Preto));

        colocarNovaPeca('a', 7, new Peao(Tabuleiro, Cor.Preto, this));
        colocarNovaPeca('b', 7, new Peao(Tabuleiro, Cor.Preto, this));
        colocarNovaPeca('c', 7, new Peao(Tabuleiro, Cor.Preto, this));
        colocarNovaPeca('d', 7, new Peao(Tabuleiro, Cor.Preto, this));
        colocarNovaPeca('e', 7, new Peao(Tabuleiro, Cor.Preto, this));
        colocarNovaPeca('f', 7, new Peao(Tabuleiro, Cor.Preto, this));
        colocarNovaPeca('g', 7, new Peao(Tabuleiro, Cor.Preto, this));
        colocarNovaPeca('h', 7, new Peao(Tabuleiro, Cor.Preto, this));
    }
}
