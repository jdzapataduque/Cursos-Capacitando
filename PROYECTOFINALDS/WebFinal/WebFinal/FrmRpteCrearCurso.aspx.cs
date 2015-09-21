using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using libConexionBD;
using System.Data;
using Microsoft.Reporting.WebForms;
using Microsoft.Reporting.WebForms.Internal;

namespace WebFinal
{
    public partial class Formulario_web15 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    int intCodigo = Convert.ToInt32(Session["codcurso"]);
                    string strNombreApp = System.Reflection.Assembly.GetExecutingAssembly().
                     GetName().Name;

                    clsConexionBD objcnx = new clsConexionBD(strNombreApp);
                    objcnx.SQL = "EXEC CrearCursoImpresion '" + intCodigo + "';";

                    if (!objcnx.LlenarDataSet(false))
                        Response.Redirect("FrmCrearCurso.aspx");

                    DataSet dts = new DataSet();//Definir e dataset:dts
                    dts = objcnx.DataSet_Lleno;
                    objcnx = null;

                    if (dts.Tables[0].Rows.Count > 0)
                    {

                        string strDireccion = AppDomain.CurrentDomain.BaseDirectory;
                        //NOTA:descomentar la sgte linea solo la primera vez y poder realizar el diseño del reporte,luego
                        //comentar
                        //dts.WriteXmlSchema(strDireccion + "DataCrearCurso.xsd");

                        this.rpteCurso.LocalReport.DataSources.Clear();
                        rpteCurso.Reset();
                        rpteCurso.LocalReport.ReportEmbeddedResource = "rptCrearCurso.rdlc";
                        ReportDataSource rds = new ReportDataSource();

                        rds.Name = "DataSet1";
                        rds.Value = dts.Tables[0];

                        rpteCurso.LocalReport.DataSources.Clear();
                        rpteCurso.LocalReport.DataSources.Add(rds);
                        rpteCurso.LocalReport.ReportPath = "rptCrearCurso.rdlc";
                        rpteCurso.LocalReport.Refresh();
                    }
                    else
                        Response.Redirect("FrmCrearCurso.aspx");
                }
                catch
                {
                    Response.Redirect("FrmCrearCurso.aspx");
                }

            }
        }
    }
}