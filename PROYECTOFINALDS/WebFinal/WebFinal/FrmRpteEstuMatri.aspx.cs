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
    public partial class Formulario_web16 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string strCedulaCli = Session["cedcliente"].ToString();
                    string strNombreApp = System.Reflection.Assembly.GetExecutingAssembly().
                     GetName().Name;

                    clsConexionBD objcnx = new clsConexionBD(strNombreApp);
                    objcnx.SQL = "EXEC EstudianteImpresion '" + strCedulaCli + "';";

                    if (!objcnx.LlenarDataSet(false))
                        Response.Redirect("FrmEstudiante.aspx");

                    DataSet dt = new DataSet();//Definir e dataset:dts
                    dt = objcnx.DataSet_Lleno;
                    objcnx = null;

                    if (dt.Tables[0].Rows.Count > 0)
                    {

                        string strDireccion = AppDomain.CurrentDomain.BaseDirectory;
                        //NOTA:descomentar la sgte linea solo la primera vez y poder realizar el diseño del reporte,luego
                        //comentar
                        //dt.WriteXmlSchema(strDireccion + "DataEstudMatri.xsd");

                        this.rpteEstuMatri.LocalReport.DataSources.Clear();
                        rpteEstuMatri.Reset();
                        rpteEstuMatri.LocalReport.ReportEmbeddedResource = "rptEstuMatri.rdlc";

                        ReportDataSource rds = new ReportDataSource();

                        rds.Name = "DataSet1";
                        rds.Value = dt.Tables[0];


                        rpteEstuMatri.LocalReport.DataSources.Clear();
                        rpteEstuMatri.LocalReport.DataSources.Add(rds);
                        rpteEstuMatri.LocalReport.ReportPath = "rptEstuMatri.rdlc";
                        rpteEstuMatri.LocalReport.Refresh();
                    }
                    else
                        Response.Redirect("FrmEstudiante.aspx");
                }
                catch
                {
                    Response.Redirect("FrmEstudiante.aspx");
                }
            }
        }
    }
}
