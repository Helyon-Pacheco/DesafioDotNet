using DesafioDotNet.Domain.Models;
using DesafioDotNet.Infra.Data.Context;
using DesafioDotNet.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesafioDotNet.Infra.Data.Repository;

public class ProductRepository : BaseRepository<Products>, IProductRepository
{
    public ProductRepository(DesafioDotNetDbContext context) : base(context) { }

    public async Task<Products> GetProductByName(string name)
    {
        return await Db.Products.AsNoTracking()
            .Include(c => c.Name)
            .FirstOrDefaultAsync(c => c.Name == name);
    }
}
