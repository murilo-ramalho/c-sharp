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
        while (Tabuleiro.posicaoValida(pos) && podeMoverPara(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (existeInimigo(pos))
            {
                break;
            }
            pos.Linha--;
        }

        // abaixo
        pos.definirValores(Posicao.Linha +1, Posicao.Coluna);
        while (Tabuleiro.posicaoValida(pos) && podeMoverPara(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (existeInimigo(pos))
            {
                break;
            }
            pos.Linha++;
        }

        // esquerda
        pos.definirValores(Posicao.Linha, Posicao.Coluna -1);
        while (Tabuleiro.posicaoValida(pos) && podeMoverPara(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (existeInimigo(pos))
            {
                break;
            }
            pos.Coluna--;
        }

        // direita
        pos.definirValores(Posicao.Linha, Posicao.Coluna +1);
        while (Tabuleiro.posicaoValida(pos) && podeMoverPara(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (existeInimigo(pos))
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

    private bool podeMoverPara(Posicao pos)
    {
        return Tabuleiro.peca(pos) == null || existeInimigo(pos);
    }
}
