using System;
using System.Collections.Generic;
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
                Response.Redirect("OdaberiSemafor.aspx");
            }
            
            
            List<PodatakZaGraf> podaci1 = new List<PodatakZaGraf>();
            List<PodatakZaGraf> podaci2 = new List<PodatakZaGraf>();
            List<PodatakZaGraf> podaci3 = new List<PodatakZaGraf>();
            List<PodatakZaGraf> podaci4 = new List<PodatakZaGraf>();
            List<PodatakZaGraf> podaci5 = new List<PodatakZaGraf>();
            List<PodatakZaGraf> podaci6 = new List<PodatakZaGraf>();

            //idemo malo na ruke napuniti podatke
            podaci1.Add(new PodatakZaGraf("Domagoj", 12));
            podaci1.Add(new PodatakZaGraf("Valentina", 43));
            podaci1.Add(new PodatakZaGraf("Matko", 18));
            podaci1.Add(new PodatakZaGraf("Ana", 21));
            podaci1.Add(new PodatakZaGraf("Dina", 134));

            podaci2.Add(new PodatakZaGraf("Domagoj", 124));
            podaci2.Add(new PodatakZaGraf("Valentina", 163));
            podaci2.Add(new PodatakZaGraf("Matko", 148));
            podaci2.Add(new PodatakZaGraf("Ana", 121));
            podaci2.Add(new PodatakZaGraf("Dina", 127));
            podaci2.Add(new PodatakZaGraf("Davor", 143));
            podaci2.Add(new PodatakZaGraf("Paola", 12));
            podaci2.Add(new PodatakZaGraf("Laura", 23));
            podaci2.Add(new PodatakZaGraf("Ema", 35));
            podaci2.Add(new PodatakZaGraf("Julio", 135));

            podaci3.Add(new PodatakZaGraf("Ema", 125));
            podaci3.Add(new PodatakZaGraf("Domagoj", 12));
            podaci3.Add(new PodatakZaGraf("Valentina", 13));
            podaci3.Add(new PodatakZaGraf("Matko", 18));
            podaci3.Add(new PodatakZaGraf("Ana", 12));
            podaci3.Add(new PodatakZaGraf("Dina", 12));
            podaci3.Add(new PodatakZaGraf("Davor", 14));
            podaci3.Add(new PodatakZaGraf("Paola", 12));
            podaci3.Add(new PodatakZaGraf("Laura", 13));
            podaci3.Add(new PodatakZaGraf("Goran K", 625));
            podaci3.Add(new PodatakZaGraf("Ema", 25));
            podaci3.Add(new PodatakZaGraf("Ema", 25));
            podaci3.Add(new PodatakZaGraf("Ema", 25));
            podaci3.Add(new PodatakZaGraf("Ema", 25));
            podaci3.Add(new PodatakZaGraf("Ema", 25));
            podaci3.Add(new PodatakZaGraf("Ema", 25));
            podaci3.Add(new PodatakZaGraf("Ema", 25));
            podaci3.Add(new PodatakZaGraf("Ema", 25));

            podaci4.Add(new PodatakZaGraf("1999", 12));
            podaci4.Add(new PodatakZaGraf("2000", 43));
            podaci4.Add(new PodatakZaGraf("2001", 18));
            podaci4.Add(new PodatakZaGraf("2002", 21));
            podaci4.Add(new PodatakZaGraf("2003", 134));
            podaci4.Add(new PodatakZaGraf("2004", 765));
            podaci4.Add(new PodatakZaGraf("2005", 123));
            podaci4.Add(new PodatakZaGraf("2006", 34));
            podaci4.Add(new PodatakZaGraf("2007", 57));
            podaci4.Add(new PodatakZaGraf("2008", 76));
            podaci4.Add(new PodatakZaGraf("2009",67));
            podaci4.Add(new PodatakZaGraf("2010", 123));
            podaci4.Add(new PodatakZaGraf("2011", 321));
            podaci4.Add(new PodatakZaGraf("2012", 45));
            podaci4.Add(new PodatakZaGraf("2013", 78));
            podaci4.Add(new PodatakZaGraf("2014", 97));
            podaci4.Add(new PodatakZaGraf("2015", 235));

            podaci5.Add(new PodatakZaGraf("Domagoj", 124));
            podaci5.Add(new PodatakZaGraf("Valentina", 163));
            podaci5.Add(new PodatakZaGraf("Matko", 148));
            podaci5.Add(new PodatakZaGraf("Ana", 121));
            podaci5.Add(new PodatakZaGraf("Dina", 127));
            podaci5.Add(new PodatakZaGraf("Davor", 143));
            podaci5.Add(new PodatakZaGraf("Paola", 12));
            podaci5.Add(new PodatakZaGraf("Laura", 23));
            podaci5.Add(new PodatakZaGraf("Ema", 35));
            podaci5.Add(new PodatakZaGraf("Julio", 135));

            podaci6.Add(new PodatakZaGraf("Ema", 125));
            podaci6.Add(new PodatakZaGraf("Domagoj", 12));
            podaci6.Add(new PodatakZaGraf("Valentina", 13));
            podaci6.Add(new PodatakZaGraf("Matko", 18));
            podaci6.Add(new PodatakZaGraf("Ana", 12));
            podaci6.Add(new PodatakZaGraf("Dina", 12));
            podaci6.Add(new PodatakZaGraf("Davor", 14));
            podaci6.Add(new PodatakZaGraf("Paola", 12));
            podaci6.Add(new PodatakZaGraf("Laura", 13));
            podaci6.Add(new PodatakZaGraf("Zeljka", 35));
            podaci6.Add(new PodatakZaGraf("Marija", 43));
            podaci6.Add(new PodatakZaGraf("Karlo", 54));
            podaci6.Add(new PodatakZaGraf("Mateo", 15));
            podaci6.Add(new PodatakZaGraf("Nika", 32));
            podaci6.Add(new PodatakZaGraf("Hrvoje", 76));
            podaci6.Add(new PodatakZaGraf("Davor", 29));
            podaci6.Add(new PodatakZaGraf("Nikola", 56));
            podaci6.Add(new PodatakZaGraf("Martin", 48));


            // tu stvaramo prvi red

            // potrebno je saznati koji semafor učitavamo. To nam piše u cookie-u. Ako je prazno, onda pokaži stranicu za odabir semafora.


            // trebamo metodu koja će stvoriti red. Koliko red ima stupaca ovisi o ulaznom parametru. Na temelju toga se mijenjaju i klase koje formatiraju red.
            // također, moramo paziti da svaki div dobije svoj jedinsveni id.  ID će glasiti: RED{n}_S{m} gdje su n i m broj redtka u stupca
            // da li trebamo svakom retku odmah poslati i koje podatke pokazuje?
            // kako se prebacujemo na novu stranicu? da li je potrebno svaki div označiti i sa brojem stranice, s obzirom da stranice mogu izgledati drugačije po broju redaka i stupaca?

            //Semafor 
                semafor01 = new Semafor(odabraniSemafor);
            //stranicaSemafora Stranica1 = new stranicaSemafora("Stranica1");

            //glavniPlaceholder.Controls.Add(semafor01);
            timerZaStranice.Enabled = false;
            timerZaStranice.Interval = (int)Session["periodOsvjezavanjaStranice"];
            divZaStranice.Controls.Add(semafor01);
            timerZaStranice.Enabled = true;
            

            
            //generirajRedak(rbRetka,brojStupaca);
           
            System.Web.UI.HtmlControls.HtmlGenericControl PrviOdTri = new
                                                    System.Web.UI.HtmlControls.HtmlGenericControl();
            PrviOdTri.ID = "PrviOdTri";
            PrviOdTri.Attributes["class"]= "col-lg-4 col-md-6";

            System.Web.UI.HtmlControls.HtmlGenericControl DrugiOdTri = new
                                                    System.Web.UI.HtmlControls.HtmlGenericControl("div");
            DrugiOdTri.ID = "DrugiOdTri";
            DrugiOdTri.Attributes["class"] = "col-lg-4 col-md-6";

            System.Web.UI.HtmlControls.HtmlGenericControl TreciOdTri = new
                                                    System.Web.UI.HtmlControls.HtmlGenericControl();
            TreciOdTri.ID = "TreciOdTri";
            TreciOdTri.Attributes["class"] = "col-lg-4 col-md-6";

            //PrviRed.Controls.Add(PrviOdTri);
            //PrviRed.Controls.Add(DrugiOdTri);
            //PrviRed.Controls.Add(TreciOdTri);


            PitaGraf pita1od3 = new PitaGraf("oVo je naslov prve pite",podaci1);
         
            PrviOdTri.InnerHtml = pita1od3.ToString();
            //PrviOdTri.InnerHtml = "prvi";

            
            
            PitaGraf pita2od3 = new PitaGraf("ovo je naslov druge pite",podaci2);
            DrugiOdTri.InnerHtml = pita2od3.ToString();
            //DrugiOdTri.InnerHtml = "drugi";

            
         
            PitaGraf pita3od3 = new PitaGraf("ovo je naslov trece pite", podaci3);
            TreciOdTri.InnerHtml = pita3od3.ToString();
            //TreciOdTri.InnerHtml = "Treći";


            CrtaGraf crta1od3 = new CrtaGraf("Ovo je naslov linijskog grafa", podaci4, 1);
            //DrugiRedPrvi.InnerHtml = crta1od3.ToString();

            StupciGraf stupci2od3 = new StupciGraf("ovo je naslov drugih stupaca", podaci5,1);
            //DrugiRedDrugi.InnerHtml = stupci2od3.ToString();

            StupciGraf stupci3od3 = new StupciGraf("ovo je naslov trećih stupaca", podaci6,2);
            //DrugiRedTreci.InnerHtml = stupci3od3.ToString();
        }
        public void generirajRedak(int rBr, int BrojStupaca) {
            for (int i = 1; i <= BrojStupaca; ++i) { 
                celijaSGrafom.Add(new System.Web.UI.HtmlControls.HtmlGenericControl());
                celijaSGrafom.Last().ID = "";
                celijaSGrafom.Last().Attributes["class"]= "col-lg-4 col-md-6";
            }


        }

        protected void timerZaStranice_Tick(object sender, EventArgs e) {
            // System.Web.UI.HtmlControls.HtmlGenericControl jura = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
            // jura.InnerHtml = "ovo je Jura </br>" + DateTime.Now;
            // divZaStranice.Controls.Add(jura);

            //semafor01.dohvatiNaslovSemafora();
            timerZaStranice.Interval = (int)Session["periodOsvjezavanjaStranice"];
            // semafor01.Controls.Clear();
            // semafor01.Controls.Add(jura);

        }
    }
}