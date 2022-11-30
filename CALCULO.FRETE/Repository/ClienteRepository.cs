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
        public async Task<Cliente> ObterPorCpfAsync(string cpf)
        {
            return await _context.Clientes.AsNoTracking().FirstAsync(x => x.CpfCnpj == cpf);
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
