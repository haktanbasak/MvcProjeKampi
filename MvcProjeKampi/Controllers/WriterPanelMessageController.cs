using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        MessageManager mm = new MessageManager(new EFMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        public ActionResult Inbox()
        {
            var messageValue = mm.GetListInbox();
            return View(messageValue);
        }

        public ActionResult Sendbox()
        {
            var messageValue = mm.GetListSendbox();
            return View(messageValue);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetById(id);
            return View(values);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = mm.GetById(id);
            return View(values);
        }

        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = messageValidator.Validate(p);
            if (results.IsValid)
            {
                p.SenderMail = "gizem@hotmail.com";
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}