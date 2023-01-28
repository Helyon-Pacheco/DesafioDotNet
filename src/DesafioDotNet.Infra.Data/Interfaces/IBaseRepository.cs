using System.Linq.Expressions;
using DesafioDotNet.Domain.Models;

namespace DesafioDotNet.Infra.Data.Interfaces;

public interface IBaseRepository<TEntity> : IDisposable where TEntity : Entity
{
    Task Add(TEntity entity);
    Task<TEntity> GetById(int id);
    Task<List<TEntity>> GetAll();
    Task Update(TEntity entity);
    Task Remove(int id);
    Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
    Task<int> SaveChanges();
}