using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace RosesResort.Models
{
    public class ServiziAggiunti
    {
        public int IDserviziAggiunti { get; set; }

        [Display(Name = "Tipo Di Stanza")]
        [Required(ErrorMessage = "Seleziona tipo di stanza")]
        public string TipoDiServizio { get; set; }
        [Display(Name = "Data del richiesta")]
        [DisplayFormat(DataFormatString ="{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DataRichiesta { get; set; }
        [Display(Name = "Quantita")]
        [Range(1,8,ErrorMessage = "seleziona da 1 a 8 altrimenti avvisa direttore")]
        public int Quantita { get; set; }

        [Display(Name = "prezzo totale")]
        [Required(ErrorMessage = "insersci prezzo totale")]
        [Range(10, 500, ErrorMessage = "inserisci prezzo")]

        public decimal Prezzo { get; set; }
        [Display(Name = "ID prenotazione")]
        public int IDprenotazione { get; set; }
    }
}