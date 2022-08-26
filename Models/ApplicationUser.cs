using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TemaPawFinal1.Models
{
    public class ApplicationUser : IdentityUser
    {

        public int HistoryId { get; set; }
        public UserTransactions UserHistory { get; set; }

        public ICollection<Filme> Cart { get; set; }

    }
}
