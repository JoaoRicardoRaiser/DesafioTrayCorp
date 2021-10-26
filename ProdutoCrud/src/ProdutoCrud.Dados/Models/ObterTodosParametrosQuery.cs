using System.Collections.Generic;

namespace ProdutoCrud.Dados.Models
{
    public class ObterTodosParametrosQuery
    {
        public List<string> Nomes { get; set; }
        public string CampoOrdenacao { get; set; }
        public bool OrdemAsc { get; set; }

        public bool TemNomes()
        {
            return Nomes?.Count > 0;
        }
    }
}
