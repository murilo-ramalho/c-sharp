using System;
using xadrez.xadrez;

namespace xadrez.tabuleiro;

public class Torre : Peca
{
    public Torre(Tabuleiro tab, Cor cor) : base(tab,cor) {}

    public override string ToString()
    {
        return "T";
    }
}
