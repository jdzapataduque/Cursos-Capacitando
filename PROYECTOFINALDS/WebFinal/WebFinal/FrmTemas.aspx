<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmTemas.aspx.cs" Inherits="WebFinal.Formulario_web14" %>
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
            <td class="auto-style9">Buscar:</td>
            <td>
                <asp:TextBox ID="txtBuscar" onkeypress="return isNumberOrLetter(event)" runat="server" Width="80%" CssClass="bordesRedondeados"></asp:TextBox>
                <asp:ImageButton ID="ibtnBuscar" runat="server" ImageUrl="~/Imágenes/buscar.png" Width="5%" OnClick="ibtnBuscar_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style8" colspan="2">
                <asp:Button ID="btnMostrar" runat="server" BackColor="#3366FF" CssClass="bordesRedondeados" Font-Bold="True" Font-Italic="True" Font-Names="Levenim MT" Font-Size="Large" ForeColor="White" Text="Mostrar Todos" OnClick="btnMostrar_Click" />
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
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7" colspan="2">
                <asp:Label ID="lblMsj" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Levenim MT" Font-Size="Large" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content5" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style5 {
            width: 100%;
            border: 1px solid #2196F3;
        }
        .auto-style6 {
        }
        .auto-style7 {
        }
        .auto-style8 {
    }
    .auto-style9 {
        width: 301px;
    }
    </style>
</asp:Content>

