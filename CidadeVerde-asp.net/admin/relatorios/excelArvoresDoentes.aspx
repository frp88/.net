<%@ Page Language="C#" AutoEventWireup="true" CodeFile="excelArvoresDoentes.aspx.cs"
    Inherits="admin_relatorios_excelArvoresDoentes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridViewArvores" runat="server" BackColor="White" AutoGenerateColumns="False"
            BorderColor="#0D5600" Width="100%" HorizontalAlign="Center" CellPadding="2" BorderStyle="Double"
            BorderWidth="3px" OnRowDataBound="GridViewArvores_RowDataBound" GridLines="Vertical">
            <RowStyle BackColor="#ffffff" />
            <Columns>
                <asp:BoundField DataField="codArvore" SortExpression="codArvore" HeaderText="codArvore">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="sCodIdentificacao" SortExpression="sCodIdentificacao"
                    HeaderText="Código de Identificação">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120" />
                </asp:BoundField>
                <asp:BoundField DataField="nStatus" SortExpression="nStatus" HeaderText="Situação">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="codEspecie" SortExpression="codEspecie" HeaderText="codEspecie">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="sNomeCientifico" SortExpression="sNomeCientifico" HeaderText="Nome Científico">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="dtLevantamento" SortExpression="dtLevantamento" DataFormatString="{0:d}"
                    HeaderText="Data Levantamento">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="140px" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="140px" />
                </asp:BoundField>
                <asp:BoundField DataField="nAltura" FooterText="nAltura" HeaderText="Altura" SortExpression="nAltura">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="nDiametroCopa" FooterText="nDiametroCopa" HeaderText="Diâmetro da Copa"
                    SortExpression="nDiametroCopa">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="125px" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="125px" />
                </asp:BoundField>
            </Columns>
            <EmptyDataTemplate>
                <table align="center" cellspacing="1" style="width: 100%">
                    <thead>
                    </thead>
                    <tbody>
                        <tr style="background-color: #ececeb; height: 13px; font-weight: bold; text-align: center;">
                            <td colspan="3">
                                Nenhuma Árvore Encontrada.
                            </td>
                        </tr>
                    </tbody>
                </table>
            </EmptyDataTemplate>
            <AlternatingRowStyle BackColor="#d5d5d5" />
            <HeaderStyle BackColor="#099409" ForeColor="White" />
            <PagerStyle BackColor="#099409" ForeColor="White" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
