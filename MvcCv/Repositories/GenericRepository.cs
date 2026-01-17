using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MvcCv.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        DbCvEntities1 db = new DbCvEntities1();

        public List<T> List()
        {
            return db.Set<T>().ToList();
        }

        public void Add(T t)
        {
            db.Set<T>().Add(t);
            db.SaveChanges();
        }

        public void TDelete(T t)
        {
            db.Set<T>().Remove(t);
            db.SaveChanges();
        }

        public T TGet(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void TUpdate(T t)
        {
            db.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> filter)
        {
            return db.Set<T>().FirstOrDefault(filter);
        }

    }
}