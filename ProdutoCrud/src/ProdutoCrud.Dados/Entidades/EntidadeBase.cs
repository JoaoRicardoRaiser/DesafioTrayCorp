using System;

namespace ProdutoCrud.Dados.Entidades
{
    public class EntidadeBase
    {
        public int Id { get; set; }
        public DateTime DataHoraGeracao { get; set; } = DateTime.Now;
        public DateTime DataHoraAlteracao { get; set; } = DateTime.Now;
    }
}
