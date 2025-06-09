using JJ.DOMAIN.Interfaces.Repositorys;
using JJ.DOMAIN.Entities;
using JJ.INFRASTRUCTURE.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace JJ.INFRASTRUCTURE.Repositories
{
    public class RepositoryProduct : IRepositoryProduct
    {
        private readonly ApplicationDbContext _context;
        public RepositoryProduct(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Product?> GetByIdAsync(int id) => await _context.Products.FindAsync(id);

        public async Task<IEnumerable<Product>> GetAllAsync() => await _context.Products.ToListAsync();

        public async Task<(IEnumerable<Product> data, int TotalCount)> GetAllPaginatedAsync(int pageNumber, int pageSize)
        {
            var totalCount = await _context.Products.CountAsync();

            var products = await _context.Products
                .AsNoTracking()
                .OrderBy(p => p.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (products, totalCount);
        }

        public async Task AddAsync(Product product) => await _context.Products.AddAsync(product);

        public void Delete(Product product) => _context.Products.Remove(product);

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
