using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FitBooking
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitForm(object sender, EventArgs e)
        {
            var searchText = Server.UrlEncode(search.Text);
            var typValue = Request.Form["typ"].ToString(); ;
            Response.Redirect("~/wyszukaj.aspx?adres=" + searchText + "&typwyszukania=" + typValue);
        }
    }
}