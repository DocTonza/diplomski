using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TonzaDiplomski {
    public partial class __rucniTestEditSucelja : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {




            //if (IsPostBack && ViewState["EditMode"] != null) {
            //    if (ViewState["EditMode"].ToString() == "1")
            //        editSemafor.Visible = true;
            //}
        }



        protected void ListViewSemafori_ItemCommand(object sender, ListViewCommandEventArgs e) {
            if (String.Equals(e.CommandName, "OdabraniSemafor")) {

                // sad napuni layer sa semaforom
                prikaziSemafor(Convert.ToInt32(e.CommandArgument));



            }
        }

        public void prikaziSemafor(int pSemaforID) {

            SemaforiDataContext db = new SemaforiDataContext();

            var semafor = (from tblSemafor in db.tblSemafors where tblSemafor.Id == pSemaforID select tblSemafor).Single();

            // straniceSrc.DataBind();
            textBoxSemaforNaziv.Text = semafor.naziv;
            labelSemaforID.Text = semafor.Id.ToString();
            ViewState["EditMode"] = "1";
            
            ListViewStranice.DataBind();

            // trebalo bi odabrati prvu stranicu za prikaz ako je moguće 
            // najlakše je da nađemo kontrolu?

            // pronađi prvu stranicu
            // pazi da li slučajno nije niz prazan
            if (ListViewStranice.Items.Count > 0) {



                foreach (Control b in ListViewStranice.Items[0].Controls) {
                    if (b is LinkButton) {
                        OdabranaStranica_Click(b as LinkButton, null);
                        //ListViewCommandEventArgs args = new ListViewCommandEventArgs(ListViewStranice.Items[0], (b as LinkButton),);
                        ListViewStranice_ItemCommand(b as LinkButton, null);
                    }
                }
            }

            //editSemafor.Visible = true;
            //contentUpdatePanel.Update();

            prikaziContentDiv("semafor");


        }

        protected void prikaziStranicu(int stranicaID) {

            ListViewStranice.DataBind();

            SemaforiDataContext db = new SemaforiDataContext();
            var stranica = (from tblStranica in db.tblStranicas where tblStranica.Id == stranicaID select tblStranica).Single();

            LabelStranicaID.Text = stranica.Id.ToString();
            TextBoxStranicaNaziv.Text = stranica.naziv;
            TextBoxStranicaVrijemePrikazivanja.Text = stranica.refreshPeriod.ToString();
            DropDownListStranicaBrojRedova.SelectedValue = stranica.brojRedova.ToString();

            oznaciTabStranice(stranicaID);


        }

        protected void ListViewStranice_ItemCommand(object sender, ListViewCommandEventArgs e) {

            // ovdje se pune kontrole kad kliknemo na odabranu stranicu u listview


            LinkButton t = sender as LinkButton;


            //if (String.Equals(e.CommandName, "OdabranaStranica")) {

            // sad napuni podatke za stranicu

            SemaforiDataContext db = new SemaforiDataContext();

            if (sender is LinkButton) {                                 // zavisi da li smo pozvali na ruke ili klikom na link
                var stranica = (from tblStranica in db.tblStranicas where tblStranica.Id == Convert.ToInt32(t.CommandArgument) select tblStranica).Single();
                LabelStranicaID.Text = stranica.Id.ToString();
                TextBoxStranicaNaziv.Text = stranica.naziv;
                TextBoxStranicaVrijemePrikazivanja.Text = stranica.refreshPeriod.ToString();
                DropDownListStranicaBrojRedova.SelectedValue = stranica.brojRedova.ToString();
            }
            else {
                var stranica = (from tblStranica in db.tblStranicas where tblStranica.Id == Convert.ToInt32(e.CommandArgument) select tblStranica).Single();
                LabelStranicaID.Text = stranica.Id.ToString();
                TextBoxStranicaNaziv.Text = stranica.naziv;
                TextBoxStranicaVrijemePrikazivanja.Text = stranica.refreshPeriod.ToString();
                DropDownListStranicaBrojRedova.SelectedValue = stranica.brojRedova.ToString();
            }

            //LabelStranicaID.Text = stranica.Id.ToString();
            //TextBoxStranicaNaziv.Text = stranica.naziv;
            //TextBoxStranicaVrijemePrikazivanja.Text = stranica.refreshPeriod.ToString();
            //DropDownListStranicaBrojRedova.SelectedValue = stranica.brojRedova.ToString();




            // }
        }

        protected void textBoxSemaforNaziv_TextChanged(object sender, EventArgs e) {
            SemaforiDataContext db = new SemaforiDataContext();
            var sem = (from s in db.tblSemafors where s.Id == Convert.ToInt32(labelSemaforID.Text) select s).Single();
            sem.naziv = textBoxSemaforNaziv.Text;

            try {
                db.SubmitChanges();
            }
            catch (Exception e1) {
                Console.WriteLine(e1);
            }

            ListViewSemafori.DataBind();
            //menuUpdatePanel.Update();
            //Response.Redirect(HttpContext.Current.Request.Path);
        }

        protected void TextBoxStranicaNaziv_TextChanged(object sender, EventArgs e) {

            SemaforiDataContext db = new SemaforiDataContext();
            var stranica = (from tblStranica in db.tblStranicas where tblStranica.Id == Convert.ToInt32(LabelStranicaID.Text) select tblStranica).Single();

            stranica.naziv = TextBoxStranicaNaziv.Text;

            try {
                db.SubmitChanges();
            }
            catch (Exception e1) {
                Console.WriteLine(e1);
            }

            ListViewStranice.DataBind();
            oznaciTabStranice(stranica.Id);
        }

        protected void OdabranaStranica_Click(object sender, EventArgs e) {

            // tu mijenjamo css klasu za asp button koji je pozvao stranicu kako bi dobili tab efekt

            foreach (Control l in (sender as LinkButton).Parent.Parent.Controls) {
                if (l is ListViewDataItem) {
                    foreach (Control k in l.Controls) {
                        if (k is LinkButton) {
                            (k as LinkButton).CssClass = "";
                        }
                    }
                }
            }

            (sender as LinkButton).CssClass = "stranica";

        }

        protected void TextBoxStranicaVrijemePrikazivanja_TextChanged(object sender, EventArgs e) {

            SemaforiDataContext db = new SemaforiDataContext();
            var stranica = (from tblStranica in db.tblStranicas where tblStranica.Id == Convert.ToInt32(LabelStranicaID.Text) select tblStranica).Single();

            try {
                stranica.refreshPeriod = Convert.ToInt32(TextBoxStranicaVrijemePrikazivanja.Text);


                try {
                    db.SubmitChanges();
                }
                catch (Exception e1) {
                    Console.WriteLine(e1);
                }

                ListViewStranice.DataBind();
                oznaciTabStranice(stranica.Id);
            }
            catch (Exception e2) {
                Console.Write(e2);
            }
        }

        protected void DropDownListStranicaBrojRedova_SelectedIndexChanged(object sender, EventArgs e) {

            //ovdje dodajemo ili brišemo redove i njihove pripadne ćelije

            SemaforiDataContext db = new SemaforiDataContext();
            var stranica = (from tblStranica in db.tblStranicas where tblStranica.Id == Convert.ToInt32(LabelStranicaID.Text) select tblStranica).Single();

            stranica.brojRedova = Convert.ToInt32(DropDownListStranicaBrojRedova.SelectedValue);



            try {
                db.SubmitChanges();
            }
            catch (Exception e1) {
                Console.WriteLine(e1);
            }

            

            // tu trebamo dodati ili brisati redove, zavisi da li ih ima više ili manje. Također treba dodavati ili brisati i njihove ćelije

            switch (stranica.brojRedova) {
                case 1:
                    // bili smo na 2, briši zadnji red
                    // prvo provjeri koja dva imamo pokupi redakID iz celije
                    IEnumerable<tblRedak> redovi = (from tblRedak in db.tblRedaks where tblRedak.stranicaID == Convert.ToInt32(LabelStranicaID.Text) select tblRedak).OrderByDescending(x => x.id);

                    tblRedak redZaBrisanje = redovi.First();
                    if (redovi.Count() > 1) {
                        db.tblRedaks.DeleteOnSubmit(redZaBrisanje);

                        IEnumerable<tblCelija> celije = (from tblCelija in db.tblCelijas where tblCelija.redakID == redZaBrisanje.id select tblCelija);
                        db.tblCelijas.DeleteAllOnSubmit(celije);
                        db.SubmitChanges();
                    }


                    break;
                case 2:
                    // trebamo dodati red
                    tblRedak redak = new tblRedak();
                    redak.stranicaID = stranica.Id;
                    db.tblRedaks.InsertOnSubmit(redak);
                    db.SubmitChanges();

                    // dodajemo i njegove celije
                    for (int i = 0; i < 3; ++i) {
                        tblCelija celija = new tblCelija();
                        celija.redakID = redak.id;
                        db.tblCelijas.InsertOnSubmit(celija);
                        db.SubmitChanges();
                    }

                    break;


            }

            ListViewStranice.DataBind();
            ListViewRedovi.DataBind();
            
            contentUpdatePanel.Update();
            oznaciTabStranice(stranica.Id);

        }

        protected void DodajSemafor_Click(object sender, EventArgs e) {
            /* 
            dodajemo semafor
            Svaki semafor odmah dobije jednu stranicu i jedan red
            dignemo prozor sa nazivom semafora, upišemo ga i prikažemo sve na desnoj strani
            */

            SemaforiDataContext db = new SemaforiDataContext();
            string privremeniNaslovSemafora = "Novi Semafor";

            tblSemafor semafor = new tblSemafor();
            tblStranica stranica = new tblStranica();
            tblRedak redak = new tblRedak();


            // upisi semafor
            semafor.naziv = privremeniNaslovSemafora;
            db.tblSemafors.InsertOnSubmit(semafor);
            db.SubmitChanges();

            //upisi stranicu semafora
            stranica.semaforID = semafor.Id;
            stranica.naziv = "Privremeni naziv stranice";
            stranica.refreshPeriod = 10000;
            stranica.brojRedova = 1;
            db.tblStranicas.InsertOnSubmit(stranica);
            db.SubmitChanges();

            //upisi redove
            redak.stranicaID = stranica.Id;
            db.tblRedaks.InsertOnSubmit(redak);
            db.SubmitChanges();

            //dodaj retku 3 celije
            for (int i = 0; i < 3; ++i) {
                tblCelija celija = new tblCelija();
                celija.redakID = redak.id;
                celija.grafID = 1;              //samo privremeno da ne bude problema kasnije !!!
                celija.upitID = 1;
                db.tblCelijas.InsertOnSubmit(celija);
                db.SubmitChanges();
            }


            prikaziSemafor(semafor.Id);


        }

        protected void LinkButtonBrisiSemafor_Click(object sender, EventArgs e) {

            int semaforID = Convert.ToInt32(labelSemaforID.Text);

            SemaforiDataContext db = new SemaforiDataContext();

            // pripazi na kaskadno brisanje

            var brisiSemafor = (from tblSemafor in db.tblSemafors where tblSemafor.Id == semaforID select tblSemafor).Single();

            var brisiStranice = (from tblStranica in db.tblStranicas where tblStranica.semaforID == semaforID select tblStranica);

            foreach (tblStranica stranica in brisiStranice) {

                var brisiRedove = from tblRedak in db.tblRedaks where tblRedak.stranicaID == stranica.Id select tblRedak;

                foreach (var redak in brisiRedove) {
                    // pronađi da li ima celija i ako ima, obriši ih
                    var brisiCelije = from tblCelija in db.tblCelijas where tblCelija.redakID == redak.id select tblCelija;
                    foreach (var celija in brisiCelije) {
                        db.tblCelijas.DeleteOnSubmit(celija);
                    }
                    // obriši redak
                    db.tblRedaks.DeleteOnSubmit(redak);

                }

                // obrisi stranicu
                db.tblStranicas.DeleteOnSubmit(stranica);
            }
            // obrisi semafor
            db.tblSemafors.DeleteOnSubmit(brisiSemafor);

            db.SubmitChanges();
            ListViewSemafori.DataBind();
            menuUpdatePanel.Update();
            contentUpdatePanel.Update();
            editSemafor.Visible = false;

        }

        protected void LinkButtonDodajStranicu_Click(object sender, EventArgs e) {
            //upisi stranicu semafora
            SemaforiDataContext db = new SemaforiDataContext();

            tblStranica stranica = new tblStranica();
            tblRedak redak = new tblRedak();

            stranica.semaforID = Convert.ToInt32(labelSemaforID.Text);
            stranica.naziv = "Privremeni naziv stranice";
            stranica.refreshPeriod = 10000;
            stranica.brojRedova = 1;
            db.tblStranicas.InsertOnSubmit(stranica);
            db.SubmitChanges();

            //upisi redove
            redak.stranicaID = stranica.Id;
            db.tblRedaks.InsertOnSubmit(redak);
            db.SubmitChanges();

            //upisi celije
            for (int i = 0; i < 3; ++i) {
                tblCelija celija = new tblCelija();
                celija.redakID = redak.id;
                db.tblCelijas.InsertOnSubmit(celija);
                db.SubmitChanges();
            }


            prikaziSemafor(stranica.semaforID);
            prikaziStranicu(stranica.Id);
            oznaciTabStranice(stranica.Id);
        }

        protected void oznaciTabStranice(int stranicaID) {
            // tu mijenjamo css klasu za asp button koji je pozvao stranicu kako bi dobili tab efekt


            foreach (Control c in ListViewStranice.Items) {
                if (c is ListViewItem) {
                    foreach (Control k in c.Controls) {
                        if (k is LinkButton) {
                            if ((k as LinkButton).Attributes["stranicaID"] == stranicaID.ToString()) {
                                (k as LinkButton).CssClass = "stranica";
                            }
                            else {
                                (k as LinkButton).CssClass = "";
                            }
                        }
                    }
                }
            }
        }

        protected void LinkButtonBrisiStranicu_Click(object sender, EventArgs e) {
            // brisanje stranice, redova i celija

            int stranicaID = Convert.ToInt32(LabelStranicaID.Text);

            SemaforiDataContext db = new SemaforiDataContext();

            // pripazi na kaskadno brisanje

            var stranica = (from tblStranica in db.tblStranicas where tblStranica.Id == stranicaID select tblStranica).Single();

            var brisiRedove = from tblRedak in db.tblRedaks where tblRedak.stranicaID == stranicaID select tblRedak;

            foreach (var redak in brisiRedove) {
                // pronađi da li ima celija i ako ima, obriši ih
                var brisiCelije = from tblCelija in db.tblCelijas where tblCelija.redakID == redak.id select tblCelija;
                foreach (var celija in brisiCelije) {
                    db.tblCelijas.DeleteOnSubmit(celija);
                }
                // obriši redak
                db.tblRedaks.DeleteOnSubmit(redak);

            }

            // obrisi stranicu
            db.tblStranicas.DeleteOnSubmit(stranica);

            db.SubmitChanges();

            // pronađi ID prethodne stranice i nju prikaži
            stranica = (from tblStranica in db.tblStranicas where tblStranica.Id < stranicaID select tblStranica).OrderByDescending(x => x.Id).First();



            prikaziStranicu(stranica.Id);
            menuUpdatePanel.Update();
            contentUpdatePanel.Update();


        }

        protected void ListViewBaze_ItemCommand(object sender, ListViewCommandEventArgs e) {

            prikaziBazu(Convert.ToInt32(e.CommandArgument));
        }

        private void prikaziBazu(int pbazaID) {

            SemaforiDataContext db = new SemaforiDataContext();
            var baza = (from tblDB in db.tblDBs where tblDB.id == pbazaID select tblDB).Single();

            labelBazaID.Text = baza.id.ToString();
            textBoxBazaNaziv.Text = baza.naziv;
            textBoxBazaKorisnik.Text = baza.korisnik;
            textBoxBazaLozinka.Text = baza.lozinka;
            //checkBoxBazaIntegratedAuth.

            prikaziContentDiv("baza");


        }


        protected void prikaziContentDiv (string contentDIV) {

            // prvo ugasi sve div-ove
            editSemafor.Visible = false;
            editServer.Visible = false;
            editUpit.Visible = false;
            editBaza.Visible = false;

            switch (contentDIV) {

                case "semafor":
                    editSemafor.Visible = true;
                        break;
                case "server":
                    editServer.Visible = true;
                        break;
                case "upit":
                    editUpit.Visible = true;
                    break;
                case "baza":
                    editBaza.Visible = true;
                    break;
            }

            contentUpdatePanel.Update();


        }

        protected void ListViewServeri_ItemCommand(object sender, ListViewCommandEventArgs e) {

            prikaziServer(Convert.ToInt32(e.CommandArgument));

        }

        private void prikaziServer(int pserverID) {

            SemaforiDataContext db = new SemaforiDataContext();
            var server = (from tblServer in db.tblServers where tblServer.id == pserverID select tblServer).Single();

            labelServerID.Text = server.id.ToString();
            textBoxServerNaziv.Text = server.naziv;
            textBoxServerServerString.Text = server.serverString;

            var dbase = (from tblDB in db.tblDBs where tblDB.serverid == server.id select tblDB).Single();
            textBoxServerDatabaseName.Text = dbase.naziv;
            
            //checkBoxServerDatabaseIntegratedAuth.Checked = (bool)dbase.integratedAuth;

            if ((bool)dbase.integratedAuth) {
                checkBoxServerDatabaseIntegratedAuth.Checked = true;
                textBoxServerDatabaseKorisnik.Enabled = false;
                textBoxServerDatabaseLozinka.Enabled = false;

            }
            textBoxServerDatabaseKorisnik.Text = dbase.korisnik;
            textBoxServerDatabaseLozinka.Text = dbase.lozinka;
            textBoxServerDatabaseAttachString.Text = dbase.dbAttachString;

            //po defaultu je snimi disabled
            buttonServerSnimiPostavke.Enabled = false;
            labelServerProvjeraStringa.Text = "";

            prikaziContentDiv("server");

        }

        protected void buttonProvjeriServerDatabaseString_Click(object sender, EventArgs e) {

            string connstring;
            // tu sad testiramo da li se možemo spojiti na server ili ćemo dobiti grešku
            //connString = "Server = (LocalDB)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\\BMS_Data.mdf; Integrated Security = False; User ID=tonza;Password=tonza";
            connstring = "Server = " + textBoxServerServerString.Text + ";";

            // ovaj dio dopisujemo samo ako postoji u bazi, a koristi se samo kad se radi o localDB-u, kada treba attachati bazu. Kad se spajamo na "Veliki" SQL to nam ne treba, pa kod unosa upozori korisnika na to
            if (textBoxServerDatabaseAttachString.Text.Length > 0)
                connstring += "AttachDbFileName= " + textBoxServerDatabaseAttachString.Text + ";";


            connstring += "Database = " + textBoxServerDatabaseName.Text + ";";
            connstring += "Integrated Security = " + (checkBoxBazaIntegratedAuth.Checked == true ? "True" : "False") + ";";
            connstring += "User ID=" + textBoxServerDatabaseKorisnik.Text + ";";
            connstring += "Password=" + textBoxServerDatabaseLozinka.Text + ";";

            bool uspjesno = true;
            try {
                SqlConnection myConn = new SqlConnection(connstring);
                //SqlCommand cmd = new SqlCommand(celijaPodaci.Last().upit, myConn);


                myConn.Open();

            }
            catch (Exception se) {
                uspjesno = false;
            }
            if (uspjesno) {
                labelServerProvjeraStringa.Text = "Uspješno spajanje na server :)";
                // dozvoli snimanje podataka
                buttonServerSnimiPostavke.Enabled = true;
            }
            else {
                labelServerProvjeraStringa.Text = "Neuspješno spajanje na server !!!";
            }

        }

        protected void checkBoxServerDatabaseIntegratedAuth_CheckedChanged(object sender, EventArgs e) {

            CheckBox kvacica = sender as CheckBox;

            textBoxServerDatabaseKorisnik.Enabled = !kvacica.Checked;
            textBoxServerDatabaseLozinka.Enabled = !kvacica.Checked;



        }

        protected void buttonServerSnimiPostavke_Click(object sender, EventArgs e) {

            SemaforiDataContext db = new SemaforiDataContext();
            tblServer server = (from tblServer in db.tblServers where tblServer.id == Convert.ToInt32(labelServerID.Text) select tblServer).Single();

            //tblServer server = new tblServer();
            //tblDB dbase = new tblDB();

            server.naziv = textBoxServerNaziv.Text;
            server.serverString = textBoxServerServerString.Text;

            db.SubmitChanges();

            tblDB dbase = (from tblDB in db.tblDBs where tblDB.serverid == server.id select tblDB).Single();

            dbase.naziv = textBoxServerDatabaseName.Text;
            dbase.serverid = server.id;
            dbase.integratedAuth = checkBoxServerDatabaseIntegratedAuth.Checked;
            dbase.korisnik = textBoxServerDatabaseKorisnik.Text;
            dbase.dbAttachString = textBoxServerDatabaseAttachString.Text;
            dbase.lozinka = textBoxServerDatabaseLozinka.Text;

            db.SubmitChanges();

            (sender as Button).Enabled = false;
            labelServerProvjeraStringa.Text = "";

            ListViewServeri.DataBind();
            menuUpdatePanel.Update();   

            
        }

        protected void linkButtonDodajServer_Click(object sender, EventArgs e) {

        }
        //}




        // kraj metoda i klase

    }
}
