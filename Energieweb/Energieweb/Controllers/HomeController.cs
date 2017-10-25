using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Energieweb.Controllers
{
    public class HomeController : Controller
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        string query;
        string apparaat = "";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            System.Diagnostics.Debug.WriteLine("asdfasdfasdfasdf");
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            query = "";
            ///query = "INSERT INTO `apparaat`(`id`, `naam`, `max`, `merk`, `type_fk`) VALUES (10,'theelepel',10,'lepelBV',1)";
            query = "SELECT * FROM apparaat;";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            
            reader = cmd.ExecuteReader();
            
            conn.Close();
            
            while(reader.HasRows && reader.Read())
            {
                apparaat = apparaat + reader["naam"] + " ";
                ViewBag.Test = reader.FieldCount;
            }
            
            System.Diagnostics.Debug.WriteLine("resultaat:" + apparaat.ToString());
            System.Diagnostics.Debug.WriteLine("asdfasdfasdfasdf");
            ViewBag.Message = "test" + apparaat.ToString();
            ViewBag.Test = apparaat;
            reader.Close();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}