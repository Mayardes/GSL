using INFORMACOESCADASTRAIS.Model;
using Microsoft.EntityFrameworkCore;
using ProductOwner.Microservice.Model;

namespace ProductOwner.Microservice.Data
{
    public class CadastroContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public CadastroContext(IConfiguration configuration)
        {
            Configuration = configuration;
            Database.EnsureCreated();
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Deposito> Depositos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Mercadoria> Mercadorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
