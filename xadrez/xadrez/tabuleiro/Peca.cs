using System;
namespace xadrez.tabuleiro;

public class Peca
{
public Posicao Posicao { get; set; }
public Cor Cor { get; protected set; }
public Tabuleiro Tabuleiro { get; protected set; }
public int qtdMovimentos { get; protected set; }

public Peca(Tabuleiro tabuleiro, Cor cor)
    {
        this.Posicao = null;
        this.Cor = Cor;
        this.Tabuleiro = tabuleiro;
        this.qtdMovimentos = 0;
    }
}
