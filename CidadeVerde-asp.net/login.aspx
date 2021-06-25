<%@ Page Title="Cidade Verde - Login" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="conteudo">
        <div class="alinhaDir" style="padding-top: 20px;">
            <asp:Image ID="Image1" runat="server" EnableViewState="false" ImageUrl="~/images/login.PNG" />
        </div>
        <div class="alinhaDir" style="padding-top: 46px;">
            <asp:Label ID="Label1" runat="server" EnableViewState="False" Font-Names="Arial, Verdana"
                Font-Bold="True" ForeColor="#099409" Font-Size="22px" Text="Área Restrita -  Digite o usuário e a senha para acesso."></asp:Label>
        </div>
        <div class="limpaDir">
        </div>
        <div style="margin-left: 0;">
            <hr />
        </div>
        <div id="colunasDados" style="margin-right: 100px;">
            <div id="esquerdaDados" style="float: left; width: 300px">
                <div class="alinhaDir" style="float: right; padding-top: 10px;">
                    <asp:Image ID="Image3" runat="server" EnableViewState="false" ImageUrl="~/images/cadeado.PNG" />
                </div>
            </div>
            <div id="direitaDados" style="float: left; width: 500px; padding-top: 70px;">
                <%--Usuario--%>
                <div class="nomecamposA">
                    Usuário:
                </div>
                <div class="txtcamposA">
                    <asp:TextBox ID="txtUsuario" CssClass="bordas" Width="300px" runat="server"></asp:TextBox>
                </div>
                <div class="limpaDir" style="padding-bottom: 10px;">
                </div>
                <%--Usuario--%>
                <div class="nomecamposA">
                    Senha:
                </div>
                <div class="txtcamposA">
                    <asp:TextBox ID="txtSenha" CssClass="bordas" Width="300px" TextMode="Password" runat="server"></asp:TextBox>
                </div>
                <div class="limpaDir" style="padding-bottom: 10px;">
                </div>
                <%--Botões Salvar e Cancelar--%>
                <div class="botoesCentro" style="padding-bottom: 10px; float: right; padding-right: 30px;">
                    <asp:Button ID="btEntrar" runat="server" CssClass="botoes" Text="Entrar" Width="150px"
                        OnClick="btEntrar_Click" />
                </div>
                <div class="limpaDir">
                </div>
                <div class="botoesCentro" style="width: 400px; margin-left: -40px;">
                    <asp:Panel ID="PanelErroLogin" runat="server" Visible="false">
                        <div class="alinhaDir">
                            <asp:Image ID="ImageErroLogin" runat="server" ImageUrl="~/images/exclamation32.png" />
                        </div>
                        <div style="padding-top: 14px;">
                            <asp:Label ID="LabelErroLogin" runat="server" Text="Login ou Senha Inválido(s)" ForeColor="#CC0000"
                                Font-Bold="true"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <div class="limpaDir">
                </div>
            </div>
        </div>
        <div class="limpaDir">
        </div>
    </div>
</asp:Content>
