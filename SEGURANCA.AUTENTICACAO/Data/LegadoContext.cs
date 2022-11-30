using Microsoft.EntityFrameworkCore;
using SEGURANCAAUTENTICACAO.Model;

namespace SEGURANCAAUTENTICACAO.Data
{
    public class LegadoContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public LegadoContext(IConfiguration configuration)
        {
            Configuration = configuration;
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<ProductOfferDetail> ProductOffers { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Deposito> Depositos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Mercadoria> Mercadorias { get; set; }

    }
}
