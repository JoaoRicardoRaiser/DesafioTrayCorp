using System;

namespace ProdutoCrud.Dados.Entidades
{
    public class Produto : EntidadeBase
    {
        public string Nome { get; set; }
        public int Estoque { get; set; }
        public decimal Valor { get; set; }

        public Produto(string nome, int estoque, decimal valor)
        {
            Nome = nome;
            Estoque = estoque;
            Valor = valor;
        }

        public void Update(int estoque, decimal valor)
        {
            Estoque = estoque;
            Valor = valor;
            DataHoraAlteracao = DateTime.Now;
        }
    }
}
