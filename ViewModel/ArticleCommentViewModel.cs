using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemaPawFinal1.Models;

namespace TemaPawFinal1.ViewModel
{
    public class ArticleCommentViewModel
    {
        public string Nume { get; set; }
        public List<ArticleComment> ListOfComments { get; set; }
        public string Comment { get; set; }
        public int ArticlesID { get; set; }
        public int Rating { get; set; }
    }
}
