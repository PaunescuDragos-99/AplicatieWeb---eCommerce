using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemaPawFinal1.Models;

namespace TemaPawFinal1.Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(BookDbContext _context)
            : base(_context)
        {
        }
    }
}
