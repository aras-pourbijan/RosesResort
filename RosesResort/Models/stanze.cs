using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace RosesResort.Models
{
    public class stanze
    {
        public int IDstanza { get; set; }

        [Display(Name = "Nome di Stanza")]
        [Required(ErrorMessage = "obligatorio")]
        public string NomeStanza { get; set; }

        [Display(Name = "tipo di stanza")]
        [Required(ErrorMessage = "obligatorio")]
        public string Tipologia { get; set; }

        [Display(Name = "Descrizione")]
        public string Descrizione { get; set; }

    }
}