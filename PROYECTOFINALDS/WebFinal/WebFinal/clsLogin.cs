using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Web;
using libConexionBD;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace WebFinal
{
    public class clsLogin
    {
        #region Atributos
        private string strnombreApp;
        private string strUser;
        private string strPass;
        private string strError;
        private string strSQL;
        private string strCode;
        private clsConexionBD objCnx;
        #endregion

        #region Constructores

        public clsLogin(string nombre)
        {
            strnombreApp = nombre;
            strUser = string.Empty;
            strPass = string.Empty;
            strError = string.Empty;
            strSQL = string.Empty;

        }
        public clsLogin(string nombre,string user,string pass)
        {
            strnombreApp = nombre;
            strUser = user;
            strPass = pass;
            strError = string.Empty;
            strSQL = string.Empty;

        }

        #endregion

        #region Propiedades

        public string User
        {
            get { return strUser; }
            set { strUser = value; }
        }

        public string Password
        {
            get { return strPass; }
            set { strPass = value; }
        }

        public string Error
        {
            get { return strError; }
            set { strError = value; }
        }

        public string SQL
        {
            get { return strSQL; }
            set { strSQL = value; }
        }
        public string ok
        {
            get { return strCode; }
        }


        #endregion

        #region Metodos Publicos

        public bool BuscarUsuario()
        {
            try
            {
                strSQL = "EXEC loginCC  '" + strUser + "', '" + strPass + "';";
                objCnx = new clsConexionBD(strnombreApp);
                objCnx.SQL = strSQL;

                if (!objCnx.ConsultarValorUnico(false))
                {
                    
                    strError = objCnx.Error;
                    objCnx = null;
                    return false;
                }

                strUser = objCnx.Valor_Unico.ToString().Trim();
                strCode = "sfdkI195";
                objCnx = null;
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
