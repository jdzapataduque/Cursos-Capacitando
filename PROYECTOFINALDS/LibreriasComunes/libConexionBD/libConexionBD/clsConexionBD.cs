using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Referenciar y usar
using System.Data;
using System.Data.SqlClient;

//Referenciar y usar
using libParametros;


namespace libConexionBD
{
    public class clsConexionBD
    {
        #region "Atributos"

        private string strApp;             //Para el nombre de la aplicación
        private string strCadenaCnx;       //Para la cadena de conexón a la BD
        private object objVrUnico;         //Para la captura y retorno del Vr. único(método: ConsultarValorUnico)) 
        private string strSQL;             //Para la sentencia SQL a ejecutarse en la BD
        private string strError;           //Para el mensaje de error
        private bool blnHayCnx;            //Para saber si hay o no Cnx a la BD
        private SqlConnection objCnx;      //Para el objeto Conexión
        private SqlCommand objCmd;         //Para el objeto Command (realiza la transacción)
        private SqlDataReader objReader;   //Para el objeto DataReader (contenedor de info)
        private SqlDataAdapter objAdapter; //Para el objeto DataAdapter (para llenar el DataSet, entre otros)
        private DataSet objDts;            //Para el objeto DataSet (contenedor de info)

        #endregion

        #region "Constructor"
            public clsConexionBD( string NombreAplicacion )
            {
                strApp = NombreAplicacion;
                blnHayCnx = false;
                objCnx = new SqlConnection();      //Para la Conexión
                objCmd = new SqlCommand();         //Para la Transacción
                objAdapter = new SqlDataAdapter(); //Para la llenar el DataSet
                objDts = new DataSet();            //Para el DataSet
            }
        #endregion

        #region "Propiedades"
            public string SQL                     //Para ingresar la sentencia SQL a ejecutarse en la BD      
            { set { strSQL = value;    } }
            public object Valor_Unico             //Para retornar el valor obtenido al invocar el método:  ConsultarValorUnico
            { get { return objVrUnico; } }
            public SqlDataReader DataReader_Lleno //Para retornar el DataReader con la info obtenida al invocar el método: Consultar
            { get { return objReader;  } }
            public DataSet DataSet_Lleno          //Para retornar el DataSet con la info obtenida al invocar el método: LlenarDataSet
            { get { return objDts;     } }
            public string Error                   //Para retornar el mensaje de error
            { get { return strError;   } }
        #endregion

        #region "Métodos Privados"

            private bool GenerarCadenaCnx()
            {
                try
                {
                    if ( string.IsNullOrEmpty( strApp ) )
                    {
                        strError = "Sin Nombre de la aplicación";
                        return false;
                    }
                    clsParametros objParams = new clsParametros();
                    if ( ! objParams.GenerarCadenaCnx( strApp ) )
                    {
                        strError = objParams.Error;
                        objParams = null;
                        return false;
                    }
                    strCadenaCnx = objParams.CadenaCnx;
                    objParams = null;
                    return true;
                }
                catch ( Exception ex )
                {
                    strError = ex.Message;
                    return false;
                }
            }

            private bool AbrirCnx()
            {
                if ( ! GenerarCadenaCnx() )
                    return false;
                objCnx.ConnectionString = strCadenaCnx;
                try
                {
                    objCnx.Open();
                    blnHayCnx = true;
                    return true;
                }
                catch ( Exception ex )
                {
                    strError = ex.Message;
                    blnHayCnx = false;
                    return false;
                }
            }

        #endregion

        #region "Métodos Públicos"

            public void CerrarCnx()
            {
                try
                {
                    objCnx.Close();
                    objCnx = null;
                    blnHayCnx = false;
                }
                catch (Exception ex)
                {
                    strError = "No se cerró o liberó la conexión, " + ex.Message;
                }
            }
            public bool Consultar( bool blnParametros )
            {
                try
                {
                    if ( string.IsNullOrEmpty( strSQL ) )
                    {
                        strError = "No definió la instrucción SQL";
                        return false;
                    }
                    if ( ! blnHayCnx )
                        if ( ! AbrirCnx() )
                            return false;
                    //Preparar el Comando para ejecutar la transacción SQL en la BD
                    objCmd.Connection = objCnx;
                    objCmd.CommandText = strSQL;

                    if (blnParametros)
                        objCmd.CommandType = CommandType.StoredProcedure;
                    else
                        objCmd.CommandType = CommandType.Text;

                    objReader = objCmd.ExecuteReader();  //Realizar la transacción en la BD
                    return true;
                }
                catch ( Exception ex )
                {
                    strError = ex.Message;
                    return false;
                }
            }
            public bool ConsultarValorUnico( bool blnParametros )
            {
                try
                {
                    if ( string.IsNullOrEmpty( strSQL ) )
                    {
                        strError = "No definió la instrucción SQL";
                        return false;
                    }
                    if ( ! blnHayCnx )
                        if ( ! AbrirCnx() )
                            return false;
                    //Preparar el Comando para ejecutar la transacción SQL en la BD
                    objCmd.Connection = objCnx;
                    objCmd.CommandText = strSQL;
                    if (blnParametros)
                        objCmd.CommandType = CommandType.StoredProcedure;
                    else
                        objCmd.CommandType = CommandType.Text;

                    objVrUnico = objCmd.ExecuteScalar();  //Realizar la transacción en la BD
                    return true;
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                    return false;
                }
            }
            public bool EjecutarSentencia( bool blnParametros )
            {
                try
                {
                    if ( string.IsNullOrEmpty(strSQL) )
                    {
                        strError = "No definió la instrucción SQL";
                        return false;
                    }
                    if ( ! blnHayCnx )
                        if ( ! AbrirCnx() )
                            return false;
                    //Preparar el Comando para ejecutar la transacción SQL en la BD
                    objCmd.Connection = objCnx;
                    objCmd.CommandText = strSQL;

                    if (blnParametros)
                        objCmd.CommandType = CommandType.StoredProcedure;
                    else
                        objCmd.CommandType = CommandType.Text;

                    objCmd.ExecuteNonQuery();   //Realizar la transacción en la BD
                    return true;
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                    return false;
                }
            }
            public bool LlenarDataSet( bool blnParametros )
            {
                try
                {
                    if ( string.IsNullOrEmpty( strSQL ) )
                    {
                        strError = "No definió la instrucción SQL";
                        return false;
                    }
                    if ( ! blnHayCnx )
                        if ( ! AbrirCnx() )
                            return false;
                    //Preparar el Comando para el DataAdapter
                    objCmd.Connection = objCnx;
                    objCmd.CommandText = strSQL;
                    if (blnParametros)
                        objCmd.CommandType = CommandType.StoredProcedure;
                    else
                        objCmd.CommandType = CommandType.Text;
                    //Preparar el DataAdapter para el uso del comando en la BD
                    objAdapter.SelectCommand = objCmd; //El DataAdapter Utiliza el Command para la transacción
                    objAdapter.Fill(objDts);//Realizar la transacción en la BD y el llenado del DataSet/Datatable
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
