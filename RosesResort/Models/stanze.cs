using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
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