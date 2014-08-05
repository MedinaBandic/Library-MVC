using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_MVC.Models;

namespace Library_MVC.Controllers
{   
    public class WarningsController : Controller
    {
        private LibraryMVCContext context = new LibraryMVCContext();

        //
        // GET: /Warnings/

        public ViewResult Index()
        {
            return View(context.Warnings.Include(warning => warning.WarningType).Include(warning => warning.Member).ToList());
        }

        //
        // GET: /Warnings/Details/5

        public ViewResult Details(int id)
        {
            Warning warning = context.Warnings.Single(x => x.WarningID == id);
            return View(warning);
        }

        //
        // GET: /Warnings/Create

        public ActionResult Create()
        {
            ViewBag.PossibleWarningTypes = context.WarningTypes;
            ViewBag.PossibleMembers = context.Members;
            return View();
        } 

        //
        // POST: /Warnings/Create

        [HttpPost]
        public ActionResult Create(Warning warning)
        {
            if (ModelState.IsValid)
            {
                context.Warnings.Add(warning);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PossibleWarningTypes = context.WarningTypes;
            ViewBag.PossibleMembers = context.Members;
            return View(warning);
        }
        
        //
        // GET: /Warnings/Edit/5
 
        public ActionResult Edit(int id)
        {
            Warning warning = context.Warnings.Single(x => x.WarningID == id);
            ViewBag.PossibleWarningTypes = context.WarningTypes;
            ViewBag.PossibleMembers = context.Members;
            return View(warning);
        }

        //
        // POST: /Warnings/Edit/5

        [HttpPost]
        public ActionResult Edit(Warning warning)
        {
            if (ModelState.IsValid)
            {
                context.Entry(warning).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleWarningTypes = context.WarningTypes;
            ViewBag.PossibleMembers = context.Members;
            return View(warning);
        }

        //
        // GET: /Warnings/Delete/5
 
        public ActionResult Delete(int id)
        {
            Warning warning = context.Warnings.Single(x => x.WarningID == id);
            return View(warning);
        }

        //
        // POST: /Warnings/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Warning warning = context.Warnings.Single(x => x.WarningID == id);
            context.Warnings.Remove(warning);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}