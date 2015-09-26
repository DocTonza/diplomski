using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace TonzaDiplomski {
    public class CelijaRetkaSemafora : System.Web.UI.HtmlControls.HtmlGenericControl {


        List<PodatakZaGraf> podaciZaGraf = new List<PodatakZaGraf>();

        string naslovCelije;
        public CelijaRetkaSemafora(string pID,int celijaID) {
            ID = pID;
            TagName = "div";
            //InnerHtml = ID + DateTime.Now;
            dohvatiPodatke(celijaID);

            SemaforiDataContext db = new SemaforiDataContext();

            tblCelija celija = (from c in db.tblCelijas where c.id == celijaID select c).Single();

            if (celija.grafID == 1) {
                PitaGraf pita = new PitaGraf(naslovCelije, podaciZaGraf,1);
                InnerHtml = pita.ToString();
            }

            if (celija.grafID == 2) {
                StupciGraf pita = new StupciGraf(naslovCelije, podaciZaGraf,1);
                InnerHtml = pita.ToString();
            }

            if (celija.grafID == 3) {
                StupciGraf pita = new StupciGraf(naslovCelije, podaciZaGraf, 2);
                InnerHtml = pita.ToString();
            }

            if (celija.grafID == 4) {
                CrtaGraf pita = new CrtaGraf(naslovCelije, podaciZaGraf,1);
                InnerHtml = pita.ToString();
            }



        }

        void dohvatiPodatke(int celijaID) {
            /* tu sada dohvaćamo podatke i vrstu grafa
            od podataka trebamo: upit, server DB, 
            */

            SemaforiDataContext db = new SemaforiDataContext();

            viewCelijaPodaci celijaPodaci = (from cP in db.viewCelijaPodacis
                        where cP.id == celijaID
                        select cP).Single();

            string connstring;
            naslovCelije = celijaPodaci.upitNaziv;

            
            connstring = "Server = "+celijaPodaci.serverString+";";

            // ovaj dio dopisujemo samo ako postoji u bazi, a koristi se samo kad se radi o localDB-u, kada treba attachati bazu. Kad se spajamo na "Veliki" SQL to nam ne treba, pa kod unosa upozori korisnika na to
            if (celijaPodaci.dbAttachString !=null && celijaPodaci.dbAttachString.Length>0)
                connstring += "AttachDbFileName= " + celijaPodaci.dbAttachString + ";";

            SimplerAES saes = new SimplerAES();
            connstring += "Database = " + celijaPodaci.dbNaziv + ";";
            connstring += "Integrated Security = " + (celijaPodaci.integratedAuth==true ? "True" : "False")+";";
            connstring += "User ID=" + celijaPodaci.korisnik + ";";
            connstring += "Password=" + saes.Decrypt(celijaPodaci.lozinka) + ";";

            SqlConnection myConn = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand(celijaPodaci.upit, myConn);

            try {
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
            catch (Exception e22) {

            }

        }
    }


}