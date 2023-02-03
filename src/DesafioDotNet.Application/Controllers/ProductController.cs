using AutoMapper;
using DesafioDotNet.Domain.Interfaces;
using DesafioDotNet.Domain.Models;
using DesafioDotNet.Infra.Data.Interfaces;
using DesafioDotNet.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioDotNet.Application.Controllers;

[Route("api/[controller]")]
public class ProductController : MainController
{
    public readonly IProductRepository _repository;
    public readonly IProductService _service;
    public IMapper _mapper;

    public ProductController(IProductRepository productRepository, IProductService productService,
            IMapper mapper, INotifier notifier) : base(notifier)
    {
        _repository = productRepository;
        _service = productService;
        _mapper = mapper;
    }


    [HttpGet]
    public async Task<IEnumerable<Products>> GetAll()
    {
        var product = _mapper.Map<IEnumerable<Products>>(await _repository.GetAll());
        return product;
    }
        

    [HttpGet("{id}")]
    public async Task<ActionResult<Products>> Get(int id)
    {
        var product = _mapper.Map<Products>(await _repository.GetById(id));

        if (product is null) return NotFound();
        
        return product;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Products product)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _repository.Add(_mapper.Map<Products>(product));

        return CustomResponse(product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Products product)
    {
        if (id != product.Id)
        {
            NotifyError("O id informado não é o mesmo que foi passado na query");
            return CustomResponse(product);
        }

        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _service.Update(_mapper.Map<Products>(product));

        return CustomResponse(product);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _repository.GetById(id);


        if (product == null) return NotFound();

        await _repository.Remove(id);

        return CustomResponse(product);
    }
}