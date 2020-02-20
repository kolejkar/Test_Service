<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pytanie.aspx.cs" Inherits="ProjektZPO.Pytanie1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="Main.css"/>
</head>
<body>
    <form id="form1" runat="server">
         <div style="align:top">
            <asp:Panel ID="menu" runat="server">
                <asp:Button ID="logoff" runat="server" Text="Wyloguj" style="position:fixed;right:10px" OnClick="logoff_Click"/>
            </asp:Panel>
        </div>
        <div id="Main" runat="server">
        </div>
    </form>
</body>
</html>
