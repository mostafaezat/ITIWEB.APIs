using Core.Entities;
using Core.Repositories;
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
        public async Task<IEnumerable<T>> GetAllAsync()
                 =>  await _context.Set<T>().ToListAsync();


        public async Task<T> GetByIdAsync(int id)
                //=> await _context.Set<T>().Where(item => item.Id == id).FirstOrDefaultAsync();
                => await _context.Set<T>().FindAsync(id);
    }
}
