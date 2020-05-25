using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WikY.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }

        [Display(Name = "Votre nom")]
        public string Author { get; set; }

        public DateTime CommentDate { get; set; } = DateTime.Now;

        [Display(Name = "Votre commentaire")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}