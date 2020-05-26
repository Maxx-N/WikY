﻿using System;
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
            if (!ModelState.IsValid)
            {
                return View("CreateArticle");
            }
            else
            {
                WikYContext myContext = new WikYContext();
                myContext.Articles.Add(myArticle);
                myContext.SaveChanges();
                return RedirectToAction("ReadArticle", new { myId = myArticle.Id }); ;
            }
        }

        public ActionResult UniqueTheme(string theme)
        {
            WikYContext myContext = new WikYContext();
            bool result = !myContext.Articles.Any(a => a.Theme == theme);
            return Json(result, JsonRequestBehavior.AllowGet);
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

        public ActionResult SearchArticle()
        {
            WikYContext myContext = new WikYContext();
            return View(myContext.Articles.ToList());
        }

        [HttpPost]
        public ActionResult SearchArticle(string choice)
        {
            WikYContext myContext = new WikYContext();
            TempData["Choice"] = choice;
            choice = choice.ToLower();
            List<Article> myList = myContext.Articles.Where(a =>
            a.Content.ToLower().Contains(choice)
            || a.Author.ToLower().Contains(choice)
            || a.Content.ToLower().Contains(choice)
            ).ToList();

            return RedirectToAction("FindArticles", myList);
        }

        public ActionResult FindArticle()
        {
            return View();
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