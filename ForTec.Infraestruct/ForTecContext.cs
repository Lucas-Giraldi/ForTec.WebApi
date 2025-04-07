using ForTec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
namespace ForTec.Infraestruct;

public class ForTecContext : DbContext
{

    public DbSet<SolicitanteEntity> Solicitante { get; set; }
    public DbSet<RelatorioEntity> Relatorio { get; set; }
    public DbSet<MunicipioEntity> Municipio { get; set; }
    public ForTecContext(DbContextOptions<ForTecContext> options) 
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SolicitanteConfiguration());
        modelBuilder.ApplyConfiguration(new RelatorioConfiguration());

        base.OnModelCreating(modelBuilder);
    }


    public class YourDbContextFactory : IDesignTimeDbContextFactory<ForTecContext>
    {
        public ForTecContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ForTecContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(
                connectionString,
                b => b.MigrationsAssembly("ForTec.Infraestruct")
            );

            return new ForTecContext(builder.Options);
        }
    }


}
