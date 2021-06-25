<%@ Page Language="C#" MasterPageFile="~/admin/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="controleInjurias.aspx.cs" Inherits="admin_controleInjurias" Title="CV - Controle de Injúrias"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="conteudo">
        <div id="dialog" title="Alerta" style="display: none;">
            <br />
            <%--<span class="ui-icon ui-icon-closethick" style="margin: 0pt 7px 50px 0pt; float: left;">
                </span>--%>
            <div class="alinhaDir">
                <asp:Image ID="ImageDialog" runat="server" meta:resourcekey="ImageDialogResource1" />
            </div>
            <div class="alinhaDir" style="margin-top: 8px;">
                <asp:Label ID="LabelDialog" runat="server" EnableViewState="False" Font-Size="13px"
                    Font-Bold="True" meta:resourcekey="LabelDialogResource1"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
        </div>
        <%--Panel Lista de Injurias--%>
        <asp:Panel ID="PanelListaInjurias" runat="server" meta:resourcekey="PanelListaInjuriasResource1">
            <div class="alinhaDir">
                <asp:Image ID="Image1" runat="server" EnableViewState="False" ImageUrl="~/images/setaDir.PNG"
                    meta:resourcekey="Image1Resource1" />
                <asp:Label ID="Label01" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                    Text="Controle de Injúrias" meta:resourcekey="Label01Resource1"></asp:Label>
            </div>
            <div class="botoesDireita">
                <asp:Button ID="btCadastrarInjuria" runat="server" CssClass="botoes" Text="Cadastrar Injúria"
                    Width="140px" OnClick="btCadastrarInjuria_Click" meta:resourcekey="btCadastrarInjuriaResource1" />
            </div>
            <div class="botoesDireita">
                <asp:HyperLink ID="HyperLinkImprimir" runat="server" CssClass="botoesDireita" Target="_blank"
                    Font-Bold="True" Font-Size="11pt" ToolTip="Clique no linkExportar Lista de Injúrias para o Excel."
                    ForeColor="#056D00" meta:resourcekey="HyperLinkImprimirResource1">Exportar Lista para o Excel</asp:HyperLink>
            </div>
            <div class="limpaDir">
            </div>
            <div class="alinhaDir">
                <asp:Image ID="ImageInformacao" runat="server" EnableViewState="False" ToolTip="Informação no controle de Injúrias"
                    ImageUrl="~/images/information32.PNG" meta:resourcekey="ImageInformacaoResource1" />
            </div>
            <div class="alinhaDir" style="padding-top: 14px;">
                <asp:Label ID="LabelAjuda" runat="server" EnableViewState="False" ForeColor="#099409"
                    Font-Size="14px" Font-Bold="True" Text="Para cadastrar uma nova injúria clique no botão 'Cadastrar Injúria' no canto superior direito"
                    meta:resourcekey="LabelAjudaResource1"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <div style="margin-left: -8px;">
                <hr />
            </div>
            <div class="alinhaDir" style="padding-top: 18px;">
                <asp:Image ID="Image2" runat="server" EnableViewState="False" ImageUrl="~/images/setaDirPEq.PNG"
                    meta:resourcekey="Image2Resource1" />
                <asp:Label ID="Label2" runat="server" EnableViewState="False" Font-Bold="True" Text="Filtrar Injúria - Selecione uma Situação da Injúria ou digite o Código da Injúria"
                    meta:resourcekey="Label2Resource1"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <div class="alinhaDir" style="margin-top: 5px; margin-right: -10px;">
                <asp:Label ID="Label56" runat="server" EnableViewState="False" Font-Bold="True" Text="Situação:"
                    meta:resourcekey="Label56Resource1"></asp:Label>
            </div>
            <div class="alinhaDir">
                <asp:RadioButtonList ID="rbSituacaoInjuria" runat="server" AutoPostBack="True" RepeatColumns="4"
                    OnSelectedIndexChanged="rbSituacaoInjuria_SelectedIndexChanged" meta:resourcekey="rbSituacaoInjuriaResource1">
                    <asp:ListItem Selected="True" Value="0" meta:resourcekey="ListItemResource3">Todas</asp:ListItem>
                    <asp:ListItem Value="1" meta:resourcekey="ListItemResource4">Presente</asp:ListItem>
                    <asp:ListItem Value="2" meta:resourcekey="ListItemResource5">Recuperada</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="alinhaDir" style="padding-left: 40px; padding-top: 8px;">
                <asp:Label ID="Label3" runat="server" EnableViewState="False" Font-Bold="True" Text="Ou Código:"
                    meta:resourcekey="Label3Resource1"></asp:Label>
                <asp:TextBox ID="txtCodigoInjuria" runat="server" CssClass="bordas" meta:resourcekey="txtCodigoInjuriaResource1"></asp:TextBox>
            </div>
            <div class="alinhaDir" style="padding-left: 10px; padding-top: 7px;">
                <asp:Button ID="btFiltrar" runat="server" Text="Filtrar" CssClass="botoes" Height="22px"
                    Width="80px" OnClick="btFiltrar_Click" meta:resourcekey="btFiltrarResource1" />
            </div>
            <div class="botoesDireita" style="padding-top: 8px;">
                <asp:Label ID="Label14" runat="server" EnableViewState="False" Font-Bold="True" Text="Mostrar Injúrias:"
                    meta:resourcekey="Label14Resource1"></asp:Label>
                <asp:DropDownList ID="ddlMostrarInjurias" runat="server" CssClass="bordas" Width="50px"
                    AutoPostBack="True" OnSelectedIndexChanged="ddlMostrarInjurias_SelectedIndexChanged"
                    meta:resourcekey="ddlMostrarInjuriasResource1">
                    <asp:ListItem Value="10" meta:resourcekey="ListItemResource6">&nbsp;10</asp:ListItem>
                    <asp:ListItem Value="20" meta:resourcekey="ListItemResource7">&nbsp;20</asp:ListItem>
                    <asp:ListItem Value="50" meta:resourcekey="ListItemResource8">&nbsp;50</asp:ListItem>
                    <asp:ListItem Value="100" meta:resourcekey="ListItemResource9">&nbsp;100</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="limpaDir">
            </div>
            <div style="margin-left: -8px;">
                <hr />
            </div>
            <div class="alinhaDir" style="padding-top: 10px;">
                <asp:Image ID="Image3" runat="server" EnableViewState="False" ImageUrl="~/images/setaDirPEq.PNG"
                    meta:resourcekey="Image3Resource1" />
                <asp:Label ID="Label4" runat="server" EnableViewState="False" Font-Bold="True" Text="Lista de Injúrias"
                    meta:resourcekey="Label4Resource1"></asp:Label>
            </div>
            <div class="alinhaDir" style="float: right; padding-right: 10px;">
                <asp:Image ID="Image8" runat="server" EnableViewState="False" ImageUrl="~/images/setaDirPEq.PNG"
                    meta:resourcekey="Image8Resource1" />
                <asp:Label ID="Label8" runat="server" EnableViewState="False" Font-Bold="True" Text="Legenda:"
                    meta:resourcekey="Label8Resource1"></asp:Label>
                <asp:Image ID="Image9" runat="server" EnableViewState="False" ImageUrl="../images/bolaLaranja.PNG"
                    meta:resourcekey="Image9Resource1" />
                <asp:Label ID="Label9" runat="server" EnableViewState="False" Font-Bold="True" Text="Injúria Presente"
                    meta:resourcekey="Label9Resource1"></asp:Label>
                <asp:Image ID="Image10" runat="server" EnableViewState="False" ImageUrl="../images/bolaVerde.PNG"
                    meta:resourcekey="Image10Resource1" />
                <asp:Label ID="Label10" runat="server" EnableViewState="False" Font-Bold="True" Text="Injúria Recuperada"
                    meta:resourcekey="Label10Resource1"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <asp:GridView ID="GridViewInjurias" runat="server" BackColor="White" AutoGenerateColumns="False"
                BorderColor="#0D5600" Width="100%" HorizontalAlign="Center" CellPadding="2" AllowPaging="True"
                AllowSorting="true" BorderStyle="Double" BorderWidth="3px" GridLines="Vertical"
                OnRowDataBound="GridViewInjurias_RowDataBound" OnRowCommand="GridViewInjurias_RowCommand"
                OnPageIndexChanging="GridViewInjurias_PageIndexChanging" OnSorting="GridViewInjurias_Sorting">
                <AlternatingRowStyle BackColor="#D5D5D5" />
                <Columns>
                    <asp:BoundField DataField="codInjuria" HeaderText="Cod Injúria" SortExpression="codInjuria">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="statusInjuria" HeaderText="statusInjuria" SortExpression="statusInjuria">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="statusInjuria" HeaderText="Sit." SortExpression="statusInjuria">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="sCodIdentificacao" HeaderText="Árvore" SortExpression="sCodIdentificacao">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="descLocalAfetado" HeaderText="Local Afetado" SortExpression="descLocalAfetado">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="descIntensidade" HeaderText="Intensidade" SortExpression="descIntensidade">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="descInjuria" HeaderText="Descrição" SortExpression="descInjuria">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="dtCadInjuria" DataFormatString="{0:d}" HeaderText="Data Cadastro"
                        meta:resourcekey="BoundFieldResource7" SortExpression="dtCadInjuria">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="dtInjuria" DataFormatString="{0:d}" HeaderText="Data Recuperação"
                        meta:resourcekey="BoundFieldResource8" SortExpression="dtInjuria">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="codArvore" HeaderText="codArvore" meta:resourcekey="BoundFieldResource9"
                        SortExpression="codArvore" />
                    <asp:ButtonField CommandName="editarInjuria" meta:resourcekey="ButtonFieldResource1"
                        Text="&lt;img alt=&quot;&quot; title=&quot;Editar Injúria&quot; src=&quot;../images/editar.png&quot; style=&quot;border: 0px&quot; /&gt;">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                    </asp:ButtonField>
                </Columns>
                <EmptyDataTemplate>
                    <table align="center" cellspacing="1" style="width: 100%">
                        <thead>
                        </thead>
                        <tbody>
                            <tr style="background-color: #ececeb; height: 13px; text-align: center;">
                                <td colspan="3">
                                    Nenhuma Injúria Encontrada.
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </EmptyDataTemplate>
                <HeaderStyle CssClass="header" />
                <HeaderStyle BackColor="#099409" ForeColor="White" />
                <PagerStyle BackColor="#099409" ForeColor="White" />
                <RowStyle BackColor="White" />
            </asp:GridView>
        </asp:Panel>
        <%--FIM Panel Lista de  Injuria--%>
        <asp:Panel ID="PanelCadastrarInjuria" runat="server" Visible="False" meta:resourcekey="PanelCadastrarInjuriaResource1">
            <div class="alinhaDir">
                <asp:Image ID="Image5" runat="server" EnableViewState="False" ImageUrl="~/images/setaDir.PNG"
                    Height="12px" Width="20px" meta:resourcekey="Image5Resource1" />
                <asp:Label ID="LabelTituloCadInjuria" runat="server" Font-Bold="True" Font-Size="14px"
                    Text="Cadastra / Atualiza Injúrias" meta:resourcekey="LabelTituloCadInjuriaResource1"></asp:Label>
            </div>
            <div class="botoesDireita">
                <asp:Button ID="btVoltarListaInjurias" runat="server" CssClass="botoes" meta:resourcekey="btVoltarListaInjuriasResource1"
                    OnClick="btVoltarListaInjurias_Click" Text="Voltar" Width="100px" />
            </div>
            <div class="limpaDir">
            </div>
            <div class="nomecampos">
                Árvore:
            </div>
            <div class="txtcampos">
                <asp:DropDownList ID="ddlCodigoIdentArvore" runat="server" CssClass="bordas" DataTextField="sCodIdentificacao"
                    DataValueField="codArvore" meta:resourcekey="ddlCodigoIdentArvoreResource1" Width="250px">
                </asp:DropDownList>
                *
            </div>
            <div class="limpaDir">
            </div>
            <div class="nomecampos">
                Local Afetado:
            </div>
            <div class="txtcampos">
                <asp:DropDownList ID="ddlLocalAfetado" runat="server" CssClass="bordas" DataTextField="descLocalAfetado"
                    DataValueField="codLocalAfetado" meta:resourcekey="ddlLocalAfetadoResource1"
                    Width="250px">
                </asp:DropDownList>
                *
            </div>
            <div class="limpaDir">
            </div>
            <div class="nomecampos">
                Intensidade:
            </div>
            <div class="txtcampos">
                <asp:DropDownList ID="ddlIntensidade" runat="server" CssClass="bordas" DataTextField="descIntensidade"
                    DataValueField="codIntensidade" meta:resourcekey="ddlIntensidadeResource1" Width="250px">
                </asp:DropDownList>
                *
            </div>
            <div class="limpaDir">
            </div>
            <div class="nomecampos">
                Descrição:
            </div>
            <div class="txtcampos">
                <asp:TextBox ID="txtDescInjuria" runat="server" CssClass="bordas" Height="70px" meta:resourcekey="txtDescInjuriaResource1"
                    Style="font-family: Arial; font-size: 13px" TextMode="MultiLine" Width="300px"></asp:TextBox>
            </div>
            *
            <div class="limpaDir">
            </div>
            <div class="nomecampos">
                Data da Recuperação:
            </div>
            <div class="txtcampos" style="float: left;">
                <asp:TextBox ID="txtDataConclusao" MaxLength="10" runat="server" CssClass="calendario"
                    Width="150px" meta:resourcekey="txtDataConclusaoResource1"></asp:TextBox>
            </div>
            <div class="txtcampos" style="float: left; margin-top: -1px; margin-left: -8px;">
                <asp:Image ID="ImageCalendario" runat="server" AlternateText="Calendário" ImageUrl="~/images/calendar.png"
                    ToolTip="Clique no campo ao lado para visualizar o calendário." meta:resourcekey="ImageCalendarioResource1" />
            </div>
            <div class="limpaDir">
            </div>
            <div class="nomecampos">
                Status da Injúria:
            </div>
            <div class="txtcampos">
                <asp:DropDownList ID="ddlStatusInjuria" runat="server" CssClass="bordas" Width="200px"
                    AutoPostBack="True" meta:resourcekey="ddlStatusInjuriaResource1">
                    <asp:ListItem Selected="True" Value="1" meta:resourcekey="ListItemResource1">Presente</asp:ListItem>
                    <asp:ListItem Value="2" meta:resourcekey="ListItemResource2">Recuperada</asp:ListItem>
                </asp:DropDownList>
                *
            </div>
            <div class="limpaDir">
            </div>
            <div class="botoesCentro">
                <asp:Button ID="btSalvarInjuria" runat="server" CssClass="botoes" Text="Salvar" OnClick="btSalvarInjuria_Click"
                    meta:resourcekey="btSalvarInjuriaResource1" />
                <asp:Button ID="btCancelarInjuria" runat="server" CssClass="botoes" Text="Cancelar"
                    OnClick="btCancelarInjuria_Click" meta:resourcekey="btCancelarInjuriaResource1" />
            </div>
            <div class="limpaDir">
            </div>
            <div class="centroAbas">
                <asp:Panel ID="PanelConfirmaInjuria" runat="server" Visible="False" Width="500px"
                    meta:resourcekey="PanelConfirmaInjuriaResource1">
                    <div class="alinhaDir">
                        <asp:Image ID="ImageConfirma" runat="server" ImageUrl="~/images/confirmation32.png"
                            meta:resourcekey="ImageConfirmaResource1" />
                    </div>
                    <div style="padding-top: 14px;">
                        <asp:Label ID="LabelErroInjuria" runat="server" ForeColor="#CC0000" Font-Bold="True"
                            meta:resourcekey="LabelErroInjuriaResource1"></asp:Label>
                        <asp:Label ID="LabelConfirmaInjuria" runat="server" ForeColor="#099409" Font-Bold="True"
                            meta:resourcekey="LabelConfirmaInjuriaResource1"></asp:Label>
                    </div>
                </asp:Panel>
            </div>
            <div class="limpaDir">
            </div>
        </asp:Panel>
        <%--FIM PanelCadastrarInjuria--%>
        <br />
    </div>
</asp:Content>
