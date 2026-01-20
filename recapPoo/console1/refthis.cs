using System.Globalization;

namespace console1
{
    class Produto
    {
        public string Nome;
        public double Preco;
        public int Qtd;

#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere adicionar o modificador "obrigatório" ou declarar como anulável.
        public Produto()
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere adicionar o modificador "obrigatório" ou declarar como anulável.
        {
            Qtd = 1;
        }

        public Produto(string nome, double preco) : this()
        {
            Nome = nome;
            Preco = preco;
        }

        public Produto(string nome, double preco, int qtd) : this(nome, preco)
        {
            Qtd = qtd;
        }
    }
}