using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.MVC.Controllers
{
    public class DeleteController : Controller
    {
        // GET: Delete
        public ActionResult Do(string CustomerID)
        {
            Service.SQL_Delete SD = new Service.SQL_Delete();
            SD.DoDelete(CustomerID);

            return View();
        }
    }
}