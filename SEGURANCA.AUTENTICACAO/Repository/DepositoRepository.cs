using Microsoft.EntityFrameworkCore;
using SEGURANCAAUTENTICACAO.Data;
using SEGURANCAAUTENTICACAO.Interfaces;
using SEGURANCAAUTENTICACAO.Model;

namespace SEGURANCAAUTENTICACAO.Repositories
{
    public class DepositoRepository : IRepository<Deposito>
    {
        private readonly LegadoContext _context;
        public DepositoRepository(LegadoContext context)
        {
            _context = context;
        }
        public async Task<Deposito> AtualizarAsync(Deposito entity, Guid id)
        {
            var resultClient = await _context.Depositos.FirstOrDefaultAsync(x => x.Id == id)
              ?? throw new Exception("Not found");

            _context.ChangeTracker.Clear();
            _context.Depositos.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<Deposito> CadastrarAsync(Deposito entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            _context.Depositos.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<Deposito>> ObterAsync()
        {
            return await _context.Depositos.Include(x => x.Mercadorias).AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<Deposito>> ObterPorIdAsync(Guid id)
        {
            return await _context.Depositos.Include(x => x.Mercadorias).AsNoTracking().Where(x => x.Id == id).ToListAsync();
        }
        public async Task<Deposito> RemoverAsync(Guid id)
        {
            var resultClient = await _context.Depositos.FirstOrDefaultAsync(x => x.Id == id)
              ?? throw new Exception("Not found");
            _context.Depositos.Remove(resultClient);
            await _context.SaveChangesAsync();
            return resultClient;
        }
    }
}
