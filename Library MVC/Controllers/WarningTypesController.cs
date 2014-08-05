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
    public class WarningTypesController : Controller
    {
        private LibraryMVCContext context = new LibraryMVCContext();

        //
        // GET: /WarningTypes/

        public ViewResult Index()
        {
            return View(context.WarningTypes.ToList());
        }

        //
        // GET: /WarningTypes/Details/5

        public ViewResult Details(int id)
        {
            WarningType warningtype = context.WarningTypes.Single(x => x.WarningTypeID == id);
            return View(warningtype);
        }

        //
        // GET: /WarningTypes/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /WarningTypes/Create

        [HttpPost]
        public ActionResult Create(WarningType warningtype)
        {
            if (ModelState.IsValid)
            {
                context.WarningTypes.Add(warningtype);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(warningtype);
        }
        
        //
        // GET: /WarningTypes/Edit/5
 
        public ActionResult Edit(int id)
        {
            WarningType warningtype = context.WarningTypes.Single(x => x.WarningTypeID == id);
            return View(warningtype);
        }

        //
        // POST: /WarningTypes/Edit/5

        [HttpPost]
        public ActionResult Edit(WarningType warningtype)
        {
            if (ModelState.IsValid)
            {
                context.Entry(warningtype).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(warningtype);
        }

        //
        // GET: /WarningTypes/Delete/5
 
        public ActionResult Delete(int id)
        {
            WarningType warningtype = context.WarningTypes.Single(x => x.WarningTypeID == id);
            return View(warningtype);
        }

        //
        // POST: /WarningTypes/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            WarningType warningtype = context.WarningTypes.Single(x => x.WarningTypeID == id);
            context.WarningTypes.Remove(warningtype);
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