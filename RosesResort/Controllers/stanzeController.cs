using RosesResort.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace RosesResort.Controllers
{
    [Authorize]
    public class stanzeController : Controller
    {
        // GET: stanze
        public ActionResult ListStanze()
        {
            List<stanze> ListaStanze = new List<stanze>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["rosesresortDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from stanze", con);
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {

                while (reader.Read())
                {
                    stanze s= new stanze(); 
                    s.IDstanza = Convert.ToInt32(reader["IDstanza"]);
                    s.NomeStanza = reader["nomestanza"].ToString();
                    s.Tipologia = reader["tipologia"].ToString();
                    s.Descrizione = reader["Descrizione"].ToString();
                   ListaStanze.Add(s);
                }
            }
            catch (Exception ex)
            {
            }
            finally { con.Close(); }




            return View(ListaStanze);
        }

        public ActionResult Edit(int ID) {
            List<stanze> ListaStanze = new List<stanze>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["rosesresortDB"].ConnectionString);
            con.Open();
            stanze S = new stanze();
            try
            {
                SqlCommand cmd = new SqlCommand("select * from stanze where IDstanza=@ID", con);
                cmd.Parameters.AddWithValue("@ID", ID);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    S.IDstanza = Convert.ToInt32(reader["IDstanza"]);
                    S.NomeStanza = reader["NomeStanza"].ToString();
                    S.Tipologia = reader["Tipologia"].ToString();
                    S.Descrizione = reader["Descrizione"].ToString();
                   
                }
            }
            catch (Exception ex)
            {

            }
            finally { con.Close(); }

            return View(S);
        }

        [HttpPost]
        public ActionResult Edit(stanze S) {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["rosesresortDB"].ConnectionString);
            con.Open();
            try
            {

                SqlCommand cmd = new SqlCommand("update stanze set NomeStanza=@NomeStanza , Tipologia=@Tipologia , Descrizione=@Descrizione" +
                    " where IDstanza=@IDstanza", con);

                cmd.Parameters.AddWithValue("IDstanza", S.IDstanza);
                cmd.Parameters.AddWithValue("NomeStanza", S.NomeStanza);
                cmd.Parameters.AddWithValue("Tipologia", S.Tipologia);
                cmd.Parameters.AddWithValue("@Descrizione", S.Descrizione);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { con.Close(); }



            return RedirectToAction("ListStanze");
        }

        public ActionResult Delete(int ID)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["rosesresortDB"].ConnectionString);
            con.Open();
            clienti C = new clienti();
            try
            {
                SqlCommand cmd = new SqlCommand("delete from stanze where IDstanza=@ID", con);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.ExecuteNonQuery();
                ViewBag.msg = "Hai eliminato una stanza !";
            }
            catch (Exception ex)
            {
                ViewBag.err = ex.Message;
            }
            finally
            {
                con.Close();
            }


            Thread.Sleep(500);
            return RedirectToAction("ListStanze");
        }

        public ActionResult Createstanza()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Createstanza(stanze S)
        {


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["rosesresortDB"].ConnectionString);
            con.Open();

           // List<SelectListItem> SelectListTipologia = new List<SelectListItem>();
           // SelectListItem S1 = new SelectListItem { Text = "Singola", Value = "1" };
            //SelectListItem S2 = new SelectListItem { Text = "Doppia", Value = "2" };
           // SelectListTipologia.Add(S1);
            //SelectListTipologia.Add(S2);
            //ViewBag.listaTipologia=SelectListTipologia;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO stanze VALUES (@nomestanza , @tipologia , @descrizione) ", con);
                cmd.Parameters.AddWithValue("nomestanza",S.NomeStanza);
                cmd.Parameters.AddWithValue("tipologia", S.Tipologia);
                cmd.Parameters.AddWithValue("descrizione", S.Descrizione);
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    ViewBag.statoAzione = "nuovo stanza si e` inserito con sucesso!";
                }

            }
            catch (Exception ex)
            {
                ViewBag.err = ex.Message;
            }

            finally { con.Close(); }
            Thread.Sleep(300);
            return View();
        }



    }
}