using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Referenciar y Usar
using libConexionBD;
using System.Windows.Forms;
using System.Web.UI.WebControls;


namespace libLlenarGrids
{
    public class clsLlenarGrids
    {
        #region "Constructor"
            public clsLlenarGrids( string NombreAplicacion )
            {
                strApp = NombreAplicacion;
                strSQL = string.Empty;
                strError = string.Empty;
            }
        #endregion

        #region "Atributos"
            private string strApp;
            private string strSQL;
            private string strError;
        #endregion

        #region "Propiedades"
            public string SQL
            { set { strSQL = value; } }
            public string Error
            { get { return strError; } }
        #endregion
          
        #region "Métodos Privados"
            private bool Validar()
            {
                if ( string.IsNullOrEmpty( strSQL ) )
                {
                    strError = "Debe definir la instrucción SQL";
                    return false;
                }
                return true;
            }
        #endregion

        #region "Métodos Públicos"
            public bool LlenarGrid_Windows( DataGridView Generico )
            {
                if ( ! Validar() )
                    return false;
                try
                {
                    clsConexionBD objConexionBd = new clsConexionBD( strApp );
                    objConexionBd.SQL = strSQL;
                    if ( ! objConexionBd.LlenarDataSet( false ) )
                    {
                        strError = objConexionBd.Error;
                        objConexionBd.CerrarCnx();
                        objConexionBd = null;
                        return false;
                    }
                    Generico.DataSource = objConexionBd.DataSet_Lleno.Tables[0];
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
            public bool LlenarGrid_Web( GridView Generico )
            {
                if ( ! Validar() )
                    return false;
                try
                {
                    clsConexionBD objConexionBd = new clsConexionBD( strApp );
                    objConexionBd.SQL = strSQL;
                    if ( ! objConexionBd.LlenarDataSet( false ) )
                    {
                        strError = objConexionBd.Error;
                        objConexionBd.CerrarCnx();
                        objConexionBd = null;
                        return false;
                    }
                    Generico.DataSource = objConexionBd.DataSet_Lleno.Tables[0];
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
