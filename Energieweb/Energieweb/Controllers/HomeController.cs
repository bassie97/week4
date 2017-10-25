using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using Energieweb.Helpers;
using System.Collections;

namespace Energieweb.Controllers
{
    public class HomeController : Controller
    {
        Database database = new Database();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "test";
            Result resultaat = database.ExecuteQuery("Select * from apparaat;");
            foreach (ArrayList result in resultaat.Dataset)
            {
                foreach (object result1 in result)
                {
                    ViewBag.Message += result1.ToString();
                }
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}