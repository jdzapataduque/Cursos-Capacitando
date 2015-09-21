using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Referenciar y usar
using System.Xml;
using System.Windows.Forms;


namespace libParametros
{
    public class clsParametros
    {

    #region "Atributos"
        private string strServidor;
        private string strBaseDatos;
        private string strUsuario;
        private string strClave;
        private string strSegInt;
        private string strArchivoXml;
        private string strCadCnx;
        private string strError;
        private XmlDocument objDoc = new XmlDocument();
        private XmlNode objNodo;
    #endregion

    #region "Constructor"
        public  clsParametros()
        {  
            strServidor = string.Empty;
            strBaseDatos = string.Empty;
            strUsuario = string.Empty;
            strClave = string.Empty;
            strSegInt = string.Empty;
            strArchivoXml = string.Empty;
            strCadCnx = string.Empty;
            strError = string.Empty;
        }
    #endregion

    #region "Propiedades"
        public string  CadenaCnx
        {   get { return strCadCnx;   }       }
        public string Error
        {   get { return  strError;   }       }
    #endregion

    #region "Métodos Públicos"
        public bool GenerarCadenaCnx( string strNombreAplicacion )
        {
            strArchivoXml = Application.StartupPath + "\\CON_"
                + strNombreAplicacion + ".xml";
            try
            {
                objDoc.Load(strArchivoXml);
                objNodo = objDoc.SelectSingleNode("//Servidor");
                strServidor = objNodo.InnerText;
                objNodo = objDoc.SelectSingleNode("//BaseDatos");
                strBaseDatos = objNodo.InnerText;
                objNodo = objDoc.SelectSingleNode("//Usuario");
                strUsuario = objNodo.InnerText;
                objNodo = objDoc.SelectSingleNode("//Clave");
                strClave = objNodo.InnerText;
                objNodo = objDoc.SelectSingleNode("//SeguridadIntegrada");
                strSegInt = objNodo.InnerText;
                objDoc = null;

                if ( strSegInt.ToLower() == "no" ) //Autenticación SQL SERVER   
                    strCadCnx = "Data Source= " + strServidor + "; " +
                      " Initial Catalog= " + strBaseDatos + "; " +
                      " User Id = " + strUsuario + "; " +
                      " Password= " + strClave + "; ";

                else if ( strSegInt.ToLower() == "si" ) //Autenticación  Windows
                    strCadCnx = "Data Source= " + strServidor + "; " +
                      " Initial Catalog= " + strBaseDatos + "; " +
                      " Integrated Security=SSPI;";
                else
                {
                    strError = "Error en conexión, falta información, consulte al Admón del Sistema";
                    return false;
                }
                return true;
            }
            catch 
            {
                strError = "Error en conexión, reintente por favor o consulte al Admón del Sistema";
                return false;
            }
        }
    #endregion

    }
}
