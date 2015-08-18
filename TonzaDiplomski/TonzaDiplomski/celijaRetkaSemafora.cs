using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace TonzaDiplomski {
    public class celijaRetkaSemafora : System.Web.UI.HtmlControls.HtmlGenericControl {

        public celijaRetkaSemafora(string pID,int redakID) {
            ID = pID;
            TagName = "div";
            InnerHtml = ID + DateTime.Now;

            dohvatiPodatke();
        }

        void dohvatiPodatke() {
            // tu sada dohvaćamo podatke i vrstu grafa
            //string connString = WebConfigurationManager.ConnectionStrings["SemaforiDBContext"].ConnectionString;
            //SqlConnection kon = new SqlConnection(connString);
            //SqlCommand komanda = new SqlCommand();
            //komanda.Connection = kon;
            //komanda.CommandType = System.Data.CommandType.Text;
            //komanda.CommandText = "Select * from celije";

            //kon.Open();
            //int brojRedova = komanda.ExecuteNonQuery();
            //kon.Close();

            //SemaforiDataContext db = new SemaforiDataContext();
            //IEnumerable<tblStranica> stranice = from p in db.tblStranicas
            //                                 select p;

            //int i = stranice.Count();
            //int a = 0;

            //foreach (tblStranica stranica in stranice) {
            //    stranica.
            //}


        }
    }


}