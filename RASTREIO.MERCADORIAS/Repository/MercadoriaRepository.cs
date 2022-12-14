using RASTREIOMERCADORIAS.Data;
using RASTREIOMERCADORIAS.Interfaces;
using RASTREIOMERCADORIAS.Model;
using Microsoft.EntityFrameworkCore;

namespace RASTREIOMERCADORIAS.Repositories
{
    public class MercadoriaRepository : IRepository<Mercadoria>
    {
        private readonly CadastroContext _context;
        public MercadoriaRepository(CadastroContext context)
        {
            _context = context;
        }
        public async Task<Mercadoria> AtualizarAsync(Mercadoria entity, Guid id)
        {
            var resultClient = await _context.Mercadorias.FirstOrDefaultAsync(x => x.Id == id)
              ?? throw new Exception("Mercadoria not found");

            var cliente = _context.Clientes.AsNoTracking().FirstOrDefault(x => x.Id == entity.ClienteId)
                ?? throw new Exception("Cliente doesn't exists");

            var forncedor = _context.Fornecedores.AsNoTracking().FirstOrDefault(x => x.Id == entity.FornecedorId)
                ?? throw new Exception("Fornecedor doesn't exists");

            var deposito = _context.Depositos.AsNoTracking().FirstOrDefault(x => x.Id == entity.DepositoId)
                ?? throw new Exception("Deposito doesn't exists");

            _context.ChangeTracker.Clear();
            _context.Mercadorias.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<Mercadoria> CadastrarAsync(Mercadoria entity)
        {
            var cliente = _context.Clientes.AsNoTracking().FirstOrDefault(x => x.Id == entity.ClienteId)
                ?? throw new Exception("Cliente doesn't exists");

            var forncedor = _context.Fornecedores.AsNoTracking().FirstOrDefault(x => x.Id == entity.FornecedorId)
                ?? throw new Exception("Fornecedor doesn't exists");

            var deposito = _context.Depositos.AsNoTracking().FirstOrDefault(x => x.Id == entity.DepositoId)
                ?? throw new Exception("Deposito doesn't exists");

            if (entity == null)
                throw new ArgumentNullException();

            _context.Mercadorias.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<Mercadoria>> ObterAsync()
        {
            return await _context.Mercadorias.ToListAsync();
        }
        public async Task<IEnumerable<Mercadoria>> ObterPorIdAsync(Guid id)
        {
            return await _context.Mercadorias.Where(x => x.Id == id).ToListAsync();
        }
        public async Task<Mercadoria> RemoverAsync(Guid id)
        {
            var resultClient = await _context.Mercadorias.FirstOrDefaultAsync(x => x.Id == id)
              ?? throw new Exception("Not found");
            _context.Mercadorias.Remove(resultClient);
            await _context.SaveChangesAsync();
            return resultClient;
        }
        public async Task<Mercadoria> RastrearMercadoriaPorIdAsync(Guid id)
        {
            var resultClient = await _context.Mercadorias.Include(x => x.Cliente)
                .Include(x => x.Fornecedor).Include(x => x.Deposito).FirstOrDefaultAsync(x => x.Id == id)
              ?? throw new Exception("Not found");
            return resultClient;
        }
        public async Task<Mercadoria> InserirStatusAsync(Guid Id,string status)
        {
            var mercadoria = _context.Mercadorias.AsNoTracking().FirstOrDefault(x => x.Id == Id)
                ?? throw new Exception("Mercadoria doesn't exists");

            mercadoria.Descricao = status;

            _context.Mercadorias.Add(mercadoria);
            await _context.SaveChangesAsync();
            return mercadoria;
        }
    }
}
