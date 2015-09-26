using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

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


        public Semafor (string pID,LinkButton labelaNaslovSemafora) {                   //ovaj pID dolazi iz Cookie-a na page load Default.aspx

            // pamtimo koja se stranica treba učitati
            if (HttpContext.Current.Session["trenutnaStranica"] == null) {
                HttpContext.Current.Session["trenutnaStranica"] = trenutnaStranica;
            }
            else {
                trenutnaStranica = (int)HttpContext.Current.Session["trenutnaStranica"];
            }

            
           

            ID = "Semafor_"+pID;                                   // tu dajemo ID samom semaforu
            

            semafor_DB_ID = Convert.ToInt32(pID);

            //labelaNaslovSemafora.Text = "sredio ga";
            //dodajNaslovSemafora(labelaNaslovSemafora);
            dohvatiNaslovSemafora(labelaNaslovSemafora);
            dohvatiStranice();
            prikaziStranicu();
        }


        private void dodajNaslovSemafora(LinkButton linkButtonNaslov) {


            // bilo bi dobro da imamo klasu za naslov semafora   ???
            
            naslovSemaforaRedak.Attributes["class"] = "row";
            //Controls.Add(naslovSemaforaRedak);

            //SiteMaster master = Page.Master

           // ((Label)Page.Master.FindControl("labelHeaderNaslovSemafora")).Text = "your new text";
            //labelHeaderNaslovSemafora




            naslovSemaforaCelija.Attributes["class"] = "col-lg-12 col-md-12 col-sm-12 semaforNaslov";

            dohvatiNaslovSemafora(linkButtonNaslov);

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

            
            if (brojStranica > 0) {
                stranicaSemafora stranica = new stranicaSemafora(stranica_HTML_ID, semafor_DB_ID, stranice.ElementAt(trenutnaStranica - 1).Id, stranice.ElementAt(trenutnaStranica - 1).refreshPeriod);

                Controls.Clear();
                //dodajNaslovSemafora(linkButtonNaslov);
                //dohvatiNaslovSemafora(linkButtonNaslov);
                Controls.Add(stranica);

                ++trenutnaStranica;
                HttpContext.Current.Session["trenutnaStranica"] = trenutnaStranica;

            }
            else {
                HttpContext.Current.Session["trenutnaStranica"] = 1;
            }
            

            //trenutnaStranica++;



        }

        public void dohvatiNaslovSemafora(LinkButton linkButtonNaslov) {
            SemaforiDataContext db = new SemaforiDataContext();
            tblSemafor
               semafor = (from p in db.tblSemafors where p.Id == semafor_DB_ID 
                                               select p).Single() ;



            //  db.Dispose();                       // ovo će garbage collector srediti
            // naslovSemaforaCelija.InnerHtml = semafori.Last().naziv + " - Stranica " + trenutnaStranica;
            linkButtonNaslov.Text = semafor.naziv;

        }
    }
}