using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.MVC.Controllers
{
    public class InquireController : Controller
    {
        // GET: Inquire
        public ActionResult DoAndShow(Model.Data Data)
        {
            Service.SQL_Inquire SI = new Service.SQL_Inquire();
            List<Model.Data> GetData = new List<Model.Data>();

            //查詢
            GetData = SI.GetData(Data);
            ViewBag.GetData = GetData;
            return View();
        }

        
    }
}