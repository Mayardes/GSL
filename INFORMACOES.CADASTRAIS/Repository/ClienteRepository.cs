using INFORMACOESCADASTRAIS.Data;
using INFORMACOESCADASTRAIS.Interfaces;
using INFORMACOESCADASTRAIS.Model;
using Microsoft.EntityFrameworkCore;

namespace INFORMACOESCADASTRAIS.Repositories
{
    public class ClienteRepository : IRepository<Cliente>
    {
        private readonly CadastroContext _context;
        public ClienteRepository(CadastroContext context)
        {
            _context = context;
        }
        public async Task<Cliente> AtualizarAsync(Cliente entity, Guid id)
        {
            var resultClient = await _context.Clientes.FirstOrDefaultAsync(x => x.Id == id)
              ?? throw new Exception("Not found");

            _context.ChangeTracker.Clear();
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<Cliente> CadastrarAsync(Cliente entity)
        {
            if(entity == null)
                throw new ArgumentNullException();

            _context.Clientes.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<Cliente>> ObterAsync()
        {
            return await _context.Clientes.AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<Cliente>> ObterPorIdAsync(Guid id)
        {
            return await _context.Clientes.AsNoTracking().Where(x => x.Id == id).ToListAsync();
        }
        public async Task<Cliente> RemoverAsync(Guid id)
        {
            var resultClient = await _context.Clientes.FirstOrDefaultAsync(x => x.Id == id)
              ?? throw new Exception("Not found");
            _context.Clientes.Remove(resultClient);
            await _context.SaveChangesAsync();
            return resultClient;
        }


    }
}
