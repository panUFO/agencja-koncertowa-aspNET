using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace agencja.Models
{
    public class Koncert
    {
        public int ID { get; set; }

        public int IDKlub { get; set; }

        [DisplayName("Nazwa"), Required(ErrorMessage = "Wprowadź nazwę.")]
        public string Nazwa { get; set; }

        [Range(0, 2000, ErrorMessage = "Wprowadź liczbę z przedziału 0-2000.")]
        public double cena_biletu { get; set; }

        public virtual Klub Klub { get; set; }
    }
}