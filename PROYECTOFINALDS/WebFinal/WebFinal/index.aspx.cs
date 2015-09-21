using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFinal
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string mensaje = "<script>javascript:alertify.success('¡Bienvenido!');</script>)";
            Controls.Add(new LiteralControl(mensaje));

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            this.Timer1.Enabled = false;
            Response.Redirect("frmLogin.aspx");
        }
    }
}