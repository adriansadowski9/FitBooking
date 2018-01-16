using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using FitBooking.CsScripts;
using FitBooking.Models;
using System.Globalization;

namespace FitBooking
{
    public partial class Profil : Page
    {
        private Entities3 db = new Entities3();
        private ApplicationDbContext db1 = new ApplicationDbContext();

        private string pid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                pid = Request.QueryString["id"];

            }

            else
            {
                Response.Redirect("~");
            }



        }
    }
}