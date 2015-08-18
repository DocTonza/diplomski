using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TonzaDiplomski {
    public partial class OdaberiSemafor : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void nazivLabel_Click(object sender, EventArgs e) {
            // tu sada spremamo odabrani semafor u cookie i redirectamo na default stranicu
            

            LinkButton btn = (LinkButton)(sender);
            string odabraniSemafor = btn.CommandArgument;

            HttpCookie kolacic = new HttpCookie("OdabraniSemafor");
            kolacic.Values.Add("OdabraniSemafor", odabraniSemafor);
            kolacic.Expires.AddMonths(6);
            Response.Cookies.Add(kolacic);

            Response.Redirect("default.aspx");

        }
    }
}