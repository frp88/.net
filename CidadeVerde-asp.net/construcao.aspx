<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center; font-size: 48px; font-family: Comic Sans MS; margin-top: 20px;">
        <asp:Label ID="LabelTitulo" runat="server" Text="Cidade Verde" Font-Bold="True" Font-Overline="False"
            Font-Strikeout="False" Font-Underline="False" ForeColor="#009900"></asp:Label>
        <br />
        <asp:Image ID="Image1" ImageUrl="images/construcao.jpg" runat="server" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Página em Construção!" Font-Bold="True"
            Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="#CC0000"></asp:Label>
    </div>
    </form>
</body>
</html>
