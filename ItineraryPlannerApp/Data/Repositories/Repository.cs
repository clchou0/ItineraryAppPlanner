using ItineraryPlannerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ItineraryPlannerApp.Data.Repositories
{
    // Generic repository interface
    // Base — written ONCE, has the generic CRUD
    public class Repository<T> where T : class
    {
        protected readonly ItineraryDbContext _context;
        public Repository(ItineraryDbContext context) => _context = context;

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T? GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
