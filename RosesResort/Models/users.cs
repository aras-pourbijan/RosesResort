using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RosesResort.Models
{
    public class users
    {
        public int IDuser { get; set; }
        [Display(Name = "Nome utente")]
        [Required (ErrorMessage ="insersci tuo nome utente per continuare!")]
        [StringLength(30, MinimumLength =4, ErrorMessage ="Nome utente deve essere  tra 4 e 30 caratteri")]
        public string NomeUtente { get; set; }
        [Display (Name="Password")]
        [Required (ErrorMessage ="e tuo password?!")]

        public string PasswordDiUser { get; set; }
        public bool ricordami { get; set; } 
    }
}