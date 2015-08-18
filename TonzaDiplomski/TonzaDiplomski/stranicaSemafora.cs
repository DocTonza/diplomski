using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TonzaDiplomski {
    public class stranicaSemafora : System.Web.UI.HtmlControls.HtmlGenericControl {

        int semafor_DB_ID;
        int stranica_DB_ID;
        int refreshPeriod;

        public stranicaSemafora(string pID, int pSemaforID, int pstranica_DB_ID, int pRefreshPeriod) {
            ID = pID;
            refreshPeriod = pRefreshPeriod;
            HttpContext.Current.Session["periodOsvjezavanjaStranice"] = refreshPeriod;

            //Semafor juraSemafor = (Semafor)this.Parent;
            //System.Web.UI.HtmlControls.HtmlGenericControl divIznad = (System.Web.UI.HtmlControls.HtmlGenericControl)juraSemafor.Parent;

            //ContentPlaceHolder MainContent = this.Parent.Parent.Parent.FindControl("glavniPlaceholder") as ContentPlaceHolder;

            //System.Web.UI.Timer mojtimer = (System.Web.UI.Timer)MainContent.FindControl("timerZaStranice");
            //mojtimer.Interval = refreshPeriod;

            

            semafor_DB_ID = pSemaforID;
            stranica_DB_ID = pstranica_DB_ID;
            TagName = "div";  

            //dohvatiBrojRedaka(semafor_DB_ID);
            dodajRetke(pstranica_DB_ID);

        }

        private void dohvatiBrojRedaka(int semaforID) {
            SemaforiDataContext db = new SemaforiDataContext();
            IEnumerable<tblStranica>
               stranice = from s in db.tblStranicas
                          where s.Id == stranica_DB_ID
                          select s;

                          
        }

        void osvjeziStranicu() {


        }

        void dodajRetke(int pstranica_DB_ID) {
            string idRetka;
            //dodajemo retke

            int i= 1;
            SemaforiDataContext db = new SemaforiDataContext();
            IEnumerable<tblRedak> redci = from r in db.tblRedaks
                                          where r.stranicaID == stranica_DB_ID
                                          select r;

            foreach (tblRedak redakItem in redci) {
                idRetka = "redak_" + i;
                redakStraniceSemafora redak = new redakStraniceSemafora(idRetka, semafor_DB_ID,redakItem.id);
                redak.Attributes["class"] = "row";
                Controls.Add(redak);
                ++i;
            }
            /*for (int i = 1; i <= brojRedaka; ++i) {
                idRetka = "redak_" + i;
                redakStraniceSemafora redak = new redakStraniceSemafora(idRetka,semafor_DB_ID);
                redak.Attributes["class"] = "row";
                Controls.Add(redak);
            }*/

        }
        // stranica nasljeđuje HtmlGenericControl, pa može biti DIV tag
        // stranica ima retke, a retci imaju stupce
        // stranica je objekt koji je zapravo div. Treba napraviti inheritance

    }
}