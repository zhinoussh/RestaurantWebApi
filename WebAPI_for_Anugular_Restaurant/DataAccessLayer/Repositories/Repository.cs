using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAPI_for_Anugular_Restaurant.DataAccessLayer.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T: class
    {
        private RestaurantDBContext _context;

        public Repository(RestaurantDBContext context)
        {
            _context = context;
        }

        public virtual List<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Insert(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();

            return obj;
        }

        public T Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();

            return obj;
        }

        public int Delete(T obj)
        {
            _context.Set<T>().Remove(obj);

            return _context.SaveChanges();
        }
    }
}