using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitBooking.Models
{
    public partial class ModelUserProfil
    {
        public Uzytkownik user { get; set ; }
        public Adres adres { get; set; }
        public Spolecznosc spolecznosc { get; set; }
        public String rola{ get; set; }
        public double dystans { get; set; }


    public virtual ICollection<ModelUserProfil> Model { get; set; }

    }
}