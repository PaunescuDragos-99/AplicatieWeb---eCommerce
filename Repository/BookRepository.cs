using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemaPawFinal1.Models;

namespace TemaPawFinal1.Repository
{
    public class BookRepository : RepositoryBase<Filme>, IBookRepository
    {
        public BookRepository(BookDbContext bookDbContext) : base(bookDbContext)
        {

        }
    }
}
