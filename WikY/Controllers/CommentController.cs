using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WikY.Models;

namespace WikY.Controllers
{
    public class CommentController : Controller
    {
        [HttpPost]
        public ActionResult CreateComment(Comment myComment)
        {
            {
                WikYContext myContext = new WikYContext();
                myContext.Comments.Add(myComment);
                myContext.SaveChanges();
                return RedirectToAction("ReadArticle", "Article", new { myId = myComment.ArticleId });
            }

        }

        public ActionResult UpdateComment(int myId)
        {
            WikYContext myContext = new WikYContext();
            Comment myComment = myContext.Comments.FirstOrDefault(c => c.Id == myId);
            return View(myComment);
        }

        [HttpPost]
        public ActionResult UpdateComment(Comment myComment)
        {
            WikYContext myContext = new WikYContext();
            Comment commentToUpdate = myContext.Comments.Find(myComment.Id);
            commentToUpdate.Author = myComment.Author;
            commentToUpdate.Content = myComment.Content;
            myContext.SaveChanges();
            return RedirectToAction("ReadArticle", "Article", new { myId = commentToUpdate.ArticleId });
        }

        public ActionResult DestroyComment(int myId)
        {
            WikYContext myContext = new WikYContext();
            Comment commentToDestroy = myContext.Comments.Find(myId);
            int myArticleId = commentToDestroy.ArticleId;
            myContext.Comments.Remove(commentToDestroy);
            myContext.SaveChanges();
            return RedirectToAction("ReadArticle", "Article", new { myId = myArticleId });
        }
    }
}