using System;
using xadrez.xadrez;

namespace xadrez.tabuleiro;

public class Torre : Peca
{
    public Torre(Tabuleiro tab, Cor cor) : base(tab,cor) {}

    public override bool[,] MovimentoPossivel()
    {
        bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
        Posicao pos = new Posicao(0, 0);

        // acima
        pos.definirValores(Posicao.Linha -1, Posicao.Coluna);
        while (Tabuleiro.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if(Tabuleiro.peca(pos) != null && Tabuleiro.peca(pos).Cor != Cor)
            {
                break;
            }
            pos.Linha--;
        }

        // abaixo
        pos.definirValores(Posicao.Linha +1, Posicao.Coluna);
        while (Tabuleiro.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if(Tabuleiro.peca(pos) != null && Tabuleiro.peca(pos).Cor != Cor)
            {
                break;
            }
            pos.Linha++;
        }

        // esquerda
        pos.definirValores(Posicao.Linha, Posicao.Coluna -1);
        while (Tabuleiro.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if(Tabuleiro.peca(pos) != null && Tabuleiro.peca(pos).Cor != Cor)
            {
                break;
            }
            pos.Coluna--;
        }

        // direita
        pos.definirValores(Posicao.Linha, Posicao.Coluna +1);
        while (Tabuleiro.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if(Tabuleiro.peca(pos) != null && Tabuleiro.peca(pos).Cor != Cor)
            {
                break;
            }
            pos.Coluna++;
        }

        return mat;
    }

    public override string ToString()
    {
        return "T";
    }

     private bool podeMover(Posicao pos)
    {
        Peca p = Tabuleiro.peca(pos);
        return p != null || p.Cor != this.Cor;
    }
}
