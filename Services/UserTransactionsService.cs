using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TemaPawFinal1.Models;
using TemaPawFinal1.Repository;

namespace TemaPawFinal1.Services
{
    public class UserTransactionsService : BaseService
    {
        public UserTransactionsService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<UserTransactions> GetUserTransactionss()
        {
            return repositoryWrapper.UserTransactionsRepository.FindAll().ToList();
        }

        public List<UserTransactions> GetUserTransactionssByCondition(Expression<Func<UserTransactions, bool>> expression)
        {
            return repositoryWrapper.UserTransactionsRepository.FindByCondition(expression).ToList();
        }

        public void AddUserTransactions(UserTransactions UserTransactions)
        {
            repositoryWrapper.UserTransactionsRepository.Create(UserTransactions);
        }

        public void UpdateUserTransactions(UserTransactions UserTransactions)
        {
            repositoryWrapper.UserTransactionsRepository.Update(UserTransactions);
        }

        public void DeleteUserTransactions(UserTransactions UserTransactions)
        {
            repositoryWrapper.UserTransactionsRepository.Delete(UserTransactions);
        }
    }
}
