<%@ Page Language="C#" MasterPageFile="~/admin/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="cadastroDoencas.aspx.cs" Inherits="admin_cadastroDoencas" Title="CV - Administrar Doenças das Árvore" %>

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
        <asp:Panel ID="PanelVerArvore" runat="server">
            <div class="alinhaDir">
                <asp:Image ID="Image1" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />
                <asp:Label ID="Label01" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                    Text="Administrar Doenças das Árvores"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <div class="alinhaDir">
                <asp:Image ID="ImageInformacao" runat="server" EnableViewState="false" ToolTip="Informação no cadastro de Doenças"
                    ImageUrl="~/images/information32.PNG" />
            </div>
            <div class="alinhaDir" style="padding-top: 14px;">
                <asp:Label ID="LabelAjuda" runat="server" EnableViewState="False" ForeColor="#099409"
                    Font-Size="14px" Font-Bold="True" Text="Para cadastrar uma doença clique no botão 'Ver Doenças' (Lado direito da tabela Lista de Árvores)"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <div style="margin-left: -8px;">
                <hr />
            </div>
            <div class="alinhaDir" style="padding-top: 18px;">
                <asp:Image ID="Image2" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                <asp:Label ID="Label2" runat="server" EnableViewState="False" Font-Bold="True" Text="Filtrar Árvores - Selecione uma Situação da Árvore ou digite o Código da Árvore"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <div class="alinhaDir" style="margin-top: 5px; margin-right: -10px;">
                <asp:Label ID="Label56" runat="server" EnableViewState="False" Font-Bold="True" Text="Situação:"></asp:Label>
            </div>
            <div class="alinhaDir">
                <asp:RadioButtonList ID="rbSituacaoArvore" runat="server" AutoPostBack="True" RepeatColumns="5"
                    OnSelectedIndexChanged="rbSituacaoArvore_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="0">Todas</asp:ListItem>
                    <asp:ListItem Value="1">Saudável</asp:ListItem>
                    <asp:ListItem Value="2">Doente</asp:ListItem>
                    <asp:ListItem Value="3">Ferida</asp:ListItem>
                    <asp:ListItem Value="4">Morta</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="alinhaDir" style="padding-left: 10px; padding-top: 8px;">
                <asp:Label ID="Label3" runat="server" EnableViewState="False" Font-Bold="True" Text="Ou Código:"></asp:Label>
                <asp:TextBox ID="txtCodigoIdentArvore" runat="server" CssClass="bordas"></asp:TextBox>
            </div>
            <div class="alinhaDir" style="padding-left: 10px; padding-top: 7px;">
                <asp:Button ID="btFiltrar" runat="server" Text="Filtrar" CssClass="botoes" Height="22px"
                    Width="80px" OnClick="btFiltrar_Click" />
            </div>
            <div class="botoesDireita" style="padding-top: 8px;">
                <asp:Label ID="Label14" runat="server" EnableViewState="False" Font-Bold="True" Text="Mostrar Árvores:"></asp:Label>
                <asp:DropDownList ID="ddlMostrarArvore" runat="server" CssClass="bordas" Width="60"
                    AutoPostBack="True" OnSelectedIndexChanged="ddlMostrarArvore_SelectedIndexChanged">
                    <asp:ListItem Value="10">&nbsp;10</asp:ListItem>
                    <asp:ListItem Value="20">&nbsp;20</asp:ListItem>
                    <asp:ListItem Value="50">&nbsp;50</asp:ListItem>
                    <asp:ListItem Value="100">&nbsp;100</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="limpaDir">
            </div>
            <div style="margin-left: -8px;">
                <hr />
            </div>
            <div class="alinhaDir" style="padding-top: 10px;">
                <asp:Image ID="Image3" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                <asp:Label ID="Label4" runat="server" EnableViewState="False" Font-Bold="True" Text="Lista de Árvores"></asp:Label>
            </div>
            <div class="alinhaDir" style="float: right; padding-right: 10px;">
                <asp:Image ID="Image8" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                <asp:Label ID="Label7" runat="server" EnableViewState="False" Font-Bold="True" Text="Legenda:"></asp:Label>
                <asp:Image ID="Image9" runat="server" EnableViewState="false" ImageUrl="~/images/arvoreSaudavel.PNG" />
                <asp:Label ID="Label9" runat="server" EnableViewState="False" Font-Bold="True" Text="Árvore Saudável"></asp:Label>
                <asp:Image ID="Image10" runat="server" EnableViewState="false" ImageUrl="~/images/arvoreDoente.PNG" />
                <asp:Label ID="Label10" runat="server" EnableViewState="False" Font-Bold="True" Text="Árvore Doente"></asp:Label>
                <asp:Image ID="Image11" runat="server" EnableViewState="false" ImageUrl="~/images/arvoreFerida.PNG" />
                <asp:Label ID="Label11" runat="server" EnableViewState="False" Font-Bold="True" Text="Árvore Ferida"></asp:Label>
                <asp:Image ID="Image6" runat="server" EnableViewState="false" ImageUrl="~/images/arvoreMorta.PNG" />
                <asp:Label ID="Label12" runat="server" EnableViewState="False" Font-Bold="True" Text="Árvore Morta"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <asp:GridView ID="GridViewArvores" runat="server" BackColor="White" AutoGenerateColumns="False"
                BorderColor="#0D5600" Width="100%" HorizontalAlign="Center" CellPadding="2" AllowPaging="True"
                BorderStyle="Double" BorderWidth="3px" OnRowDataBound="GridViewArvores_RowDataBound"
                OnPageIndexChanging="GridViewArvores_PageIndexChanging" GridLines="Vertical"
                OnRowCommand="GridViewArvores_RowCommand" AllowSorting="True" OnSorting="GridViewArvores_Sorting">
                <RowStyle BackColor="#ffffff" />
                <Columns>
                    <asp:BoundField DataField="codArvore" SortExpression="codArvore" HeaderText="codArvore">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nStatus" SortExpression="nStatus" HeaderText="nStatus">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nStatus" SortExpression="nStatus" HeaderText="Situação">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="codEspecie" SortExpression="codEspecie" HeaderText="codEspecie">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="sCodIdentificacao" SortExpression="sCodIdentificacao"
                        HeaderText="Código Identificação">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="sNomeCientifico" SortExpression="sNomeCientifico" HeaderText="Nome Científico">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="dtPlantio" SortExpression="dtPlantio" DataFormatString="{0:d}"
                        HeaderText="Data Plantio">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="130px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="130px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="dtLevantamento" SortExpression="dtLevantamento" DataFormatString="{0:d}"
                        HeaderText="Data Levantamento">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="130px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="130px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nAltura" FooterText="nAltura" HeaderText="Altura" SortExpression="nAltura">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nDiametroCopa" FooterText="nDiametroCopa" HeaderText="Diâmetro Copa"
                        SortExpression="nDiametroCopa">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Link" CommandName="verDoencas" Text='<img alt="" title="Clique aqui para ver as doenças da Árvore" src="../images/detalhes.png" style="border: 0px" />'>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </asp:ButtonField>
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
                <HeaderStyle CssClass="header" />
                <AlternatingRowStyle BackColor="#d5d5d5" />
                <PagerStyle BackColor="#099409" ForeColor="White" />
            </asp:GridView>
        </asp:Panel>
        <%--FIM Panel Ver Arvore--%>
        <%--Panel Doenças de uma Árvore--%>
        <asp:Panel ID="PanelDoencasArvore" runat="server" Visible="false">
            <div class="alinhaDir">
                <asp:Image ID="Image4" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                    Height="12px" Width="20px" />
                <asp:Label ID="Label5" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                    Text="Histórico de Doenças da Árvore"></asp:Label>
            </div>
            <%--Botão btPanelCadastrarDoenca e btVoltarTelaVerArvore--%>
            <div class="botoesDireita">
                <asp:Button ID="btPanelCadastrarDoenca" runat="server" CssClass="botoes" Text="Cadastrar nova doença"
                    OnClick="btPanelCadastrarDoenca_Click" />
                <asp:Button ID="btVoltarTelaVerArvore" runat="server" CssClass="botoes" Text="Voltar"
                    Width="100px" OnClick="btVoltarTelaVerArvore_Click" />
            </div>
            <div class="limpaDir">
            </div>
            <div class="alinhaDir">
                <asp:Label ID="LabelTituloCodigoArvore" runat="server" EnableViewState="False" Font-Bold="True"
                    Text="Código da Árvore:"></asp:Label>
                <asp:Label ID="LabelCodigoArvore" runat="server" EnableViewState="false" Text=""></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <asp:GridView ID="GridViewDoencasArvore" runat="server" BackColor="White" AutoGenerateColumns="False"
                BorderColor="#0D5600" Width="100%" HorizontalAlign="Center" CellPadding="2" AllowPaging="True"
                BorderStyle="Double" BorderWidth="3px" GridLines="Vertical" OnRowDataBound="GridViewDoencasArvore_RowDataBound"
                OnRowCommand="GridViewDoencasArvore_RowCommand">
                <RowStyle BackColor="#ffffff" />
                <Columns>
                    <asp:BoundField DataField="codDoenca" SortExpression="codDoenca" HeaderText="codDoenca">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="statusDoenca" SortExpression="statusDoenca" HeaderText="statusDoenca">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Image ID="ImageStatusArvore" runat="server" Height="16px" Width="16px" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="descParasita" SortExpression="descParasita" HeaderText="descParasita">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="descGrupoParasita" SortExpression="descGrupoParasita"
                        HeaderText="descGrupoParasita">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Parasitas">
                        <ItemTemplate>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                    </asp:TemplateField>
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
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="dtDoenca" SortExpression="dtDoenca" DataFormatString="{0:d}"
                        HeaderText="Data Recuperação">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Link" CommandName="editarDoenca" Text='<img alt="" title="Editar Doença" src="../images/editar.png" style="border: 0px" />'>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </asp:ButtonField>
                    <asp:ButtonField ButtonType="Link" CommandName="excluirDoenca" Text='<img alt="" title="Excluir Doença" src="../images/excluir.png" style="border: 0px" />'>
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
        </asp:Panel>
        <%--FIM Panel Doenças de uma Árvore--%>
        <asp:Panel ID="PanelCadastrarDoenca" runat="server" Visible="false">
            <div class="alinhaDir">
                <asp:Image ID="Image5" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                    Height="12px" Width="20px" />
                <asp:Label ID="Label6" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                    Text="Cadastra / Atualiza Doenças"></asp:Label>
            </div>
            <%--Botão btVoltarDoencasArvore--%>
            <div class="botoesDireita">
                <asp:Button ID="btVoltarDoencasArvore" runat="server" CssClass="botoes" Text="Voltar"
                    Width="100px" OnClick="btVoltarDoencasArvore_Click" />
            </div>
            <div class="limpaDir">
            </div>
            <div class="alinhaDir">
                <asp:Label ID="LabelTituloCodArv" runat="server" EnableViewState="False" Font-Bold="True"
                    Text="Código da Árvore:"></asp:Label>
                <asp:Label ID="LabelCodArvore" runat="server" EnableViewState="False" Text=""></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <div class="nomecampos" style="margin-top: 8px; margin-right: -10px;">
                <asp:Label ID="Label8" runat="server" EnableViewState="False" Font-Bold="True" Text="Parasitas ou Grupo Parasitas:"></asp:Label>
            </div>
            <div class="txtcampos">
                <asp:RadioButtonList ID="rbTipoParasitas" runat="server" RepeatColumns="2" OnSelectedIndexChanged="rbTipoParasitas_SelectedIndexChanged"
                    AutoPostBack="True">
                    <asp:ListItem Value="1">Parasitas</asp:ListItem>
                    <asp:ListItem Value="2">Grupo de Parasitas</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="limpaDir">
            </div>
            <%--Panel Parasitas--%>
            <asp:Panel ID="PanelParasitas" runat="server" Visible="false">
                <div class="nomecampos">
                    Parasitas:
                </div>
                <div class="txtcampos">
                    <asp:DropDownList ID="ddlParasitas" runat="server" CssClass="bordas" Width="250"
                        DataTextField="descParasita" DataValueField="codParasita">
                    </asp:DropDownList>
                    *
                </div>
                <div class="limpaDir">
                </div>
            </asp:Panel>
            <%--Panel Parasitas--%>
            <asp:Panel ID="PanelGrupoParasitas" runat="server" Visible="false">
                <div class="nomecampos">
                    Grupo de Parasitas:
                </div>
                <div class="txtcampos">
                    <asp:DropDownList ID="ddlGrupoParasitas" runat="server" CssClass="bordas" Width="250"
                        DataTextField="descGrupoParasita" DataValueField="codGrupoParasita">
                    </asp:DropDownList>
                    *
                </div>
                <div class="limpaDir">
                </div>
            </asp:Panel>
            <%--Local Afetado--%>
            <div class="nomecampos">
                Local Afetado:
            </div>
            <div class="txtcampos">
                <asp:DropDownList ID="ddlLocalAfetado" runat="server" CssClass="bordas" Width="250"
                    DataTextField="descLocalAfetado" DataValueField="codLocalAfetado">
                </asp:DropDownList>
                *
            </div>
            <div class="limpaDir">
            </div>
            <%--Intensidade--%>
            <div class="nomecampos">
                Intensidade:
            </div>
            <div class="txtcampos">
                <asp:DropDownList ID="ddlIntensidade" runat="server" CssClass="bordas" Width="250"
                    DataTextField="descIntensidade" DataValueField="codIntensidade">
                </asp:DropDownList>
                *
            </div>
            <div class="limpaDir">
            </div>
            <%--Descrição da Doença--%>
            <div class="nomecampos">
                Descrição:
            </div>
            <div class="txtcampos">
                <asp:TextBox ID="txtDescDoenca" runat="server" Height="70px" TextMode="MultiLine"
                    Width="300px" CssClass="bordas" Style="font-family: Arial; font-size: 13px"></asp:TextBox>
                *
            </div>
            <div class="limpaDir">
            </div>
            <%--Data de Recuperação--%>
            <div class="nomecampos">
                Data de Recuperação:
            </div>
            <div class="txtcampos" style="float: left;">
                <asp:TextBox ID="txtDataDoenca" MaxLength="10" runat="server" CssClass="calendario"
                    Width="150px"></asp:TextBox>
            </div>
            <div class="txtcampos" style="float: left; margin-top: -1px; margin-left: -8px;">
                <asp:Image ID="ImageCalendario" runat="server" AlternateText="Calendário" ImageUrl="~/images/calendar.png"
                    ToolTip="Clique no campo ao lado para visualizar o calendário." />
            </div>
            <div class="limpaDir">
            </div>
            <%--Status da Arvore--%>
            <div class="nomecampos">
                Situação da Doença:
            </div>
            <div class="txtcampos">
                <asp:DropDownList ID="ddlStatusDoenca" runat="server" CssClass="bordas" Width="200"
                    AutoPostBack="True">
                    <asp:ListItem Selected="True" Value="1">Presente</asp:ListItem>
                    <asp:ListItem Value="2">Recuperada</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="limpaDir">
            </div>
            <%--Botões Salvar e Cancelar--%>
            <div class="botoesCentro">
                <asp:Button ID="btSalvarDoenca" runat="server" CssClass="botoes" Text="Salvar" OnClick="btSalvarDoenca_Click" />
                <asp:Button ID="btCancelarDoenca" runat="server" CssClass="botoes" Text="Cancelar"
                    OnClick="btCancelarDoenca_Click" />
            </div>
            <div class="limpaDir">
            </div>
            <div class="centroAbas">
                <asp:Panel ID="PanelConfirmaDoenca" runat="server" Visible="false" Width="500px">
                    <div class="alinhaDir">
                        <asp:Image ID="ImageConfirma" runat="server" ImageUrl="~/images/confirmation32.png" />
                    </div>
                    <div style="padding-top: 14px;">
                        <asp:Label ID="LabelErroDoenca" runat="server" Text="" ForeColor="#CC0000" Font-Bold="true"></asp:Label>
                        <asp:Label ID="LabelConfirmaDoenca" runat="server" Text="" ForeColor="#099409" Font-Bold="true"></asp:Label>
                    </div>
                </asp:Panel>
            </div>
            <div class="limpaDir">
            </div>
        </asp:Panel>
        <%--FIM PanelCadastrarDoenca--%>
        <br />
    </div>
</asp:Content>
