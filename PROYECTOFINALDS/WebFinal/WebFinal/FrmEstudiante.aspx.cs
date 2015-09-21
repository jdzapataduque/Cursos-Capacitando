using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFinal
{
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        #region Variables
        static string strNombreApp;//Variables mias
        static int intOpcion;//1:Agregar 2:Modificar//Variables mias
        string strCedCliente;
        string strCodCurso, strTituloCurso,strCodMatri;
        double dblEdad;
        double dblCel,dblTel;//Variables mias
        string strNombreCompl,strDir,strCodEmpl,strCodPago;//Variables mias
        double dblValormatri;
        #endregion

        #region Metodos Personalizados

        private bool GrabarRegistroMatri()
        {
            try
            {
                
                strCedCliente = this.TxtCedula.Text.Trim().ToUpper();
                strNombreCompl = this.TxtNombreCompl.Text.Trim().ToUpper();
                dblEdad = Convert.ToDouble(TxtEdad.Text);
                dblTel = Convert.ToDouble(this.txtTel.Text.Trim());
                dblCel = Convert.ToDouble(this.TxtCel.Text.Trim());
                strDir = this.TxtDir.Text.Trim().ToUpper();
                strCodEmpl = this.rblEmpleado.SelectedValue;
                strCodPago = this.rblFormaPago.SelectedValue;
                strCodCurso=this.ddlCursoInscribir.SelectedValue;
                strTituloCurso = this.ddlCursoInscribir.SelectedItem.Text;
                strCodMatri = this.txtCodMatri.Text.Trim();
                //Mensaje(strCodCurso);
                //return true;/////
                clsEstudiante objGrabar = new clsEstudiante(strNombreApp,strCedCliente,
                    strNombreCompl,dblEdad,dblTel, dblCel,strDir,strCodEmpl,strCodPago,
                    strCodCurso,strTituloCurso,strCodMatri);
                if (intOpcion == 1)
                {
                    if (!objGrabar.IngresarEstudiante())
                    {
                        Mensaje(objGrabar.Error);
                        this.TxtNombreCompl.Focus();
                        return false;
                    }
                    strCedCliente = objGrabar.CedulaCliente.ToString();
                    if (strCedCliente == "-1")
                    {
                        Mensaje("Eres un empleado y no puedes inscribirte a este curso ó Código de matrícula inválida");
                        this.TxtNombreCompl.Focus();
                        return false;
                    }
                    if (strCedCliente == "0")
                    {
                        Mensaje("Error al realizar el procedimiento");
                        this.TxtNombreCompl.Focus();
                        return false;
                    }

                }
                else if (intOpcion == 2)
                {
                    if (!objGrabar.ModificarEstudiante())
                    {
                        Mensaje(objGrabar.Error);
                        this.TxtNombreCompl.Focus();
                        return false;
                    }

                }
                else
                {
                    Mensaje("Error No clasificado --> consulte con el admon de Sistema");
                    this.TxtNombreCompl.Focus();
                    return false;
                }
                this.TxtCedula.Text = strCedCliente;
                this.TxtNombreCompl.Focus();
                Mensaje("Registro Grabado con éxito");
                LlenarGridEstudiantes();
                return true;

            }
            catch (Exception ex)
            {
                Mensaje("Error -> " + ex.Message);
                this.TxtBuscar.Focus();
                return false;
            }

        }

        private void LlenarGridEstudiantes()
        {
            try
            {
                clsEstudiante objXX = new clsEstudiante(strNombreApp);
                if (!objXX.LlenarGridsEstudiantes(this.GrvDatos))
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

        private bool GrabarRegistroMod()
        {
            try
            {
                intOpcion = 2;

                strCedCliente = this.TxtCedula.Text.Trim().ToUpper();
                strNombreCompl = this.TxtNombreCompl.Text.Trim().ToUpper();
                dblEdad = Convert.ToDouble(TxtEdad.Text);
                dblTel = Convert.ToDouble(this.txtTel.Text.Trim());
                dblCel = Convert.ToDouble(this.TxtCel.Text.Trim());
                strDir = this.TxtDir.Text.Trim().ToUpper();

                clsEstudiante objGrabar = new clsEstudiante(strNombreApp);
                objGrabar.CedulaCliente = strCedCliente;
                objGrabar.Nombre = strNombreCompl;
                objGrabar.Edad = dblEdad;
                objGrabar.Telefono = dblTel;
                objGrabar.Celular = dblCel;
                objGrabar.Direccion = strDir;
                //Enviar info clase
                if (intOpcion == 1)
                {
                    if (!objGrabar.IngresarEstudiante())
                    {
                        Mensaje(objGrabar.Error);
                        this.TxtNombreCompl.Focus();
                        return false;
                    }
                    strCedCliente = objGrabar.CedulaCliente;
                    if (strCedCliente == "-1")
                    {
                        Mensaje("Error ,debes ingresar otro código");
                        this.TxtNombreCompl.Focus();
                        return false;
                    }
                    if (strCedCliente == "0")
                    {
                        Mensaje("Error al realizar el procedimiento");
                        this.TxtNombreCompl.Focus();
                        return false;
                    }

                }
                else if (intOpcion == 2)
                {
                    if (!objGrabar.ModificarEstudiante())
                    {
                        Mensaje(objGrabar.Error);
                        this.TxtNombreCompl.Focus();
                        return false;
                    }

                }
                else
                {
                    Mensaje("Error No clasificado --> consulte con el admon de Sistema");
                    this.TxtNombreCompl.Focus();
                    return false;
                }
                this.TxtCedula.Text = strCedCliente;
                this.TxtNombreCompl.Focus();
                Mensaje("Registro Grabado con éxito");
                LlenarGridEstudiantes();
                ddlCursoInscribir.Enabled = true;
                return true;

            }
            catch (Exception ex)
            {
                Mensaje("Error -> " + ex.Message);
                this.TxtCedula.Focus();
                return false;
            }

        }//Modificar Estudiante

        private void Mensaje(string Texto)
        {
            this.LblMsj.Text = Texto.Trim();
        }

        private void LlenarGridMatrciulaxCed()
        {
            try
            {
                clsEstudiante objXX = new clsEstudiante(strNombreApp);
                objXX.CedulaCliente = strCedCliente;
                if (!objXX.LlenarGridsMatriculaxCed(this.GrvDatos))
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

        private void LLenarCursos()//LlenarComboCURSOS()
        {
            clsEstudiante objXX = new clsEstudiante(strNombreApp);
            if (!objXX.LlenarCombo(this.ddlCursoInscribir))
            {
                Mensaje(objXX.Error);
                objXX = null;
                return;
            }
        }

        private void LLenarCargos()//LlenarRadiolCargos()
        {
            clsEstudiante objXX = new clsEstudiante(strNombreApp);
            if (!objXX.LlenarRbEmpleado(this.rblEmpleado))
            {
                Mensaje(objXX.Error);
                objXX = null;
                return;
            }
        }

        private void LLenarFormasdePago()//LlenarRadiolCargos()
        {
            clsEstudiante objXX = new clsEstudiante(strNombreApp);
            if (!objXX.LlenarRbFormasdePago(this.rblFormaPago))
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

        private void Limpiar()
        {
            Mensaje(string.Empty);
            LimpiarTodo(this);
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                strNombreApp = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                LLenarCursos();//Combo
                LLenarCargos();//RadioButoon
                LLenarFormasdePago();//RadioButoon
                LlenarGridEstudiantes();//llenar estudiantes
                intOpcion = 0;
                TxtBuscar.Focus();
            }
        }

        protected void BtnInscribir_Click(object sender, EventArgs e)
        {
            try
            {
                PnlCliente.Enabled = false;
                ddlCursoInscribir.Enabled = false;
                BtnInscribir.Enabled = false;
            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
            }
            
        }

        protected void MnuOpciones_MenuItemClick(object sender, MenuEventArgs e)
        {
            this.ibtnBuscar.Visible = true;
            TxtBuscar.ReadOnly = false;
            //          
            rblEmpleado.Enabled = true;
            rblFormaPago.Enabled = true;
            PnlCliente.Enabled = true;
            txtCodMatri.Enabled = true;
            BtnInscribir.Enabled = true;
            ddlCursoInscribir.Enabled = true;


            switch (this.MnuOpciones.SelectedValue)
            {

                case "opcModificar":
                    intOpcion = 2;
                    rblEmpleado.Enabled = false;
                    rblFormaPago.Enabled = false;
                    txtCodMatri.Enabled = true;
                    BtnInscribir.Enabled = true;
                    ddlCursoInscribir.Enabled = false;
                    this.TxtCedula.Focus();
                    break;

                case "opcGrabar":
                    if (intOpcion == 2)
                    {
                        GrabarRegistroMod();
                        return;
                    }

                    intOpcion = 1;
                    GrabarRegistroMatri();
                    break;

                case "opcCancelar":
                    intOpcion = 0;
                    this.ibtnBuscar.Visible = true;
                    //          
                    rblEmpleado.Enabled = true;
                    rblFormaPago.Enabled = true;
                    PnlCliente.Enabled = true;
                    txtCodMatri.Enabled = true;
                    BtnInscribir.Enabled = true;
                    ddlCursoInscribir.Enabled = true;
                    TxtBuscar.ReadOnly = false;
                    Limpiar();
                    LlenarGridEstudiantes();//llenar estudiantes
                    ddlCursoInscribir.Focus();
                    break;
                case "opcImprimir":
                    intOpcion = 0;
                    strCedCliente = this.TxtBuscar.Text;
                    if (string.IsNullOrWhiteSpace(strCedCliente))
                    {
                        Mensaje("Código no válido");
                        TxtBuscar.Focus();
                        return;
                    }

                    Session["cedcliente"] = strCedCliente;
                    Response.Redirect("FrmRpteEstuMatri.aspx");

                    break;
                default:
                    Mensaje("Opción no válida");
                    break;
            }
        }

        protected void GrvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrvDatos.PageIndex = e.NewPageIndex;
            LlenarGridEstudiantes();
        }

        protected void ibtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                strCedCliente = this.TxtBuscar.Text.Trim();
                if (string.IsNullOrWhiteSpace(strCedCliente))
                {
                    Mensaje("Cédula no válida");
                    this.TxtBuscar.ReadOnly = false;
                    this.TxtBuscar.Focus();
                    return;
                }
                LlenarGridMatrciulaxCed();
            }
            catch (Exception ex)
            {
                Mensaje("Error--> " + ex.Message);
            }
           }
        }
    }
