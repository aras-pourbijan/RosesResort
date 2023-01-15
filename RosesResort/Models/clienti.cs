using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RosesResort.Models
{
    public class clienti
    {

        public int IDcliente { get; set; }
        [Display(Name = "Codice Fiscale")]
        [Required(ErrorMessage = "obligatorio")]
        public string CodiceFiscale { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "obligatorio")]
        public string Nome { get; set; }
        [Display(Name = "Cognome")]
        [Required(ErrorMessage = "obligatorio")]
        public string Cognome { get; set; }
        [Display(Name = "Citta")]
        
        public string Citta { get; set; }
        [Display(Name = "Provincia")]
        public string Provincia { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Tel/Cellulare")]
        public string Tel { get; set; }

    }
}