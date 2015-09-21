using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFinal
{
    public partial class frmLogin : System.Web.UI.Page
    {
        #region Variables
        string strNombreApp,strUsuario,strClave;
        string mensaje = "<script>javascript:alertify.success('¡Acceso concedido!');</script>)";
        string mensajeError = "<script>javascript:alertify.error('¡Acceso Denegado!');</script>)";
        #endregion

        #region Metodos Personalizados

        private void Mensaje(string texto)
        {
            this.lblMsj.Text = texto;
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                strNombreApp = System.Reflection.Assembly.GetExecutingAssembly()
                .GetName().Name;
            }

        }

        protected void btnInicar_Click(object sender, EventArgs e)
        {
            try
            {
                strNombreApp = System.Reflection.Assembly.GetExecutingAssembly()
                .GetName().Name;
                strUsuario = txtUsu.Text;
                strClave = txtClave.Text;

                if (string.IsNullOrWhiteSpace(strUsuario) ||
                   string.IsNullOrWhiteSpace(strClave))
                {
                    Mensaje("Nombre de Usuario o Clave no válidos");
                    Controls.Add(new LiteralControl(mensajeError));
                    return;
                }
                clsLogin log = new clsLogin(strNombreApp, strUsuario, strClave);
                if (!log.BuscarUsuario())
                {
                    Mensaje("Acceso denegado");
                    Controls.Add(new LiteralControl(mensajeError));
                    log = null;
                    return;
                }
                if (log.ok == "sfdkI195")
                {
                    Session["usu"] = strUsuario;
                    Mensaje("Cargando...");
                    Mensaje("Bienvenido");
                    Response.Redirect("FrmInicio.aspx");
                }
                else
                {
                    this.lblMsj.Text = "Acceso denegado";
                    Controls.Add(new LiteralControl(mensajeError));
                }
                Controls.Add(new LiteralControl(mensaje));
            }
            catch (Exception ex)
            {
                Controls.Add(new LiteralControl(mensajeError));
                Mensaje("Acceso denegado");
                
            }
           
        }

        protected void linkButtonFac_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}