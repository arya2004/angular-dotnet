using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {   
        private readonly AppDbContext _appDbContext;
        public ProductRepository(AppDbContext appDbContext)
        {

            _appDbContext = appDbContext;

        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _appDbContext.productBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _appDbContext.Products.Include(p => p.ProductBrand).Include(p => p.ProductType).FirstOrDefaultAsync(u => u.ProductId == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _appDbContext.Products.Include(p => p.ProductBrand).Include(p => p.ProductType).ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _appDbContext.productTypes.ToListAsync();
        }

        
    }
}
