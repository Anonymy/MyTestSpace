using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTest.Controllers
{
    public class AjaxController : Controller
    {
        //
        // GET: /Ajax/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDate()
        {
            System.Threading.Thread.Sleep(3000);
            return Content(System.DateTime.Now.ToString());
        }
    }
}
