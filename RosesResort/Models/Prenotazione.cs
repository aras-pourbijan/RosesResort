using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace RosesResort.Models
{
    public class Prenotazione
    {
        public int IDprenotazione { get; set; }

        [Display(Name = "Data del Prenotazione")]
        [Required(ErrorMessage = "Obligatrio")]
        public DateTime DataPrenotazione { get; set; }
        [Display(Name = "Stagione")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public int StaggioneDiAnno { get; set; }

        [Display(Name = "Data del check-in")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Obligatrio")]
        public DateTime Checkin { get; set; }
        [Display(Name = "Data del check-out")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Obligatrio")]
        public DateTime Checkout { get; set; }
        [Display(Name ="Acconto versato")]
        [Range(1, int.MaxValue)]
        public decimal Acconto { get; set; }
        [Display(Name = "Descrizione")]
        public string Descrizione { get; set; }

        [Display(Name = "Cliente")]
        public int IDclienti { get; set; }

        [Display(Name = "stanza")]
        public int IDstanza { get; set; }
        [Display(Name = "Tariffa")]
        [Required(ErrorMessage = "Obligatrio")]
        [Range(45, int.MaxValue)]
        public decimal Tariffa { get; set; }
        public string ospite { get; set; }  
    }
}



