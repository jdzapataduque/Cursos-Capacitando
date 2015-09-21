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
using LibChkBoxList;

namespace WebFinal
{
    public class clsCrearCurso
    {
        #region Atributos
        private string strNombreApp;
        private string strSql, strNombreCurso;
        private int intNhoras;
        private int intCodCurso;
        private string strCodCurso;
        private string strNedicion;
        private double dblValor;
        private string strTemas;
        private string strPrerrequisitos;
        //private bool blnActivo;
        private DateTime dtmInicio;
        private string strCodEmpleado;
        private string strNroDoce;
        private string strError;
        private clsConexionBD objCnx;
        private SqlDataReader Reader_Local;
        #endregion

        #region Constructores
        public clsCrearCurso(string Nombre_Aplicacion)
        {
            strNombreApp = Nombre_Aplicacion;
            strNombreCurso = string.Empty;
            intNhoras = 0;
            strNedicion = string.Empty;
            dblValor = 0;
            strTemas = string.Empty;
            strPrerrequisitos = string.Empty;
            strCodEmpleado=string.Empty;
            strNroDoce=string.Empty;
            intCodCurso = 0;
            strError = string.Empty;
        }

        public clsCrearCurso(string Nombre_Aplicacion, string Nombre,
            int horas,string edicion, double valor,string temas,string prerre,
            DateTime inicio,string codempleado,string nrdoc,int cod)
        {
            strNombreApp = Nombre_Aplicacion;
            strNombreCurso = Nombre;
            intNhoras = horas;
            strNedicion = edicion;
            dblValor = valor;
            strTemas = temas;
            strPrerrequisitos = prerre;
            dtmInicio = inicio;
            strCodEmpleado = codempleado;
            strNroDoce = nrdoc;
            intCodCurso = cod;
            strError = string.Empty;
        }
        #endregion

        #region Propiedades

        public string CodCurso
        {
            get { return strCodCurso; }
            set { strCodCurso = value; }
        }
        public int CodCursoint
        {
            get { return intCodCurso; }
            set { intCodCurso = value; }
        }


        public string NombreCurso
        {
            set { strNombreCurso = value; }
            get { return strNombreCurso; }
        }
        public int Horas
        {
            get { return intNhoras; }
            set { intNhoras = value; }
        }
        public string NEdicion
        {
            get { return strNedicion; }
            set { strNedicion = value; }
        }
        public double  Valor
        {
            get { return dblValor; }
            set { dblValor = value; }
        }
        public string Temas
        {
            get { return strTemas; }
            set { strTemas = value; }
        }
        public string Prerrequisitos
        {
            get { return strPrerrequisitos; }
            set { strPrerrequisitos = value; }
        }
        public string Error
        {
            get { return strError; }
        }

        #endregion

        #region Metodos Privados

        private bool Validar()
        {
            if (string.IsNullOrEmpty(strNombreCurso))
            {
                strError = "Error--> Falta ingresar el Nombre Curso";
                return false;
            }

            if (intNhoras<=0)
            {
                strError = "Error--> Horas Inválidas";
                return false;
            }
            if (string.IsNullOrEmpty(strNedicion))
            {
                strError = "Error--> Falta ingresar el número de Edición";
                return false;
            }
            if (dblValor <= 0)
            {
                strError = "Error-->  Valor del Curso Inválido";
                return false;
            }
            if (intCodCurso <= 0)
            {
                strError = "Error-->  Código del Curso Inválido";
                return false;
            }
            if (string.IsNullOrEmpty(strPrerrequisitos))
            {
                strError = "Error--> Falta ingresar los Prerrequisitos";
                return false;
            }
            if (string.IsNullOrEmpty(strTemas))
            {
                strError = "Error--> Falta ingresar los Temas";
                return false;
            }
            if (string.IsNullOrEmpty(strCodEmpleado))
            {
                strError = "Error--> Falta ingresar el código del empleado";
                return false;
            }
            if (string.IsNullOrEmpty(strNroDoce))
            {
                strError = "Error--> Falta ingresar el número de documento";
                return false;
            }

            return true;
        }

        private bool ValidarMod()
        {
            if (string.IsNullOrEmpty(strNombreCurso))
            {
                strError = "Error--> Falta ingresar el Nombre Curso";
                return false;
            }

            if (intNhoras <= 0)
            {
                strError = "Error--> Horas Inválidas";
                return false;
            }
            if (intCodCurso <= 0)
            {
                strError = "Error-->  Código del Curso Inválido";
                return false;
            }
            if (string.IsNullOrWhiteSpace(strTemas))
            {
                strError = "Error-->  Temas del Curso Inválido";
                return false;
            }


            return true;
        }//ValidarModificar Mio

        private bool Grabar()
        {
            try
            {
                if (!Validar())
                    return false;

                objCnx = new clsConexionBD(strNombreApp);
                objCnx.SQL = strSql;

                if (!objCnx.ConsultarValorUnico(false))
                {
                    strError = objCnx.Error;
                    objCnx = null;
                    return false;

                }
                 strCodCurso= objCnx.Valor_Unico.ToString();
                objCnx = null;
                return true;

            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        private bool GrabarMod()
        {
            try
            {
                if (!ValidarMod())
                    return false;

                objCnx = new clsConexionBD(strNombreApp);
                objCnx.SQL = strSql;

                if (!objCnx.ConsultarValorUnico(false))
                {
                    strError = objCnx.Error;
                    objCnx = null;
                    return false;

                }
                strCodCurso = objCnx.Valor_Unico.ToString();
                objCnx = null;
                return true;

            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }//Grabar Modificar

        #endregion

        #region Metodos Publicos

        public bool IngresarCurso()
        {
            try
            {
                strSql = "EXEC CrearNuevoCurso '" + strNombreCurso + "','" + intNhoras +
                "','" + strNedicion + "','" + dblValor + "','" + strTemas + "','" + 
                strPrerrequisitos + "','" + dtmInicio.ToShortDateString() +
                "','" + strCodEmpleado + "','" + strNroDoce + "','" + intCodCurso + "';";
                return Grabar();
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        public bool ModificarCurso()
        {
            try
            {
                strSql = "EXEC ModificarCursoCreado '" + intCodCurso + "','" + strNombreCurso +
                    "','" + intNhoras + "','" + strTemas + "';";
                return GrabarMod();

            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        public bool BuscarCurso(int Codigo)
        {
            try
            {
                if (Codigo<=0)
                {
                    strError = "Error--> Código del Curso Inválido";
                    return false;
                }
                strSql = "EXEC BuscarCursoXCodigo '" + Codigo + "'; ";
                objCnx = new clsConexionBD(strNombreApp);
                objCnx.SQL = strSql;
                if (!objCnx.Consultar(false))
                {
                    strError = objCnx.Error;
                    objCnx = null;
                    return false;
                }
                Reader_Local = objCnx.DataReader_Lleno;
                if (Reader_Local.HasRows)//Si existen registros
                {
                    Reader_Local.Read();
                    intCodCurso = Reader_Local.GetInt32(0);
                    strNombreCurso = Reader_Local.GetString(1);
                    Reader_Local.Close();
                    return true;
                }
                strError = "No se encontró Ningun registro :" + Codigo;
                Reader_Local.Close();
                objCnx = null;
                return false;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;

            }

        }

        public bool LlenarGridsCursos(GridView GridaLlenar)
        {
            clsLlenarGrids objLlenar = new clsLlenarGrids(strNombreApp);
            objLlenar.SQL = "EXEC llenarGridCursos;";
            if (!objLlenar.LlenarGrid_Web(GridaLlenar))
            {
                strError = objLlenar.Error;
                return false;
            }
            return true;
        }

        public bool LlenarGridsCursosXCodigoc(GridView GridaLlenar)
        {
            clsLlenarGrids objLlenar = new clsLlenarGrids(strNombreApp);
            objLlenar.SQL = "EXEC BuscarCursoXCodigo '" + intCodCurso + "'; ";
            if (!objLlenar.LlenarGrid_Web(GridaLlenar))
            {
                strError = objLlenar.Error;
                return false;
            }
            return true;
        }

        public bool LlenarCBlistPrerre(CheckBoxList cblallenar)
        {
            ClsChkList objLlenar = new ClsChkList(strNombreApp);
            objLlenar.SQL = "EXEC LlenarCBPrerrequisitos;";
            objLlenar.CampoID = "Clave";
            objLlenar.CampoTexto = "Dato";
            if (!objLlenar.LlenarChkbL_Web(cblallenar))
            {
                strError = objLlenar.Error;
                return false;
            }
            return true;
        }

        public bool LlenarRbEmpleado(RadioButtonList radioaLlenar)
        {
            clsLlenarRBList objLlenar = new clsLlenarRBList(strNombreApp);
            objLlenar.SQL = "EXEC LlenarRadioEmpleados;";
            objLlenar.CampoID = "Clave";
            objLlenar.CampoTexto = "Dato";
            if (!objLlenar.LlenarRadioBL_Web(radioaLlenar))
            {
                strError = objLlenar.Error;
                return false;
            }
            return true;
        }

        #endregion
    }
}
