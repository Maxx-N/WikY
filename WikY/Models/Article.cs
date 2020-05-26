using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WikY.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Display(Name = "Thème")]
        [StringLength(20, ErrorMessage = "Votre thème doit comprendre 20 caractères au maximum.")]
        [Required(ErrorMessage = "Votre article doit avoir un thème.")]
        [Remote("UniqueTheme", "Article", ErrorMessage = "Ce thème existe déjà")]
        public string Theme { get; set; }

        [Display(Name = "Auteur")]
        public string Author { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public string Image { get; set; }

        [Display(Name = "Contenu de l'article")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Votre article doit avoir un contenu.")]
        public string Content { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}