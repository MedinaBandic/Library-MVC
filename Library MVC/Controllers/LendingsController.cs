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
    public class LendingsController : Controller
    {
        private LibraryMVCContext context = new LibraryMVCContext();

        //
        // GET: /Lendings/

        public ViewResult Index()
        {
            return View(context.Lendings.Include(lending => lending.Member).ToList());
        }

        //
        // GET: /Lendings/Details/5

        public ViewResult Details(int id)
        {
            Lending lending = context.Lendings.Single(x => x.LendingID == id);
            return View(lending);
        }

        //
        // GET: /Lendings/Create

        public ActionResult Create()
        {
            ViewBag.PossibleMembers = context.Members;
            return View();
        } 

        //
        // POST: /Lendings/Create

        [HttpPost]
        public ActionResult Create(Lending lending)
        {
            if (ModelState.IsValid)
            {
                context.Lendings.Add(lending);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PossibleMembers = context.Members;
            return View(lending);
        }
        
        //
        // GET: /Lendings/Edit/5
 
        public ActionResult Edit(int id)
        {
            Lending lending = context.Lendings.Single(x => x.LendingID == id);
            ViewBag.PossibleMembers = context.Members;
            return View(lending);
        }

        //
        // POST: /Lendings/Edit/5

        [HttpPost]
        public ActionResult Edit(Lending lending)
        {
            if (ModelState.IsValid)
            {
                context.Entry(lending).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleMembers = context.Members;
            return View(lending);
        }

        //
        // GET: /Lendings/Delete/5
 
        public ActionResult Delete(int id)
        {
            Lending lending = context.Lendings.Single(x => x.LendingID == id);
            return View(lending);
        }

        //
        // POST: /Lendings/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Lending lending = context.Lendings.Single(x => x.LendingID == id);
            context.Lendings.Remove(lending);
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