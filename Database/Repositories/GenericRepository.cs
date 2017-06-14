using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class GenericRepository<T> : IRepository<T, Guid> where T : class
    {
        protected DbContext db;

        public GenericRepository(DbContext context)
        {
            this.db = context;
        }

        public virtual IQueryable<T> GetAll()
        {
            return db.Set<T>();
        }

        public virtual bool Add(T entitiy)
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

        public virtual T GetById(Guid id)
        {
            return db.Set<T>().Find(id);
        }

        public virtual bool Remove(Guid id)
        {
            var entity = db.Set<T>().Find(id);
            return Remove(entity);
        }

        public virtual bool Remove(T entity)
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

        public virtual bool Update(T entity)
        {
            //zakładam że nie jest attached w db
            try
            {
                db.Set<T>().Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public virtual void SaveChanges()
        {
            db.SaveChanges();
        }

        public virtual void Dispose()
        {
            db.Dispose();
        }

        public virtual bool Exists(Guid id)
        {
            return db.Set<T>().Find(id) != null;
        }
    }
}
