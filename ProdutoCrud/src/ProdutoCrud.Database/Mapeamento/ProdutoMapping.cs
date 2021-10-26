using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutoCrud.Dados.Entidades;

namespace ProdutoCrud.Dados.Mapeamento
{
    class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produto");
            builder.HasKey(p => p.Id).HasName("id");
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Nome).HasColumnName("nome");
            builder.Property(p => p.Estoque).HasColumnName("estoque");
            builder.Property(p => p.Valor).HasColumnName("valor");
            builder.Property(p => p.DataHoraGeracao).HasColumnName("data_hora_geracao");
            builder.Property(p => p.DataHoraAlteracao).HasColumnName("data_hora_alteracao");
        }
    }
}
