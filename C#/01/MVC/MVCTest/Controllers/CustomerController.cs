using MVCTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTest.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(int id)
        {
            Customer customer = new Customer();
            customer.id = id;
            customer.strName = "赵大";
            ViewData.Model = customer;
            return View();
        }

    }
}
