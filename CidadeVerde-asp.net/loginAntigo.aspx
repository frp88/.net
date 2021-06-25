<%@ Page Language="C#" AutoEventWireup="true" CodeFile="loginAntigo.aspx.cs" Inherits="loginAntigo"
    Title="Cidade Verde - Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="images/icocv.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="admin/estiloAdmin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="geral">
            <div id="topo">
                <div style="padding-left: 150px; padding-top: 3px;">
                    <asp:HyperLink ID="HyperLinkSiteUsuario" runat="server" NavigateUrl="~/inicio.aspx"
                        ToolTip="Ir para a Página Inicial do Site do Usuário" Target="_blank" ImageUrl="~/images/siglaCV.PNG">CV</asp:HyperLink>
                </div>
                <div style="clear: left;">
                </div>
            </div>
            <div style="background-color: #099409; width: 977px; height: 27px; margin: 1px;">
            </div>
            <div class="conteudo">
                <div style="padding: 10px;">
                    <div class="alinhaDir">
                        <asp:Image ID="Image1" runat="server" EnableViewState="false" ImageUrl="~/images/login.PNG" />
                    </div>
                    <div class="alinhaDir" style="padding-top: 26px;">
                        <asp:Label ID="Label1" runat="server" EnableViewState="False" Font-Names="Arial, Verdana"
                            Font-Bold="True" ForeColor="#099409" Font-Size="22px" Text="Área Restrita -  Digite o usuário e a senha para acesso."></asp:Label>
                    </div>
                    <div class="limpaDir">
                    </div>
                    <div style="margin-left: -19px;">
                        <hr />
                    </div>
                    <div id="colunasDados">
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
                </div>
            </div>
            <div class="limpaDir">
            </div>
            <br />
        </div>
        <div id="rodape">
            Cidade Verde © Todos os direitos reservados | By: Fernando e Bruno</div>
    </div>
    </form>
</body>
</html>
