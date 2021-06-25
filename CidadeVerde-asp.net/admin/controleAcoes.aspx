<%@ Page Language="C#" MasterPageFile="~/admin/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="controleAcoes.aspx.cs" Inherits="controleAcoes" Title="CV - Controle de Ações" %>

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
        <%--Panel Lista de Açoes--%>
        <asp:Panel ID="PanelListaAcoes" runat="server">
            <div class="alinhaDir">
                <asp:Image ID="Image1" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />
                <asp:Label ID="Label01" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                    Text="Controle de Ações"></asp:Label>
            </div>
            <%--Botão btPanelCadastrarAçoes e btVoltarTelaVerAcoes--%>
            <div class="botoesDireita">
                <asp:Button ID="btPanelCadastrarAcao" runat="server" CssClass="botoes" Text="Cadastrar Ação"
                    Width="140px" OnClick="btPanelCadastrarAcao_Click" />
            </div>
            <div class="botoesDireita">
                <asp:HyperLink ID="HyperLinkImprimir" runat="server" CssClass="botoesDireita" Target="_blank"
                    Font-Bold="True" Font-Size="11pt" ToolTip="Clique no link para Exportar Lista de Ações para o Excel."
                    ForeColor="#056D00">Exportar Lista para o Excel</asp:HyperLink>
            </div>
            <div class="limpaDir">
            </div>
            <div class="alinhaDir">
                <asp:Image ID="ImageInformacao" runat="server" EnableViewState="false" ToolTip="Informação no controle de Ações"
                    ImageUrl="~/images/information32.PNG" />
            </div>
            <div class="alinhaDir" style="padding-top: 14px;">
                <asp:Label ID="LabelAjuda" runat="server" EnableViewState="False" ForeColor="#099409"
                    Font-Size="14px" Font-Bold="True" Text="Para cadastrar uma nova ação clique no botão 'Cadastrar Ação' no canto superior direito"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <div style="margin-left: -8px;">
                <hr />
            </div>
            <div class="alinhaDir" style="padding-top: 18px;">
                <asp:Image ID="Image2" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                <asp:Label ID="Label2" runat="server" EnableViewState="False" Font-Bold="True" Text="Filtrar Ação - Selecione uma Situação da Áção ou digite o Código da Ação"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <div class="alinhaDir" style="margin-top: 5px; margin-right: -10px;">
                <asp:Label ID="Label56" runat="server" EnableViewState="False" Font-Bold="True" Text="Situação:"></asp:Label>
            </div>
            <div class="alinhaDir">
                <asp:RadioButtonList ID="rbSituacaoAcao" runat="server" AutoPostBack="True" RepeatColumns="4"
                    OnSelectedIndexChanged="rbSituacaoAcao_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="0">Todas</asp:ListItem>
                    <asp:ListItem Value="1">Pendente</asp:ListItem>
                    <asp:ListItem Value="2">Concluída</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="alinhaDir" style="padding-left: 40px; padding-top: 8px;">
                <asp:Label ID="Label3" runat="server" EnableViewState="False" Font-Bold="True" Text="Ou Código:"></asp:Label>
                <asp:TextBox ID="txtCodigoAcao" runat="server" CssClass="bordas"></asp:TextBox>
            </div>
            <div class="alinhaDir" style="padding-left: 10px; padding-top: 7px;">
                <asp:Button ID="btFiltrar" runat="server" Text="Filtrar" CssClass="botoes" Height="22px"
                    Width="80px" OnClick="btFiltrar_Click" />
            </div>
            <div class="botoesDireita" style="padding-top: 8px;">
                <asp:Label ID="Label14" runat="server" EnableViewState="False" Font-Bold="True" Text="Mostrar Ações:"></asp:Label>
                <asp:DropDownList ID="ddlMostrarAcoes" runat="server" CssClass="bordas" Width="50"
                    AutoPostBack="True" OnSelectedIndexChanged="ddlMostrarAcoes_SelectedIndexChanged">
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
                <asp:Label ID="Label4" runat="server" EnableViewState="False" Font-Bold="True" Text="Lista de Ações"></asp:Label>
            </div>
            <div class="alinhaDir" style="float: right; padding-right: 10px;">
                <asp:Image ID="Image8" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                <asp:Label ID="Label8" runat="server" EnableViewState="False" Font-Bold="True" Text="Legenda:"></asp:Label>
                <asp:Image ID="Image9" runat="server" EnableViewState="false" ImageUrl="../images/bolaVermelha.PNG" />
                <asp:Label ID="Label9" runat="server" EnableViewState="False" Font-Bold="True" Text="Ação Pendente"></asp:Label>
                <asp:Image ID="Image10" runat="server" EnableViewState="false" ImageUrl="../images/bolaVerde.PNG" />
                <asp:Label ID="Label10" runat="server" EnableViewState="False" Font-Bold="True" Text="Ação Concluída"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <asp:GridView ID="GridViewAcoes" runat="server" BackColor="White" AutoGenerateColumns="False"
                BorderColor="#0D5600" Width="100%" HorizontalAlign="Center" CellPadding="2" AllowSorting="True"
                AllowPaging="True" BorderStyle="Double" BorderWidth="3px" GridLines="Vertical"
                OnRowDataBound="GridViewAcoes_RowDataBound" OnRowCommand="GridViewAcoes_RowCommand"
                OnPageIndexChanging="GridViewAcoes_PageIndexChanging" OnSorting="GridViewAcoes_Sorting">
                <RowStyle BackColor="#ffffff" />
                <Columns>
                    <asp:BoundField DataField="codHistorico" SortExpression="codHistorico" HeaderText="Cod Ação">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="62px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nStatusHistorico" SortExpression="nStatusHistorico" HeaderText="nStatusHistorico">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nStatusHistorico" SortExpression="nStatusHistorico" HeaderText="Sit.">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="codArvore" SortExpression="codArvore" HeaderText="codArvore">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="sCodIdentificacao" SortExpression="sCodIdentificacao"
                        HeaderText="Árvore">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110px" />
                    </asp:BoundField>
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
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="dtHistorico" SortExpression="dtHistorico" DataFormatString="{0:d}"
                        HeaderText="Data Realização">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Link" CommandName="editarAcao" Text='<img alt="" title="Clique aqui para Editar a Ação" src="../images/editar.png" style="border: 0px" />'>
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
                <HeaderStyle CssClass="header" />
                <AlternatingRowStyle BackColor="#d5d5d5" />
                <HeaderStyle BackColor="#099409" ForeColor="White" />
                <PagerStyle BackColor="#099409" ForeColor="White" />
            </asp:GridView>
        </asp:Panel>
        <%--FIM Panel Lista de  Acoes--%>
        <asp:Panel ID="PanelCadastrarAcao" runat="server" Visible="false">
            <div class="alinhaDir">
                <asp:Image ID="Image5" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                    Height="12px" Width="20px" />
                <asp:Label ID="LabelTituloCad" runat="server" Font-Bold="True" Font-Size="14px" Text="Cadastra / Atualiza Ação"></asp:Label>
            </div>
            <%--Botão btVoltarAcoesArvore--%>
            <div class="botoesDireita">
                <asp:Button ID="btVoltarListaAcoes" runat="server" CssClass="botoes" Text="Voltar"
                    Width="100px" OnClick="btVoltarListaAcoes_Click" />
            </div>
            <div class="limpaDir">
            </div>
            <br />
            <%--Codigo da Árvore Arvore--%>
            <div class="nomecampos">
                Árvore:
            </div>
            <div class="txtcampos">
                <asp:DropDownList ID="ddlCodigoIdentArvore" runat="server" CssClass="bordas" Width="250"
                    DataTextField="sCodIdentificacao" DataValueField="codArvore">
                </asp:DropDownList>
                *
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
            <%--Data de Realização--%>
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
                <asp:DropDownList ID="ddlAcaoRecomendada" runat="server" CssClass="bordas" Width="250"
                    DataTextField="descAcaoRecomendada" DataValueField="codAcaoRecomendada">
                </asp:DropDownList>
                *
            </div>
            <div class="limpaDir">
            </div>
            <%--Status da Ação--%>
            <div class="nomecampos">
                Status da Ação:
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
                    <asp:ListItem Value="3">Morta</asp:ListItem>
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
