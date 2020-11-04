using ChineseBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChineseBridge.Controllers
{
    public class RolesController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        [Authorize]
        public ActionResult Index()
        {
            var roles = context.Roles.ToList();
            if (User.IsInRole("Headmaster"))
            {
                return View(roles);
            }
            else
            {
                return View("CustomerIndex");
            }
            

        }
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                {
                    Name = collection["RoleName"]
                });
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
        public ActionResult Edit(string roleName)
        {
            var role = context.Roles.Where(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            return View(role);
        }
        [HttpPost]
        public ActionResult Edit(Microsoft.AspNet.Identity.EntityFramework.IdentityRole role)
        {
            try
            {
                context.Entry(role).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(string roleName)
        {
            var role = context.Roles.Where(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            context.Roles.Remove(role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}