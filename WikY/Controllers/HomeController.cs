using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WikY.Models;

namespace WikY.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            WikYContext myContext = new WikYContext();

            return View(myContext.Articles.ToList());
        }

        public ActionResult PostArticle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PostArticle(Article myArticle)
        {
            WikYContext myContext = new WikYContext();
            myContext.Articles.Add(myArticle);
            myContext.SaveChanges();

            return RedirectToAction("ReadArticle", new { myId = myArticle.Id }); ;
        }

        public ActionResult ReadArticle(int myId)
        {
            WikYContext myContext = new WikYContext();
            Article myArticle = myContext.Articles.FirstOrDefault(a => a.Id == myId);
            ViewBag.Article = myArticle;
            return View();
        }

        [HttpPost]
        public ActionResult ReadArticle(Comment myComment)
        {
            WikYContext myContext = new WikYContext();
            myContext.Comments.Add(myComment);
            myContext.SaveChanges();
            return RedirectToAction("ReadArticle", new { myId = myComment.ArticleId });
        }

        public ActionResult UpdateArticle(int myId)
        {
            WikYContext myContext = new WikYContext();
            Article myArticle = myContext.Articles.FirstOrDefault(a => a.Id == myId);
            return View(myArticle);
        }

        [HttpPost]
        public ActionResult UpdateArticle(Article myArticle)
        {
            WikYContext myContext = new WikYContext();
            Article articleToUpdate = myContext.Articles.Find(myArticle.Id);
            articleToUpdate.Theme = myArticle.Theme;
            articleToUpdate.Author = myArticle.Author;
            articleToUpdate.Content = myArticle.Content;
            myContext.SaveChanges();
            return RedirectToAction("ReadArticle", new { myId = myArticle.Id });
        }

        public ActionResult DestroyArticle(int myId)
        {
            WikYContext myContext = new WikYContext();
            Article myArticle = myContext.Articles.FirstOrDefault(a => a.Id == myId);
            myContext.Articles.Remove(myArticle);
            myContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}