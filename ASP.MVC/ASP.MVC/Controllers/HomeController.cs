﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Service.SQL_GetCodeTable SGCT = new Service.SQL_GetCodeTable();
            List<Model.Data> GetCodeTable = new List<Model.Data>();
            GetCodeTable = SGCT.GetCodeTable();
            FillCodeTable(GetCodeTable);
            return View();
        }

        public void FillCodeTable(List<Model.Data> Data)
        {
            List<SelectListItem> ContactTitle = new List<SelectListItem>();
            ContactTitle.Add(new SelectListItem()
            {
                Text = "",
                Value = "null"
            });
            foreach (var item in Data)
            {
                ContactTitle.Add(new SelectListItem()
                {
                    Text = item.ContactTitle,
                    Value = item.CodeId
                });
            }
            ViewBag.ContactTitle = ContactTitle;
        }
    }
}