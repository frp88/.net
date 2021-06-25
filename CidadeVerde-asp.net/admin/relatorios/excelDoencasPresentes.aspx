<%@ Page Language="C#" AutoEventWireup="true" CodeFile="excelDoencasPresentes.aspx.cs" Inherits="admin_relatorios_excelDoencasPresentes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="GridViewDoencas" runat="server" BackColor="White" AutoGenerateColumns="False"
            BorderColor="#0D5600" Width="100%" HorizontalAlign="Center" CellPadding="2" BorderStyle="Double"
            BorderWidth="3px" GridLines="Vertical" OnRowDataBound="GridViewDoencas_RowDataBound">
            <RowStyle BackColor="#ffffff" />
            <Columns>
                <asp:BoundField DataField="codDoenca" SortExpression="codDoenca" HeaderText="Cod Doença">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="statusDoenca" SortExpression="statusDoenca" HeaderText="Situação da Doença">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="sCodIdentificacao" SortExpression="sCodIdentificacao"
                    HeaderText="Árvore">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110px" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110px" />
                </asp:BoundField>
                <asp:BoundField DataField="descParasita" SortExpression="descParasita" HeaderText="Parasita / Grupo Parasita">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="descGrupoParasita" SortExpression="descGrupoParasita"
                    HeaderText="descGrupoParasita">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="descLocalAfetado" SortExpression="descLockalAfetado" HeaderText="Local Afetado">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="descIntensidade" SortExpression="descIntensidade" HeaderText="Intensidade">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="descDoenca" SortExpression="descDoenca" HeaderText="Descrição">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="dtCadDoenca" SortExpression="dtCadDoenca" DataFormatString="{0:d}"
                    HeaderText="Data Cadastro">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110px" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110px" />
                </asp:BoundField>
                <asp:BoundField DataField="dtDoenca" SortExpression="dtDoenca" DataFormatString="{0:d}"
                    HeaderText="Data Recuperação">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110px" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110px" />
                </asp:BoundField>
                <asp:BoundField DataField="codArvore" SortExpression="codArvore" HeaderText="codArvore">
                </asp:BoundField>
            </Columns>
            <EmptyDataTemplate>
                <table align="center" cellspacing="1" style="width: 100%">
                    <thead>
                    </thead>
                    <tbody>
                        <tr style="background-color: #ececeb; height: 13px; text-align: center;">
                            <td colspan="3">
                                Nenhuma Doença Encontrada.
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
