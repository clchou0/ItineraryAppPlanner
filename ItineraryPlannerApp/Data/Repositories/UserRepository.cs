using System;
using System.Collections.Generic;
using System.Text;
using ItineraryPlannerApp.Models;

namespace ItineraryPlannerApp.Data.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(ItineraryDbContext context) : base(context) { }
    }
}
