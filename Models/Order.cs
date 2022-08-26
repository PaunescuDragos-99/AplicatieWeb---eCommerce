using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemaPawFinal1.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public ApplicationUser Buyer { get; set; }
        public ICollection<Filme> Product { get; set; }
    }
}
