<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teacher.aspx.cs" Inherits="ProjektZPO.Teacher" %>

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
        <div style="float:left;width:35%" ID="Przedmioty" runat="server">
            <p>Aby utworzyć nowy przedmiot wpisz nazwę przedmioty i kliknij przycisk "Utwórz przedmiot".</p>
            <asp:TextBox runat="server" ID="new_lesson"></asp:TextBox><asp:Button runat="server" ID="create_lesson" Text="Utwórz przedmiot" OnClick="create_lesson_Click" />
            <asp:Label ID="info" Text="<p>Wybierz przedmiot</p>" runat="server"/>
        </div>
        <div style="float:left;width:65%">
            <asp:Button ID="new" Text="Nowy" runat="server" OnClick="new_Click" />
            <asp:Button ID="edit" Text="Edytuj" runat="server" OnClick="edit_Click" />
            <asp:Button ID="delete" Text="Usuń" runat="server" OnClick="delete_Click" />
            <br />
            <asp:Button ID="PStudenci" Text="Studenci" runat="server" OnClick="Tab_Click" />
            <asp:Button ID="PZadania" Text="Pytania" runat="server" OnClick="Tab_Click" />
            <div ID="TabControl" runat="server">
                <asp:ListBox ID="lista" runat="server">
                </asp:ListBox>
            </div>
        </div>
    </form>
</body>
</html>
