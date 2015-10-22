using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TonzaDiplomski
{
    public partial class _Default : Page
    {

        // kako generirati dinamički objekt sa dinamičkim imenom ???... Napraviti listu tih objekata
        List<System.Web.UI.HtmlControls.HtmlGenericControl> celijaSGrafom = new List<System.Web.UI.HtmlControls.HtmlGenericControl>();
        Semafor semafor01;

        protected void Page_Load(object sender, EventArgs e)
        {

            //pokupi Cookie da vidimo koji semafor hoćemo otvoriti
            string odabraniSemafor="";
            if (Request.Cookies["OdabraniSemafor"] != null ) {//&& !IsPostBack) {
                odabraniSemafor = Request.Cookies["OdabraniSemafor"]["odabraniSemafor"];
            }
            else {
                Response.Redirect("OdabirSemafora.aspx");
            }
            

            // ako nije postback, onda resetiraj stranicu koja se pokazuje na prvu
            if (!IsPostBack) {
                Session["trenutnaStranica"] = 1;
            }
          

            // tu stvaramo prvi red

            // potrebno je saznati koji semafor učitavamo. To nam piše u cookie-u. Ako je prazno, onda pokaži stranicu za odabir semafora.


            // trebamo metodu koja će stvoriti red. Koliko red ima stupaca ovisi o ulaznom parametru. Na temelju toga se mijenjaju i klase koje formatiraju red.
            // također, moramo paziti da svaki div dobije svoj jedinsveni id.  ID će glasiti: RED{n}_S{m} gdje su n i m broj redtka u stupca
            // da li trebamo svakom retku odmah poslati i koje podatke pokazuje?
            // kako se prebacujemo na novu stranicu? da li je potrebno svaki div označiti i sa brojem stranice, s obzirom da stranice mogu izgledati drugačije po broju redaka i stupaca?

            //Semafor 
                semafor01 = new Semafor(odabraniSemafor, ((LinkButton)Page.Master.FindControl("labelHeaderNaslovSemafora")));
            //stranicaSemafora Stranica1 = new stranicaSemafora("Stranica1");

            /*if (Session["NaslovSemaforaIStranice"] != null) {
                (Page.Master.FindControl("labelHeaderNaslovSemafora") as LinkButton).Text = (string)Session["NaslovSemaforaIStranice"];
                
            }*/


            timerZaStranice.Enabled = false;
            timerZaStranice.Interval = (int)Session["periodOsvjezavanjaStranice"];
            divZaStranice.Controls.Add(semafor01);
            timerZaStranice.Enabled = true;
            

            
        
        }
     

        protected void timerZaStranice_Tick(object sender, EventArgs e) {
           
            timerZaStranice.Interval = (int)Session["periodOsvjezavanjaStranice"];
            
           
           
        }

       
    }
}