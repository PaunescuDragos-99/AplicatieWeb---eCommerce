using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemaPawFinal1.Models;

namespace TemaPawFinal1.Repository
{
    public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
    {
        public UserRepository(BookDbContext _context)
            : base(_context)
        {
        }
    }
}
