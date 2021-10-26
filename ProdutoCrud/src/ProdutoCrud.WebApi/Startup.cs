using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProdutoCrud.Database;
using ProdutoCrud.IoC;
using System;

namespace ProdutoCrud.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<ProdutoCrudDbContext>();
            services.RegistrarServices();
            
            UpdateDatabase(ConfigureFluentMigrator(services));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static IServiceProvider ConfigureFluentMigrator(IServiceCollection services)
        {
            return services
                .AddFluentMigratorCore()
                .ConfigureRunner(r => r
                .AddPostgres()
                .WithGlobalConnectionString(DbInfoProvider.GetPostgresConnectionString())
                .ScanIn(typeof(DbInfoProvider).Assembly).For.Migrations())
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}
