<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReCaptchaEx.aspx.cs" Inherits="RecaptchaGoogleCSharpExample.ReCaptchaEx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src='https://www.google.com/recaptcha/api.js'></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            email<br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            Nome<br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            <div class="g-recaptcha" data-sitekey="6LfD8GAUAAAAAPhVmS4idohsJA6La6ZViWbm6Fqj"></div>
             <br />
            <br />
            <asp:Button ID="Btnvalida" runat="server" OnClick="Btnvalida_Click" style="height: 26px" Text="Valida" />
            <br />
            <asp:Label ID="LblEsito" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
