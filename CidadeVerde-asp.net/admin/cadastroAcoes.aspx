<%@ Page Language="C#" MasterPageFile="~/admin/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="cadastroAcoes.aspx.cs" Inherits="admin_cadastroAcoes" Title="CV - Administrar Ações" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="conteudo">
        <div id="dialog" title="Alerta" style="display: none;">
            <br />
            <%--<span class="ui-icon ui-icon-closethick" style="margin: 0pt 7px 50px 0pt; float: left;">
                </span>--%>
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
        <asp:Panel ID="PanelVerArvore" runat="server">
            <div class="alinhaDir">
                <asp:Image ID="Image1" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />
                <asp:Label ID="Label01" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                    Text="Administrar Ações das Árvores"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <div class="alinhaDir">
                <asp:Image ID="ImageInformacao" runat="server" EnableViewState="false" ToolTip="Informação no cadastro de Ações"
                    ImageUrl="~/images/information32.PNG" />
            </div>
            <div class="alinhaDir" style="padding-top: 14px;">
                <asp:Label ID="LabelAjuda" runat="server" EnableViewState="False" ForeColor="#099409"
                    Font-Size="14px" Font-Bold="True" Text="Para cadastrar uma ação clique no botão 'Ver Ações' (Lado direito da tabela Lista de Árvores)"></asp:Label>
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
                <asp:Label ID="Label8" runat="server" EnableViewState="False" Font-Bold="True" Text="Legenda:"></asp:Label>
                <asp:Image ID="Image9" runat="server" EnableViewState="false" ImageUrl="~/images/arvoreSaudavel.PNG" />
                <asp:Label ID="Label9" runat="server" EnableViewState="False" Font-Bold="True" Text="Árvore Saudável"></asp:Label>
                <asp:Image ID="Image10" runat="server" EnableViewState="false" ImageUrl="~/images/arvoreDoente.PNG" />
                <asp:Label ID="Label10" runat="server" EnableViewState="False" Font-Bold="True" Text="Árvore Doente"></asp:Label>
                <asp:Image ID="Image6" runat="server" EnableViewState="false" ImageUrl="~/images/arvoreFerida.PNG" />
                <asp:Label ID="Label7" runat="server" EnableViewState="False" Font-Bold="True" Text="Árvore Ferida"></asp:Label>
                <asp:Image ID="Image11" runat="server" EnableViewState="false" ImageUrl="~/images/arvoreMorta.PNG" />
                <asp:Label ID="Label11" runat="server" EnableViewState="False" Font-Bold="True" Text="Árvore Morta"></asp:Label>
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
                    <asp:ButtonField ButtonType="Link" CommandName="verAcoes" Text='<img alt="" title="Clique aqui para ver as ações da Árvore" src="../images/detalhes.png" style="border: 0px" />'>
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
        <%--Panel Açoes de uma Árvore--%>
        <asp:Panel ID="PanelHitoricoAcoesArvore" runat="server" Visible="false">
            <div class="alinhaDir">
                <asp:Image ID="Image4" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                    Height="12px" Width="20px" />
                <asp:Label ID="Label5" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                    Text="Histórico de Ações da Árvore"></asp:Label>
            </div>
            <%--Botão btPanelCadastrarAçoes e btVoltarTelaVerAcoes--%>
            <div class="botoesDireita">
                <asp:Button ID="btPanelCadastrarAcao" runat="server" CssClass="botoes" Text="Cadastrar nova ação"
                    OnClick="btPanelCadastrarAcao_Click" />
                <asp:Button ID="btVoltarTelaVerAcao" runat="server" CssClass="botoes" Text="Voltar"
                    Width="100px" OnClick="btVoltarTelaVerAcao_Click" />
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
            <asp:GridView ID="GridViewAcoesArvore" runat="server" BackColor="White" AutoGenerateColumns="False"
                BorderColor="#0D5600" Width="100%" HorizontalAlign="Center" CellPadding="2" AllowPaging="True"
                BorderStyle="Double" BorderWidth="3px" GridLines="Vertical" OnRowDataBound="GridViewAcoesArvore_RowDataBound"
                OnRowCommand="GridViewAcoesArvore_RowCommand">
                <RowStyle BackColor="#ffffff" />
                <Columns>
                    <asp:BoundField DataField="codHistorico" SortExpression="codHistorico" HeaderText="codHistorico">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nStatusHistorico" SortExpression="nStatusHistorico" HeaderText="nStatusHistorico">
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
                    <asp:BoundField DataField="descAcaoRecomendada" SortExpression="descAcaoRecomendada"
                        HeaderText="Ação Recomendada">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="descHistorico" SortExpression="descHistorico" HeaderText="Descrição">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="dtCadHistorico" SortExpression="dtCadHistorico" DataFormatString="{0:d}"
                        HeaderText="Data Cadastro">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="dtHistorico" SortExpression="dtHistorico" DataFormatString="{0:d}"
                        HeaderText="Data Realização">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110px" />
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Link" CommandName="editarAcao" Text='<img alt="" title="Editar Ação" src="../images/editar.png" style="border: 0px" />'>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </asp:ButtonField>
                    <asp:ButtonField ButtonType="Link" CommandName="excluirAcao" Text='<img alt="" title="Excluir Ação" src="../images/excluir.png" style="border: 0px" />'>
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
                                    Nenhuma Ação Encontrada.
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
        <%--FIM Panel Acoes de uma Árvore--%>
        <asp:Panel ID="PanelCadastrarAcao" runat="server" Visible="false">
            <div class="alinhaDir">
                <asp:Image ID="Image5" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                    Height="12px" Width="20px" />
                <asp:Label ID="Label6" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                    Text="Cadastra / Atualiza Ação"></asp:Label>
            </div>
            <%--Botão btVoltarAcoesArvore--%>
            <div class="botoesDireita">
                <asp:Button ID="btVoltarAcoesArvore" runat="server" CssClass="botoes" Text="Voltar"
                    Width="100px" OnClick="btVoltarAcoesArvore_Click" />
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
            <%--Descrição da Acao--%>
            <div class="nomecampos">
                Descrição:
            </div>
            <div class="txtcampos">
                <asp:TextBox ID="txtDescAcao" runat="server" Height="80px" TextMode="MultiLine" Width="350px"
                    CssClass="bordas" Style="font-family: Arial; font-size: 13px"></asp:TextBox>
                *
            </div>
            <div class="limpaDir">
            </div>
            <%--Data de Levamtamento--%>
            <div class="nomecampos">
                Data de Realização:
            </div>
            <div class="txtcampos" style="float: left;">
                <asp:TextBox ID="txtDataAcao" MaxLength="10" runat="server" CssClass="calendario"
                    Width="150px"></asp:TextBox>
            </div>
            <div class="txtcampos" style="float: left; margin-left: -8px;">
                <asp:Image ID="ImageCalendario" runat="server" AlternateText="Calendário" ImageUrl="~/images/calendar.png"
                    ToolTip="Clique no campo ao lado para visualizar o calendário." />
            </div>
            <div class="limpaDir">
            </div>
            <%--Ação Recomendada--%>
            <div class="nomecampos">
                Ação Recomendada:
            </div>
            <div class="txtcampos">
                <asp:DropDownList ID="ddlAcaoRecomendada" runat="server" CssClass="bordas" Width="200px"
                    DataTextField="descAcaoRecomendada" DataValueField="codAcaoRecomendada">
                </asp:DropDownList>
                *
            </div>
            <div class="limpaDir">
            </div>
            <%--Status da Ação--%>
            <div class="nomecampos">
                Situação da Ação:
            </div>
            <div class="txtcampos">
                <asp:DropDownList ID="ddlStatusAcao" runat="server" CssClass="bordas" Width="200"
                    AutoPostBack="True">
                    <asp:ListItem Selected="True" Value="1">Pendente</asp:ListItem>
                    <asp:ListItem Value="2">Concluída</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="limpaDir">
            </div>
            <%--Status da Arvore--%>
            <%--<div class="nomecampos">
                Situação da Árvore:
            </div>
            <div class="txtcampos">
                <asp:DropDownList ID="ddlStatusArvore" runat="server" CssClass="bordas" Width="200"
                    AutoPostBack="True">
                    <asp:ListItem Selected="True" Value="1">Saudável</asp:ListItem>
                    <asp:ListItem Value="2">Doente</asp:ListItem>
                    <asp:ListItem Value="3">Ferida</asp:ListItem>
                    <asp:ListItem Value="4">Morta</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="limpaDir">
            </div>--%>
            <%--Botões Salvar e Cancelar--%>
            <div class="botoesCentro">
                <asp:Button ID="btSalvarAcao" runat="server" CssClass="botoes" Text="Salvar" OnClick="btSalvarAcao_Click" />
                <asp:Button ID="btCancelarAcao" runat="server" CssClass="botoes" Text="Cancelar"
                    OnClick="btCancelarAcao_Click" />
            </div>
            <div class="limpaDir">
            </div>
            <div class="botoesCentro" style="width: 600px;">
                <asp:Panel ID="PanelConfirmaAcao" runat="server" Visible="false">
                    <div class="alinhaDir">
                        <asp:Image ID="ImageConfirma" runat="server" ImageUrl="~/images/confirmation32.png" />
                    </div>
                    <div style="padding-top: 14px;">
                        <asp:Label ID="LabelErroAcao" runat="server" Text="" ForeColor="#CC0000" Font-Bold="true"></asp:Label>
                        <asp:Label ID="LabelConfirmaAcao" runat="server" Text="" ForeColor="#099409" Font-Bold="true"></asp:Label>
                    </div>
                </asp:Panel>
            </div>
            <div class="limpaDir">
            </div>
        </asp:Panel>
        <%--FIM PanelCadastrarAcao--%>
        <br />
    </div>
</asp:Content>
