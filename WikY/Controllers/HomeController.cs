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

            List<Article> myList = myContext.Articles.OrderByDescending(a => a.CreationDate).ToList();
            ViewBag.MostRecent = myList[0];

            return View(myContext.Articles.ToList());
        }
    }
}