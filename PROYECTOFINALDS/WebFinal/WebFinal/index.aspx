<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebFinal.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <link href='https://fonts.googleapis.com/css?family=Maven+Pro' rel='stylesheet' type='text/css'/>
    <link rel="stylesheet" href="Css/plus.css" />
    <link href="Css/alertify.min.css" rel="stylesheet" />
    <script src="js/alertify.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.4.3/angular.min.js"></script>
    <title>Bienvenido a CC</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style3 {
            color: #FFFFFF;
            font-weight: normal;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center" id="cuerpo">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <table align="center" class="auto-style1">
            <tr>
                <td style="width: 30%">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Imágenes/CAPACITANDO.png" />
                </td>
                <td><h1 class="auto-style3"><em><strong>Bienvenido a Cursos Capacitando</strong></em></h1>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style2">
                    <asp:Timer ID="Timer1" runat="server" Interval="1500" OnTick="Timer1_Tick">
                    </asp:Timer>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td><p>Powered By Capacitando 
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Imágenes/minic.png" Width="2%" />
                    ®</p>
                 <p>Todos los derechos reservados ©<br />2015</p>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
