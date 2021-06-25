<%@ Page Language="C#" MasterPageFile="~/admin/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="cadastroUsuario.aspx.cs" Inherits="admin_cadastroUsuario" Title="CV - Administrar Usuários" %>

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
        <asp:Panel ID="PanelVerUsuarios" runat="server">
            <div class="alinhaDir">
                <asp:Image ID="Image1" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />
                <asp:Label ID="Label01" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                    Text="Administrar Usuários"></asp:Label>
            </div>
            <%--Botão PanelCadastrarArvore--%>
            <div class="botoesDireita">
                <asp:Button ID="btPanelCadUsuario" runat="server" CssClass="botoes" Text="Cadastrar Usuário"
                    OnClick="btPanelCadUsuario_Click" />
            </div>
            <div class="limpaDir">
            </div>
            <div class="alinhaDir">
                <asp:Image ID="ImageInformacao" runat="server" EnableViewState="false" ToolTip="Informação no cadastro de Usuários"
                    ImageUrl="~/images/information32.PNG" />
            </div>
            <div class="alinhaDir" style="padding-top: 14px;">
                <asp:Label ID="LabelAjuda" runat="server" EnableViewState="False" ForeColor="#099409"
                    Font-Size="14px" Font-Bold="True" Text="Para cadastrar um novo usuário clique no botão 'Cadastrar Usuário' (Lado direito da tela)"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <div style="margin-left: -8px;">
                <hr />
            </div>
            <div class="alinhaDir" style="padding-top: 18px;">
                <asp:Image ID="Image2" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                <asp:Label ID="Label2" runat="server" EnableViewState="False" Font-Bold="True" Text="Filtrar Usuário - Digite o Nome ou o CPF do Usuário"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <div class="alinhaDir" style="padding-top: 8px;">
                <asp:Label ID="Label3" runat="server" EnableViewState="False" Font-Bold="True" Text="Nome ou CPF:"></asp:Label>
                <asp:TextBox ID="txtFiltro" runat="server" Width="200px" CssClass="bordas"></asp:TextBox>
            </div>
            <div class="alinhaDir" style="padding-left: 10px; padding-top: 7px;">
                <asp:Button ID="btFiltrar" runat="server" Text="Filtrar" CssClass="botoes" Height="22px"
                    Width="80px" OnClick="btFiltrar_Click" />
            </div>
            <div class="limpaDir">
            </div>
            <div style="margin-left: -8px;">
                <hr />
            </div>
            <div class="alinhaDir" style="padding-top: 10px;">
                <asp:Image ID="Image3" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                <asp:Label ID="Label4" runat="server" EnableViewState="False" Font-Bold="True" Text="Lista de Usuários"></asp:Label>
            </div>
            <div class="alinhaDir" style="float: right; padding-right: 10px;">
                <asp:Image ID="Image8" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                <asp:Label ID="Label8" runat="server" EnableViewState="False" Font-Bold="True" Text="Legenda:"></asp:Label>
                <asp:Image ID="Image9" runat="server" EnableViewState="false" ImageUrl="~/images/userUsuario.PNG" />
                <asp:Label ID="Label9" runat="server" EnableViewState="False" Font-Bold="True" Text="Usuário"></asp:Label>
                <asp:Image ID="Image10" runat="server" EnableViewState="false" ImageUrl="~/images/userAdmin.PNG" />
                <asp:Label ID="Label10" runat="server" EnableViewState="False" Font-Bold="True" Text="Administrador"></asp:Label>
                <asp:Image ID="Image11" runat="server" EnableViewState="false" ImageUrl="~/images/userMaster.PNG" />
                <asp:Label ID="Label11" runat="server" EnableViewState="False" Font-Bold="True" Text="Master"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <asp:GridView ID="GridViewUsuarios" runat="server" BackColor="White" AutoGenerateColumns="False"
                BorderColor="#0D5600" Width="100%" HorizontalAlign="Center" CellPadding="2" AllowPaging="True"
                BorderStyle="Double" BorderWidth="3px" GridLines="Vertical" OnRowDataBound="GridViewUsuarios_RowDataBound"
                OnPageIndexChanging="GridViewUsuarios_PageIndexChanging" OnRowCommand="GridViewUsuarios_RowCommand">
                <RowStyle BackColor="#ffffff" />
                <Columns>
                    <asp:BoundField DataField="codUsuario" SortExpression="codUsuario" HeaderText="codUsuario">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nTipo" SortExpression="nTipo" HeaderText="nTipo">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Tipo">
                        <ItemTemplate>
                            <asp:Image ID="ImageTipoUsuario" runat="server" Height="16px" Width="16px" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="sCPF" SortExpression="sCPF" HeaderText="CPF">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="sNome" SortExpression="sNome" HeaderText="Nome">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="sLogin" SortExpression="sLogin" HeaderText="Login">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="sEmail" SortExpression="sEmail" HeaderText="E-mail">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="sTelefone" SortExpression="sTelefone" HeaderText="Telefone">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Link" CommandName="editarUsuario" Text='<img alt="" title="Editar Usuário" src="../images/editar.png" style="border: 0px" />'>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </asp:ButtonField>
                    <asp:ButtonField ButtonType="Link" CommandName="excluirUsuario" Text='<img alt="" title="Excluir Usuário" src="../images/excluir.png" style="border: 0px" />'>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </asp:ButtonField>
                </Columns>
                <EmptyDataTemplate>
                    <table align="center" cellspacing="1" style="width: 100%">
                        <thead>
                        </thead>
                        <tbody>
                            <tr style="background-color: #ececeb; height: 13px; text-align: center;">
                                <td colspan="3">
                                    Nenhum Usuário Encontrado.
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </EmptyDataTemplate>
                <AlternatingRowStyle BackColor="#d5d5d5" />
                <HeaderStyle BackColor="#099409" ForeColor="White" />
                <PagerStyle BackColor="#099409" ForeColor="White" />
            </asp:GridView>
        </asp:Panel>
        <%--FIM Panel Ver Usuarios--%>
        <%--Panel Cadastro / Edição de Usuário--%>
        <asp:Panel ID="PanelCadUsuario" runat="server" Visible="false">
            <div class="alinhaDir">
                <asp:Image ID="Image5" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                    Height="12px" Width="20px" />
                <asp:Label ID="LabelTitulo" runat="server" Font-Bold="True" Font-Size="14px" Text="Cadastra Usuário"></asp:Label>
            </div>
            <%--Botão btVoltarVerUsuarios--%>
            <div class="botoesDireita">
                <asp:Button ID="btReiniciarSenha" runat="server" CssClass="botoes" Text="Reiniciar Senha"
                    OnClick="btReiniciarSenha_Click" />
                <asp:Button ID="btVoltarVerUsuarios" runat="server" CssClass="botoes" Text="Voltar"
                    Width="100px" OnClick="btVoltarVerUsuarios_Click" />
                <br />
                <asp:Label ID="LabelMsgReiniciaSenha" runat="server" Text="Senha Reiniciada com Sucesso!"
                    Font-Bold="True" Visible="False"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <div class="alinhaDir">
                <asp:Label ID="LabelTituloLogin" runat="server" Font-Bold="True" Text="Login:" Visible="False"></asp:Label>
                <asp:Label ID="LabelLogin" runat="server" EnableViewState="False" Text=""></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <%--Login--%>
            <div class="nomecampos">
                <asp:Label ID="LabelCadLogin" runat="server" Text="Login:"></asp:Label>
            </div>
            <div class="txtcampos">
                <asp:TextBox ID="txtLogin" runat="server" CssClass="bordas" Text="" Width="200px"></asp:TextBox>
                *
            </div>
            <asp:Button ID="btVerificarDisponibilidade" runat="server" CssClass="botoes" Text="Verificar Disponibilidade"
                OnClick="btVerificarDisponibilidade_Click" />
            <asp:Label ID="LabelLoginCadastrado" runat="server" Text="Login já cadastrado" Font-Bold="true"
                ForeColor="#cc0000" Visible="false"></asp:Label>
            <asp:Label ID="LabelLoginDisponivel" runat="server" Text="Login disponível" Font-Bold="true"
                ForeColor="#099409" Visible="false"></asp:Label>
            <div class="limpaDir">
            </div>
            <%--Nome--%>
            <div class="nomecampos">
                Nome:
            </div>
            <div class="txtcampos">
                <asp:TextBox ID="txtNome" runat="server" CssClass="bordas" Width="300px"></asp:TextBox>
                *
            </div>
            <div class="limpaDir">
            </div>
            <%--CPF--%>
            <div class="nomecampos">
                CPF:
            </div>
            <div class="txtcampos">
                <asp:TextBox ID="txtCPF" runat="server" CssClass="bordas" MaxLength="11" Width="200px"></asp:TextBox>
                * (Apenas Números)
            </div>
            <div class="limpaDir">
            </div>
            <%--E-mail--%>
            <div class="nomecampos">
                E-mail:
            </div>
            <div class="txtcampos">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="bordas" Width="300px"></asp:TextBox>
                *
            </div>
            <div class="limpaDir">
            </div>
            <%--Telefone--%>
            <div class="nomecampos">
                Telefone:
            </div>
            <div class="txtcampos">
                <asp:TextBox ID="txtTelefone" runat="server" CssClass="bordas" Width="200px"></asp:TextBox>
                *
            </div>
            <div class="limpaDir">
            </div>
            <%--Tipo do Usuario--%>
            <div class="nomecampos">
                Tipo de Usuário:
            </div>
            <div class="txtcampos">
                <asp:DropDownList ID="ddlTipoUsuario" runat="server" CssClass="bordas" Width="200">
                    <asp:ListItem Selected="True" Value="0">Selecione o Tipo do Usuário</asp:ListItem>
                    <asp:ListItem Value="2">Administrador</asp:ListItem>
                    <asp:ListItem Value="3">Usuário</asp:ListItem>
                    <asp:ListItem Value="4">Desativado</asp:ListItem>
                </asp:DropDownList>
                *
            </div>
            <div class="limpaDir">
            </div>
            <%--Botões Salvar e Cancelar--%>
            <div class="botoesCentro">
                <asp:Button ID="btSalvarUsuario" runat="server" CssClass="botoes" Text="Salvar" OnClick="btSalvarUsuario_Click" />
                <asp:Button ID="btCancelarUsuario" runat="server" CssClass="botoes" Text="Cancelar"
                    OnClick="btCancelarUsuario_Click" />
            </div>
            <div class="limpaDir">
            </div>
            <div class="botoesCentro" style="width: 600px; margin-left: -20px;">
                <asp:Panel ID="PanelConfirmaUsuario" runat="server" Visible="false">
                    <div class="alinhaDir">
                        <asp:Image ID="ImageConfirmaUsuario" runat="server" ImageUrl="~/images/confirmation32.png" />
                    </div>
                    <div style="padding-top: 14px;">
                        <asp:Label ID="LabelConfirmaUsuario" runat="server" Text="" ForeColor="#099409" Font-Bold="true"></asp:Label>
                        <asp:Label ID="LabelErroUsuario" runat="server" Text="" ForeColor="#CC0000" Font-Bold="true"></asp:Label>
                    </div>
                </asp:Panel>
            </div>
            <div class="limpaDir">
            </div>
        </asp:Panel>
        <%--FIM PanelCadastrarUsuario--%>
        <br />
    </div>
</asp:Content>
