<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="ProjektZPO.AddStudent" %>

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
        <div>
            <h2>Wybierz studenta aby dodac go do przedmiotu:</h2>
            <asp:ListBox ID="listbox" runat="server"></asp:ListBox>
            <asp:Button ID="add" Text="Dodaj" runat="server" OnClick="add_Click" />
            <asp:Button ID="back" Text="Zamknij" runat="server" OnClick="back_Click" />
        </div>
    </form>
</body>
</html>
