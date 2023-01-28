using DesafioDotNet.Domain.Interfaces;
using DesafioDotNet.Domain.Models;
using DesafioDotNet.Domain.Models.Validations;
using DesafioDotNet.Infra.Data.Interfaces;
using DesafioDotNet.Service.Interfaces;

namespace DesafioDotNet.Service.Services;

public class ProductService : BaseService, IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository, INotifier notifier) : base(notifier)
    {
        _productRepository = productRepository;
    }

    public async Task Add(Products product)
    {
        if (!ExecuteValidation(new ProductValidation(), product)) return;

        await _productRepository.Add(product);
    }

    public async Task Remove(int id)
    {
        await _productRepository.Remove(id);
    }

    public async Task Update(Products product)
    {
        if (!ExecuteValidation(new ProductValidation(), product)) return;

        await _productRepository.Update(product);
    }

    public void Dispose()
    {
        _productRepository?.Dispose();
    }
}
