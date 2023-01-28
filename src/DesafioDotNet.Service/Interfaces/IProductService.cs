using DesafioDotNet.Domain.Models;

namespace DesafioDotNet.Service.Interfaces;

public interface IProductService
{
    Task Add(Products product);
    Task Update(Products product);
    Task Remove(int id);
}
