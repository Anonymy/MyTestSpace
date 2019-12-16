using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTest.Controllers
{
    public class EmployeeEXController : Controller
    {
        private SalesERPDBEntities db = new SalesERPDBEntities();

        //
        // GET: /EmployeeEX/

        public ActionResult Index()
        {
            return View(db.TblEmployee.ToList());
        }

        //
        // GET: /EmployeeEX/Details/5

        public ActionResult Details(int id = 0)
        {
            TblEmployee tblemployee = db.TblEmployee.Find(id);
            if (tblemployee == null)
            {
                return HttpNotFound();
            }
            return View(tblemployee);
        }

        //
        // GET: /EmployeeEX/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /EmployeeEX/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TblEmployee tblemployee)
        {
            if (ModelState.IsValid)
            {
                db.TblEmployee.Add(tblemployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblemployee);
        }

        //
        // GET: /EmployeeEX/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TblEmployee tblemployee = db.TblEmployee.Find(id);
            if (tblemployee == null)
            {
                return HttpNotFound();
            }
            return View(tblemployee);
        }

        //
        // POST: /EmployeeEX/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TblEmployee tblemployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblemployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblemployee);
        }

        //
        // GET: /EmployeeEX/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TblEmployee tblemployee = db.TblEmployee.Find(id);
            if (tblemployee == null)
            {
                return HttpNotFound();
            }
            return View(tblemployee);
        }

        //
        // POST: /EmployeeEX/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblEmployee tblemployee = db.TblEmployee.Find(id);
            db.TblEmployee.Remove(tblemployee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}