using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WikY.Models;

namespace WikY.Controllers
{
    public class ArticleController : Controller
    {
        public ActionResult IndexArticle()
        {
            WikYContext myContext = new WikYContext();

            return View(myContext.Articles.OrderByDescending(a => a.CreationDate).ToList());
        }

        public ActionResult CreateArticle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateArticle(Article myArticle)
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
            return View(myArticle);
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
            Article myArticle = myContext.Articles.Find(myId);
            myContext.Articles.Remove(myArticle);
            myContext.SaveChanges();
            return RedirectToAction("IndexArticle");
        }
    }
}