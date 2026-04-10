using System;
using xadrez.tabuleiro;

namespace xadrez.xadrez;

public class Rei : Peca
{
    public Rei(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro,cor) {}

    private bool podeMover(Posicao pos)
    {
        Peca p = Tabuleiro.peca(pos);
        return p == null || p.Cor != this.Cor;
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

        return mat;
    }

    public override string ToString()
    {
        return "R";
    }

}
