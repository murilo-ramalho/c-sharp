using System;
using xadrez.tabuleiro;

namespace xadrez.xadrez;

public class Rei : Peca
{
    public Rei(Tabuleiro tabuleiro, Cor cor, PartidaXadrex partida) : base(tabuleiro,cor)
    {
        this.partida = partida;
    }
    private PartidaXadrex partida;

    private bool podeMover(Posicao pos)
    {
        Peca p = Tabuleiro.peca(pos);
        return p == null || p.Cor != this.Cor;
    }
    private bool testeTorreRoque(Posicao pos)
    {
        Peca p = Tabuleiro.peca(pos);
        return p != null && p is Torre && p.Cor == Cor && p.qtdMovimentos == 0;
    }
    public override bool[,] MovimentoPossivel()
    {
        bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
        if (Posicao == null)
        {
            return mat;
        }
        Posicao pos = new Posicao(0, 0);

        // acima
        pos.definirValores(Posicao.Linha -1, Posicao.Coluna);
        if(Tabuleiro.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        // abaixo
        pos.definirValores(Posicao.Linha +1, Posicao.Coluna);
        if(Tabuleiro.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        // esquerda
        pos.definirValores(Posicao.Linha, Posicao.Coluna -1);
        if(Tabuleiro.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        // direita
        pos.definirValores(Posicao.Linha, Posicao.Coluna +1);
        if(Tabuleiro.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        // nordeste
        pos.definirValores(Posicao.Linha -1, Posicao.Coluna +1);
        if(Tabuleiro.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        // sudeste
        pos.definirValores(Posicao.Linha +1, Posicao.Coluna +1);
        if(Tabuleiro.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        // sudoeste
        pos.definirValores(Posicao.Linha +1, Posicao.Coluna -1);
        if(Tabuleiro.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        // noroeste
        pos.definirValores(Posicao.Linha -1, Posicao.Coluna -1);
        if(Tabuleiro.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        // especial roque
        if(qtdMovimentos==0 && !partida.isXeque)
        {
            // roque pequeno
            Posicao posT1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
            if(testeTorreRoque(posT1))
            {
                Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
                if (Tabuleiro.peca(p1) == null && Tabuleiro.peca(p2) == null)
                {
                    mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                }
            }
        }

        return mat;
    }

    public override string ToString()
    {
        return "R";
    }

}
