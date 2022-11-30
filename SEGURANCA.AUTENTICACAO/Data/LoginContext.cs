using Microsoft.EntityFrameworkCore;
using SEGURANCAAUTENTICACAO.Model;

namespace SEGURANCAAUTENTICACAO.Data
{
    public class LoginContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public LoginContext(IConfiguration configuration)
        {
            Configuration = configuration;
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Usuario> Usuarios { get; set; }

    }
}
