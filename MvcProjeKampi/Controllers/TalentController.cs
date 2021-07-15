using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class TalentController : Controller
    {
        // GET: Talent
        TalentManager tm = new TalentManager(new EFTalentDal());
        AdminManager am = new AdminManager(new EFAdminDal());
        public ActionResult Index()
        {
            string mail = (string)Session["AdminUsername"];
            var admin = am.GetByName(mail);
            var talentValues = tm.GetTalentsByAdmin(admin.AdminID);
            return View(talentValues);
        }

        [HttpGet]
        public ActionResult AddTalent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTalent(Talent talent)
        {
            string mail = (string)Session["AdminUsername"];
            var admin = am.GetByName(mail);
            talent.AdminID = admin.AdminID;
            tm.AddTalent(talent);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTalent(int id)
        {
            var talent = tm.GetByID(id);
            return View(talent);
        }

        [HttpPost]
        public ActionResult UpdateTalent(Talent talent)
        {
            tm.UpdateTalent(talent);
            return RedirectToAction("Index");
        }
    }
}