using xadrez.tabuleiro;

namespace xadrez.xadrez;

public class Cavalo : Peca
{
    public Cavalo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) { }

    public override bool[,] MovimentoPossivel()
    {
        bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
        if (Posicao == null)
        {
            return mat;
        }

        Posicao pos = new Posicao(0, 0);
        int[,] movimentos = new int[,]
        {
            { -2, -1 }, { -2, 1 },
            { -1, -2 }, { -1, 2 },
            { 1, -2 }, { 1, 2 },
            { 2, -1 }, { 2, 1 }
        };

        for (int i = 0; i < movimentos.GetLength(0); i++)
        {
            pos.definirValores(Posicao.Linha + movimentos[i, 0], Posicao.Coluna + movimentos[i, 1]);
            if (Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
        }

        return mat;
    }

    public override string ToString()
    {
        return "C";
    }

    private bool podeMover(Posicao pos)
    {
        Peca p = Tabuleiro.peca(pos);
        return p == null || p.Cor != Cor;
    }
}
