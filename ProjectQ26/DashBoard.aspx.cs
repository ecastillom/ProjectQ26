using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectQ26
{
    public partial class DashBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserPlayer Usuario = Utils.Generico.usuarioRegistrado(Session);


        }


    }
}