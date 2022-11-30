using Microsoft.EntityFrameworkCore;
using CALCULOFRETE.Data;
using CALCULOFRETE.Interfaces;
using CALCULOFRETE.Model;

namespace CALCULOFRETE.Repositories
{
    public class ClienteRepository : IRepository<Cliente>
    {
        private readonly FreteClienteDBContext _context;
        public ClienteRepository(FreteClienteDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Cliente>> ObterPorCpfAsync(string cpf)
        {
            return await _context.Clientes.AsNoTracking().Where(x => x.CpfCnpj == cpf).ToListAsync();
        }
        public async Task<Cliente> CadastrarAsync(Cliente entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            _context.Clientes.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
