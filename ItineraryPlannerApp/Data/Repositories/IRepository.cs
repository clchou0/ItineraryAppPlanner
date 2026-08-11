using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ItineraryPlannerApp.Data.Repositories
{
    // Generic repository interface
    public interface IRepository<T> where T : class
    {
        T? GetById(int id); // Get entity by ID
        IEnumerable<T> GetAll(); // Get all entities
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate); // Find entities by predicate
        void Add(T entity); // Add entity
        void SaveChanges(); // Save changes to database
        void Remove(T entity);
        void Update(T entity);
    }
}
