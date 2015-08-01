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
        protected void Page_Load(object sender, EventArgs e)
        {
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
            podaci3.Add(new PodatakZaGraf("Ema", 25));
            podaci3.Add(new PodatakZaGraf("Ema", 25));
            podaci3.Add(new PodatakZaGraf("Ema", 25));
            podaci3.Add(new PodatakZaGraf("Ema", 25));
            podaci3.Add(new PodatakZaGraf("Ema", 25));
            podaci3.Add(new PodatakZaGraf("Ema", 25));
            podaci3.Add(new PodatakZaGraf("Ema", 25));
            podaci3.Add(new PodatakZaGraf("Ema", 25));
            podaci3.Add(new PodatakZaGraf("Ema", 25));

            podaci4.Add(new PodatakZaGraf("Domagoj", 12));
            podaci4.Add(new PodatakZaGraf("Valentina", 43));
            podaci4.Add(new PodatakZaGraf("Matko", 18));
            podaci4.Add(new PodatakZaGraf("Ana", 21));
            podaci4.Add(new PodatakZaGraf("Dina", 134));

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

         

            PitaGraf pita1od3 = new PitaGraf("oVo je naslov prve pite",podaci1);
            PrviOdTri.InnerHtml = pita1od3.ToString();
            //PrviOdTri.InnerHtml = "prvi";

            
            
            PitaGraf pita2od3 = new PitaGraf("ovo je naslov druge pite",podaci2);
            DrugiOdTri.InnerHtml = pita2od3.ToString();
            //DrugiOdTri.InnerHtml = "drugi";

            
         
            PitaGraf pita3od3 = new PitaGraf("ovo je naslov trece pite", podaci3);
            TreciOdTri.InnerHtml = pita3od3.ToString();
            //TreciOdTri.InnerHtml = "Treći";


            StupciGraf stupci2od3 = new StupciGraf("ovo je naslov drugih stupaca", podaci5,1);
            DrugiRedDrugi.InnerHtml = stupci2od3.ToString();

            StupciGraf stupci3od3 = new StupciGraf("ovo je naslov trećih stupaca", podaci6,2);
            DrugiRedTreci.InnerHtml = stupci3od3.ToString();
        }
    }
}