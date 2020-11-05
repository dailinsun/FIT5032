using ChineseBridge.Models;
using ChineseBridge.Utils;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChineseBridge.Controllers
{
    public class BookEventController : Controller
    {
        // GET: BookEvent
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Book(int Id)
        {
            if (User.IsInRole("Student"))
            {
                var ClassinCampus = db.ClassinCampuses.Include("Classtype").Where(be => be.Id == Id).FirstOrDefault();
                var UserId = User.Identity.GetUserId();
                var check = db.BookEvents.Where(be => be.ClassinCampusId == Id && be.ApplicationUserId == UserId).FirstOrDefault();
                if(check ==null)
                {
                    var bookEvent = new BookEvent { ApplicationUserId = UserId, ClassinCampusId = Id };
                    db.BookEvents.Add(bookEvent);
                    db.SaveChanges();

                    string toEmail = User.Identity.GetUserName();
                    string subject = "Booking class confirm";
                    string content = "You have already book the" + ClassinCampus.Classtype.Name.ToString() + "class at" + ClassinCampus.StartTime.ToString();
                    EmailSender es = new EmailSender();
                    es.SendSingle(toEmail, subject,content);
                }
                else
                {
                ViewBag.Error = "You have already book this class";
                }
                return View("Index");
            }
            else
            {
                return View("Error");
            }

        }
        public JsonResult Analysis()
        {
            var bookEvents = db.BookEvents.Include("ClassinCampus").Include("ClassinCampus.Campus").Include("ClassinCampus.Classtype").ToList();

            // eventType     count()

            var bookPerCampus =
                from bookEvent in bookEvents
                group bookEvent by bookEvent.ClassinCampus.Campus into bookGroup

                select new
                {
                    Campus = bookGroup.Key,
                    Count = bookGroup.Count()
                };

            var bookPerBranchEvent =
                from bookEvent in bookEvents
                group bookEvent by new { bookEvent.ClassinCampus.Campus, bookEvent.ClassinCampus.Classtype } into bookGroup
                select new
                {
                    Book = bookGroup.Key,
                    Count = bookGroup.Count()
                };

            //return new JsonResult { Data = bookPerEvent, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult { Data = bookPerCampus, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}