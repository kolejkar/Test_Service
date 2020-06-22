<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProjektZPO.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="Main.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Generator Testów</h1>
            <p><b>Oferujemy:</b><br />
               <ul>
                   <li>Tworzenie quizów dla uczniów i studentów. Wraz z auto oceną postępów</li>
                   <li>Losowe generowanie pytań dla każdego ucznia lub studenta.</li>
                   <li>Możliwość edycji pytań</li>
               </ul></p>
            <img src="like.jpg" alt="Like" />
        </div>
        <div id="Home">
        <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" TitleText="Logowanie do serwisu:"></asp:Login>
            <p class="rejestr">Jeśli nie posiadasz konta: <a href="Register.aspx">Rejestracja do serwisu</a></p>
        </div>
    </form>
</body>
</html>
