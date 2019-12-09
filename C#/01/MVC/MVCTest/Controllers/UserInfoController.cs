using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTest.Controllers
{
    public class UserInfoController : Controller
    {
        //
        // GET: /UserInfo/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegisterInfo()
        {
            return View();
        }

        public ActionResult RegisterResult()
        {
            string str = Request["txtname"];
            return Content(str);
        }
    }
}
