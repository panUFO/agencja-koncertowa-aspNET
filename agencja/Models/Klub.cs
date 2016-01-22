using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace agencja.Models
{
    public class Klub
    {
        public int ID { get; set; }

        [DisplayName("Nazwa"), Required(ErrorMessage = "Wprowadź nazwę.")]
        public string Nazwa { get; set; }

        [DisplayName("Miasto"), Required(ErrorMessage = "Wprowadź miasto.")]
        public string Miasto { get; set; }

        [DisplayName("Ilosc_miejsc"), Required(ErrorMessage = "Wprowadź ilość miejsc.")]
        public int Ilosc_miejsc { get; set; }

        public virtual ICollection<Koncert> Koncerty { get; set; }
    }
}