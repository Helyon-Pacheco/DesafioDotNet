using System.Linq.Expressions;
using DesafioDotNet.Domain.Models;
using DesafioDotNet.Infra.Data.Context;
using DesafioDotNet.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesafioDotNet.Infra.Data.Repository;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity, new()
{
    protected readonly DesafioDotNetDbContext Db;
    protected readonly DbSet<TEntity> DbSet;

    protected BaseRepository(DesafioDotNetDbContext db)
    {
        Db = db;
        DbSet = db.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
    }

    public virtual async Task<TEntity> GetById(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual async Task<List<TEntity>> GetAll()
    {
        return await DbSet.ToListAsync();
    }

    public virtual async Task Add(TEntity entity)
    {
        DbSet.Add(entity);
        await SaveChanges();
    }

    public virtual async Task Update(TEntity entity)
    {
        DbSet.Update(entity);
        await SaveChanges();
    }

    public virtual async Task Remove(int id)
    {
        DbSet.Remove(new TEntity { Id = id });
        await SaveChanges();
    }

    public async Task<int> SaveChanges()
    {
        return await Db.SaveChangesAsync();
    }

    public void Dispose()
    {
        Db?.Dispose();
    }
}
