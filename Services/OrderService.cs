using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TemaPawFinal1.Models;
using TemaPawFinal1.Repository;

namespace TemaPawFinal1.Services
{
    public class OrderService : BaseService
    {
        public OrderService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Order> GetOrders()
        {
            return repositoryWrapper.OrderRepository.FindAll().ToList();
        }

        public List<Order> GetOrdersByCondition(Expression<Func<Order, bool>> expression)
        {
            return repositoryWrapper.OrderRepository.FindByCondition(expression).ToList();
        }

        public void AddOrder(Order Order)
        {
            repositoryWrapper.OrderRepository.Create(Order);
        }

        public void UpdateOrder(Order Order)
        {
            repositoryWrapper.OrderRepository.Update(Order);
        }

        public void DeleteOrder(Order Order)
        {
            repositoryWrapper.OrderRepository.Delete(Order);
        }
    }
}
