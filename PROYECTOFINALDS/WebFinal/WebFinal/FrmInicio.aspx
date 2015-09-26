<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmInicio.aspx.cs" Inherits="WebFinal.Formulario_web1" %>

<asp:Content ID="Content4" ContentPlaceHolderID="Cuerpo" runat="server">
 
    <link href="Css/alertify.min.css" rel="stylesheet" />
    <script src="js/alertify.min.js"></script>
    <table class="auto-style5">
        <tr>
            <td class="auto-style6"><strong><em>Bienvenido&nbsp;
                <asp:Label ID="lblUsu" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="#3399FF">

                </asp:Label>&nbsp;a Sistema de Matrículas CC</em></strong><br />
                </td>
        </tr>
    </table>
 
</asp:Content>
<asp:Content ID="Content5" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style5 {
            width: 100%;
        }
    .auto-style6 {
        color: #666666;
    }
    </style>
</asp:Content>

