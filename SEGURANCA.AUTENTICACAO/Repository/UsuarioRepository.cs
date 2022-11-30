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
        public async Task<Usuario> AtualizarAsync(Usuario entity, Guid id)
        {
            var resultClient = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id)
              ?? throw new Exception("Not found");

            _context.ChangeTracker.Clear();
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<Usuario> CadastrarAsync(Usuario entity)
        {
            if(entity == null)
                throw new ArgumentNullException();

            _context.Usuarios.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<Usuario>> ObterAsync()
        {
            return await _context.Usuarios.AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<Usuario>> ObterPorIdAsync(Guid id)
        {
            return await _context.Usuarios.AsNoTracking().Where(x => x.Id == id).ToListAsync();
        }
        public async Task<Usuario> RemoverAsync(Guid id)
        {
            var resultClient = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id)
              ?? throw new Exception("Not found");
            _context.Usuarios.Remove(resultClient);
            await _context.SaveChangesAsync();
            return resultClient;
        }


    }
}
