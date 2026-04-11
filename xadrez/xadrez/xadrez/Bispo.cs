using xadrez.tabuleiro;

namespace xadrez.xadrez;

public class Bispo : Peca
{
    public Bispo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) { }

    public override bool[,] MovimentoPossivel()
    {
        bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
        if (Posicao == null)
        {
            return mat;
        }

        Posicao pos = new Posicao(0, 0);

        // noroeste
        pos.definirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
        while (Tabuleiro.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (Tabuleiro.peca(pos) != null && Tabuleiro.peca(pos).Cor != Cor)
            {
                break;
            }
            pos.Linha--;
            pos.Coluna--;
        }

        // nordeste
        pos.definirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
        while (Tabuleiro.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (Tabuleiro.peca(pos) != null && Tabuleiro.peca(pos).Cor != Cor)
            {
                break;
            }
            pos.Linha--;
            pos.Coluna++;
        }

        // sudeste
        pos.definirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
        while (Tabuleiro.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (Tabuleiro.peca(pos) != null && Tabuleiro.peca(pos).Cor != Cor)
            {
                break;
            }
            pos.Linha++;
            pos.Coluna++;
        }

        // sudoeste
        pos.definirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
        while (Tabuleiro.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (Tabuleiro.peca(pos) != null && Tabuleiro.peca(pos).Cor != Cor)
            {
                break;
            }
            pos.Linha++;
            pos.Coluna--;
        }

        return mat;
    }

    public override string ToString()
    {
        return "B";
    }

    private bool podeMover(Posicao pos)
    {
        Peca p = Tabuleiro.peca(pos);
        return p == null || p.Cor != Cor;
    }
}
