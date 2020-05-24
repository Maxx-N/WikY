using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WikY.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Display(Name = "Thème")]
        public string Theme { get; set; }

        [Display(Name = "Auteur")]
        public string Author { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public string Image { get; set; }

        [Display(Name = "Contenu de l'article")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}