using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TemaPawFinal1.Models
{
    public class ArticleComment
    {
        [Key]
        public int ID { get; set; }
        public string Comments { get; set; }
        public DateTime PublishedDate { get; set; }
        public Filme Filmes { get; set; }
        public int FilmesID { get; set; }
        [ForeignKey("FilmesId")]
        public int Rating { get; set; }
    }
}
