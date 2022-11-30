namespace RASTREIOMERCADORIAS.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> ObterAsync();
        Task<IEnumerable<TEntity>> ObterPorIdAsync(Guid id);
        Task<TEntity> CadastrarAsync(TEntity entity);
        Task<TEntity> AtualizarAsync(TEntity entity, Guid id);
        Task<TEntity> RemoverAsync(Guid id);
    }
}
