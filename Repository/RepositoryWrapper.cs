using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemaPawFinal1.Models;

namespace TemaPawFinal1.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private BookDbContext _context;
        private IBookRepository _bookRepository;
        private IOrderRepository orderRepository;       
        private ICategoryRepository categoryRepository;
        private IUserRepository userRepository;
        private IUserTransactionsRepository userTransactionsRepository;

        public IBookRepository BookRepository
        {
            get
            {
                if (_bookRepository == null)
                {
                    _bookRepository = new BookRepository(_context);
                }
                return _bookRepository;
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                if (orderRepository == null)
                {
                    orderRepository = new OrderRepository(_context);
                }
                return orderRepository;
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (categoryRepository == null)
                {
                    categoryRepository = new CategoryRepository(_context);
                }
                return categoryRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(_context);
                }
                return userRepository;
            }
        }

        public IUserTransactionsRepository UserTransactionsRepository
        {
            get
            {
                if (userTransactionsRepository == null)
                {
                    userTransactionsRepository = new UserTransactionsRepository(_context);
                }
                return userTransactionsRepository;
            }
        }



        public RepositoryWrapper(BookDbContext bookDbContext)
        {
            _context = bookDbContext;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
