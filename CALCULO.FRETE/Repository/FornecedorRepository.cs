using Microsoft.EntityFrameworkCore;
using SISTEMALEGADO.Data;
using SISTEMALEGADO.Interfaces;
using SISTEMALEGADO.Model;

namespace SISTEMALEGADO.Repositories
{
    public class FornecedorRepository : IRepository<Fornecedor>
    {
        private readonly LegadoContext _context;
        public FornecedorRepository(LegadoContext context)
        {
            _context = context;
        }
        public async Task<Fornecedor> AtualizarAsync(Fornecedor entity, Guid id)
        {
            var resultClient = await _context.Fornecedores.FirstOrDefaultAsync(x => x.Id == id)
              ?? throw new Exception("Not found");

            _context.ChangeTracker.Clear();
            _context.Fornecedores.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<Fornecedor> CadastrarAsync(Fornecedor entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            _context.Fornecedores.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<Fornecedor>> ObterAsync()
        {
            return await _context.Fornecedores.Include(x => x.Mercadorias).AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<Fornecedor>> ObterPorIdAsync(Guid id)
        {
            return await _context.Fornecedores.Include(x => x.Mercadorias).AsNoTracking().Where(x => x.Id == id).ToListAsync();
        }
        public async Task<Fornecedor> RemoverAsync(Guid id)
        {
            var resultClient = await _context.Fornecedores.FirstOrDefaultAsync(x => x.Id == id)
              ?? throw new Exception("Not found");
            _context.Fornecedores.Remove(resultClient);
            await _context.SaveChangesAsync();
            return resultClient;
        }
    }
}
