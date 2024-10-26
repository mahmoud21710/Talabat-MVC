using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Me.BLL.Interfaces;
using Talabat.Me.DAL.Data.Contexts;
using Talabat.Me.DAL.Model;

namespace Talabat.Me.BLL.Repositories
{
    public class GenericRepositorey<TEntity, TKey> : IGenericRepositorey<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly TalabatDbContext _context;

        public GenericRepositorey(TalabatDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            if(typeof(TEntity) == typeof(Product)) 
            {
                return (IEnumerable<TEntity>) await _context.Products.Include(P=>P.Brand).Include(R=>R.Type).ToListAsync();
            }
            if (typeof(TEntity) == typeof(ProductRestaurant))
            {
                return (IEnumerable<TEntity>)await _context.ProductRestaurant.Include(PS => PS.Restaurants).Include(PS =>PS.Products).ToListAsync();
            }
            if (typeof(TEntity) == typeof(Restaurants))
            {
                return (IEnumerable<TEntity>) await _context.Restaurants.ToListAsync();
            }
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            if (typeof(TEntity) == typeof(Product))
            {
                return await _context.Products.Where(P => P.Id==id as int?).Include(P => P.Brand).Include(R => R.Type).FirstOrDefaultAsync() as TEntity;
            }
            return await _context.Set<TEntity>().FindAsync(id);
        }
        public async Task AddAsync(TEntity entity)
        {
             await _context.AddAsync(entity);
        }
        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }
        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        

        
    }
}
