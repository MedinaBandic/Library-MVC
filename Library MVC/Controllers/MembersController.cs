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
    public class MembersController : Controller
    {
        private LibraryMVCContext context = new LibraryMVCContext();

        //
        // GET: /Members/

        public ViewResult Index()
        {
            return View(context.Members.Include(member => member.Department).ToList());
        }

        //
        // GET: /Members/Details/5

        public ViewResult Details(int id)
        {
            Member member = context.Members.Single(x => x.MemberID == id);
            return View(member);
        }

        //
        // GET: /Members/Create

        public ActionResult Create()
        {
            ViewBag.PossibleDepartments = context.Departments;
            return View();
        } 

        //
        // POST: /Members/Create

        [HttpPost]
        public ActionResult Create(Member member)
        {
            if (ModelState.IsValid)
            {
                context.Members.Add(member);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PossibleDepartments = context.Departments;
            return View(member);
        }
        
        //
        // GET: /Members/Edit/5
 
        public ActionResult Edit(int id)
        {
            Member member = context.Members.Single(x => x.MemberID == id);
            ViewBag.PossibleDepartments = context.Departments;
            return View(member);
        }

        //
        // POST: /Members/Edit/5

        [HttpPost]
        public ActionResult Edit(Member member)
        {
            if (ModelState.IsValid)
            {
                context.Entry(member).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleDepartments = context.Departments;
            return View(member);
        }

        //
        // GET: /Members/Delete/5
 
        public ActionResult Delete(int id)
        {
            Member member = context.Members.Single(x => x.MemberID == id);
            return View(member);
        }

        //
        // POST: /Members/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = context.Members.Single(x => x.MemberID == id);
            context.Members.Remove(member);
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