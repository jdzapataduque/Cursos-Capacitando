using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace WebFinal
{
    public partial class Formulario_web12 : System.Web.UI.Page
    {

        #region Variables
        static string strNombreApp;
        static string strUsuario;
        string strCodigo;
        static int intOpcion;//1:Agregar 2:Modificar
        DateTime dtmini;
        int intCodCurso;
        int intCod;//Para Buscar Por codigo del curso
        string strNombreCurso, strnEdicion, strTemas,strPrerre;
        int intHoras;
        string strCodEmpleado, strNroDoc;
        double dblValor;
         string mensaje = "<script>javascript:alertify.success('Proceso Exitoso');</script>)";     
         string mensajeError = "<script>javascript:alertify.error('Lo sentimos ocurrió un error');</script>)";
        #endregion

        #region Metodos Personalizados

        private void Mensaje(string Texto)
        {
            this.LblMsj.Text = Texto.Trim();
        }

        private void Limpiar()
        {
            Mensaje(string.Empty);
            LimpiarTodo(this);
        }

        private void LlenarGridCursos()
        {
            try
            {
                clsCrearCurso objXX = new clsCrearCurso(strNombreApp);
                if (!objXX.LlenarGridsCursos(this.grvDatos))
                {
                    Mensaje(objXX.Error);
                    objXX = null;
                    return;
                }


            }
            catch (Exception ex)
            {

                Mensaje(ex.Message);
            }
        }

        private void LlenarGridCursosXCodigo()
        {
            try
            {
                clsCrearCurso objXX = new clsCrearCurso(strNombreApp);
                objXX.CodCursoint = intCod;
                if (!objXX.LlenarGridsCursosXCodigoc(this.grvDatos))
                {
                    Mensaje(objXX.Error);
                    objXX = null;
                    return;
                }


            }
            catch (Exception ex)
            {

                Mensaje(ex.Message);
            }
        }

        private void LLenarPrerre()//LlenarcbListpree()
        {
            clsCrearCurso objXX = new clsCrearCurso(strNombreApp);
            if (!objXX.LlenarCBlistPrerre(this.cblPrerre))
            {
                Mensaje(objXX.Error);
                objXX = null;
                return;
            }
        }

        private void LimpiarTodo(Control parent)
        {

            foreach (Control c in parent.Controls)
            {
                if ((c.GetType() == typeof(TextBox)))
                {

                    ((TextBox)(c)).Text = "";
                }

                if (c.HasControls())
                {
                    LimpiarTodo(c);
                }
            }
        }

        private void Buscar(int Codigo)
        {
            Mensaje(string.Empty);
            clsCrearCurso objBuscar = new clsCrearCurso(strNombreApp);
            if (!objBuscar.BuscarCurso(Codigo))
            {
                Mensaje(objBuscar.Error);
                objBuscar = null;
                return;
            }
            return;
        }

        private bool GrabarRegistro()
        {
            try
            {
                intOpcion = 1;
                Mensaje(string.Empty);
                strNombreCurso = this.txtNombre.Text.Trim().ToUpper();
                intHoras = Convert.ToInt32( this.txtnHoras.Text.Trim());
                strnEdicion = this.txtnEdicion.Text.Trim().ToUpper();
                dblValor = Convert.ToDouble(this.txtValor.Text.Trim());
                strTemas = this.txtTemas.Text.Trim().ToUpper();
                strPrerre =strPrerre+ this.cblPrerre.SelectedItem.Text;
                dtmini = clFechaini.SelectedDate;
                strCodEmpleado = rbEmpleado.SelectedValue;
                if (string.IsNullOrEmpty(strCodEmpleado))
                {
                    Mensaje("Error--> Seleccione un empleado");
                    return false;
                    
                }
                strNroDoc = txtNroDocEmpl.Text.Trim();
                intCodCurso = Convert.ToInt32(txtCodCurso.Text);
                //Mensaje(strCodEmpleado);
               //return true;/////
                clsCrearCurso objGrabar = new clsCrearCurso(strNombreApp,strNombreCurso,
                    intHoras,strnEdicion,dblValor,strTemas,strPrerre,dtmini,
                    strCodEmpleado,strNroDoc,intCodCurso);
                if (intOpcion == 1)
                {
                    if (!objGrabar.IngresarCurso())
                    {
                        Mensaje(objGrabar.Error);
                        this.txtNombre.Focus();
                        return false;
                    }
                     strCodigo = objGrabar.CodCurso.ToString();
                    if (strCodigo == "-1")
                    {
                        Mensaje("Error ya existe un registro con el mismo código o nombre");
                        Controls.Add(new LiteralControl(mensajeError));
                        this.txtNombre.Focus();
                        return false;
                    }
                    if (strCodigo == "0")
                    {
                        Mensaje("Error al realizar el procedimiento");
                        Controls.Add(new LiteralControl(mensajeError));
                        this.txtNombre.Focus();
                        return false;
                    }

                }
                else if (intOpcion == 2)
                {
                    if (!objGrabar.ModificarCurso())
                    {
                        Mensaje(objGrabar.Error);
                        this.txtNombre.Focus();
                        return false;
                    }

                }
                else
                {
                    Mensaje("Error No clasificado --> consulte con el admon de Sistema");
                    this.txtNombre.Focus();
                    return false;
                }
                this.txtBuscar.Text = strCodigo;
                this.txtBuscar.ReadOnly = true;
                this.txtNombre.Focus();
                Mensaje("Registro Grabado con éxito");
                Controls.Add(new LiteralControl(mensaje));
                LlenarGridCursos();
                return true;

            }
            catch (Exception ex)
            {
                Mensaje("Error -> " + ex.Message);
                this.txtBuscar.Focus();
                return false;
            }

        }

        private bool GrabarRegistroMod()
        {
            try
            {
                intOpcion = 2;

                Mensaje(string.Empty);
                intCodCurso = Convert.ToInt32(txtCodCurso.Text);
                strNombreCurso = this.txtNombre.Text.Trim().ToUpper();
                intHoras = Convert.ToInt32(this.txtnHoras.Text.Trim());
                strTemas = txtTemas.Text.Trim();

                clsCrearCurso objGrabar = new clsCrearCurso(strNombreApp);
                objGrabar.NombreCurso = strNombreCurso;
                objGrabar.CodCursoint = intCodCurso;
                objGrabar.Horas = intHoras;
                objGrabar.Temas = strTemas;
                //Enviar info clase
                if (intOpcion == 1)
                {
                    if (!objGrabar.IngresarCurso())
                    {
                        Mensaje(objGrabar.Error);
                        this.txtNombre.Focus();
                        return false;
                    }
                    strCodigo = objGrabar.CodCurso.ToString();
                    if (strCodigo == "-1")
                    {
                        Mensaje("Error ya existe un registro con el mismo código o nombre");
                        this.txtNombre.Focus();
                        return false;
                    }
                    if (strCodigo == "0")
                    {
                        Mensaje("Error al realizar el procedimiento");
                        this.txtNombre.Focus();
                        return false;
                    }

                }
                else if (intOpcion == 2)
                {
                    if (!objGrabar.ModificarCurso())
                    {
                        Mensaje(objGrabar.Error);
                        this.txtNombre.Focus();
                        return false;
                    }

                }
                else
                {
                    Mensaje("Error No clasificado --> consulte con el admon de Sistema");
                    this.txtNombre.Focus();
                    return false;
                }
                this.txtBuscar.Text = strCodigo;
                this.txtBuscar.ReadOnly = true;
                this.txtNombre.Focus();
                Mensaje("Registro Grabado con éxito");
                LlenarGridCursos();
                string mensaje = "<script>javascript:alertify.success('¡Registro Grabado con exito!');</script>)";
                Controls.Add(new LiteralControl(mensaje));
                return true;

            }
            catch (Exception ex)
            {
                Mensaje("Error -> " + ex.Message);
                this.txtBuscar.Focus();
                return false;
            }

        }//Modificar datos

        private void LLenarCargos()//LlenarRadiolCargos()
        {
            clsCrearCurso objXX = new clsCrearCurso(strNombreApp);
            if (!objXX.LlenarRbEmpleado(this.rbEmpleado))
            {
                Mensaje(objXX.Error);
                objXX = null;
                return;
            }
        }


        #endregion
                        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                strNombreApp = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

                LLenarPrerre();
                LlenarGridCursos();
                LLenarCargos();
                intOpcion = 0;

                if (Session["usu"] == null)
                {
                    Response.Redirect("Error.aspx");
                    //mandar a una pagina de error
                }
                strUsuario = Session["usu"].ToString();

                if (string.IsNullOrWhiteSpace(strUsuario))
                {
                    Response.Redirect("index.aspx");
                }
            }
        }

        protected void grvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvDatos.PageIndex = e.NewPageIndex;
            LlenarGridCursos();
        }

        protected void mnuOpciones_MenuItemClick(object sender, MenuEventArgs e)
        {
            this.ibtnBuscar.Visible = false;
            this.txtBuscar.ReadOnly = true;

            //
            txtnEdicion.Enabled = true;
            txtValor.Enabled = true;
            clFechaini.Enabled = true;
            txtTemas.Enabled = true;
            PnlPrerrequisitos.Enabled = true;
            txtNroDocEmpl.Enabled = true;
            rbEmpleado.Enabled = true;

            switch (this.mnuOpciones.SelectedValue)
            {
                case "opcBuscar":
                    intOpcion = 0;
                    Limpiar();
                    this.txtBuscar.ReadOnly = false;
                    this.ibtnBuscar.Visible = true;
                    this.txtBuscar.Focus();
                    break;

                case "opcModificar":
                    intOpcion = 2;
                    txtnEdicion.Enabled = false;
                    txtValor.Enabled = false;
                    clFechaini.Enabled = false;
                    PnlPrerrequisitos.Enabled = false;
                    txtNroDocEmpl.Enabled = false;
                    rbEmpleado.Enabled = false;
                    this.txtCodCurso.Focus();
                    break;

                case "opcGrabar":
                    if (intOpcion == 2)
                    {
                        GrabarRegistroMod();
                        return;
                    }

                    intOpcion = 1;
                    GrabarRegistro();
                    break;

                case "opcCancelar":
                    intOpcion = 0;
                    Limpiar();
                    break;
                case "opcImprimir":

                    try
                    {
                        this.txtBuscar.ReadOnly = false;
                      intOpcion = 0;
                    intCod =Convert.ToInt32( this.txtBuscar.Text);
                    if (intCod<=0)
                    {
                        Mensaje("Código no válido");
                        txtBuscar.Focus();
                        return;
                    }

                    Session["codcurso"] = intCod;
                    Response.Redirect("FrmRpteCrearCurso.aspx");
                    }
                    catch (Exception ex)
                    {
                        Mensaje(ex.Message);
                        txtBuscar.Focus();
                    }

                    break;
                default:
                    Mensaje("Opción no válida");
                    break;
            }
        }

        protected void ibtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                intCod = Convert.ToInt32(this.txtBuscar.Text);
                if (intCod<=0)
                {
                    Mensaje("Código no válido");
                    this.txtBuscar.ReadOnly = false;
                    this.txtBuscar.Focus();
                    return;
                }
                this.txtBuscar.ReadOnly = true;
                LlenarGridCursosXCodigo();
            }
            catch (Exception ex)
            {
                Mensaje("Error--> " + ex.Message);
            }
            finally
            {
                ibtnBuscar.Visible = false;
            }
        }
    }
}