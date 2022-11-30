namespace SEGURANCAAUTENTICACAO.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> CadastrarAsync(TEntity entity);
    }
}
