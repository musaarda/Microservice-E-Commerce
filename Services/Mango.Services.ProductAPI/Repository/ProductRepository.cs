using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mango.Services.ProductAPI.DbContexts;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public ProductRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
    {
        Product product = _mapper.Map<ProductDto, Product>(productDto);
        if (product.ProductId > 0)
        {
            _db.Products.Update(product);
        }
        else
        {
            _db.Products.Add(product);
        }
        await _db.SaveChangesAsync();
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<bool> DeleteProduct(int productId)
    {
        try
        {
            Product product = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
            if (product == default)
                return false;

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }

    public async Task<ProductDto> GetProductById(int productId)
    {
        Product product = await _db.Products
                                .Where(x => x.ProductId == productId)
                                .FirstOrDefaultAsync();
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<IEnumerable<ProductDto>> GetProducts()
    {
        List<Product> productList = await _db.Products.ToListAsync();
        return _mapper.Map<List<ProductDto>>(productList);
    }
}
