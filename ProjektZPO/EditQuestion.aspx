<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditQuestion.aspx.cs" Inherits="ProjektZPO.EditQuestion" %>

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
            <p>Podaj pytanie:</p>
            <asp:TextBox ID="question" runat="server"></asp:TextBox>
            <p>Podaj odpowiedź a następnie, kliknij przycisk "Dodaj odpowiedź" aby dodać odpowiedź.<br />Kliknij "Usuń odpowiedź" aby usunąć zaznaczoną odpowiedź.</p>
            <br />
            <asp:TextBox ID="result" runat="server"></asp:TextBox>
            <asp:CheckBox ID="good" runat="server" Text="Poprawna"/>
            <asp:Button ID="add" runat="server" Text="Dodaj odpowiedź" OnClick="add_Click" />
            <asp:Button ID="del" runat="server" Text="Usuń odpowiedź" OnClick="del_Click" />
            <br />
            <p>Dostępne odpowiedzi: (Poprawna jest zaznaczona na zielono)</p>
            <asp:Button Text="Zmień status" ID="change" OnClick="change_Click" runat="server" /> <br />
            <asp:ListBox ID="odp" runat="server"></asp:ListBox>
            <asp:Button ID="back" runat="server" Text="Zamknij" OnClick="back_Click" />
        </div>
    </form>
</body>
</html>
