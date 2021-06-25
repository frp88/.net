<%@ Page Language="C#" MasterPageFile="~/admin/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="controleDoencas.aspx.cs" Inherits="admin_controleDoencas" Title="CV - Controle de Doenças" %>

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
        <%--Panel Lista de Doenças--%>
        <asp:Panel ID="PanelListaDoencas" runat="server">
            <div class="alinhaDir">
                <asp:Image ID="Image1" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />
                <asp:Label ID="Label01" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                    Text="Controle de Doenças"></asp:Label>
            </div>
            <%--Botão btPanelCadastrarDoencas--%>
            <div class="botoesDireita">
                <asp:Button ID="btCadastrarDoenca" runat="server" CssClass="botoes" Text="Cadastrar Doença"
                    Width="140px" OnClick="btCadastrarDoenca_Click" />
            </div>
            <div class="botoesDireita">
                <asp:HyperLink ID="HyperLinkImprimir" runat="server" CssClass="botoesDireita" Target="_blank"
                    Font-Bold="True" Font-Size="11pt" ToolTip="Clique no link para exportar Lista de Doenças para o Excel."
                    ForeColor="#056D00">Exportar Lista para o Excel</asp:HyperLink>
            </div>
            <div class="limpaDir">
            </div>
            <div class="alinhaDir">
                <asp:Image ID="ImageInformacao" runat="server" EnableViewState="false" ToolTip="Informação no controle de Doenças"
                    ImageUrl="~/images/information32.PNG" />
            </div>
            <div class="alinhaDir" style="padding-top: 14px;">
                <asp:Label ID="LabelAjuda" runat="server" EnableViewState="False" ForeColor="#099409"
                    Font-Size="14px" Font-Bold="True" Text="Para cadastrar uma nova doença clique no botão 'Cadastrar Doença' no canto superior direito"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <div style="margin-left: -8px;">
                <hr />
            </div>
            <div class="alinhaDir" style="padding-top: 18px;">
                <asp:Image ID="Image2" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                <asp:Label ID="Label2" runat="server" EnableViewState="False" Font-Bold="True" Text="Filtrar Doença - Selecione uma Situação da Doença ou digite o Código da Doença"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <div class="alinhaDir" style="margin-top: 5px; margin-right: -10px;">
                <asp:Label ID="Label56" runat="server" EnableViewState="False" Font-Bold="True" Text="Situação:"></asp:Label>
            </div>
            <div class="alinhaDir">
                <asp:RadioButtonList ID="rbSituacaoDoenca" runat="server" AutoPostBack="True" RepeatColumns="4"
                    OnSelectedIndexChanged="rbSituacaoDoenca_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="0">Todas</asp:ListItem>
                    <asp:ListItem Value="1">Presente</asp:ListItem>
                    <asp:ListItem Value="2">Recuperada</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="alinhaDir" style="padding-left: 40px; padding-top: 8px;">
                <asp:Label ID="Label3" runat="server" EnableViewState="False" Font-Bold="True" Text="Ou Código:"></asp:Label>
                <asp:TextBox ID="txtCodigoDoenca" runat="server" CssClass="bordas"></asp:TextBox>
            </div>
            <div class="alinhaDir" style="padding-left: 10px; padding-top: 7px;">
                <asp:Button ID="btFiltrar" runat="server" Text="Filtrar" CssClass="botoes" Height="22px"
                    Width="80px" OnClick="btFiltrar_Click" />
            </div>
            <div class="botoesDireita" style="padding-top: 8px;">
                <asp:Label ID="Label14" runat="server" EnableViewState="False" Font-Bold="True" Text="Mostrar Doenças:"></asp:Label>
                <asp:DropDownList ID="ddlMostrarDoencas" runat="server" CssClass="bordas" Width="50"
                    AutoPostBack="True" OnSelectedIndexChanged="ddlMostrarDoencas_SelectedIndexChanged">
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
                <asp:Label ID="Label4" runat="server" EnableViewState="False" Font-Bold="True" Text="Lista de Doenças"></asp:Label>
            </div>
            <div class="alinhaDir" style="float: right; padding-right: 10px;">
                <asp:Image ID="Image8" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                <asp:Label ID="Label8" runat="server" EnableViewState="False" Font-Bold="True" Text="Legenda:"></asp:Label>
                <asp:Image ID="Image9" runat="server" EnableViewState="false" ImageUrl="../images/bolaAmarela.PNG" />
                <asp:Label ID="Label9" runat="server" EnableViewState="False" Font-Bold="True" Text="Doença Presente"></asp:Label>
                <asp:Image ID="Image10" runat="server" EnableViewState="false" ImageUrl="../images/bolaVerde.PNG" />
                <asp:Label ID="Label10" runat="server" EnableViewState="False" Font-Bold="True" Text="Doença Recuperada"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <asp:GridView ID="GridViewDoencas" runat="server" BackColor="White" AutoGenerateColumns="False"
                BorderColor="#0D5600" Width="100%" HorizontalAlign="Center" CellPadding="2" AllowPaging="True"
                AllowSorting="true" BorderStyle="Double" BorderWidth="3px" GridLines="Vertical"
                OnRowDataBound="GridViewDoencas_RowDataBound" OnRowCommand="GridViewDoencas_RowCommand"
                OnPageIndexChanging="GridViewDoencas_PageIndexChanging" OnSorting="GridViewDoencas_Sorting">
                <RowStyle BackColor="#ffffff" />
                <Columns>
                    <asp:BoundField DataField="codDoenca" SortExpression="codDoenca" HeaderText="Cod Doença">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="statusDoenca" SortExpression="statusDoenca" HeaderText="statusDoenca">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="statusDoenca" SortExpression="statusDoenca" HeaderText="Sit.">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="sCodIdentificacao" SortExpression="sCodIdentificacao"
                        HeaderText="Árvore">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110px" />
                    </asp:BoundField>
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
                    <asp:BoundField DataField="descLocalAfetado" SortExpression="descLocalAfetado" HeaderText="Local Afetado">
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
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="dtDoenca" SortExpression="dtDoenca" DataFormatString="{0:d}"
                        HeaderText="Data Recuperação">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="codArvore" SortExpression="codArvore" HeaderText="codArvore">
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Link" CommandName="editarDoenca" Text='<img alt="" title="Editar Doença" src="../images/editar.png" style="border: 0px" />'>
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
                <HeaderStyle CssClass="header" />
                <AlternatingRowStyle BackColor="#d5d5d5" />
                <HeaderStyle BackColor="#099409" ForeColor="White" />
                <PagerStyle BackColor="#099409" ForeColor="White" />
            </asp:GridView>
        </asp:Panel>
        <%--FIM Panel Lista de  Doenca--%>
        <asp:Panel ID="PanelCadastrarDoenca" runat="server" Visible="false">
            <div class="alinhaDir">
                <asp:Image ID="Image5" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                    Height="12px" Width="20px" />
                <asp:Label ID="LabelTituloCadDoenca" runat="server" Font-Bold="True" Font-Size="14px"
                    Text="Cadastra / Atualiza Doenças"></asp:Label>
            </div>
            <%--Botão btVoltarDoencasArvore--%>
            <div class="botoesDireita">
                <asp:Button ID="btVoltarListaDoencas" runat="server" CssClass="botoes" Text="Voltar"
                    Width="100px" OnClick="btVoltarListaDoencas_Click" />
            </div>
            <div class="limpaDir">
            </div>
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
            <div class="nomecampos" style="margin-top: 8px; margin-right: -10px;">
                <asp:Label ID="Label5" runat="server" EnableViewState="False" Font-Bold="True" Text="Parasitas ou Grupo Parasitas:"></asp:Label>
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
                Data da Recuperação:
            </div>
            <div class="txtcampos" style="float: left;">
                <asp:TextBox ID="txtDataConclusao" MaxLength="10" runat="server" CssClass="calendario"
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
                Status da Doença:
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
