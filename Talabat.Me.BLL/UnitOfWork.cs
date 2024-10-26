using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Me.BLL.Interfaces;
using Talabat.Me.BLL.Repositories;
using Talabat.Me.DAL.Data.Contexts;
using Talabat.Me.DAL.Model;

namespace Talabat.Me.BLL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TalabatDbContext _context;
        private Hashtable _repositories;
        public UnitOfWork(TalabatDbContext context)
        {
           _context = context;
           _repositories = new Hashtable();
        }
        public IGenericRepositorey<TEntity, TKey> GenerateRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(type)) 
            {
                var repositories =new GenericRepositorey<TEntity,TKey>(_context);
                _repositories.Add(type, repositories);
            }
            return _repositories[type] as IGenericRepositorey<TEntity, TKey>;

        }
        public async Task<int> CompleteAsync()
        {
           return  await _context.SaveChangesAsync();
        }

    }
}
