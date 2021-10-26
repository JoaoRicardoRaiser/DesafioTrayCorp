using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutoCrud.Dados.Entidades;

namespace ProdutoCrud.Dados.Mapeamento
{
    class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome);
            builder.Property(p => p.Estoque);
            builder.Property(p => p.Valor);
            builder.Property(p => p.DataHoraGeracao);
            builder.Property(p => p.DataHoraAlteracao);
        }
    }
}
