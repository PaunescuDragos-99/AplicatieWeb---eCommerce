using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TemaPawFinal1.Models;
using TemaPawFinal1.Repository;

namespace TemaPawFinal1.Services
{
    public class BookService : BaseService
    {
        public BookService(IRepositoryWrapper repositoryWrapper) : base(repositoryWrapper)
        {

        }

        public List<Filme> GetBook()
        {
            return repositoryWrapper.BookRepository.FindAll().ToList();
        }

        public List<Filme> GetBookByCondition(Expression<Func<Filme, bool>> expression)
        {
            return repositoryWrapper.BookRepository.FindByCondition(expression).ToList();
        }

        public void AddBook(Filme book)
        {
            repositoryWrapper.BookRepository.Create(book);
        }

        public void UpdateBook(Filme book)
        {
            repositoryWrapper.BookRepository.Update(book);
        }

        public void DeleteBook(Filme book)
        {
            repositoryWrapper.BookRepository.Delete(book);
        }
    }
}
