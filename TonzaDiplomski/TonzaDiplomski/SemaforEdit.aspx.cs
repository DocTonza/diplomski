using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

namespace TonzaDiplomski {


    public partial class SemaforEdit1 : System.Web.UI.Page {

        // tu si definiramo var-ove
        SemaforiDataContext db = new SemaforiDataContext();



        protected void Page_Load(object sender, EventArgs e) {




            napuniAccordion2();

            //if (IsPostBack && ViewState["semaforiAcordionOtvoreni"]!=null) {
            //    SemaforiAccordion.SelectedIndex = (int)ViewState["semaforAcccordionOtvoreni"];
            //}
            //else
            //    ViewState["semaforAcccordionOtvoreni"] = 100; ;


    }



        public void snimiBtn_Click(object sender, EventArgs e) {
            //editorPodataka.Visible = false;
            //modal.Visible = false;
            // lbl1.Text = text1.Text;

        }

        public void napuniAccordion2() {
            // povuci semafore
            IEnumerable<tblSemafor> semafori = from s in db.tblSemafors select s;

            foreach (tblSemafor semafor in semafori) {
                AccordionPane aPaneSemafor = new AccordionPane();
                aPaneSemafor.ID = "aPaneSemafor" + semafor.Id.ToString();
                aPaneSemafor.HeaderContainer.Controls.Add(new LiteralControl(semafor.naziv));
                

                Button btnDodajStranicu = new Button();
                btnDodajStranicu.ID = "btnDodajStranicuNaSemafor_ID" + semafor.Id.ToString();
                btnDodajStranicu.Text = "Dodaj Stranicu";
                btnDodajStranicu.CssClass = "AccordianAddEdditControls";
                btnDodajStranicu.Click += (sender, e) => dodajStranicuSemafora(sender, e, semafor.Id);
                aPaneSemafor.ContentContainer.Controls.Add(btnDodajStranicu);


                // dodaj content stranica
                Accordion AccordianStranica = new Accordion();
                AccordianStranica.ID = "AccordionStranicaSemafora" + semafor.Id.ToString();

                //if (!IsPostBack) {
                //    AccordianStranica.SelectedIndex = 0;
                //}

                AccordianStranica.FadeTransitions = false;
                AccordianStranica.FramesPerSecond = 50;
                AccordianStranica.RequireOpenedPane = false;
                AccordianStranica.HeaderCssClass = "AccordianStranicaNaslov sjena";
                AccordianStranica.TransitionDuration = 90;


                // povuci stranice
                IEnumerable<tblStranica> stranice = from str in db.tblStranicas where str.semaforID == semafor.Id select str;
              

                foreach (tblStranica stranica in stranice) {
                    AccordionPane aPaneStranica = new AccordionPane();
                    aPaneStranica.ID = "AccordianStranicaStranice" + stranica.Id.ToString();
                    aPaneStranica.HeaderContainer.Controls.Add(new LiteralControl(stranica.naziv));


                    LinkButton btnEditStranice = new LinkButton();
                    btnEditStranice.ID = "buttonMijenjajStranicu";
                    btnEditStranice.Text = "promijeni";
                    btnEditStranice.CssClass = "AccordianAddEdditControls";
                    btnEditStranice.Click += (sender, e) => mijenjajStranicuSemafora(sender, e, stranica.Id);
                    aPaneStranica.HeaderContainer.Controls.Add(btnEditStranice);

                    // razmak
                    aPaneStranica.HeaderContainer.Controls.Add(new LiteralControl("|"));

                    LinkButton btnBrisiStranicu = new LinkButton();
                    btnBrisiStranicu.ID = "buttonBrisiStranicu";
                    btnBrisiStranicu.Text = "briši";
                    btnBrisiStranicu.CssClass = "AccordianAddEdditControls";
                    btnBrisiStranicu.Click += (sender, e) => brisiStranicuSemafora(sender, e, stranica.Id);
                    aPaneStranica.HeaderContainer.Controls.Add(btnBrisiStranicu);






                    // dodaj content redova
                    Accordion AccordianRedova = new Accordion();
                    AccordianRedova.ID = "AccordionRedovaStranica" + stranica.Id.ToString();
                    AccordianRedova.SelectedIndex = 100;
                    AccordianRedova.FadeTransitions = false;
                    AccordianRedova.FramesPerSecond = 50;
                    AccordianRedova.RequireOpenedPane = false;
                    AccordianRedova.HeaderCssClass = "AccordianRedNaslov sjena";
                    AccordianStranica.TransitionDuration = 80;

                    //povuciredove
                    IEnumerable<tblRedak> redovi = from r in db.tblRedaks where r.stranicaID == stranica.Id select r;

                    foreach (tblRedak red in redovi) {
                        AccordionPane aPaneRedova = new AccordionPane();
                        aPaneRedova.ID = "AcordianStranicaRedova" + red.id.ToString();
                        aPaneRedova.HeaderContainer.Controls.Add(new LiteralControl("Redak_" + red.id.ToString()));

                        // tu sada treba napraviti kontrolu za prikaz celija i dodati je u aPaneRedova ContentContainer

                        Panel prvi = new Panel();
                        prvi.Width = 300;
                        prvi.Height = 300;
                        prvi.BorderStyle = BorderStyle.Solid;
                        prvi.BorderWidth = 2;

                        aPaneRedova.ContentContainer.Controls.Add(prvi);
                        //aPaneRedova.ContentContainer.Controls.Add(new LiteralControl("unutra"));

                        AccordianRedova.Panes.Add(aPaneRedova);

                    }


                    aPaneStranica.ContentContainer.Controls.Add(AccordianRedova);

                    AccordianStranica.Panes.Add(aPaneStranica);
                }


                aPaneSemafor.ContentContainer.Controls.Add(AccordianStranica);


                SemaforiAccordion.Panes.Add(aPaneSemafor);

            }
        }


        public void napuniAccordion() {

            // povuci semafore
            IEnumerable<tblSemafor> semafori = from s in db.tblSemafors
                                               select s;

            // dodaj accordion pane za svaki semafor

            foreach (tblSemafor semafor in semafori) {
                AccordionPane apaneSemafor = new AccordionPane();
                apaneSemafor.ID = "AccordionPaneSemaforID_" + semafor.Id.ToString();

                // generiramo header pane-a
                LinkButton semaforNaslov = new LinkButton();
                semaforNaslov.ID = "linkButtonNaslovSemaforID_" + semafor.Id.ToString();
                semaforNaslov.Text = semafor.naziv;

                apaneSemafor.HeaderContainer.Controls.Add(semaforNaslov);

                // generiramo content za Semafor pane ContentContainer
                IEnumerable<tblStranica> stranice = from str in db.tblStranicas
                                                    where str.semaforID == semafor.Id
                                                    select str;

                // container na koji ide content i navigacija 
                Panel containerPanel = new Panel();
                containerPanel.CssClass = "pnl1Class";
                containerPanel.ID = "containerPanelSemaforID_" + semafor.Id.ToString();

                // na ovaj panel ide sav content, tj popis stranica
                Panel contentPanel = new Panel();
                contentPanel.CssClass = "AccordionContentPaneContent";

                containerPanel.Controls.Add(contentPanel);
                // dodaj ga u semafor content 
                apaneSemafor.ContentContainer.Controls.Add(containerPanel);

                // accordion stranica
                foreach (tblStranica stranica in stranice) {
                    Accordion StraniceAccordion = new Accordion();
                    //StraniceAccordion.RequireOpenedPane = false;
                    //StraniceAccordion.SelectedIndex = 1000;

                    //StraniceAccordion.Attributes["runat"] = "server";
                    StraniceAccordion.Attributes["SelectedIndex"] = "1000";
                    StraniceAccordion.Attributes["FadeTransitions"] = "false";
                    StraniceAccordion.Attributes["FramesPerSecond"] = "30";
                    StraniceAccordion.Attributes["RequireOpenedPane"] = "False";
                    StraniceAccordion.Attributes["HeaderCssClass"] = "AccordianSemaforNaslov";



                    StraniceAccordion.ID = "StranicaAccordionID_" + stranica.Id.ToString();
                    AccordionPane apStranica = new AccordionPane();
                    apStranica.ID = "AccordionPaneStranicaID_" + stranica.Id.ToString();

                    apStranica.HeaderContainer.ID = "HeaderContainterStranicaID_" + stranica.Id.ToString();
                    LinkButton naslovStranice = new LinkButton();

                    naslovStranice.ID = "linkButtonNaslovStraniceID_" + stranica.Id.ToString();
                    naslovStranice.Text = stranica.naziv;
                    naslovStranice.Click += (sender, e) => mijenjajStranicuSemafora(sender, e, stranica.Id);

                    // generiramo header pane-a Stranice

                    //apStranica.HeaderContainer.Controls.Add(naslovStranice);
                    apStranica.HeaderContainer.Controls.Add(new LiteralControl("Ovo je header"));

                    // dodaj svakom headeru neki redak bezveze za test
                    apStranica.ContentContainer.Controls.Add(new LiteralControl("ovo je interni"));


                    /*
                    // sad ide content, a to su zapravo redovi
                    IEnumerable<tblRedak> retci = from r in db.tblRedaks where r.stranicaID == stranica.Id select r;

                    Panel containerPanelRedak = new Panel();
                    containerPanelRedak.CssClass = "pnl1Class";
                    containerPanelRedak.ID = "containerPanelSemaforID_" + semafor.Id.ToString();

                    // na ovaj panel ide sav content, tj popis stranica
                    Panel contentPanelRedak = new Panel();
                    contentPanelRedak.CssClass = "AccordionContentPaneContent";

                    containerPanelRedak.Controls.Add(contentPanelRedak);
                    // dodaj ga u stranica content 
                    apStranica.ContentContainer.Controls.Add(containerPanelRedak);

                    foreach (tblRedak redak in retci) {
                        Accordion RetciAccordion = new Accordion();
                        RetciAccordion.ID = "RedakAccordionID_" + redak.id.ToString();
                        AccordionPane apRedak = new AccordionPane();
                        apRedak.ID = "AccordionPaneRedakID_" + redak.id.ToString();

                        apRedak.HeaderContainer.ID = "HeaderContainerRedakID_" + redak.id.ToString();

                        LinkButton naslovRetka = new LinkButton();
                        naslovRetka.ID = "linkButtonNaslovRetkaID_" + redak.id.ToString();
                        naslovRetka.Text = "neki naslov retka";

                        //naslovRetka.Click +=

                        apRedak.HeaderContainer.Controls.Add(naslovRetka);

                        RetciAccordion.Panes.Add(apRedak);
                        contentPanelRedak.Controls.Add(RetciAccordion);

                    }   //kraj foreach za dodavanje redaka

                    */


                    StraniceAccordion.Panes.Add(apStranica);
                    //testAcco.Panes.Add(apStranica);

                    //dodajemo AccoridionStranica na content Pane accordiona Semafora
                    contentPanel.Controls.Add(StraniceAccordion);


                } // kraj foreach za dodavanje stranica






                //dodaj gumb za dodavanje stranice
                LinkButton btnDodajStranicu = new LinkButton();
                btnDodajStranicu.ID = "linkButtonDodajStranicu_sID" + semafor.Id.ToString(); ;
                btnDodajStranicu.Text = "Dodaj Stranicu";

                //dodaj gumb za brisanje stranice
                LinkButton btnBrisiStranicu = new LinkButton();
                btnBrisiStranicu.ID = "linkButtonBrisiStranicu_sID" + semafor.Id.ToString(); ;
                btnBrisiStranicu.Text = "Obriši Stranicu";


                Panel navigationContainer = new Panel();
                navigationContainer.ID = "DodajStranicu";
                navigationContainer.CssClass = "AccordionContentPaneNavigacija";

                // dodaj kontrole na stranicu 
                navigationContainer.Controls.Add(btnDodajStranicu);
                navigationContainer.Controls.Add(new LiteralControl("&nbsp;"));
                navigationContainer.Controls.Add(btnBrisiStranicu);

                btnDodajStranicu.Click += (sender, e) => dodajStranicuSemafora(sender, e, semafor.Id);
                //apSemafor.ContentContainer.Controls.AddAt(0, divZaDodajStranicuLinkbutton);
                containerPanel.Controls.Add(navigationContainer);



                // dodaj pane u accordion
                SemaforiAccordion.Panes.Add(apaneSemafor);

            } //kraj foreach za dodavanje semafora
        }    //kraj za napuniAccordion()

        private void brisiStranicuSemafora(object sender, EventArgs e, int p_id) {

            // pripazi na kaskadno brisanje
            var brisiStranicu = (from tblStranica in db.tblStranicas where tblStranica.Id == p_id select tblStranica).Single();
            var brisiRedove = from tblRedak in db.tblRedaks where tblRedak.stranicaID == p_id select tblRedak;                      // ovaj vraća više

            foreach (var redak in brisiRedove) {
                // pronađi da li ima celija i ako ima, obriši ih
                var brisiCelije = from tblCelija in db.tblCelijas where tblCelija.redakID == redak.id select tblCelija;
                foreach (var celija in brisiCelije) {
                    db.tblCelijas.DeleteOnSubmit(celija);
                }
                // na kraju obriši i redak
                db.tblRedaks.DeleteOnSubmit(redak);
            
            }

            // na kraju obrisi i stranicu
            db.tblStranicas.DeleteOnSubmit(brisiStranicu);

            // ajde sad submitChanges
            try {
                db.SubmitChanges();
            }
            catch (Exception e1) {
                Console.WriteLine(e1);

                //db.SubmitChanges();
            }

            Response.Redirect(HttpContext.Current.Request.Path);
        }

        private void mijenjajStranicuSemafora(object sender, EventArgs e, int p_id) {

            // pokupi podatke o stranici
            var stranica = (from s in db.tblStranicas where s.Id == p_id select s).Single();

            //predpopuni polja
            lblEditInsertDelete.Text = "edit";
            lblIdStranice.Text = stranica.Id.ToString();
            textBoxNaslovStranice.Text = stranica.naziv;
            textBoxRefreshStranice.Text = stranica.refreshPeriod.ToString();

            //prikazi formu za promjenu
            modal.Visible = true;
            editorStranice.Visible = true;


        }

        public void dodajStranicuSemafora(object sender, EventArgs e, int semaforId) {

            
            // isprazni kontrole ako je ostalo štogod teksta iz postbacka
            textBoxNaslovStranice.Text = "";
            textBoxNaslovStranice.Attributes["placeholder"] = "naslov";

            textBoxRefreshStranice.Text = "";
            textBoxNaslovStranice.Attributes["placeholder"] = "vrijeme (ms)";

            lblEditInsertDelete.Text = "insert";
            modal.Visible = true;

            editorStranice.Visible = true;
            lblIdSemafora.Text = semaforId.ToString();

        }  //kraj za dodajStranicuSemafora() 

        protected void buttonOdustaniStranica_Click(object sender, EventArgs e) {
            modal.Visible = false;
            editorStranice.Visible = false;
        }

        protected void buttonSnimiStranica_Click(object sender, EventArgs e) {

            switch (lblEditInsertDelete.Text) {

                case "insert":
                    // insert nove stranice
                    tblStranica stranicaInsert = new tblStranica {
                        naziv = textBoxNaslovStranice.Text,
                        refreshPeriod = Convert.ToInt32(textBoxRefreshStranice.Text),
                        semaforID = Convert.ToInt32(lblIdSemafora.Text),
                        brojRedova = 2
                    };

                    db.tblStranicas.InsertOnSubmit(stranicaInsert);

                    // submitaj u bazu 
                    try {
                        db.SubmitChanges();
                    }
                    catch (Exception e1) {
                        Console.WriteLine(e1);

                        //db.SubmitChanges();
                    }
                    break;
                case "edit":
                    // update stranice
                    // pokupi podatke o stranici
                    var stranicaEdit = (from s in db.tblStranicas where s.Id == Convert.ToInt32(lblIdStranice.Text) select s).Single();

                    stranicaEdit.naziv = textBoxNaslovStranice.Text;
                    stranicaEdit.refreshPeriod = Convert.ToInt32(textBoxRefreshStranice.Text);

                    try {
                        db.SubmitChanges();
                    }
                    catch (Exception e1) {
                        Console.WriteLine(e1);

                        //db.SubmitChanges();
                    }

                    break;
                case "delete":
                    break;



            }


            // ugasi prozore
            ViewState["snimanje"] = "da";
            //Page_Load(this, null);
            modal.Visible = false;
            editorStranice.Visible = false;

            Response.Redirect(HttpContext.Current.Request.Path);

        }

        protected void SemaforiAccordion_ItemCommand(object sender, CommandEventArgs e) {
        //    ViewState["semaforAcccordionOtvoreni"] = SemaforiAccordion.SelectedIndex;
        
        }
    }


}