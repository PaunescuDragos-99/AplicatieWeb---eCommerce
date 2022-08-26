using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TemaPawFinal1.Models;
using TemaPawFinal1.Repository;

namespace TemaPawFinal1.Services
{
    public class UserService : BaseService
    {
        public UserService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<ApplicationUser> GetApplicationUsers()
        {
            return repositoryWrapper.UserRepository.FindAll().ToList();
        }

        public List<ApplicationUser> GetApplicationUsersByCondition(Expression<Func<ApplicationUser, bool>> expression)
        {
            return repositoryWrapper.UserRepository.FindByCondition(expression).ToList();
        }

        public void AddApplicationUser(ApplicationUser ApplicationUser)
        {
            repositoryWrapper.UserRepository.Create(ApplicationUser);
        }

        public void UpdateApplicationUser(ApplicationUser ApplicationUser)
        {
            repositoryWrapper.UserRepository.Update(ApplicationUser);
        }

        public void DeleteApplicationUser(ApplicationUser ApplicationUser)
        {
            repositoryWrapper.UserRepository.Delete(ApplicationUser);
        }
    }
}
