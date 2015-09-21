<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="WebFinal.frmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href='https://fonts.googleapis.com/css?family=Maven+Pro' rel='stylesheet' type='text/css'/>
    <link href="Css/main.css" rel="stylesheet" />
    <link href="Css/style.css" rel="stylesheet" />
    <link href="Css/alertify.min.css" rel="stylesheet" />
    <script src="js/alertify.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.4.3/angular.min.js"></script>
    <title>Login de Cursos Capacitando</title>
    <style type="text/css">
        body {
             font-family: 'Maven Pro', sans-serif;
             font-size:1em;
        }
        .bordesRedondeados {
    border-radius:5px;
}
        .auto-style1 {
            width: 80%;
            border: 3px solid #2196F3;
            border-radius:5px;
        }
        .auto-style2 {
            text-align: center;
        }
    </style>
    <script>



        function isNumberOrLetter(evt) {

            var charCode = (evt.which) ? evt.which : event.keyCode;

            if ((charCode > 65 && charCode < 91) || (charCode > 97 && charCode < 123) || (charCode > 47 && charCode < 58))
                return true;

            return false;
        }

  </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
    
        <table align="center" class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Imágenes/CAPACITANDO.png" Width="25%" />
                </td>
            </tr>
            <tr>
                <td>Usuario:</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtUsu"  ng-model="name" runat="server" Width="50%" CssClass="bordesRedondeados" Font-Italic="True" Font-Size="Large"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Clave:</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtClave"  runat="server" Width="50%" CssClass="bordesRedondeados" TextMode="Password" Font-Italic="True" Font-Overline="False" Font-Size="Large"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnInicar" runat="server" BackColor="#2196F3" Font-Bold="True" Font-Italic="True" Font-Names="Levenim MT" Font-Size="Larger" ForeColor="White" Text="Iniciar" Width="40%" CssClass="bordesRedondeados" OnClick="btnInicar_Click" />
                </td>
            </tr>
            <tr>
                <td>                        
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMsj" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                    <br />
                    <div ng-app="">
                    <h3>&nbsp;</h3>

                    </div>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
