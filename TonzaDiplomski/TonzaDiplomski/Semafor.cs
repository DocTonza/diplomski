using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TonzaDiplomski {
    public class Semafor : System.Web.UI.HtmlControls.HtmlGenericControl {
        int semafor_DB_ID;                   //ovo je property koji kaže koji je to semafor u našim postavkama, za razliku od ID taga koji se upisuje u HTML. Možda se može i objediniti.
        int brojStranica;
        int trenutnaStranica=1;                //uvijek krećemo od prve stranice
       
        System.Web.UI.HtmlControls.HtmlGenericControl naslovSemaforaRedak = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
        System.Web.UI.HtmlControls.HtmlGenericControl naslovSemaforaCelija = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

        System.Web.UI.UpdatePanel glavniPanel = new System.Web.UI.UpdatePanel();

        SemaforiDataContext db = new SemaforiDataContext();
        IEnumerable<tblStranica> stranice;


        public Semafor (string pID) {                   //ovaj pID dolazi iz Cookie-a na page load Default.aspx

            // pamtimo koja se stranica treba učitati
            if (HttpContext.Current.Session["trenutnaStranica"] == null) {
                HttpContext.Current.Session["trenutnaStranica"] = trenutnaStranica;
            }
            else {
                trenutnaStranica = (int)HttpContext.Current.Session["trenutnaStranica"];
            }

            
           

            ID = "Semafor_"+pID;                                   // tu dajemo ID samom semaforu
            

            semafor_DB_ID = Convert.ToInt32(pID);
            
            dodajNaslovSemafora();
            dohvatiStranice();
            prikaziStranicu();
        }


        private void dodajNaslovSemafora() {


            // bilo bi dobro da imamo klasu za naslov semafora   ???
            
            naslovSemaforaRedak.Attributes["class"] = "row";
            Controls.Add(naslovSemaforaRedak);

            
            

            naslovSemaforaCelija.Attributes["class"] = "col-lg-12 col-md-12 col-sm-12 semaforNaslov";

            dohvatiNaslovSemafora();

            // probaj dodati panel, pa na njega onda dodati naslov semafora
            glavniPanel.ID = "glavniPanel";
            glavniPanel.ContentTemplateContainer.Controls.Add(naslovSemaforaCelija);
            naslovSemaforaRedak.Controls.Add(glavniPanel);
            
            //naslovSemaforaRedak.Controls.Add(naslovSemaforaCelija);
        }

        void dohvatiStranice() {
            string stranica_HTML_ID;

            stranice = from s in db.tblStranicas
                                                where s.semaforID == semafor_DB_ID
                                                select s;

            brojStranica = stranice.Count();


            
        }

        public void prikaziStranicu() {

            if (trenutnaStranica > brojStranica) {
                trenutnaStranica = 1;
            }

            string stranica_HTML_ID = ID + "_stranica_" + trenutnaStranica;                // gereriramo HTML ID
            //stranice.ElementAt(trenutnaStranica-1).Id
            stranicaSemafora stranica = new stranicaSemafora(stranica_HTML_ID, semafor_DB_ID, stranice.ElementAt(trenutnaStranica - 1).Id, stranice.ElementAt(trenutnaStranica - 1).refreshPeriod);
            
            Controls.Clear();
            dodajNaslovSemafora();
            Controls.Add(stranica);

            ++trenutnaStranica;
                HttpContext.Current.Session["trenutnaStranica"] = trenutnaStranica;
            

            //trenutnaStranica++;



        }

        public void dohvatiNaslovSemafora() {
            SemaforiDataContext db = new SemaforiDataContext();
            IEnumerable<tblSemafor> 
               semafori = from p in db.tblSemafors where p.Id == semafor_DB_ID 
                                               select p ;



            //  db.Dispose();                       // ovo će garbage collector srediti
            naslovSemaforaCelija.InnerHtml = semafori.Last().naziv + " - Stranica " + trenutnaStranica;

        }
    }
}