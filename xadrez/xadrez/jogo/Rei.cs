using System;
using xadrez.tabuleiro;

namespace xadrez.jogo;

public class Rei : Peca
{
    public Rei(Tabuleiro tab, Cor cor) : base(tab,cor) {}

    public override string ToString()
    {
        return "R";
    }
}
