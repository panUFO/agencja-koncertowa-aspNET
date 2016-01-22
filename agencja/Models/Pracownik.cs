using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using agencja.Validators;

namespace agencja.Models
{
    public class Pracownik
    {
        public int ID { get; set; }

        [DisplayName("Imię"), Required(ErrorMessage = "Wprowadź imię.")]
        public string Imie { get; set; }


        [DisplayName("Nazwisko")]
        [StringLength(30, MinimumLength = 2)]
        [Required(ErrorMessage = "Nazwisko jest za krótkie")]
        public string Nazwisko { get; set; }

        [Required]
        public string Plec { get; set; }

        [Required]
        public string Stanowisko { get; set; }

        [Required]
        [isPesel("Plec", ErrorMessage = "Błędny pesel!")]
        public string Pesel { get; set; }


    }
}