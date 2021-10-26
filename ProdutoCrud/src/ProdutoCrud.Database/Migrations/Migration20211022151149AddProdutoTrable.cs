using FluentMigrator;

namespace ProdutoCrud.Database.Migrations
{
    [Migration(20211022151149, "Aadicionando tabela Produto")]
    public class Migration20211022151149AddProdutoTrable : Migration
    {
        public override void Up()
        {
            Create
                .Table("produto")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("nome").AsString().NotNullable()
                .WithColumn("estoque").AsInt32().NotNullable()
                .WithColumn("valor").AsDecimal().NotNullable()
                .WithColumn("data_hora_geracao").AsDateTime().NotNullable()
                .WithColumn("data_hora_alteracao").AsDateTime().NotNullable();
        }

        public override void Down()
        {
            Delete
                .Table("produto");
        }

    }
}
