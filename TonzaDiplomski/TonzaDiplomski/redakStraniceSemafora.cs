using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TonzaDiplomski {
    public class redakStraniceSemafora : System.Web.UI.HtmlControls.HtmlGenericControl {

        //string ID;
        int semaforID;

        public redakStraniceSemafora(string pID, int pSemaforID, int pRedak_DB_ID) {
            ID = pID;                       //ovo je HTML ID
            semaforID = pSemaforID;
            TagName = "div";                // treba nam da je DIV
            //dodajCelije(3,ID);
            dodajCelije(pRedak_DB_ID, ID);
        }

        void dodajCelije(int pRedak_DB_ID, string redakID) {
            string HTML_ID_Celije;

            int i = 1;
            SemaforiDataContext db = new SemaforiDataContext();
            IEnumerable<tblCelija>
               celije = from c in db.tblCelijas
                        where c.redakID == pRedak_DB_ID
                        select c;

            foreach (tblCelija celijaItem in celije) {
                HTML_ID_Celije = redakID + "_celija_" + i;
                celijaRetkaSemafora celija = new celijaRetkaSemafora(HTML_ID_Celije, celijaItem.id);
                celija.Attributes["class"] = "col-lg-4 col-md-6";

                Controls.Add(celija);
                ++i;
            }
            /*for (int i = 1; i <= brojCelija; ++i) {
                idCelije = redakID+"_celija_" + i;
                celijaRetkaSemafora celija = new celijaRetkaSemafora(idCelije);
                celija.Attributes["class"] = "col-lg-4 col-md-6";
                
                Controls.Add(celija);
            }*/

        }
    }
}