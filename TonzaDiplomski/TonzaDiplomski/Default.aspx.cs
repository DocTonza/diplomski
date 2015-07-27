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
            List<PodatakZaGraf> podaci = new List<PodatakZaGraf>();
            List<PodatakZaGraf> podaci2 = new List<PodatakZaGraf>();
            List<PodatakZaGraf> podaci3 = new List<PodatakZaGraf>();

            //idemo malo na ruke napuniti podatke
            podaci.Add(new PodatakZaGraf("Domagoj", 12));
            podaci.Add(new PodatakZaGraf("Valentina", 43));
            podaci.Add(new PodatakZaGraf("Matko", 18));
            podaci.Add(new PodatakZaGraf("Ana", 21));
            podaci.Add(new PodatakZaGraf("Dina", 134));


            Pita pita1od3 = new Pita("oVo je naslov prve pite",podaci);
            PrviOdTri.InnerHtml = pita1od3.ToString();

            //idemo malo na ruke napuniti podatke
            podaci2.Add(new PodatakZaGraf("Domagoj", 128));
            podaci2.Add(new PodatakZaGraf("Valentina", 143));
            podaci2.Add(new PodatakZaGraf("Matko", 148));
            podaci2.Add(new PodatakZaGraf("Ana", 121));
            podaci2.Add(new PodatakZaGraf("Dina", 127));
            podaci2.Add(new PodatakZaGraf("Davor", 143));
            podaci2.Add(new PodatakZaGraf("Paola", 12));
            podaci2.Add(new PodatakZaGraf("Laura", 23));
            podaci2.Add(new PodatakZaGraf("Ema", 35));
            podaci2.Add(new PodatakZaGraf("Julio", 135));
            Pita pita2od3 = new Pita("ovo je naslov druge pite",podaci2);
            DrugiOdTri.InnerHtml = pita2od3.ToString();


            //idemo malo na ruke napuniti podatke
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
         
            Pita pita3od3 = new Pita("ovo je naslov trece pite", podaci3);
            TreciOdTri.InnerHtml = pita3od3.ToString();

        }
    }
}