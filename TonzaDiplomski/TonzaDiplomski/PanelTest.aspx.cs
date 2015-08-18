using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TonzaDiplomski {
    public partial class PanelTest : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            //ScripManager1.
            Panel djurdja = new Panel();
            ScriptManager manager = new ScriptManager();
        }
        public void DajVrijeme() {
            Response.Write("Evo ga na !!! "+DateTime.Now);
        }

        protected void timer_Tick(object sender, EventArgs e) {
            System.Web.UI.HtmlControls.HtmlGenericControl jura = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
            jura.InnerHtml = "ovo je Jura </br>"+DateTime.Now;
            testniDiv.Controls.Add(jura);
        }
    }
}