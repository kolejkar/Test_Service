<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ProjektZPO.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Rejestracja w serwisie</title>
    <link rel="stylesheet" type="text/css" href="Main.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Rejestracja użytkownika:</h1>
                <asp:Wizard ID="CreateUser" runat="server" ActiveStepIndex="0" FinishCompleteButtonText="Utwórz konto" OnFinishButtonClick="CreateUser_FinishButtonClick">
                    <WizardSteps>
                        <asp:WizardStep ID="Makeuser" runat="server" title="Tworzenie użykowinka">
                            <table>
                                <tr>
                                    <th>Tworzenie użytkownika:</th>
                                </tr>
                                <tr>
                                    <td>Imię:</td>
                                    <td>
                                        <asp:TextBox runat="server" ID="Name" MaxLength="50" />
                                        <asp:RequiredFieldValidator runat="server" ID="ValidateName" ControlToValidate="Name"
                                            ErrorMessage="Wymagane jest imię." Display="Dynamic">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Nazwisko:</td>
                                    <td>
                                        <asp:TextBox runat="server" ID="Surname" MaxLength="50" />
                                        <asp:RequiredFieldValidator runat="server" ID="ValidateSurname" ControlToValidate="Surname"
                                            ErrorMessage="Wymagane jest nazwisko." Display="Dynamic">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                <td>E-mail:</td>
                                    <td>
                                        <asp:TextBox runat="server" ID="Email" MaxLength="50" />
                                        <asp:RequiredFieldValidator runat="server" ID="ValidateEmail" ControlToValidate="Email"
                                            ErrorMessage="Wymagany jest email. Potrzebny do logowania." Display="Dynamic">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                <td>Hasło:</td>
                                    <td>
                                        <asp:TextBox runat="server" ID="Password" MaxLength="50" TextMode="Password" />
                                        <asp:RequiredFieldValidator runat="server" ID="ValidatePassword" ControlToValidate="Password"
                                            ErrorMessage="Wymagane jset hasło do logowania." Display="Dynamic">*</asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID = "ValidatePassword1" runat = "server" ControlToCompare = "Password" 
                                            ControlToValidate = "Confirm" Display = "Dynamic" ErrorMessage = "Hasła nie pasują do siebie."></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Powtórz hasło:</td>
                                    <td>
                                        <asp:TextBox runat="server" ID="Confirm" MaxLength="50" TextMode="Password" />
                                        <asp:RequiredFieldValidator runat="server" ID="ValidateConfirm" ControlToValidate="Confirm"
                                            ErrorMessage="Prosimy o powtórzenie hasła." Display="Dynamic">*</asp:RequiredFieldValidator>
                                    <tr>
                                        <td>Numer indeksu:</td>
                                        <td>
                                            <asp:TextBox runat="server" ID="Indeks" MaxLength="5" />
                                            <asp:RequiredFieldValidator runat="server" ID="ValidateIndeks1" ControlToValidate="Indeks"
                                            ErrorMessage="Prosimy o wpisanie numeru indeksu." Display="Dynamic">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="ValidateIndeks" runat="server"
                                                ControlToValidate="Indeks" Display="Dynamic" ErrorMessage="Wymagany jest numer indeksu." ValidationExpression="[0-9]{5}"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                </tr>
                             </table>
                        </asp:WizardStep>
                        <asp:WizardStep ID="Complete" runat="server" StepType="Complete">
                            <p>Konto zostało utworzone pomyśnie.</p>
                            <a href="Login.aspx">Powrót do strony głównej</a>
                        </asp:WizardStep>
                    </WizardSteps>
                </asp:Wizard>
        </div>
    </form>
</body>
</html>
