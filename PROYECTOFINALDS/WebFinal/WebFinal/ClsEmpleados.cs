using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using libConexionBD;
using libLlenarGrids;

namespace WebFinal
{
    public class ClsEmpleados
    {
        #region Atributos
        private string strNombreApp;
        private string strCod;
        private string strError;
        private clsConexionBD objCnx;
        private SqlDataReader Reader_Local;
        #endregion

        #region Constructores
        public ClsEmpleados(string Nombre_Aplicacion)
        {
            strNombreApp = Nombre_Aplicacion;        
            strError = string.Empty;
        }

        public ClsEmpleados(string Nombre_Aplicacion, string cod)
        {
            strNombreApp = Nombre_Aplicacion;
            strCod = cod;
            strError = string.Empty;
        }
        #endregion

        #region Propiedades
       
        public string CodEmpl
        {
            get { return strCod; }
            set { strCod = value; }
        }

        public string Error
        {
            get { return strError; }
        }

        #endregion

        #region Metodos Privados

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(strCod))
            {
                strError = "Error de código de Empleado";
                return false;
            }
            return true;
        }

        #endregion

        #region Metodos Publicos

        public bool LlenarGridsEmpl(GridView GridaLlenar)
        {
            clsLlenarGrids objLlenar = new clsLlenarGrids(strNombreApp);
            objLlenar.SQL = "EXEC llenarGridEmpleados;";
            if (!objLlenar.LlenarGrid_Web(GridaLlenar))
            {
                strError = objLlenar.Error;
                return false;
            }
            return true;
        }

        public bool LlenarGridsEmplxCod(GridView GridaLlenar)
        {
            clsLlenarGrids objLlenar = new clsLlenarGrids(strNombreApp);
            objLlenar.SQL = "EXEC llenarGridEmpleadosxCod '" + strCod + "'; ";
            if (!objLlenar.LlenarGrid_Web(GridaLlenar))
            {
                strError = objLlenar.Error;
                return false;
            }
            return true;
        }


        #endregion
    }
}
