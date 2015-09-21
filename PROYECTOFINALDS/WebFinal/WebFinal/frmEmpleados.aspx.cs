using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFinal
{
    public partial class Formulario_web13 : System.Web.UI.Page
    {
        #region Variables
        string strNombreApp,strCod;
        static string strUsuario;
        #endregion

        #region Métodos personalizados

        private void LlenarGridEmpleados()
        {
            try
            {
                strNombreApp = System.Reflection.Assembly.GetExecutingAssembly()
               .GetName().Name;
                ClsEmpleados objXX = new ClsEmpleados(strNombreApp);
                if (!objXX.LlenarGridsEmpl(this.grvDatos))
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

        private void LlenarGridEmplxCod()
        {
            try
            {
                strNombreApp = System.Reflection.Assembly.GetExecutingAssembly()
               .GetName().Name;
                ClsEmpleados objXX = new ClsEmpleados(strNombreApp);
                objXX.CodEmpl = strCod;
                if (!objXX.LlenarGridsEmplxCod(this.grvDatos))
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

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                strNombreApp = System.Reflection.Assembly.GetExecutingAssembly()
                .GetName().Name;
                LlenarGridEmpleados();

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
            }
            LlenarGridEmpleados();
        }

        protected void ibtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                strCod = txtBuscar.Text.Trim();
                if (string.IsNullOrWhiteSpace(strCod))
                {
                    Mensaje("Código del Tema Inválido");
                    return;
                }
                LlenarGridEmplxCod();

            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        protected void grvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvDatos.PageIndex = e.NewPageIndex;
            LlenarGridEmpleados();
        }
    }
       
}