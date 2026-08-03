using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ItineraryPlannerApp.Data.Repositories
{
    // Generic repository interface
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ItineraryPlannerContext _context;
        public Repository(ItineraryPlannerContext context)
        {
            _context = context;
        }
        public ItineraryPlannerContext Context { get { return _context; } }
        public T? GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList(); // Retrieve all entities
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList(); // Find entities by predicate
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity); // Add entity to DbSet
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges(); // Save changes to the database
        }
    }


}
