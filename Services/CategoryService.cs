using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TemaPawFinal1.Models;
using TemaPawFinal1.Repository;

namespace TemaPawFinal1.Services
{
    public class CategoryService : BaseService
    {
        public CategoryService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Category> GetCategorys()
        {
            return repositoryWrapper.CategoryRepository.FindAll().ToList();
        }

        public List<Category> GetCategorysByCondition(Expression<Func<Category, bool>> expression)
        {
            return repositoryWrapper.CategoryRepository.FindByCondition(expression).ToList();
        }

        public void AddCategory(Category Category)
        {
            repositoryWrapper.CategoryRepository.Create(Category);
        }

        public void UpdateCategory(Category Category)
        {
            repositoryWrapper.CategoryRepository.Update(Category);
        }

        public void DeleteCategory(Category Category)
        {
            repositoryWrapper.CategoryRepository.Delete(Category);
        }
    }
}
