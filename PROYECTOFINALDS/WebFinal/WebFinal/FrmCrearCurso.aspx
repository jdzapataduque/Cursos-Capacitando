<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmCrearCurso.aspx.cs" Inherits="WebFinal.Formulario_web12" %>
<asp:Content ID="Content4" ContentPlaceHolderID="Cuerpo" runat="server">
    <script>



        function isNumberOrLetter(evt) {

            var charCode = (evt.which) ? evt.which : event.keyCode;

            if ((charCode > 65 && charCode < 91) || (charCode > 97 && charCode < 123) || (charCode > 47 && charCode < 58))
                return true;

            return false;
        }

  </script>
    <link href="Css/alertify.min.css" rel="stylesheet" />
    <script src="js/alertify.min.js"></script>
    <table align="center" class="auto-style5">
        <tr>
            <td colspan="2">Crear Curso</td>
        </tr>
        <tr>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style13">Buscar:</td>
            <td>
                <asp:TextBox ID="txtBuscar" onkeypress="return isNumberOrLetter(event)" runat="server" CssClass="bordesRedondeados" Width="80%"></asp:TextBox>
                <asp:ImageButton ID="ibtnBuscar" runat="server" ImageUrl="~/Imágenes/buscar.png" Width="5%" OnClick="ibtnBuscar_Click" Visible="False" />
            </td>
        </tr>
        <tr>
            <td class="auto-style6" colspan="2">
                <asp:GridView ID="grvDatos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="True" OnPageIndexChanging="grvDatos_PageIndexChanging" PageSize="2">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7" colspan="2">
                <asp:Panel ID="PnlDatosCurso" runat="server" GroupingText="Datos Curso">
                    <table align="center" class="auto-style5">
                        <tr>
                            <td class="auto-style14">Código Curso:</td>
                            <td>
                                <asp:TextBox ID="txtCodCurso" onkeypress="return isNumberOrLetter(event)" runat="server" Width="90%" CssClass="bordesRedondeados"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14">Nombre:</td>
                            <td>
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="bordesRedondeados" Width="90%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14">Número de Horas:</td>
                            <td>
                                <asp:TextBox ID="txtnHoras" onkeypress="return isNumberOrLetter(event)" runat="server" CssClass="bordesRedondeados" Width="90%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14">Número de Edición:</td>
                            <td>
                                <asp:TextBox ID="txtnEdicion"  runat="server" CssClass="bordesRedondeados" Width="90%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14">Valor:</td>
                            <td>
                                <asp:TextBox ID="txtValor" onkeypress="return isNumberOrLetter(event)" runat="server" CssClass="bordesRedondeados" Width="90%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14">Fecha de Inicio:</td>
                            <td>
                                <asp:Calendar ID="clFechaini" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="100%">
                                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                    <OtherMonthDayStyle ForeColor="#999999" />
                                    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                    <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                    <WeekendDayStyle BackColor="#CCCCFF" />
                                </asp:Calendar>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14">Temas:</td>
                            <td>
                                <asp:TextBox ID="txtTemas"  runat="server" CssClass="bordesRedondeados" TextMode="MultiLine" Width="95%"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8" colspan="2">
                <asp:Panel ID="PnlPrerrequisitos" runat="server" GroupingText="Prerrequisitos">
                    <asp:CheckBoxList ID="cblPrerre" runat="server" Width="98%" RepeatDirection="Horizontal" Font-Bold="True" Font-Italic="True" >
                    </asp:CheckBoxList>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style13">Número de Documento del Empleado</td>
            <td>
                <asp:TextBox ID="txtNroDocEmpl" onkeypress="return isNumberOrLetter(event)" runat="server" CssClass="bordesRedondeados" Width="95%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style12" colspan="2">
                <asp:Panel ID="pnlEmpleado" runat="server">
                    <asp:RadioButtonList ID="rbEmpleado" runat="server" Font-Bold="True" Font-Italic="True" RepeatDirection="Horizontal" Width="98%">
                    </asp:RadioButtonList>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="auto-style10" colspan="2">
                <asp:Menu ID="mnuOpciones" runat="server" BackColor="#2196F3" Font-Bold="True" Font-Italic="True" Font-Names="Levenim MT" ForeColor="White" Orientation="Horizontal" RenderingMode="Table" Width="100%" OnMenuItemClick="mnuOpciones_MenuItemClick">
                    <Items>
                        <asp:MenuItem Text="Grabar" Value="opcGrabar"></asp:MenuItem>
                        <asp:MenuItem Text="Buscar" Value="opcBuscar"></asp:MenuItem>
                        <asp:MenuItem Text="Modificar" Value="opcModificar"></asp:MenuItem>
                        <asp:MenuItem Text="Cancelar" Value="opcCancelar"></asp:MenuItem>
                        <asp:MenuItem Text="Imprimir" Value="opcImprimir"></asp:MenuItem>
                    </Items>
                </asp:Menu>
            </td>
        </tr>
        <tr>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style11" colspan="2">
                <asp:Label ID="LblMsj" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Levenim MT" Font-Size="Large" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content5" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style5 {
            width: 100%;
        }
        .auto-style6 {}
        .auto-style7 {
        }
        .auto-style8 {
        }
        .auto-style10 {
            height: 22px;
        }
        .auto-style11 {
        }
        .auto-style12 {
        }
        .auto-style13 {
            width: 403px;
        }
        .auto-style14 {
            width: 397px;
        }
    </style>
</asp:Content>

