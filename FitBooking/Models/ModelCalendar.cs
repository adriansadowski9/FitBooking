using DHTMLX.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitBooking.Models
{
    public partial class ModelCaledar
    {
        public Uzytkownik klient { get; set ; }
        public Uzytkownik funkcyjna { get; set; }
        public DHXScheduler scheduler { get; set; }
        public List <Spotkanie> lista { get; set; }
        public Boolean wlasciciel { get; set; } = false;
        public int select { get; set; }
        //public virtual ICollection<ModelCaledar> Model { get; set; }

    }
}