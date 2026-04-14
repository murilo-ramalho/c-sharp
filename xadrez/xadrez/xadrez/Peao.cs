using xadrez.tabuleiro;

namespace xadrez.xadrez;

public class Peao : Peca
{
    private PartidaXadrex partida;
    public Peao(Tabuleiro tabuleiro, Cor cor, PartidaXadrex partida) : base(tabuleiro, cor)
    {
        this.partida = partida;
    }

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
        if (Tabuleiro.posicaoValida(pos) && existeInimigo(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        // captura na diagonal direita
        pos.definirValores(Posicao.Linha + direcao, Posicao.Coluna + 1);
        if (Tabuleiro.posicaoValida(pos) && existeInimigo(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        // en passant (branco na linha 3; preto na linha 4)
        if ((Cor == Cor.Branco && Posicao.Linha == 3) || (Cor == Cor.Preto && Posicao.Linha == 4))
        {
            Posicao esquerdaAdj = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
            Posicao esquerdaCap = new Posicao(Posicao.Linha + direcao, Posicao.Coluna - 1);
            if (Tabuleiro.posicaoValida(esquerdaAdj) &&
                Tabuleiro.posicaoValida(esquerdaCap) &&
                existeInimigo(esquerdaAdj) &&
                Tabuleiro.peca(esquerdaAdj) == partida.vulneravelEnPassant)
            {
                mat[esquerdaCap.Linha, esquerdaCap.Coluna] = true;
            }

            Posicao direitaAdj = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
            Posicao direitaCap = new Posicao(Posicao.Linha + direcao, Posicao.Coluna + 1);
            if (Tabuleiro.posicaoValida(direitaAdj) &&
                Tabuleiro.posicaoValida(direitaCap) &&
                existeInimigo(direitaAdj) &&
                Tabuleiro.peca(direitaAdj) == partida.vulneravelEnPassant)
            {
                mat[direitaCap.Linha, direitaCap.Coluna] = true;
            }
        }

        

        return mat;
    }

    public override string ToString()
    {
        return "P";
    }
}
