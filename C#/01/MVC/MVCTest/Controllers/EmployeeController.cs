using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTest.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        SalesERPDBEntities _dbContext = new SalesERPDBEntities();
        public ActionResult Index()
        {

            ViewData.Model = _dbContext.TblEmployee.AsEnumerable();
            return View();
        }

        public ActionResult Details(Int32 Id)
        {
            ViewData.Model = _dbContext.TblEmployee.Find(Id);
            return View();
        }
    }
}
