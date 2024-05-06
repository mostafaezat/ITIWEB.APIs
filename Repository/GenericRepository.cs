using Core.Entities;
using Core.Repositories;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;

        public GenericRepository(StoreContext context)
        {
            _context = context;
        }

        private IQueryable<T> ApplySpecifications(ISpecifications<T> spec)
            => SpecificationEvaluator<T>.GetQuery(_context.Set<T>(), spec);


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            /// Eager loading
            ///if (typeof(T) == typeof(Product))
            ///{
            ///    return (IEnumerable<T>) await _context.Set<Product>()
                    ///    .Where(item => item.Id == id)
                    ///    .Include(P => P.ProductBrand).Include(p => p.ProductType)
                    ///    .ToListAsync();
            ///}
            if (typeof(T) == typeof(Product))
            {
                return (IEnumerable<T>) await _context.Set<Product>().Include(P => P.ProductBrand)
                    .Include(p => p.ProductType).ToListAsync();
            }
            return await _context.Set<T>().ToListAsync();

        }
        public async Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecifications<T> spec)
            => await ApplySpecifications(spec).ToListAsync();

 
        

        public async Task<T> GetByIdAsync(int id)
                //=> await _context.Set<T>().Where(item => item.Id == id).FirstOrDefaultAsync();
                => await _context.Set<T>().FindAsync(id);

        public async Task<T> GetByIdWithSpecAsync(ISpecifications<T> spec)
                => await ApplySpecifications(spec).FirstOrDefaultAsync();
    }
}
