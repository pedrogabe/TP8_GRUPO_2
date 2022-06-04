<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TP5_GRUPO_2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txt" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtParams" runat="server">parameters</asp:TextBox>
            <asp:Button OnClick="NonQuery" runat="server" Text="NonQuery"/>
            <asp:Button OnClick="Query" runat="server" Text="Query"/>
            <asp:Label ID="lblNonQuery" Text="NonQuery: " runat="server"></asp:Label>
            <asp:GridView ID="gv" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
