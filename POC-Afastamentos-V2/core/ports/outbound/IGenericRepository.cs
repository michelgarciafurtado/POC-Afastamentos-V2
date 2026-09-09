using System.Linq.Expressions;

namespace POC_Afastamentos_V2.core.ports.outbound
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> ObterTodosAsync();
        Task<TEntity?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicate);
        Task AdicionarAsync(TEntity entity);
        void Atualizar(TEntity entity);
        void Remover(TEntity entity);
        Task<int> CommitAsync();
        IQueryable<TEntity> Queryable();
    }
}
