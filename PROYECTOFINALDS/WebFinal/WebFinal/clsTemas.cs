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
using libLlenarCombos;
using libLlenarGrids;
using LibLlenarRBList;

namespace WebFinal
{
    public class clsTemas
    {
        #region Atributos
        private string strNombreApp;
        private int intCod;
        private string strError;
        private clsConexionBD objCnx;
        private SqlDataReader Reader_Local;
        #endregion

        #region Constructores
        public clsTemas(string Nombre_Aplicacion)
        {
            strNombreApp = Nombre_Aplicacion;        
            strError = string.Empty;
        }

        public clsTemas(string Nombre_Aplicacion,int cod)
        {
            strNombreApp = Nombre_Aplicacion;
            intCod = cod;
            strError = string.Empty;
        }
        #endregion

        #region Propiedades
       
        public int CodTemas
        {
            get { return intCod; }
            set { intCod = value; }
        }

        public string Error
        {
            get { return strError; }
        }

        #endregion

        #region Metodos Privados

        private bool Validar()
        {
            if (intCod<=0)
            {
                strError = "Error de código de Temas";
                return false;
            }
            return true;
        }

        #endregion

        #region Metodos Publicos

        public bool LlenarGridsTemas(GridView GridaLlenar)
        {
            clsLlenarGrids objLlenar = new clsLlenarGrids(strNombreApp);
            objLlenar.SQL = "EXEC llenarGridTemas;";
            if (!objLlenar.LlenarGrid_Web(GridaLlenar))
            {
                strError = objLlenar.Error;
                return false;
            }
            return true;
        }

        public bool LlenarGridsTemasxCod(GridView GridaLlenar)
        {
            clsLlenarGrids objLlenar = new clsLlenarGrids(strNombreApp);
            objLlenar.SQL = "EXEC llenarGridTemasxCod '" + intCod + "'; ";
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
