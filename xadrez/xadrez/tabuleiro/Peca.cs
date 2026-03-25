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

    public void incrementarQtaMovimentos()
    {
        qtdMovimentos++;
    }

    public abstract bool[,] MovimentoPossivel();
}
