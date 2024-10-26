using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Me.DAL.Model;

namespace Talabat.Me.BLL.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepositorey<TEntity,TKey> GenerateRepository<TEntity,TKey>() where TEntity : BaseEntity<TKey>;
        Task<int> CompleteAsync();
    }
}
