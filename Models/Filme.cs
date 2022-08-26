using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TemaPawFinal1.Models
{
    public class Filme
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        public string Author { get; set; }

        public string Aparitie { get; set; }

        public string Pret { get; set; }
        public ICollection<ArticleComment> ArticlesComments { get; set; }


        public byte[] Image { get; set; }
    }
}
