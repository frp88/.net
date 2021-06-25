<%@ Page Language="C#" MasterPageFile="~/admin/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="cadastroCEP.aspx.cs" Inherits="admin_cadastroCEP" Title="CV - Administrar CEPs" %>

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
        <asp:Panel ID="PanelVerCEPs" runat="server">
            <div class="alinhaDir">
                <asp:Image ID="Image1" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />
                <asp:Label ID="Label01" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                    Text="Administrar CEPs"></asp:Label>
            </div>
            <%--Botão PanelCadastrarArvore--%>
            <div class="botoesDireita">
                <asp:Button ID="btPanelCadCEP" runat="server" CssClass="botoes" Text="Cadastrar CEP"
                    OnClick="btPanelCadCEP_Click" />
            </div>
            <div class="limpaDir">
            </div>
            <div class="alinhaDir">
                <asp:Image ID="ImageInformacao" runat="server" EnableViewState="false" ToolTip="Informação no cadastro de CEP"
                    ImageUrl="~/images/information32.PNG" />
            </div>
            <div class="alinhaDir" style="padding-top: 14px;">
                <asp:Label ID="LabelAjuda" runat="server" EnableViewState="False" ForeColor="#099409"
                    Font-Size="14px" Font-Bold="True" Text="Para cadastrar um novo CEP clique no botão 'Cadastrar CEP' (Lado direito da tela)"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <div style="margin-left: -8px;">
                <hr />
            </div>
            <div class="alinhaDir" style="padding-top: 18px;">
                <asp:Image ID="Image2" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                <asp:Label ID="Label2" runat="server" EnableViewState="False" Font-Bold="True" Text="Filtrar CEP - Digite o CEP:"></asp:Label>
            </div>
            <div class="alinhaDir" style="padding-top: 17px; padding-left: 10px;">
                <asp:TextBox ID="txtFiltro" runat="server" Width="200px" CssClass="bordas"></asp:TextBox>
            </div>
            <div class="alinhaDir" style="padding-top: 16px; padding-left: 10px;">
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
                <asp:Label ID="Label4" runat="server" EnableViewState="False" Font-Bold="True" Text="Lista de CEPs"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <asp:GridView ID="GridViewCEPs" runat="server" BackColor="White" AutoGenerateColumns="False"
                BorderColor="#0D5600" Width="100%" HorizontalAlign="Center" CellPadding="2" AllowPaging="True"
                BorderStyle="Double" BorderWidth="3px" GridLines="Vertical" OnRowDataBound="GridViewCEPs_RowDataBound"
                OnPageIndexChanging="GridViewCEPs_PageIndexChanging" OnRowCommand="GridViewCEPs_RowCommand">
                <RowStyle BackColor="#ffffff" />
                <Columns>
                    <asp:BoundField DataField="sCEP" SortExpression="sCEP" HeaderText="CEP">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="sLogradouro" SortExpression="sLogradouro" HeaderText="sLogradouro">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="codTipoLogradouro" SortExpression="codTipoLogradouro"
                        HeaderText="codTipoLogradouro">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="descTipoLogradouro" SortExpression="descTipoLogradouro"
                        HeaderText="descTipoLogradouro">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Logradouro">
                        <ItemTemplate>
                            <asp:Label ID="LabelLogradouro" runat="server" Text=""></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="sBairro" SortExpression="sBairro" HeaderText="Bairro">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="sCidade" SortExpression="sCidade" HeaderText="Cidade">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="sEstado" SortExpression="sEstado" HeaderText="Estado">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40px" />
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Link" CommandName="editarCEP" Text='<img alt="" title="Editar CEP" src="../images/editar.png" style="border: 0px" />'>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </asp:ButtonField>
                    <asp:ButtonField ButtonType="Link" CommandName="excluirCEP" Text='<img alt="" title="Excluir CEP" src="../images/excluir.png" style="border: 0px" />'>
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
                                    Nenhum CEP Encontrado.
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
        <%--FIM Panel Ver CEPs--%>
        <%--Panel Cadastro / Edição de CEP--%>
        <asp:Panel ID="PanelCadCEP" runat="server" Visible="false">
            <div class="alinhaDir">
                <asp:Image ID="Image5" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                    Height="12px" Width="20px" />
                <asp:Label ID="LabelTitulo" runat="server" Font-Bold="True" Font-Size="14px" Text="Cadastra CEP"></asp:Label>
            </div>
            <%--Botão PanelCadastrarArvore--%>
            <div class="botoesDireita">
                <asp:Button ID="btVoltarTelaVerArvore" runat="server" CssClass="botoes" Text="Voltar"
                    Width="100px" OnClick="btVoltarTelaVerArvore_Click" />
            </div>
            <div class="limpaDir">
            </div>
            <%--sCEP--%>
            <div class="nomecampos">
                CEP:
            </div>
            <div class="txtcampos">
                <asp:TextBox ID="txtCEP" runat="server" CssClass="bordas" Width="300px"></asp:TextBox>
                * Somente Números
            </div>
            <div class="limpaDir">
            </div>
            <%--Tipo de Logradouro--%>
            <div class="nomecampos">
                Tipo de Logradouro:
            </div>
            <div class="txtcampos">
                <asp:DropDownList ID="ddlTipoLogradouro" runat="server" CssClass="bordas" Width="300"
                    DataTextField="descTipoLogradouro" DataValueField="codTipoLogradouro">
                </asp:DropDownList>
                *
            </div>
            <div class="limpaDir">
            </div>
            <%--Logradouro--%>
            <div class="nomecampos">
                Logradouro:
            </div>
            <div class="txtcampos">
                <asp:TextBox ID="txtLogradouro" runat="server" CssClass="bordas" Text="" Width="300px"></asp:TextBox>
                *
            </div>
            <div class="limpaDir">
            </div>
            <%--Bairro--%>
            <div class="nomecampos">
                Bairro:
            </div>
            <div class="txtcampos">
                <asp:TextBox ID="txtBairro" runat="server" CssClass="bordas" Text="" Width="300px"></asp:TextBox>
                *
            </div>
            <div class="limpaDir">
            </div>
            <%--Cidade--%>
            <div class="nomecampos">
                Cidade:
            </div>
            <div class="txtcampos">
                <asp:TextBox ID="txtCidade" runat="server" CssClass="bordas" Text="" Width="300px"></asp:TextBox>
                *
            </div>
            <div class="limpaDir">
            </div>
            <%--Estado--%>
            <div class="nomecampos">
                Estado:
            </div>
            <div class="txtcampos">
                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="bordas" Width="200">
                    <asp:ListItem Value="0">Selecione um estado</asp:ListItem>
                    <asp:ListItem Value="AC">Acre</asp:ListItem>
                    <asp:ListItem Value="AL">Alagoas</asp:ListItem>
                    <asp:ListItem Value="AP">Amapá</asp:ListItem>
                    <asp:ListItem Value="AM">Amazonas</asp:ListItem>
                    <asp:ListItem Value="BA">Bahia</asp:ListItem>
                    <asp:ListItem Value="CE">Ceará</asp:ListItem>
                    <asp:ListItem Value="DF">Distrito Federal</asp:ListItem>
                    <asp:ListItem Value="ES">Espírito Santo</asp:ListItem>
                    <asp:ListItem Value="GO">Goiás</asp:ListItem>
                    <asp:ListItem Value="MA">Maranhão</asp:ListItem>
                    <asp:ListItem Value="MT">Mato Grosso</asp:ListItem>
                    <asp:ListItem Value="MS">Mato Grosso do Sul</asp:ListItem>
                    <asp:ListItem Value="MG">Minas Gerais</asp:ListItem>
                    <asp:ListItem Value="PR">Paraná</asp:ListItem>
                    <asp:ListItem Value="PB">Paraíba</asp:ListItem>
                    <asp:ListItem Value="PA">Pará</asp:ListItem>
                    <asp:ListItem Value="PE">Pernambuco</asp:ListItem>
                    <asp:ListItem Value="PI">Piauí</asp:ListItem>
                    <asp:ListItem Value="RJ">Rio de Janeiro</asp:ListItem>
                    <asp:ListItem Value="RN">Rio Grande do Norte</asp:ListItem>
                    <asp:ListItem Value="RS">Rio Grande do Sul</asp:ListItem>
                    <asp:ListItem Value="RR">Roraima</asp:ListItem>
                    <asp:ListItem Value="RO">Rondônia</asp:ListItem>
                    <asp:ListItem Value="SC">Santa Catarina</asp:ListItem>
                    <asp:ListItem Value="SP">São Paulo</asp:ListItem>
                    <asp:ListItem Value="SE">Sergipe</asp:ListItem>
                    <asp:ListItem Value="TO">Tocantins</asp:ListItem>
                </asp:DropDownList>
                *
            </div>
            <div class="limpaDir">
            </div>
            <%--Botões Salvar e Cancelar--%>
            <div class="botoesCentro">
                <asp:Button ID="btSalvarCEP" runat="server" CssClass="botoes" Text="Salvar" OnClick="btSalvarCEP_Click" />
                <asp:Button ID="btCancelarCEP" runat="server" CssClass="botoes" Text="Cancelar" OnClick="btCancelarCEP_Click" />
            </div>
            <div class="limpaDir">
            </div>
            <div class="botoesCentro" style="width: 600px; margin-left: -20px;">
                <asp:Panel ID="PanelConfirmaCEP" runat="server" Visible="false">
                    <div class="alinhaDir">
                        <asp:Image ID="ImageConfirmaCEP" runat="server" ImageUrl="~/images/confirmation32.png" />
                    </div>
                    <div style="padding-top: 14px;">
                        <asp:Label ID="LabelConfirmaCEP" runat="server" Text="" ForeColor="#099409" Font-Bold="true"></asp:Label>
                        <asp:Label ID="LabelErroCEP" runat="server" Text="" ForeColor="#CC0000" Font-Bold="true"></asp:Label>
                    </div>
                </asp:Panel>
            </div>
            <div class="limpaDir">
            </div>
        </asp:Panel>
        <%--FIM PanelCadastrarCEP--%>
        <br />
    </div>
</asp:Content>
