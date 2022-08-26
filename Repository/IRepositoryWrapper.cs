using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemaPawFinal1.Repository
{
    public interface IRepositoryWrapper
    {

        IBookRepository BookRepository { get; }
        IUserRepository UserRepository { get; }
        IOrderRepository OrderRepository { get; }
        IUserTransactionsRepository UserTransactionsRepository { get; }
        ICategoryRepository CategoryRepository { get; }


        void Save();
    }
}
