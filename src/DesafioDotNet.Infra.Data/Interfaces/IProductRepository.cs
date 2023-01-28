using DesafioDotNet.Domain.Models;

namespace DesafioDotNet.Infra.Data.Interfaces;

public interface IProductRepository : IBaseRepository<Products>
{
    Task<Products> GetProductByName(string name);
}
