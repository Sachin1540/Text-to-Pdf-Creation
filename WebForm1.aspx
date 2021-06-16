<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Enter the text you want to change!!
       From <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        To <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:Button ID="btnGenerate" runat="server" Text="Button" OnClick="btnGenerate_Click" />
    <asp:Label runat="server" ID="lbl1"></asp:Label>
    </div>
    </form>
</body>
</html>
