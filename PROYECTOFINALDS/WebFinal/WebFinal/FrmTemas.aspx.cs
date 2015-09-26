using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFinal
{
    public partial class Formulario_web14 : System.Web.UI.Page
    {
        #region Variables
        string  strNombreApp;
        int intCodTemas;
        #endregion
        static string strUsuario;

        #region Métodos personalizados

        private void LlenarGridTemasxCod()
        {
            try
            {
                strNombreApp = System.Reflection.Assembly.GetExecutingAssembly()
               .GetName().Name;
                clsTemas objXX = new clsTemas(strNombreApp);
                objXX.CodTemas = intCodTemas;
                if (!objXX.LlenarGridsTemasxCod(this.grvDatos))
                {
                    Mensaje(objXX.Error);
                    objXX = null;
                    return;
                }
            }
            catch (Exception ex)
            {

                Mensaje(ex.Message);
            }
        }

        private void LlenarGridTemas()
        {
            try
            {
                strNombreApp = System.Reflection.Assembly.GetExecutingAssembly()
               .GetName().Name;
                clsTemas objXX = new clsTemas(strNombreApp);
                if (!objXX.LlenarGridsTemas(this.grvDatos))
                {
                    Mensaje(objXX.Error);
                    objXX = null;
                    return;
                }
            }
            catch (Exception ex)
            {

                Mensaje(ex.Message);
            }
        }

        private void Mensaje(string Texto)
        {
            this.lblMsj.Text = Texto.Trim();
        }

        #endregion

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
                strNombreApp = System.Reflection.Assembly.GetExecutingAssembly()
                .GetName().Name;
                LlenarGridTemas();
                
            }
        }

        protected void ibtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                intCodTemas =Convert.ToInt32( txtBuscar.Text.Trim());
                if (intCodTemas<=0)
                {
                    Mensaje("Código del Tema Inválido");
                    return;
                }
                LlenarGridTemasxCod();

            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        protected void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                LlenarGridTemas();
                txtBuscar.Focus();
            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
            }
           
        }

        protected void grvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvDatos.PageIndex = e.NewPageIndex;
            LlenarGridTemas();
        }
    }
}