using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        Context context = new Context();
        public ActionResult Index()
        {
            ViewBag.CategoriesCount = context.Categories.Count();
            ViewBag.YazilimCount = context.Categories.Count(x=>x.CategoryName=="yazılım");
            ViewBag.ContainsA = context.Writers.Count(x=>x.WriterName.Contains("a"));
            ViewBag.MaxCategory = context.Categories.Max(x=>x.CategoryName);
            ViewBag.CategoriTrueFalse = context.Categories.Count(x => x.CategoryStatus == true) - context.Categories.Count(x => x.CategoryStatus == false);
            return View();
        }
    }
}