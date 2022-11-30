using Microsoft.EntityFrameworkCore;
using CALCULOFRETE.Model;

namespace CALCULOFRETE.Data
{
    public class FreteClienteDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public FreteClienteDBContext(IConfiguration configuration)
        {
            Configuration = configuration;
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<Cliente> Clientes { get; set; }

    }
}
