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
    public class clientiController : Controller
    {
        // GET: clienti
        public ActionResult ListaClienti()
        {
            List<clienti> ListaClienti = new List<clienti>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["rosesresortDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from clients", con);
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {

                while (reader.Read())
                {
                    clienti C = new clienti();
                    C.IDcliente = Convert.ToInt32(reader["IDclienti"]);
                    C.CodiceFiscale = reader["codicefiscale"].ToString();
                    C.Nome = reader["nome"].ToString();
                    C.Cognome = reader["cognome"].ToString();
                    C.Citta = reader["citta"].ToString();
                    C.Provincia = reader["provincia"].ToString();
                    C.Email = reader["email"].ToString();
                    C.Tel = reader["tel"].ToString();
                    ListaClienti.Add(C);
                }
            }
            catch (Exception ex)
            {
            }
            finally { con.Close(); }




            return View(ListaClienti);
        }

        public ActionResult edit(int ID)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["rosesresortDB"].ConnectionString);
            con.Open();
            clienti C = new clienti();
            try
            {
                SqlCommand cmd = new SqlCommand("select * from clients where IDclienti=@ID", con);
                cmd.Parameters.AddWithValue("@ID", ID);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    C.IDcliente = Convert.ToInt32(reader["IDclienti"]);
                    C.CodiceFiscale = reader["codicefiscale"].ToString();
                    C.Nome = reader["nome"].ToString();
                    C.Cognome = reader["cognome"].ToString();
                    C.Citta = reader["citta"].ToString();
                    C.Provincia = reader["provincia"].ToString();
                    C.Email = reader["email"].ToString();
                    C.Tel = reader["tel"].ToString();

                }
            }
            catch (Exception ex)
            {

            }
            finally { con.Close(); }

            return View(C);
        }
        [HttpPost]
        public ActionResult edit(clienti C)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["rosesresortDB"].ConnectionString);
            con.Open();
            try
            {

                SqlCommand cmd = new SqlCommand("update clients set codiceFiscale=@Cf , nome=@Nome , cognome=@Cognome , " +
                    "Citta=@Citta , provincia=@provincia, email=@email , tel=@tel  where IDclienti=@IDclienti", con);

                cmd.Parameters.AddWithValue("@IDclienti", C.IDcliente);
                cmd.Parameters.AddWithValue("@Cf", C.CodiceFiscale);
                cmd.Parameters.AddWithValue("@Nome", C.Nome);
                cmd.Parameters.AddWithValue("@Cognome", C.Cognome);
                cmd.Parameters.AddWithValue("@Citta", C.Citta);
                cmd.Parameters.AddWithValue("@provincia", C.Provincia);
                cmd.Parameters.AddWithValue("@email", C.Email);
                cmd.Parameters.AddWithValue("@tel", C.Tel);
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex) { }
            finally { con.Close(); }



            return RedirectToAction("ListaClienti");
        }

        public ActionResult Delete(int ID)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["rosesresortDB"].ConnectionString);
            con.Open();
            clienti C = new clienti();
            try
            {
                SqlCommand cmd =new SqlCommand( "delete from clients where IDclienti=@ID", con);
                cmd.Parameters.AddWithValue("@ID", ID);
                int row=cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    ViewBag.dlt = "Hai eliminato un cliente !";
                }
            }
            catch (Exception ex)
            {
                ViewBag.errmsg = ex.Message;
            }
            finally
            {
                con.Close();
            }


            Thread.Sleep(500);
            return RedirectToAction("ListaClienti");
        }


        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(clienti C)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["rosesresortDB"].ConnectionString);
            con.Open();
            try { 
            SqlCommand cmd = new SqlCommand("INSERT INTO clients VALUES (@CodiceFiscale , @Nome , @Cognome ,  @citta , @provincia,  @email , @tel) ", con);
            cmd.Parameters.AddWithValue("CodiceFiscale", C.CodiceFiscale);
            cmd.Parameters.AddWithValue("Nome", C.Nome);
            cmd.Parameters.AddWithValue("Cognome", C.Cognome);
            cmd.Parameters.AddWithValue("citta", C.Citta);
            cmd.Parameters.AddWithValue("provincia", C.Provincia);
            cmd.Parameters.AddWithValue("email", C.Email);
            cmd.Parameters.AddWithValue("tel", C.Tel);
            int row = cmd.ExecuteNonQuery();
            if (row > 0)
            {
                ViewBag.statoAzione= "nuovo cliente si e` inserito con sucesso!";
            }

            }catch(Exception ex)
            {
                ViewBag.err = ex.Message;
            }

            finally { con.Close(); }
            Thread.Sleep(500);
            return View();  
        }



    }
}