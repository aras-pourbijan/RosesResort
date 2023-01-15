using RosesResort.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RosesResort.Controllers
{
    public class homeController : Controller
    {
        // GET: home
        public ActionResult login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult login(users U)
        {
            List<users> ListaUser = new List<users>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["rosesresortDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from users where nomeutente=@username and PasswordDiUser=@password", con);
            cmd.Parameters.AddWithValue("username", U.NomeUtente);
            cmd.Parameters.AddWithValue("password", U.PasswordDiUser);
            SqlDataReader reader = cmd.ExecuteReader();
            try { 
            if (reader.HasRows)
            {
                FormsAuthentication.SetAuthCookie(U.NomeUtente,U.ricordami);
           
                return Redirect(FormsAuthentication.DefaultUrl);
            }
            else
            {
                ViewBag.error="per entrareinserisci dati corretti!";
             
            }
            }catch(Exception ex) {
            }
            finally { con.Close(); }    
                return View();
        }
    }
}