<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="WebFinal.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href='https://fonts.googleapis.com/css?family=Maven+Pro' 
 rel='stylesheet' type='text/css'/>
    <title>Error Inesperado</title>
    <style>
        body {
        background-color:#2196F3;
         font-family: 'Maven Pro', sans-serif;
              color:white;
        }
        h3 {
                          font-size:3em;
        }
        p {
            font-size:1em;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:Timer ID="TmrError" runat="server" Interval="1500" OnTick="TmrError_Tick">
            </asp:Timer>
        <br />
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imágenes/error.png" Width="25%" />
        <br />
    <h3>Error Inesperado, Inténtalo de Nuevo</h3>
       
        
         <p>C.Capacitando<asp:Image ID="Image2" runat="server" ImageUrl="~/Imágenes/minic.png" Width="2.5%" />
                        </p>
                        <p>2015</p>
    </div>
    </form>
</body>
</html>
