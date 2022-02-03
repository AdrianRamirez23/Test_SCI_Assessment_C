using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.MVC.Models;

namespace Test.MVC.Controllers
{
    public class SCIResultController : Controller
    {
        // GET: SCIResult
        public ActionResult Index(ResultForm resultForm)
        {
            return View(resultForm);
        }
    }
}