using System;
using System.Collections.Generic;
using System.Text;
using ItineraryPlannerApp.Models;

namespace ItineraryPlannerApp.Data.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(ItineraryDbContext context) : base(context) { }
        public IEnumerable<User> GetAll() { return _context.Users.ToList(); }
        public User? GetById(int id) { return _context.Users.SingleOrDefault(u => u.Id == id); }
        public void Delete(int id)
        {
            User? user = this.GetById(id);
            if (user is not null) Remove(user);
        }
    }
}
