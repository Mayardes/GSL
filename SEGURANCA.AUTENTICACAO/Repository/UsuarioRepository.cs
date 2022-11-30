using Microsoft.EntityFrameworkCore;
using SEGURANCAAUTENTICACAO.Data;
using SEGURANCAAUTENTICACAO.Interfaces;
using SEGURANCAAUTENTICACAO.Model;

namespace SEGURANCAAUTENTICACAO.Repositories
{
    public class UsuarioRepository : IRepository<Usuario>
    {
        private readonly LoginContext _context;
        public UsuarioRepository(LoginContext context)
        {
            _context = context;
        }
        public async Task<Usuario> CadastrarAsync(Usuario entity)
        {
            if(entity == null)
                throw new ArgumentNullException();

            _context.Usuarios.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

    }
}
