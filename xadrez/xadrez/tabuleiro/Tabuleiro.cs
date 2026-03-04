using System;
using System.Linq.Expressions;

namespace xadrez.tabuleiro;

public class Tabuleiro
{
    public int Linhas { get; set; }
    public int Colunas { get; set; }
    private Peca[,] Pecas;

    public Tabuleiro(int linhas, int colunas)
        {
            this.Linhas = linhas;
            this.Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }

     public Peca peca(int linha, int coluna)
    {
        return Pecas[linha,coluna];
    }

    public void colocarPeca(Peca p, Posicao pos)
    {
        if (pos.Linha > 7 || pos.Coluna > 7)
            throw new Exception("burro");

        Pecas[pos.Linha, pos.Coluna] = p;
        p.Posicao = pos;
    }
}
