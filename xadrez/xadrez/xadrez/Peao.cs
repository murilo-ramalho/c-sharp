using xadrez.tabuleiro;

namespace xadrez.xadrez;

public class Peao : Peca
{
    public Peao(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) { }

    public override bool[,] MovimentoPossivel()
    {
        bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
        if (Posicao == null)
        {
            return mat;
        }

        Posicao pos = new Posicao(0, 0);
        int direcao = Cor == Cor.Branco ? -1 : 1;

        // movimento simples
        pos.definirValores(Posicao.Linha + direcao, Posicao.Coluna);
        if (Tabuleiro.posicaoValida(pos) && Tabuleiro.peca(pos) == null)
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        // movimento duplo inicial
        pos.definirValores(Posicao.Linha + (2 * direcao), Posicao.Coluna);
        Posicao frente = new Posicao(Posicao.Linha + direcao, Posicao.Coluna);
        if (qtdMovimentos == 0 && Tabuleiro.posicaoValida(pos) && Tabuleiro.posicaoValida(frente) && Tabuleiro.peca(frente) == null && Tabuleiro.peca(pos) == null)
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        // captura na diagonal esquerda
        pos.definirValores(Posicao.Linha + direcao, Posicao.Coluna - 1);
        if (Tabuleiro.posicaoValida(pos) && temAdversaria(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        // captura na diagonal direita
        pos.definirValores(Posicao.Linha + direcao, Posicao.Coluna + 1);
        if (Tabuleiro.posicaoValida(pos) && temAdversaria(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        return mat;
    }

    public override string ToString()
    {
        return "P";
    }

    private bool temAdversaria(Posicao pos)
    {
        Peca p = Tabuleiro.peca(pos);
        return p != null && p.Cor != Cor;
    }
}
