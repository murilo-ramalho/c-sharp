using xadrez.tabuleiro;

namespace xadrez.xadrez;

public class Dama : Peca
{
    public Dama(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) { }

    public override bool[,] MovimentoPossivel()
    {
        bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
        if (Posicao == null)
        {
            return mat;
        }

        Posicao pos = new Posicao(0, 0);

        // vertical e horizontal
        pos.definirValores(Posicao.Linha - 1, Posicao.Coluna);
        while (Tabuleiro.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (Tabuleiro.peca(pos) != null && Tabuleiro.peca(pos).Cor != Cor)
            {
                break;
            }
            pos.Linha--;
        }

        pos.definirValores(Posicao.Linha + 1, Posicao.Coluna);
        while (Tabuleiro.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (Tabuleiro.peca(pos) != null && Tabuleiro.peca(pos).Cor != Cor)
            {
                break;
            }
            pos.Linha++;
        }

        pos.definirValores(Posicao.Linha, Posicao.Coluna - 1);
        while (Tabuleiro.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (Tabuleiro.peca(pos) != null && Tabuleiro.peca(pos).Cor != Cor)
            {
                break;
            }
            pos.Coluna--;
        }

        pos.definirValores(Posicao.Linha, Posicao.Coluna + 1);
        while (Tabuleiro.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (Tabuleiro.peca(pos) != null && Tabuleiro.peca(pos).Cor != Cor)
            {
                break;
            }
            pos.Coluna++;
        }

        // diagonais
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
        return "Q";
    }

    private bool podeMover(Posicao pos)
    {
        Peca p = Tabuleiro.peca(pos);
        return p == null || p.Cor != Cor;
    }
}
