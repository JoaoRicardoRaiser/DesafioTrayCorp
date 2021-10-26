using Npgsql;
using System;

namespace ProdutoCrud.Database
{
    public static class DbInfoProvider
    {
        public static string Host { get; set; } = Environment.GetEnvironmentVariable("POSTGRES_HOST") ?? "localhost";
        public static string Database { get; set; } = Environment.GetEnvironmentVariable("POSTGRES_DATABASE") ?? "produto_crud";
        public static string User { get; set; } = Environment.GetEnvironmentVariable("POSTGRES_USERNAME") ?? "postgres";
        public static string Password { get; set; } = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? "postgres";
        
        public static string GetPostgresConnectionString()
        {
            var stringBuilder = new NpgsqlConnectionStringBuilder
            {
                Host = Host,
                Database = Database,
                Username = User,
                Password = Password
            };

            return stringBuilder.ConnectionString;
        }
    }

}
