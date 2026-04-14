using System;
namespace xadrez.tabuleiro;

public abstract class Peca
{
    public Posicao Posicao { get; set; }
    public Cor Cor { get; protected set; }
    public Tabuleiro Tabuleiro { get; protected set; }
    public int qtdMovimentos { get; protected set; }

    public Peca(Tabuleiro tabuleiro, Cor cor)
    {
        this.Posicao = null;
        this.Cor = cor;
        this.Tabuleiro = tabuleiro;
        this.qtdMovimentos = 0;
    }

    public bool existeMovimentoPossiveis()
    {
        bool[,] mat = MovimentoPossivel();
        for (int i = 0; i < Tabuleiro.Linhas; i++)
        {
            for (int j = 0; j < Tabuleiro.Colunas; j++)
            {
                if (mat[i,j])
                    return true;
            }
        }
        return false;
    }

    public bool movimentoPossivel(Posicao pos)
    {
        return MovimentoPossivel()[pos.Linha, pos.Coluna];
    }

    protected bool existeInimigo(Posicao pos)
    {
        Peca p = Tabuleiro.peca(pos);
        return p != null && p.Cor != Cor;
    }

    public void incrementarQtaMovimentos()
    {
        qtdMovimentos++;
    }

    public void decrementarQtaMovimentos()
    {
        qtdMovimentos--;
    }

    public abstract bool[,] MovimentoPossivel();
}
