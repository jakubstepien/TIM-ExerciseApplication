using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public interface IRepository<TEntity, TKey> : IDisposable where TEntity : class
    {
        TEntity GetById(TKey id);

        bool Add(TEntity entitiy);

        bool Update(TEntity entity);

        bool Remove(TEntity entitiy);

        bool Remove(TKey id);

        void SaveChanges();
    }
}
