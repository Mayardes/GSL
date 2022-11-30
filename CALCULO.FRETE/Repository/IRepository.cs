namespace CALCULOFRETE.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> ObterPorCpfAsync(string id);
        Task<TEntity> CadastrarAsync(TEntity entity);
    }
}
