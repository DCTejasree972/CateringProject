using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication14.Models;

namespace WebApplication14.Controllers
{
    public class CustomerController : Controller
    {
        CateringDatabaseContext cc = new CateringDatabaseContext();
        // GET: Customer
        public ActionResult Index()
        {
            return View(cc.c.ToList());
        }
    }
}