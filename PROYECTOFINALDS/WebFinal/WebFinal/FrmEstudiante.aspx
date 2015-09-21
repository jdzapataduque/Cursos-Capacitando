<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmEstudiante.aspx.cs" Inherits="WebFinal.Formulario_web11" %>
<asp:Content ID="Content4" ContentPlaceHolderID="Cuerpo" runat="server">
  <script>


      function isNumberOrLetter(evt) {

          var charCode = (evt.which) ? evt.which : event.keyCode;

          if ((charCode > 65 && charCode < 91) || (charCode > 97 && charCode < 123) || (charCode > 47 && charCode < 58))
              return true;

          return false;
      }

  </script>
    <table align="center" class="auto-style5">
    <tr>
        <td colspan="2"><strong><em>Nuevo Estudiante</em></strong></td>
    </tr>
    <tr>
        <td class="auto-style13">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:DropDownList ID="ddlCursoInscribir" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Levenim MT" Font-Size="Large" Height="80%" Width="70%">
                <asp:ListItem Value="opcSeleccionarCurso">Seleccionar Curso</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style13">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Panel ID="PnlCliente" runat="server" CssClass="espacioderecho" GroupingText="Cliente" Width="95%">
                <table align="center" class="auto-style6">
                    <tr>
                        <td class="auto-style7">Cédula:</td>
                        <td>
                            <asp:TextBox ID="TxtCedula" onkeypress="return isNumberOrLetter(event)" runat="server" CssClass="bordesRedondeados" Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7">Nombre Completo:</td>
                        <td>
                            <asp:TextBox ID="TxtNombreCompl" runat="server" CssClass="bordesRedondeados" Width="99%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7">Edad:</td>
                        <td>
                            <asp:TextBox ID="TxtEdad" onkeypress="return isNumberOrLetter(event)" runat="server" CssClass="bordesRedondeados" style="text-align: left" Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7">Teléfono:</td>
                        <td>
                            <asp:TextBox ID="txtTel" onkeypress="return isNumberOrLetter(event)" runat="server" CssClass="bordesRedondeados" Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7">Celular:</td>
                        <td>
                            <asp:TextBox ID="TxtCel" onkeypress="return isNumberOrLetter(event)" runat="server" CssClass="bordesRedondeados" style="text-align: left" Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7">Dirección</td>
                        <td>
                            <asp:TextBox ID="TxtDir"  runat="server" CssClass="bordesRedondeados" Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7">Código Matrícula:</td>
                        <td>
                            <asp:TextBox ID="txtCodMatri" onkeypress="return isNumberOrLetter(event)" runat="server" CssClass="bordesRedondeados" Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td class="auto-style13">
            <asp:Button ID="BtnInscribir" runat="server" BackColor="#2196F3" Font-Bold="True" Font-Italic="True" Font-Names="Levenim MT" Font-Size="Large" ForeColor="White" Text="Inscribir" Width="80%" OnClick="BtnInscribir_Click" CssClass="bordesRedondeados" />
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style13">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style13">Buscar:</td>
        <td>
            <asp:TextBox ID="TxtBuscar" onkeypress="return isNumberOrLetter(event)" runat="server" CssClass="bordesRedondeados" Width="80%"></asp:TextBox>
            <asp:ImageButton ID="ibtnBuscar" runat="server" CssClass="espacioderecho" ImageUrl="~/Imágenes/buscar.png" Width="5%" OnClick="ibtnBuscar_Click" />
        </td>
    </tr>
    <tr>
        <td class="auto-style8" colspan="2">
            <asp:GridView ID="GrvDatos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="True" PageSize="2" OnPageIndexChanging="GrvDatos_PageIndexChanging">
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
        <td class="auto-style9" colspan="2">
            <asp:Panel ID="pnlEmpleado" runat="server" GroupingText="Empleado">
                <asp:RadioButtonList ID="rblEmpleado" runat="server" CssClass="espacioderecho" Font-Bold="True" Font-Italic="True" Font-Names="Levenim MT" Width="90%" RepeatDirection="Horizontal">
                </asp:RadioButtonList>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td class="auto-style13">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style10" colspan="2">
            <asp:Panel ID="PnlPago" runat="server" CssClass="espacioderecho" GroupingText="Forma de Pago">
                <asp:RadioButtonList ID="rblFormaPago" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Levenim MT" Width="90%" RepeatDirection="Horizontal">
                </asp:RadioButtonList>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td class="auto-style11" colspan="2">
            <asp:Menu ID="MnuOpciones" runat="server" BackColor="#2196F3" CssClass="espacioderecho" DynamicHorizontalOffset="2" Font-Bold="True" Font-Italic="True" Font-Names="Levenim MT" Font-Size="1em" ForeColor="White" Orientation="Horizontal" RenderingMode="Table" StaticSubMenuIndent="10px" Width="100%" OnMenuItemClick="MnuOpciones_MenuItemClick">
                <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <DynamicMenuStyle BackColor="#E3EAEB" />
                <DynamicSelectedStyle BackColor="#1C5E55" />
                <Items>
                    <asp:MenuItem Text="Grabar" Value="opcGrabar"></asp:MenuItem>
                    <asp:MenuItem Text="Modificar" Value="opcModificar"></asp:MenuItem>
                    <asp:MenuItem Text="Imprimir" Value="opcImprimir"></asp:MenuItem>
                    <asp:MenuItem Text="Cancelar" Value="opcCancelar"></asp:MenuItem>
                </Items>
                <StaticHoverStyle BackColor="#666666" ForeColor="White" />
                <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <StaticSelectedStyle BackColor="#1C5E55" />
            </asp:Menu>
        </td>
    </tr>
    <tr>
        <td class="auto-style13">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style12" colspan="2">
            <asp:Label ID="LblMsj" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Large" ForeColor="Red"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>
<asp:Content ID="Content5" runat="server" contentplaceholderid="head">
    <style type="text/css">
    .auto-style5 {
        width: 100%;
        border: 2px solid #2196F3;
    }
        .auto-style6 {
            width: 100%;
        }
        .auto-style7 {
            width: 285px;
        }
        .auto-style8 {
        }
        .auto-style9 {
        }
        .auto-style10 {
        }
        .auto-style11 {
        }
        .auto-style12 {
        }
        .auto-style13 {
            width: 303px;
        }
    </style>
</asp:Content>

