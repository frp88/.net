<%@ Page Language="C#" MasterPageFile="~/admin/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="minhaConta.aspx.cs" Inherits="admin_minhaConta" Title="CV - Minha Conta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="conteudo">
        <%---- DIV DE DIALOGO ----%>
        <div id="dialog" title="Alerta" style="display: none;">
            <br />
            <div class="alinhaDir">
                <asp:Image ID="ImageDialog" runat="server" />
            </div>
            <div class="alinhaDir" style="margin-top: 8px;">
                <asp:Label ID="LabelDialog" runat="server" Text="" EnableViewState="false" Font-Size="13px"
                    Font-Bold="true"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
        </div>
        <%---- FIM DIV DE DIALOGO ----%>
        <div id="adminEspecie" style="margin-bottom: -10px;">
            <asp:Panel ID="PanelAdminEspecie" runat="server">
                <div class="alinhaDir">
                    <asp:Image ID="Image2" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />
                    <asp:Label ID="Label3" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                        Text="Alterar Dados Pessoais"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir">
                    <asp:Image ID="ImageInformacao" runat="server" EnableViewState="false" ToolTip="Informação no dados pessoais"
                        ImageUrl="~/images/information32.PNG" />
                </div>
                <div class="alinhaDir" style="padding-top: 14px;">
                    <asp:Label ID="LabelAjuda" runat="server" EnableViewState="False" ForeColor="#099409"
                        Font-Size="14px" Font-Bold="True" Text="Clique na aba 'Meus Dados' para alterar o os dados pessoais e na aba 'Alterar Senha' para alterar a senha"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div id="abas">
                    <%--TITULOS DE ABAS--%>
                    <ul>
                        <li>&nbsp;</li>
                        <li><a href="#abaDadosPessoais"><span>Meus Dados</span></a></li>
                        <li><a href="#abaAlterarSenha"><span>Alterar Senha</span></a></li>
                    </ul>
                    <%--ABA Dados Pessoais--%>
                    <div id="abaDadosPessoais">
                        <asp:Panel ID="PanelDadosPessoais" runat="server" Visible="true">
                            <div class="alinhaDir">
                                <asp:Image ID="Image3" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPeq.PNG" />
                                <asp:Label ID="Label2" runat="server" EnableViewState="False" Font-Size="12px" Font-Bold="True"
                                    Text="Meus Dados"></asp:Label>
                            </div>
                            <div class="limpaDir">
                            </div>
                            <br />
                            <%--Usuário--%>
                            <div class="nomecamposA">
                                Usuário:
                            </div>
                            <div class="txtcamposA">
                                <asp:Label ID="LabelUsuarioDadosPessoais" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="limpaDir">
                            </div>
                            <%--Nome Completo--%>
                            <div class="nomecamposA">
                                Nome:
                            </div>
                            <div class="txtcamposA">
                                <asp:TextBox ID="txtNome" runat="server" CssClass="bordas" Text="" Width="300px"></asp:TextBox>
                                *
                            </div>
                            <div class="limpaDir">
                            </div>
                            <%--CPF--%>
                            <div class="nomecamposA">
                                CPF:
                            </div>
                            <div class="txtcamposA">
                                <asp:TextBox ID="txtCPF" runat="server" CssClass="bordas" Text="" Width="300px"></asp:TextBox>
                                * (Somente Números)
                            </div>
                            <div class="limpaDir">
                            </div>
                            <%--Telefone--%>
                            <div class="nomecamposA">
                                Telefone:
                            </div>
                            <div class="txtcamposA">
                                <asp:TextBox ID="txtTelefone" runat="server" CssClass="bordas" Text="" Width="300px"></asp:TextBox>
                                *
                            </div>
                            <div class="limpaDir">
                            </div>
                            <%--Email--%>
                            <div class="nomecamposA">
                                E-mail:
                            </div>
                            <div class="txtcamposA">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="bordas" Text="" Width="300px"></asp:TextBox>
                                *
                            </div>
                            <div class="limpaDir">
                            </div>
                            <%--Botão Salvar e Cancelar Dados Pessoais--%>
                            <div class="centroAbas">
                                <asp:Button ID="btSalvarDadosPessoais" runat="server" CssClass="botoesAba" Text="Salvar"
                                    Width="100px" OnClick="btSalvarDadosPessoais_Click" />
                                <asp:Button ID="btCancelarDadosPessoais" runat="server" CssClass="botoesAba" Text="Cancelar"
                                    Width="100px" OnClick="btCancelarDadosPessoais_Click" />
                            </div>
                            <div class="limpaDir">
                            </div>
                            <div class="centroAbas">
                                <%--painel confirmação dados da árvore--%>
                                <asp:Panel ID="PanelConfirmaDadosArvore" runat="server" Width="400px" Visible="false">
                                    <div class="alinhaDir">
                                        <asp:Image ID="ImageConfirmaDadosPessoais" runat="server" ImageUrl="~/images/exclamation32.png" />
                                    </div>
                                    <div style="padding-top: 14px;">
                                        <asp:Label ID="LabelDadosPessoaisErro" runat="server" Text="" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
                                        <asp:Label ID="LabelDadosPessoaisOk" runat="server" Text="Dados Atualizados com Sucesso!"
                                            Font-Bold="true" ForeColor="#099409"></asp:Label>
                                    </div>
                                </asp:Panel>
                            </div>
                            <div class="limpaDir">
                            </div>
                        </asp:Panel>
                    </div>
                    <%--FIM Aba Dados Pessoais--%>
                    <%--ABA Alterar Senha--%>
                    <div id="abaAlterarSenha">
                        <asp:Panel ID="PanelAlterarSenha" runat="server" Visible="true">
                            <div class="alinhaDir">
                                <asp:Image ID="Image1" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPeq.PNG" />
                                <asp:Label ID="Label1" runat="server" EnableViewState="False" Font-Size="12px" Font-Bold="True"
                                    Text="Alterar Senha"></asp:Label>
                            </div>
                            <div class="limpaDir">
                            </div>
                            <br />
                            <%--Usuário--%>
                            <div class="nomecamposA">
                                Usuário:
                            </div>
                            <div class="txtcamposA">
                                <asp:Label ID="LabelUsuarioAlterarSenha" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="limpaDir">
                            </div>
                            <%--Senha Antiga--%>
                            <div class="nomecamposA">
                                Senha Antiga:
                            </div>
                            <div class="txtcamposA">
                                <asp:TextBox ID="txtSenhaAntiga" runat="server" CssClass="bordas" Text="" TextMode="Password"
                                    Width="300px"></asp:TextBox>
                                *
                            </div>
                            <div class="limpaDir">
                            </div>
                            <%--Nova Senha--%>
                            <div class="nomecamposA">
                                Nova Senha:
                            </div>
                            <div class="txtcamposA">
                                <asp:TextBox ID="txtNovaSenha" runat="server" CssClass="bordas" Text="" TextMode="Password"
                                    Width="300px"></asp:TextBox>
                                *
                            </div>
                            <div class="limpaDir">
                            </div>
                            <%--Confirmar Nova Senha--%>
                            <div class="nomecamposA">
                                Confirmar Senha:
                            </div>
                            <div class="txtcamposA">
                                <asp:TextBox ID="txtRepitaNovaSenha" runat="server" CssClass="bordas" Text="" TextMode="Password"
                                    Width="300px"></asp:TextBox>
                                *
                            </div>
                            <div class="limpaDir">
                            </div>
                            <%--Botão Salvar e Cancelar Dados Pessoais--%>
                            <div class="centroAbas">
                                <asp:Button ID="btSalvarSenha" runat="server" CssClass="botoesAba" Text="Salvar"
                                    Width="100px" OnClick="btSalvarSenha_Click" />
                                <asp:Button ID="btCancelarSenha" runat="server" CssClass="botoesAba" Text="Cancelar"
                                    Width="100px" OnClick="btCancelarSenha_Click" />
                            </div>
                            <div class="limpaDir">
                            </div>
                            <div class="centroAbas">
                                <%--painel confirmação dados da árvore--%>
                                <asp:Panel ID="PanelConfirmaSenha" runat="server" Width="400px" Visible="false">
                                    <div class="alinhaDir">
                                        <asp:Image ID="ImageConfirmaSenha" runat="server" ImageUrl="~/images/exclamation32.png" />
                                    </div>
                                    <div style="padding-top: 14px;">
                                        <asp:Label ID="LabelSenhaErro" runat="server" Text="" Font-Bold="true" ForeColor="#CC0000"></asp:Label>
                                        <asp:Label ID="LabelSenhaOK" runat="server" Text="Senha Atualizada com Sucesso!"
                                            Font-Bold="true" ForeColor="#099409"></asp:Label>
                                    </div>
                                </asp:Panel>
                            </div>
                            <div class="limpaDir">
                            </div>
                        </asp:Panel>
                    </div>
                    <%--FIM ABA Espécies NÃO RECOMENDADAS--%>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
