using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace TonzaDiplomski {
    public class celijaRetkaSemafora : System.Web.UI.HtmlControls.HtmlGenericControl {


        List<PodatakZaGraf> podaciZaGraf = new List<PodatakZaGraf>();

        string naslovCelije;
        public celijaRetkaSemafora(string pID,int celijaID) {
            ID = pID;
            TagName = "div";
            //InnerHtml = ID + DateTime.Now;
            dohvatiPodatke(celijaID);

            PitaGraf pita = new PitaGraf(naslovCelije, podaciZaGraf);
            InnerHtml = pita.ToString();

            
        }

        void dohvatiPodatke(int celijaID) {
            /* tu sada dohvaćamo podatke i vrstu grafa
            od podataka trebamo: upit, server DB, 
            */

            SemaforiDataContext db = new SemaforiDataContext();
            IEnumerable<viewCelijaPodaci>
               celijaPodaci = from cP in db.viewCelijaPodacis
                        where cP.id == celijaID
                        select cP;

            string connstring;
            naslovCelije = celijaPodaci.Last().upitNaziv;

            //connString = "Server = (LocalDB)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\\BMS_Data.mdf; Integrated Security = False; User ID=tonza;Password=tonza";
            connstring = "Server = "+celijaPodaci.Last().serverString+";";
            connstring += "AttachDbFileName= " + celijaPodaci.Last().dbAttachString + ";";
            connstring += "Database = " + celijaPodaci.Last().dbNaziv + ";";
            connstring += "Integrated Security = " + (celijaPodaci.Last().integratedAuth==true ? "True" : "False")+";";
            connstring += "User ID=" + celijaPodaci.Last().korisnik + ";";
            connstring += "Password=" + celijaPodaci.Last().lozinka + ";";

            SqlConnection myConn = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand(celijaPodaci.Last().upit, myConn);

            myConn.Open();

            string bla;
            // napuni podatke u listu podataka za graf
            using (SqlDataReader oReader = cmd.ExecuteReader()) {
                while (oReader.Read()) {

                    podaciZaGraf.Add(new PodatakZaGraf(oReader.GetValue(0).ToString(), (double)(decimal)oReader.GetValue(1)));
                 
                }

                myConn.Close();
            }


        }
    }


}