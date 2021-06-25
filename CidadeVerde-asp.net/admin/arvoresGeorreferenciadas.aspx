<%@ Page Language="C#" MasterPageFile="~/admin/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="arvoresGeorreferenciadas.aspx.cs" Inherits="admin_arvoresGeorreferenciadas"
    Title="CV - Árvores Georreferenciadas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="conteudo">
        <div class="texto">
            <p>
                O site <strong><font color="#056D00">Arvores Georreferenciadas</font></strong> foi
                desenvolvido no intuito de
            </p>
        </div>
        <asp:GridView ID="GridViewCoordenadas" runat="server" BackColor="White" AutoGenerateColumns="False"
            BorderColor="#0D5600" Width="100%" HorizontalAlign="Center" CellPadding="2" AllowPaging="True"
            BorderStyle="Double" BorderWidth="3px">
            <RowStyle BackColor="#ffffff" />
            <Columns>
                <asp:BoundField DataField="codArvore" SortExpression="codArvore" HeaderText="codArvore">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="gCoordenadas" SortExpression="gCoordenadas" HeaderText="gCoordenadas">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="latitude" SortExpression="latitude" HeaderText="latitude">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="longitude" SortExpression="longitude" HeaderText="longitude">
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
                                Nenhuma Coordenadas Encontrada.
                            </td>
                        </tr>
                    </tbody>
                </table>
            </EmptyDataTemplate>
            <AlternatingRowStyle BackColor="#d5d5d5" />
            <HeaderStyle BackColor="#099409" ForeColor="White" />
            <PagerStyle BackColor="#099409" ForeColor="White" />
        </asp:GridView>
        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Height="148px" Width="595px"></asp:TextBox>
        <br />
    </div>
</asp:Content>
