using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using libConexionBD;
using System.Windows.Forms;
using System.Web.UI.WebControls;

namespace LibChkBoxList
{
    public class ClsChkList
    {
        #region "Constructor"
            public ClsChkList(string NombreAplicacion)
            {
                strApp = NombreAplicacion;
                strSQL = string.Empty;
                strCampoID = string.Empty;
                strCampoTexto = string.Empty;
                strError = string.Empty;
            }
        #endregion

        #region "Atributos"
            private string strApp;
            private string strSQL;
            private string strCampoID;
            private string strCampoTexto;
            private string strError;
        #endregion

        #region "Propiedades"
            public string SQL
            { set { strSQL = value;        } }
            public string CampoID
            { set { strCampoID = value;    } }
            public string CampoTexto
            { set { strCampoTexto = value; } }
            public string Error
            { get { return strError;       } }
        #endregion

        #region "Métodos Privados"
            private bool Validar()
            {
                if ( string.IsNullOrEmpty( strSQL ) )
                {
                    strError = "Debe definir una instrucción SQL";
                    return false;
                }
                if ( string.IsNullOrEmpty( strCampoID ) )
                {
                    strError = "Debe definir el nombre del Campo con la PK(Id)";
                    return false;
                }
                if ( string.IsNullOrEmpty( strCampoTexto ) )
                {
                    strError = "Debe definir el nombre del Campo con valores Texto";
                    return false;
                }
                return true;
            }
        #endregion

        #region "Métodos Públicos"
            public bool LlenarChkbL_Web( CheckBoxList  Generico )
            {
                if ( ! Validar() )
                    return false;
                clsConexionBD objConexionBd = new clsConexionBD( strApp );
                try
                {
                    objConexionBd.SQL = strSQL;
                    if ( ! objConexionBd.LlenarDataSet( false ) )
                    {
                        strError = objConexionBd.Error;
                        objConexionBd.CerrarCnx();
                        objConexionBd = null;
                        return false;
                    }
                    Generico.DataSource = objConexionBd.DataSet_Lleno.Tables[0];
                    Generico.DataValueField = strCampoID;
                    Generico.DataTextField = strCampoTexto;
                    Generico.DataBind();
                    objConexionBd.CerrarCnx();
                    objConexionBd = null;
                    return true;
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                    return false;
                }
            }

            public bool LlenarChkbL_Desktop(CheckedListBox Generico)
            {
                if (!Validar())
                    return false;
                try
                {
                    clsConexionBD objConexionBd = new clsConexionBD(strApp);
                    objConexionBd.SQL = strSQL;
                    if (!objConexionBd.LlenarDataSet(false))
                    {
                        strError = objConexionBd.Error;
                        objConexionBd.CerrarCnx();
                        objConexionBd = null;
                        return false;
                    }
                    Generico.DataSource = objConexionBd.DataSet_Lleno.Tables[0];
                    Generico.ValueMember = strCampoID;
                    Generico.DisplayMember = strCampoTexto;
                    Generico.Refresh();
                    objConexionBd.CerrarCnx();
                    objConexionBd = null;
                    return true;
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                    return false;
                }
            }
        #endregion
    }
}
