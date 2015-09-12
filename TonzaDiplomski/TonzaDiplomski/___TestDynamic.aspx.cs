using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TonzaDiplomski {
    public partial class ___TestDynamic : System.Web.UI.Page {

        TextBox t1;
        protected void Page_Load(object sender, EventArgs e) {
            GenerirajKontrole();
        }

        public void GenerirajKontrole() {

            t1 = new TextBox();
            t1.ID = "t1";
            t1.Text = "ovo je na početku";
            Page.Form.Controls.Add(t1);

            Button b1 = new Button();
            b1.ID = "b1";
            b1.Text = "Klikni!!!!";
            b1.Click += new EventHandler(b1_Click);
            Page.Form.Controls.Add(b1);



        }

        public void b1_Click (object sender, EventArgs e) {
            Literal l = new Literal();
            l.Text = t1.Text;
            Page.Controls.Add(l);

        }
    }

   
}