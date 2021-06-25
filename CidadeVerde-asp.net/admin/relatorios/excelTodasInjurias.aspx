<%@ Page Language="C#" AutoEventWireup="true" CodeFile="excelTodasInjurias.aspx.cs"
    Inherits="admin_relatorios_excelTodasInjurias" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridViewInjurias" runat="server" BackColor="White" AutoGenerateColumns="False"
            BorderColor="#0D5600" Width="100%" HorizontalAlign="Center" CellPadding="2" BorderStyle="Double"
            BorderWidth="3px" GridLines="Vertical" OnRowDataBound="GridViewInjurias_RowDataBound">
            <RowStyle BackColor="#ffffff" />
            <Columns>
                <asp:BoundField DataField="codInjuria" SortExpression="codInjuria" HeaderText="Cod Injúria">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="statusInjuria" SortExpression="statusInjuria" HeaderText="Situação da Injúria">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="sCodIdentificacao" SortExpression="sCodIdentificacao"
                    HeaderText="Árvore">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110px" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110px" />
                </asp:BoundField>
                <asp:BoundField DataField="descLocalAfetado" SortExpression="descLockalAfetado" HeaderText="Local Afetado">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="descIntensidade" SortExpression="descIntensidade" HeaderText="Intensidade">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="descInjuria" SortExpression="descInjuria" HeaderText="Descrição">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="dtCadInjuria" SortExpression="dtCadInjuria" DataFormatString="{0:d}"
                    HeaderText="Data Cadastro">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110px" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110px" />
                </asp:BoundField>
                <asp:BoundField DataField="dtInjuria" SortExpression="dtInjuria" DataFormatString="{0:d}"
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
                                Nenhuma Injúria Encontrada.
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
