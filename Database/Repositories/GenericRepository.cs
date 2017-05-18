using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class GenericRepository<T> : IRepository<T,Guid> where T : class
    {
        protected DbContext db;

        public GenericRepository(DbContext context)
        {
            this.db = context;
        }

        public bool Add(T entitiy)
        {
            try
            {
                db.Set<T>().Add(entitiy);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public T GetById(Guid id)
        {
            return db.Set<T>().Find(id);
        }

        public bool Remove(Guid id)
        {
            var entity = db.Set<T>().Find(id);
            return Remove(entity);
        }

        public bool Remove(T entity)
        {
            try
            {
                if (entity != null)
                {
                    db.Set<T>().Remove(entity);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(T entity)
        {
            //zakładam że nie jest attached w db
            try
            {
                db.Set<T>().Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
