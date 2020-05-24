﻿using System;
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

        [Display(Name = "Auteur du commentaire")]
        public string Author { get; set; }

        public DateTime CommentDate { get; set; } = DateTime.Now;

        [Display(Name = "Tapez votre commentaire ici")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}