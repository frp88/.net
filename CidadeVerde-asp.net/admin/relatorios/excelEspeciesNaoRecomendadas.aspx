<%@ Page Language="C#" AutoEventWireup="true" CodeFile="excelEspeciesNaoRecomendadas.aspx.cs"
    Inherits="admin_relatorios_excelEspeciesNaoRecomendadas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridViewEspecies" runat="server" BackColor="White" AutoGenerateColumns="False"
            BorderColor="#0D5600" Width="100%" HorizontalAlign="Center" CellPadding="2" BorderStyle="Double"
            BorderWidth="3px" GridLines="Vertical" OnRowDataBound="GridViewEspecies_RowDataBound">
            <RowStyle BackColor="#ffffff" />
            <Columns>
                <asp:BoundField DataField="codEspecie" SortExpression="codEspecie" HeaderText="codEspecie">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="nRecArborizacaoUrbana" SortExpression="nRecArborizacaoUrbana"
                    HeaderText="Rec. Arbori. Urbana">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="sNomeCientifico" SortExpression="sNomeCientifico" HeaderText="Nome Científico">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="codGenero" SortExpression="codGenero" HeaderText="codGenero">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="descGenero" SortExpression="descGenero" HeaderText="Gênero">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="sClima" SortExpression="sClima" HeaderText="Clima">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="sEpocaFloracao" SortExpression="sEpocaFloracao" HeaderText="Época da Floração">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="descFormaCopa" SortExpression="descFormaCopa" HeaderText="Forma da Copa">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="nAlturaMedia" SortExpression="nAlturaMedia" HeaderText="Altura Média">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
            </Columns>
            <EmptyDataTemplate>
                <table align="center" cellspacing="1" style="width: 100%">
                    <thead>
                    </thead>
                    <tbody>
                        <tr style="background-color: #ececeb; height: 13px; font-weight: bold; text-align: center;">
                            <td colspan="3">
                                Nenhuma Espécie Encontrada.
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
