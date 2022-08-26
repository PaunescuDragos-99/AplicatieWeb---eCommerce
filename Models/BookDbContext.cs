using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemaPawFinal1.Models
{
    public class BookDbContext : IdentityDbContext<ApplicationUser>
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        { }
        
        override
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Filme> Books { get; set; }
        public DbSet<UserTransactions> UserHistory { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<ArticleComment> ArticlesComments { get; set; }
    }
}
