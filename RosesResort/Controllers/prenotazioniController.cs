using RosesResort.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RosesResort.Controllers
{
    public class prenotazioniController : Controller
    {
        // GET: prenotazioni

        [Authorize]
        public ActionResult ListaPrenotazioni()
        {
            List<Prenotazione> ListaPrenotazioni = new List<Prenotazione>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["rosesresortDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select IDprenotazione, nome, cognome, checkin, checkout,nomestanza, tipologia, tel , tariffa, acconto from prenotazioni inner join clients on prenotazioni.IDclienti=clients.IDclienti inner join stanze on prenotazioni.IDstanza=stanze.IDstanza", con);
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {

                while (reader.Read())
                {
                    Prenotazione p=new Prenotazione();  
                    p.IDprenotazione= Convert.ToInt32(reader["IDprenotazione"]);
                    p.Checkin = Convert.ToDateTime(reader["Checkin"]);
                    p.Checkout = Convert.ToDateTime(reader["Checkout"]);
                    p.Acconto = Convert.ToDecimal(reader["acconto"]);
                    p.Tariffa = Convert.ToDecimal(reader["Tariffa"]);
                    ListaPrenotazioni.Add(p);   
                }
            }
            catch (Exception ex)
            {
            }
            finally { con.Close(); }




            return View(ListaPrenotazioni);
        }
    }
}