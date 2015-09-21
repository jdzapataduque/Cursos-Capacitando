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
    public class clsEstudiante
    {
        #region Atributos
        private string strNombreApp;
        private string strSql, strCedulaCliente, strNombreCompl;
        private string strCodEmpl, strCodPago,strCodCurso,strCodMatri,strTituloCurso;
        private double dblEdad;
        private double dblCel;
        private double dblTel;
        private string strDireccion;
        private string strError;
        private clsConexionBD objCnx;
        private SqlDataReader Reader_Local;
        #endregion

        #region Constructores
        public clsEstudiante(string Nombre_Aplicacion)
        {
            strNombreApp = Nombre_Aplicacion;
            strCedulaCliente = string.Empty;
            strNombreCompl = string.Empty;
            dblEdad = 0;
            dblTel = 0;
            dblCel = 0;
            strDireccion = string.Empty;
            strCodEmpl = string.Empty;
            strCodPago = string.Empty;
            strCodCurso= string.Empty;
            strCodMatri = string.Empty;
            strTituloCurso = string.Empty;
            strError = string.Empty;
        }

        public clsEstudiante(string Nombre_Aplicacion, string Cedula, string Nombre,
            double edad, double tel, double cel, string dir, string empl, string pago, 
            string ccurso,string titulocurso,string codmatri)
        {
            strNombreApp = Nombre_Aplicacion;
            strCedulaCliente = Cedula;
            strNombreCompl = Nombre;
            dblEdad = edad;
            dblTel = tel;
            dblCel = cel;
            strDireccion = dir;
            strCodEmpl = empl;
            strCodPago = pago;
            strCodCurso = ccurso;
            strCodMatri = codmatri;
            strTituloCurso = titulocurso;
            strError = string.Empty;
        }
        #endregion

        #region Propiedades
        public string CedulaCliente
        {
            set { strCedulaCliente = value; }
            get { return strCedulaCliente; }
        }
        public string Nombre
        {
            get { return strNombreCompl; }
            set { strNombreCompl = value; }
        }
        public double Telefono
        {
            get { return dblTel; }
            set { dblTel = value; }
        }
        public double Edad
        {
            get { return dblEdad; }
            set { dblEdad = value; }
        }
        public double Celular
        {
            get { return dblCel; }
            set { dblCel = value; }
        }
        public string Direccion
        {
            get { return strDireccion; }
            set { strDireccion = value; }
        }
        public string CodEmple
        {
            get { return strCodEmpl; }
            set { strCodEmpl = value; }
        }
        public string Error
        {
            get { return strError; }
        }

        #endregion

        #region Metodos Privados

        private bool Validar()
        {
            if (string.IsNullOrEmpty(strCedulaCliente))
            {
                strError = "Error--> Falta ingresar la cédula";
                return false;
            }

            if (string.IsNullOrEmpty(strNombreCompl))
            {
                strError = "Error--> Falta ingresar el Nombre";
                return false;
            }
            if (string.IsNullOrEmpty(strDireccion))
            {
                strError = "Error--> Falta ingresar la dirección";
                return false;
            }
            if (string.IsNullOrEmpty(strCodEmpl))
            {
                strError = "Error--> Falta códido del empleado";
                return false;
            }
            if (string.IsNullOrEmpty(strCodMatri))
            {
                strError = "Error--> Falta códido de la matrícula";
                return false;
            }
            if (string.IsNullOrEmpty(strCodPago))
            {
                strError = "Error--> Falta códido del pago";
                return false;
            }
            if (string.IsNullOrEmpty(strTituloCurso))
            {
                strError = "Error--> Falta Nombre del curso";
                return false;
            }
            if (dblEdad<=0)
            {
                strError = "Error-->  Edad Inválida";
                return false;
            }
            if (dblCel <= 0)
            {
                strError = "Error-->  Celular Inválido";
                return false;
            }
            if (dblTel <= 0)
            {
                strError = "Error-->  Teléfono Inválido";
                return false;
            }
            return true;
        }

        private bool ValidarMod()
        {
            if (string.IsNullOrEmpty(strCedulaCliente))
            {
                strError = "Error--> Falta ingresar la cédula";
                return false;
            }

            if (string.IsNullOrEmpty(strNombreCompl))
            {
                strError = "Error--> Falta ingresar el Nombre";
                return false;
            }
            if (string.IsNullOrEmpty(strDireccion))
            {
                strError = "Error--> Falta ingresar la dirección";
                return false;
            }
            if (dblEdad <= 0)
            {
                strError = "Error-->  Edad Inválida";
                return false;
            }
            if (dblCel <= 0)
            {
                strError = "Error-->  Celular Inválido";
                return false;
            }
            if (dblTel <= 0)
            {
                strError = "Error-->  Teléfono Inválido";
                return false;
            }
            return true;
        }

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

                strCedulaCliente = objCnx.Valor_Unico.ToString();
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

                strCedulaCliente = objCnx.Valor_Unico.ToString();
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

        #region Metodos Publicos

        public bool IngresarEstudiante()
        {
            try
            {
                strSql = "EXEC GrabarEstudiante '" + strCedulaCliente + "','" + strNombreCompl +
                "','" + dblEdad + "','" + dblTel + "','" + dblCel + "','" +
                strDireccion + "','" + strCodEmpl + "','" + strCodPago + "','" +
                 strCodCurso + "','" + strTituloCurso + "','" + strCodMatri +"';";
                return Grabar();
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        public bool ModificarEstudiante()
        {
            try
            {
                strSql = "EXEC ModificarEstudiante '" + strCedulaCliente + "','" +
                 strNombreCompl + "','" + dblEdad + "','" +dblTel+"','" + dblCel
                + "','" + strDireccion + "';";
                return GrabarMod();

            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        public bool LlenarGridsEstudiantes(GridView GridaLlenar)
        {
            clsLlenarGrids objLlenar = new clsLlenarGrids(strNombreApp);
            objLlenar.SQL = "EXEC llenarGridEstudiantes;";
            if (!objLlenar.LlenarGrid_Web(GridaLlenar))
            {
                strError = objLlenar.Error;
                return false;
            }
            return true;
        }

        public bool LlenarGridsMatriculaxCed(GridView GridaLlenar)
        {
            clsLlenarGrids objLlenar = new clsLlenarGrids(strNombreApp);
            objLlenar.SQL = "EXEC BuscarMatriculaporCedula '" + strCedulaCliente + "'; ";
            if (!objLlenar.LlenarGrid_Web(GridaLlenar))
            {
                strError = objLlenar.Error;
                return false;
            }
            return true;
        }

        public bool LlenarCombo(DropDownList ComboaLlenar)
        {
            clsLlenarCombos objLlenar = new clsLlenarCombos(strNombreApp);
            objLlenar.SQL = "EXEC LlenarComboCursos;";
            objLlenar.CampoID = "Clave";
            objLlenar.CampoTexto = "Dato";
            if (!objLlenar.LlenarCombo_Web(ComboaLlenar))
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

        public bool LlenarRbFormasdePago(RadioButtonList radioaLlenar)
        {
            clsLlenarRBList objLlenar = new clsLlenarRBList(strNombreApp);
            objLlenar.SQL = "EXEC LlenarRadioFormasdePago;";
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
