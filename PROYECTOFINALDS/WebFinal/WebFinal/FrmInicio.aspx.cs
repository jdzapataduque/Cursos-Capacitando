using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook;

namespace WebFinal
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        static string strUsuario;
        private const string AppId = "697281460404387";
        private Uri _LoginUrl;
        private const string _ExtendedPermissions = "user_about_me,publish_stream,offline_access";
        FacebookClient fbClient = new FacebookClient();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["usu"] == null)
                {
                    Response.Redirect("Error.aspx");
                    //mandar a una pagina de error
                }
                strUsuario = Session["usu"].ToString();

                if (string.IsNullOrWhiteSpace(strUsuario))
                {
                    Response.Redirect("index.aspx");
                }
                lblUsu.Text = strUsuario;
                string mensaje = "<script>javascript:alertify.success('¡Bienvenido!');</script>)";
                Controls.Add(new LiteralControl(mensaje));
            }
        }
        private void Login()
        { 

        }
    }
}