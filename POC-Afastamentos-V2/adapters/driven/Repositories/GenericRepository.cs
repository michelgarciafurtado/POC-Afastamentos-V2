using Microsoft.EntityFrameworkCore;
using POC_Afastamentos_V2.adapters.driven.ConnectionDB;
using POC_Afastamentos_V2.core.ports.outbound;
using System.Linq.Expressions;

namespace POC_Afastamentos_V2.adapters.driven.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<TEntity> DbSet;

    protected GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        DbSet = context.Set<TEntity>();
    }

    public virtual async Task AdicionarAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
    }

    public virtual void Atualizar(TEntity entity)
    {
        DbSet.Update(entity);
    }

    public virtual async Task<IEnumerable<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
    }

    public virtual async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public virtual async Task<TEntity?> ObterPorIdAsync(Guid id)
    {
        return await DbSet.FindAsync(id);
    }
    

    public virtual async Task<IEnumerable<TEntity>> ObterTodosAsync()
    {
        return await DbSet.AsNoTracking().ToListAsync();
    }

    public virtual void Remover(TEntity entity)
    {
        DbSet.Remove(entity);
    }
}
