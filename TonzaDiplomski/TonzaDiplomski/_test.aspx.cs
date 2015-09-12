using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TonzaDiplomski {
    public partial class _test : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

      

        protected void Unnamed_Click(object sender, EventArgs e) {
            System.Web.UI.HtmlControls.HtmlGenericControl stranicaPanel = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            
            sender.GetType();
            var test = sender as Control;
            //stranicaPanel.t

            stranicaPanel.ID = "stranicaPanel";
            stranicaPanel.Attributes["class"] = "boxIndent sjena";
            stranicaPanel.InnerHtml = (sender as Control).Parent.ID;


            glavniContainer.Controls.AddAt(0,stranicaPanel);
            
            

        }
    }
}