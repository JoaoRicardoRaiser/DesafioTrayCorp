using System;
using System.ComponentModel.DataAnnotations;

namespace ProdutoCrud.Dados.Model
{
    public class UpdateProdutoModel
    {
        [Required]
        public int Estoque { get; set; }
        private decimal _valor { get; set; }
        [Required]
        public decimal Valor
        {
            get
            {
                return _valor;
            }
            set => _valor = value >= 0 ? value : throw new ArgumentOutOfRangeException("Apenas valores positivos são permitidos");
        }
    }
}
