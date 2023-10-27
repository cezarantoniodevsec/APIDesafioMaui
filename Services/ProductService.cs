namespace WebApi.Services;

using AutoMapper;
using ProductsAPI.Repositories;
using WebApi.Entities;
using WebApi.Models.Product;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAll();
    Task<Product> GetById(int id);
    Task Create(CreateProductRequest model);
    Task Update(int id, UpdateProductRequest model);
    Task Delete(int id);
}

public class ProductService : IProductService
{
    private IProductRepository _ProductRepository;
    private readonly IMapper _mapper;

    public ProductService(
        IProductRepository ProductRepository,
        IMapper mapper)
    {
        _ProductRepository = ProductRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _ProductRepository.GetAll();
    }

    public async Task<Product> GetById(int id)
    {
        var Product = await _ProductRepository.GetById(id);

        if (Product == null)
            throw new KeyNotFoundException("Product not found");

        return Product;
    }

    public async Task Create(CreateProductRequest model)
    {
        // map model to new Product object
        var Product = _mapper.Map<Product>(model);

        // save Product
        await _ProductRepository.Create(Product);
    }

    public async Task Update(int id, UpdateProductRequest model)
    {
        var Product = await _ProductRepository.GetById(id);

        if (Product == null)
            throw new KeyNotFoundException("Product not found");


        // copy model props to Product
        _mapper.Map(model, Product);

        Product.Id = id;
        // save Product
        await _ProductRepository.Update(Product);
    }

    public async Task Delete(int id)
    {
        await _ProductRepository.Delete(id);
    }
}