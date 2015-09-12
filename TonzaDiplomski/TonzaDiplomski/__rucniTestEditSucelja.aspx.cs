using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TonzaDiplomski {
    public partial class __rucniTestEditSucelja : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            
            

            if (IsPostBack && ViewState["EditMode"] !=null) {
                if (ViewState["EditMode"].ToString() == "1")
                    editSemafor.Visible = true;
            }
        }



        protected void ListViewSemafori_ItemCommand(object sender, ListViewCommandEventArgs e) {
            if (String.Equals(e.CommandName, "OdabraniSemafor")) {

                // sad napuni layer sa semaforom

                SemaforiDataContext db = new SemaforiDataContext();

                var semafor=(from tblSemafor in db.tblSemafors where tblSemafor.Id == Convert.ToInt32(e.CommandArgument) select tblSemafor).Single();

                textBoxSemaforNaziv.Text = semafor.naziv;
                SemaforID.Text = semafor.Id.ToString();
                ViewState["EditMode"] = "1";
                editSemafor.Visible = true;
                


            }
        }

        protected void ListViewStranice_ItemCommand(object sender, ListViewCommandEventArgs e) {


            if (String.Equals(e.CommandName, "OdabranaStranica")) {

                // sad napuni layer sa stranicom

                SemaforiDataContext db = new SemaforiDataContext();
                var stranica = (from tblStranica in db.tblStranicas where tblStranica.Id == Convert.ToInt32(e.CommandArgument) select tblStranica).Single();

                LabelStranicaID.Text = stranica.Id.ToString();
                TextBoxStranicaNaziv.Text = stranica.naziv;
                TextBoxStranicaVrijemePrikazivanja.Text = stranica.refreshPeriod.ToString();
                /*textBoxSemaforNaziv.Text = stanica.naziv;
                SemaforID.Text = stranica.Id.ToString();
                ViewState["EditMode"] = "1";
                editSemafor.Visible = true;
                */


            }
        }

        protected void textBoxSemaforNaziv_TextChanged(object sender, EventArgs e) {
            SemaforiDataContext db = new SemaforiDataContext();
            var sem = (from s in db.tblSemafors where s.Id == Convert.ToInt32(SemaforID.Text) select s).Single();
            sem.naziv = textBoxSemaforNaziv.Text;

            try {
                db.SubmitChanges();
            }
            catch (Exception e1) {
                Console.WriteLine(e1);
            }
            
            ListViewSemafori.DataBind();
            //menuUpdatePanel.Update();
            //Response.Redirect(HttpContext.Current.Request.Path);
        }

        protected void TextBoxStranicaNaziv_TextChanged(object sender, EventArgs e) {

            SemaforiDataContext db = new SemaforiDataContext();
            var stranica = (from tblStranica in db.tblStranicas where tblStranica.Id == Convert.ToInt32(LabelStranicaID.Text) select tblStranica).Single();

            stranica.naziv = TextBoxStranicaNaziv.Text;

            try {
                db.SubmitChanges();
            }
            catch (Exception e1) {
                Console.WriteLine(e1);  
            }

            ListViewStranice.DataBind();
        }

        protected void OdabranaStranica_Click(object sender, EventArgs e) {

            // tu mijenjamo css klasu za asp button koji je pozvao stranicu kako bi dobili tab efekt

            foreach (Control l in (sender as LinkButton).Parent.Parent.Controls) {
                if (l is ListViewDataItem) {
                    foreach (Control k in l.Controls) {
                        if (k is LinkButton) {
                            (k as LinkButton).CssClass = "";
                        }
                    }
                }
            }
 
            (sender as LinkButton).CssClass = "stranica";
            
        }

        protected void TextBoxStranicaVrijemePrikazivanja_TextChanged(object sender, EventArgs e) {

            SemaforiDataContext db = new SemaforiDataContext();
            var stranica = (from tblStranica in db.tblStranicas where tblStranica.Id == Convert.ToInt32(LabelStranicaID.Text) select tblStranica).Single();

            stranica.refreshPeriod = Convert.ToInt32(TextBoxStranicaVrijemePrikazivanja.Text);

            try {
                db.SubmitChanges();
            }
            catch (Exception e1) {
                Console.WriteLine(e1);
            }

            ListViewStranice.DataBind();
        }
    }
}