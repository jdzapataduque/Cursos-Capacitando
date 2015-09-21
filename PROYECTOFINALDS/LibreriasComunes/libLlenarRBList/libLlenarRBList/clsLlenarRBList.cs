using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Referenciar y Usar
using libConexionBD;
using System.Web.UI.WebControls;

namespace LibLlenarRBList
{
    public class clsLlenarRBList
    {
        #region "Constructor"
            public clsLlenarRBList( string NombreAplicacion )
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
            public bool LlenarRadioBL_Web( RadioButtonList Generico )
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
        #endregion
    }
}
