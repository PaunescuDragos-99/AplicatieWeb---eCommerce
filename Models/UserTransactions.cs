using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemaPawFinal1.Models
{
    public class UserTransactions
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Filme Product { get; set; }

        public DateTime PurchaseDate { get; set; }

        public UserTransactions()
        {
            PurchaseDate = DateTime.Now;


        }
    }
}
