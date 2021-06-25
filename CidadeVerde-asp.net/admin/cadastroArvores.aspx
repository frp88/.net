<%@ Page Language="C#" MasterPageFile="~/admin/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="cadastroArvores.aspx.cs" Inherits="admin_cadastroArvores" Title="CV - Administrar �rvores" %>

<%--<%@ Register Assembly="Artem.GoogleMap" Namespace="Artem.Web.UI.Controls" TagPrefix="artem" %>--%>
<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="maps"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="conteudo">
        <%--        <maps:GMap ID="mapa" Width="550" Height="400px" runat="server" Key="ABQIAAAA0bjc-[chave Google]" />--%>
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
        <asp:Panel ID="panelVerArvore" runat="server">
            <div class="alinhaDir">
                <asp:Image ID="Image1" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                    Height="12px" Width="20px" />
                <asp:Label ID="Label01" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                    Text="Administrar �rvores"></asp:Label>
            </div>
            <%--Bot�o PanelCadastrarArvore--%>
            <div class="botoesDireita">
                <asp:Button ID="btPanelCadastrarArvore" runat="server" CssClass="botoes" Text="Cadastrar �rvore"
                    OnClick="btPanelCadastrarArvore_Click" />
            </div>
            <div class="botoesDireita">
                <asp:HyperLink ID="HyperLinkImprimir" runat="server" CssClass="botoesDireita" Target="_blank"
                    Font-Bold="True" Font-Size="11pt" ToolTip="Clique no link para Exportar Lista de Arvores para o Excel."
                    ForeColor="#056D00">Exportar Lista para o Excel</asp:HyperLink>
            </div>
            <div class="limpaDir">
            </div>
            <div class="alinhaDir">
                <asp:Image ID="ImageAjuda" runat="server" EnableViewState="false" ToolTip="Informa��es para o Cadastro de �rvores"
                    ImageUrl="~/images/information32.png" />
            </div>
            <div class="alinhaDir" style="padding-top: 14px;">
                <asp:Label ID="LabelAjuda" runat="server" EnableViewState="False" ForeColor="#099409"
                    Font-Size="14px" Font-Bold="True" Text="Para cadastrar uma �rvore clique no bot�o Cadastrar �rvore. (Do lado direito da tela)"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <div style="margin-left: -8px;">
                <hr />
            </div>
            <div class="alinhaDir" style="padding-top: 18px;">
                <asp:Image ID="Image6" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                <asp:Label ID="Label5" runat="server" EnableViewState="False" Font-Bold="True" Text="Filtrar �rvores - Selecione uma Situa��o da �rvore ou digite o C�digo da �rvore"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <div class="alinhaDir" style="margin-top: 5px; margin-right: -10px;">
                <asp:Label ID="Label56" runat="server" EnableViewState="False" Font-Bold="True" Text="Situa��o:"></asp:Label>
            </div>
            <div class="alinhaDir">
                <asp:RadioButtonList ID="rbSituacaoArvore" runat="server" AutoPostBack="True" RepeatColumns="5"
                    OnSelectedIndexChanged="rbSituacaoArvore_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="0">Todas</asp:ListItem>
                    <asp:ListItem Value="1">Saud�vel</asp:ListItem>
                    <asp:ListItem Value="2">Doente</asp:ListItem>
                    <asp:ListItem Value="3">Ferida</asp:ListItem>
                    <asp:ListItem Value="4">Morta</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="alinhaDir" style="padding-left: 10px; padding-top: 8px;">
                <asp:Label ID="Label6" runat="server" EnableViewState="False" Font-Bold="True" Text="Ou C�digo:"></asp:Label>
                <asp:TextBox ID="txtCodigoIdentArvore" runat="server" CssClass="bordas"></asp:TextBox>
            </div>
            <div class="alinhaDir" style="padding-left: 10px; padding-top: 7px;">
                <asp:Button ID="btFiltrar" runat="server" Text="Filtrar" CssClass="botoes" Height="22px"
                    Width="80px" OnClick="btFiltrar_Click" />
            </div>
            <div class="botoesDireita" style="padding-top: 8px;">
                <asp:Label ID="Label14" runat="server" EnableViewState="False" Font-Bold="True" Text="Mostrar �rvores:"></asp:Label>
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
                <asp:Image ID="Image7" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                <asp:Label ID="Label7" runat="server" EnableViewState="False" Font-Bold="True" Text="Lista de �rvores"></asp:Label>
            </div>
            <div class="alinhaDir" style="float: right; padding-right: 10px;">
                <asp:Image ID="Image8" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                <asp:Label ID="Label8" runat="server" EnableViewState="False" Font-Bold="True" Text="Legenda:"></asp:Label>
                <asp:Image ID="Image9" runat="server" EnableViewState="false" ImageUrl="~/images/arvoreSaudavel.PNG" />
                <asp:Label ID="Label9" runat="server" EnableViewState="False" Font-Bold="True" Text="�rvore Saud�vel"></asp:Label>
                <asp:Image ID="Image10" runat="server" EnableViewState="false" ImageUrl="~/images/arvoreDoente.PNG" />
                <asp:Label ID="Label10" runat="server" EnableViewState="False" Font-Bold="True" Text="�rvore Doente"></asp:Label>
                <asp:Image ID="Image15" runat="server" EnableViewState="false" ImageUrl="~/images/arvoreFerida.PNG" />
                <asp:Label ID="Label15" runat="server" EnableViewState="False" Font-Bold="True" Text="�rvore Ferida"></asp:Label>
                <asp:Image ID="Image11" runat="server" EnableViewState="false" ImageUrl="~/images/arvoreMorta.PNG" />
                <asp:Label ID="Label11" runat="server" EnableViewState="False" Font-Bold="True" Text="�rvore Morta"></asp:Label>
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
                    <asp:BoundField DataField="nStatus" SortExpression="nStatus" HeaderText="Situa��o">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="codEspecie" SortExpression="codEspecie" HeaderText="codEspecie">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="sCodIdentificacao" SortExpression="sCodIdentificacao"
                        HeaderText="C�digo Identifica��o">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="sNomeCientifico" SortExpression="sNomeCientifico" HeaderText="Nome Cient�fico">
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
                    <asp:BoundField DataField="nDiametroCopa" FooterText="nDiametroCopa" HeaderText="Di�metro Copa"
                        SortExpression="nDiametroCopa">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Link" CommandName="verArvore" Text='<img alt="" title="Clique aqui para Ver Detalhes e / ou Editar a �rvore" src="../images/editar.png" style="border: 0px" />'>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </asp:ButtonField>
                    <asp:ButtonField ButtonType="Link" CommandName="excluirArvore" Text='<img alt="" title="Clique aqui para Excluir a �rvore." src="../images/excluir.png" style="border: 0px" />'>
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
                                    Nenhuma �rvore Encontrada.
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
        <%--Fim Panel Ver Arvores--%>
        <asp:Panel ID="PanelAdminArvore" runat="server" Visible="false">
            <div class="alinhaDir">
                <asp:Image ID="Image2" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />
                <asp:Label ID="LabelCadArvore" runat="server" EnableViewState="true" Font-Bold="True"
                    Font-Size="14px" Text="Cadastro de �rvores"></asp:Label>
            </div>
            <%--Bot�o PanelCadastrarArvore--%>
            <div class="botoesDireita">
                <asp:Button ID="btVoltarTelaVerArvore" runat="server" CssClass="botoes" Text="Voltar"
                    OnClick="btVoltarTelaVerArvore_Click" Width="100px" />
            </div>
            <div class="limpaDir">
            </div>
            <div class="alinhaDir">
                <asp:Image ID="ImageInstrucoes" runat="server" EnableViewState="true" ToolTip="Instru��es para Cadastro"
                    ImageUrl="~/images/information32.png" />
            </div>
            <div class="alinhaDir" style="padding-top: 14px;">
                <asp:Label ID="LabelInstrucoes" runat="server" ForeColor="#099409" Font-Size="14px"
                    Font-Bold="True" Text="Preencha os Dados da �rvore e clique em &quot;Salvar&quot;. Logo ap�s clique nas abas e cadastre as outras informa��es."></asp:Label>
                <asp:Label ID="LabelErroCad" runat="server" EnableViewState="true" ForeColor="#cc0000"
                    Font-Size="14px" Font-Bold="True" Text="Erro" Visible="false"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <br />
            <div id="abas">
                <%--TITULOS DE ABAS--%>
                <ul>
                    <li><a href="#abaDadosArvore"><span>Dados da �rvore</span></a></li>
                    <li><a href="#abaEnderecoArvore"><span>Endere�o</span></a></li>
                    <li><a href="#abaCoordenadasArvore"><span>Localiza��o Geogr�fica</span></a></li>
                    <li><a href="#abaEntornoArvore"><span>Entorno</span></a></li>
                    <li><a href="#abaInterferenciasArvore"><span>Interfer�ncias</span></a></li>
                    <li><a href="#abaImagemArvore"><span>Imagem</span></a></li>
                </ul>
                <%--ABA CADASTRAR / ATUALIZAR DADOS DA ARVORE--%>
                <div id="abaDadosArvore">
                    <asp:Panel ID="PanelDadosArvore" runat="server" Visible="true">
                        <div class="alinhaDir">
                            <asp:Image ID="Image3" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPeq.PNG" />
                            <asp:Label ID="Label2" runat="server" EnableViewState="False" Font-Bold="True" Text="Dados da �rvore"></asp:Label>
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--Tipo de Especie--%>
                        <div class="nomecampos">
                            Tipo de Esp�cie:
                        </div>
                        <div class="txtcampos">
                            <asp:DropDownList ID="ddlTipoEspecie" runat="server" CssClass="bordas" Width="200"
                                AutoPostBack="True" DataTextField="sNomeCientifico" DataValueField="codEspecie"
                                OnSelectedIndexChanged="ddlTipoEspecie_SelectedIndexChanged">
                            </asp:DropDownList>
                            *
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--Di�metro da Copa--%>
                        <div class="nomecampos">
                            Di�metro da Copa:
                        </div>
                        <div class="txtcampos">
                            <asp:TextBox ID="txtDiametroCopa" runat="server" CssClass="bordas" Text="" Width="150px"></asp:TextBox>
                            * (Em metros)
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--Altura--%>
                        <div class="nomecampos">
                            Altura:
                        </div>
                        <div class="txtcampos">
                            <asp:TextBox ID="txtAltura" runat="server" CssClass="bordas" Text="" Width="150px"></asp:TextBox>
                            * (Em metros)
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--Persist�ncia da Folhas--%>
                        <div class="nomecampos">
                            Persist�ncia da Folhas:
                        </div>
                        <div class="txtcampos">
                            <asp:TextBox ID="txtPersistenciaFolhas" runat="server" CssClass="bordas" Text=""
                                Width="250px"></asp:TextBox>
                            *
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--Data de Plantio--%>
                        <div class="nomecampos">
                            Data de Plantio:
                        </div>
                        <div class="txtcampos" style="float: left;">
                            <asp:TextBox ID="txtDataPlantio" MaxLength="10" runat="server" CssClass="calendario"
                                Width="150px"></asp:TextBox>
                            *
                        </div>
                        <div class="txtcampos" style="float: left; margin-top: -1px; margin-left: -8px;">
                            <asp:Image ID="Image13" runat="server" AlternateText="Calend�rio" ImageUrl="~/images/calendar.png"
                                ToolTip="Clique no campo ao lado para visualizar o calend�rio." />
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--Data de Levantamento--%>
                        <div class="nomecampos">
                            Data de Levantamento:
                        </div>
                        <div class="txtcampos" style="float: left;">
                            <asp:TextBox ID="txtDataLevantamento" MaxLength="10" runat="server" CssClass="calendario"
                                Width="150px"></asp:TextBox>
                            *
                        </div>
                        <div class="txtcampos" style="float: left; margin-top: -1px; margin-left: -8px;">
                            <asp:Image ID="ImageCalendario" runat="server" AlternateText="Calend�rio" ImageUrl="~/images/calendar.png"
                                ToolTip="Clique no campo ao lado para visualizar o calend�rio." />
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--Status da Arvore--%>
                        <div class="nomecampos">
                            Situa��o da �rvore:
                        </div>
                        <div class="txtcampos">
                            <asp:DropDownList ID="ddlStatusArvore" runat="server" CssClass="bordas" Width="200"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlStatusArvore_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="1">Saud�vel</asp:ListItem>
                                <asp:ListItem Value="2">Doente</asp:ListItem>
                                <asp:ListItem Value="3">Ferida</asp:ListItem>
                                <asp:ListItem Value="4">Morta</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--Bot�o Salvar e Cancelar Dados da Arvore--%>
                        <div class="centroAbas">
                            <asp:Button ID="btDadosArvoreSalvar" runat="server" CssClass="botoesAba" Text="Salvar"
                                OnClick="btDadosArvoreSalvar_Click" Width="100px" />
                            <asp:Button ID="btDadosArvoreCancelar" runat="server" CssClass="botoesAba" Text="Cancelar"
                                OnClick="btDadosArvoreCancelar_Click" Width="100px" />
                        </div>
                        <div class="limpaDir">
                        </div>
                        <div class="centroAbas">
                            <%--painel confirma��o dados da �rvore--%>
                            <asp:Panel ID="PanelConfirmaDadosArvore" runat="server" Width="400px" Visible="false">
                                <div class="alinhaDir">
                                    <asp:Image ID="ImageConfirmaDadosArvore" runat="server" ImageUrl="~/images/exclamation32.png" />
                                </div>
                                <div style="padding-top: 14px;">
                                    <asp:Label ID="LabelDadosArvoreErro" runat="server" Text="" Font-Bold="true" ForeColor="#CC0000"></asp:Label>
                                    <asp:Label ID="LabelDadosArvoreOk" runat="server" Text="" Font-Bold="true" ForeColor="#099409"></asp:Label>
                                </div>
                            </asp:Panel>
                        </div>
                    </asp:Panel>
                    <%--Fim Panel Dados Arvores--%>
                    <div class="limpaDir">
                    </div>
                </div>
                <%--Fim Div abaDadosArvore--%>
                <%--ABA CADASTRAR / ATUALIZAR LOCALIZA�AO DA ARVORE--%>
                <div id="abaEnderecoArvore">
                    <asp:Panel ID="PanelEnderecoArvore" runat="server">
                        <div class="alinhaDir">
                            <asp:Image ID="Image4" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPeq.PNG" />
                            <asp:Label ID="Label3" runat="server" EnableViewState="False" Font-Bold="True" Text="Endere�o da �rvore"></asp:Label>
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--CEP--%>
                        <div class="nomecampos">
                            CEP:
                        </div>
                        <div class="txtcampos">
                            <asp:TextBox ID="txtCEP" runat="server" CssClass="bordas" Text="" Width="180px"></asp:TextBox>
                            * Somente N�meros
                        </div>
                        <asp:Button ID="btLocalizarCEP" runat="server" CssClass="botoesAba" Text="Localizar Endere�o"
                            OnClick="btLocalizarCEP_Click" />
                        <asp:Label ID="LabelErroCEP" runat="server" Text="" Font-Bold="true" ForeColor="#cc0000"
                            Visible="false"></asp:Label>
                        <div class="limpaDir">
                        </div>
                        <div style="padding-left: 210px;">
                            <strong>Obs.:&nbsp;</strong>CEP Somente N�meros.</div>
                        <br />
                        <div class="limpaDir">
                        </div>
                        <%--Tipo de Logradouro--%>
                        <div class="nomecampos">
                            Tipo de Logradouro:
                        </div>
                        <div class="txtcampos">
                            <asp:DropDownList ID="ddlTipoLogradouro" runat="server" CssClass="bordas" Width="250"
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
                            <asp:TextBox ID="txtLogradouro" runat="server" CssClass="bordas" Text="" Width="250px"></asp:TextBox>
                            *
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--Bairro--%>
                        <div class="nomecampos">
                            Bairro:
                        </div>
                        <div class="txtcampos">
                            <asp:TextBox ID="txtBairro" runat="server" CssClass="bordas" Text="" Width="250px"></asp:TextBox>
                            *
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--Cidade--%>
                        <div class="nomecampos">
                            Cidade:
                        </div>
                        <div class="txtcampos">
                            <asp:TextBox ID="txtCidade" runat="server" CssClass="bordas" Text="" Width="250px"></asp:TextBox>
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
                                <asp:ListItem Value="AP">Amap�</asp:ListItem>
                                <asp:ListItem Value="AM">Amazonas</asp:ListItem>
                                <asp:ListItem Value="BA">Bahia</asp:ListItem>
                                <asp:ListItem Value="CE">Cear�</asp:ListItem>
                                <asp:ListItem Value="DF">Distrito Federal</asp:ListItem>
                                <asp:ListItem Value="ES">Esp�rito Santo</asp:ListItem>
                                <asp:ListItem Value="GO">Goi�s</asp:ListItem>
                                <asp:ListItem Value="MA">Maranh�o</asp:ListItem>
                                <asp:ListItem Value="MT">Mato Grosso</asp:ListItem>
                                <asp:ListItem Value="MS">Mato Grosso do Sul</asp:ListItem>
                                <asp:ListItem Value="MG">Minas Gerais</asp:ListItem>
                                <asp:ListItem Value="PR">Paran�</asp:ListItem>
                                <asp:ListItem Value="PB">Para�ba</asp:ListItem>
                                <asp:ListItem Value="PA">Par�</asp:ListItem>
                                <asp:ListItem Value="PE">Pernambuco</asp:ListItem>
                                <asp:ListItem Value="PI">Piau�</asp:ListItem>
                                <asp:ListItem Value="RJ">Rio de Janeiro</asp:ListItem>
                                <asp:ListItem Value="RN">Rio Grande do Norte</asp:ListItem>
                                <asp:ListItem Value="RS">Rio Grande do Sul</asp:ListItem>
                                <asp:ListItem Value="RR">Roraima</asp:ListItem>
                                <asp:ListItem Value="RO">Rond�nia</asp:ListItem>
                                <asp:ListItem Value="SC">Santa Catarina</asp:ListItem>
                                <asp:ListItem Value="SP">S�o Paulo</asp:ListItem>
                                <asp:ListItem Value="SE">Sergipe</asp:ListItem>
                                <asp:ListItem Value="TO">Tocantins</asp:ListItem>
                            </asp:DropDownList>
                            *
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--Complemento--%>
                        <div class="nomecampos">
                            Complemento:
                        </div>
                        <div class="txtcampos">
                            <asp:TextBox ID="txtComplemento" runat="server" CssClass="bordas" Text="" Width="200px"></asp:TextBox>
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--Numero--%>
                        <div class="nomecampos">
                            N�mero:
                        </div>
                        <div class="txtcampos">
                            <asp:TextBox ID="txtNumero" runat="server" CssClass="bordas" Text="" Width="200px"></asp:TextBox>
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--Bot�es Salvar e Cancelar Localiza��o da �rvore--%>
                        <div class="centroAbas">
                            <asp:Button ID="btEnderecoSalvar" runat="server" CssClass="botoesAba" Text="Salvar"
                                OnClick="btEnderecoSalvar_Click" Width="100px" />
                            <asp:Button ID="btEnderecoCancelar" runat="server" CssClass="botoesAba" Text="Cancelar"
                                OnClick="btEnderecoCancelar_Click" Width="100px" />
                        </div>
                        <div class="limpaDir">
                        </div>
                        <div class="centroAbas" style="margin-left: -10px;">
                            <%--painel confirma��o dados da �rvore--%>
                            <asp:Panel ID="PanelConfirmaEnderecoArvore" runat="server" Visible="false" Width="400px">
                                <div class="alinhaDir">
                                    <asp:Image ID="ImageConfirmaEnderecoArvore" runat="server" ImageUrl="~/images/exclamation32.png" />
                                </div>
                                <div style="padding-top: 14px;">
                                    <asp:Label ID="LabelEnderecoAvoreErro" runat="server" Text="" Font-Bold="true" ForeColor="#CC0000"></asp:Label>
                                    <asp:Label ID="LabelEnderecoAvoreOk" runat="server" Text="" Font-Bold="true" ForeColor="#099409"></asp:Label>
                                </div>
                            </asp:Panel>
                        </div>
                    </asp:Panel>
                    <%--Fim PanelEnderecoArvore--%>
                    <div class="limpaDir">
                    </div>
                </div>
                <%--Fim Div abaEnderecoArvore--%>
                <%--ABA CADASTRAR / ATUALIZAR COORDENADAS DA ARVORE--%>
                <div id="abaCoordenadasArvore">
                    <asp:Panel ID="PanelCoordenadasArvore" runat="server">
                        <div id="colunasDados">
                            <div id="esquerdaDados" style="float: left; width: 360px">
                                <div class="alinhaDir">
                                    <asp:Image ID="Image14" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPeq.PNG" />
                                    <asp:Label ID="Label13" runat="server" EnableViewState="False" Font-Size="14px" Font-Bold="True"
                                        Text="Localiza��o Geogr�fica da �rvore"></asp:Label>
                                </div>
                                <div class="limpaDir">
                                </div>
                                <div class="alinhaDir">
                                    <asp:Image ID="Image16" runat="server" EnableViewState="false" ToolTip="Informa��es para o Cadastro das Goordenadas Geogr�ficas"
                                        ImageUrl="~/images/information32.png" />
                                </div>
                                <div class="alinhaDir" style="padding-top: 10px;">
                                    <asp:Label ID="Label16" runat="server" EnableViewState="False" ForeColor="#099409"
                                        Font-Size="12px" Font-Bold="True" Text="Clique no mapa para preencher a Latitude e<br />a Longitude"></asp:Label>
                                </div>
                                <div class="limpaDir">
                                </div>
                                <br />
                                <%--Latitude--%>
                                <div style="margin-top: 3px; padding-left: 5px; margin-bottom: 5px; font-size: 12px;
                                    font-weight: bold; float: left; position: relative;">
                                    Latitude:
                                </div>
                                <div class="txtcampos">
                                    <asp:TextBox ID="txtLatitude" runat="server" CssClass="lat" Text="" Width="200px"></asp:TextBox>
                                    Ex.: 55.5555555555
                                </div>
                                <div class="limpaDir">
                                </div>
                                <%--Longitude--%>
                                <div style="margin-top: 3px; padding-left: 5px; margin-bottom: 5px; font-size: 12px;
                                    font-weight: bold; float: left; position: relative;">
                                    Longitude:
                                </div>
                                <div class="txtcampos">
                                    <asp:TextBox ID="txtLongitude" runat="server" CssClass="log" Text="" Width="200px"></asp:TextBox>
                                    Ex.: 55.5555555555
                                </div>
                                <div class="limpaDir">
                                </div>
                                <%--Bot�es Salvar e Cancelar Dados Arvore--%>
                                <div style="margin-top: 3px; padding-left: 5px; margin-bottom: 5px; font-size: 12px;
                                    font-weight: bold; float: left; position: relative;">
                                    <asp:Button ID="btCoordenadasSalvar" runat="server" CssClass="botoesAba" Text="Salvar"
                                        Width="100px" OnClick="btCoordenadasSalvar_Click" />
                                    <asp:Button ID="btCoordenadasCancelar" runat="server" CssClass="botoesAba" Text="Cancelar"
                                        Width="100px" OnClick="btCoordenadasCancelar_Click" />
                                </div>
                                <div class="limpaDir">
                                </div>
                                <div style="margin-top: 3px; margin-bottom: 5px; font-size: 12px; font-weight: bold;
                                    float: left; position: relative;">
                                    <%--Painel confirma��o Coordenadas da �rvore--%>
                                    <asp:Panel ID="PanelConfirmaCoordenadas" runat="server" Visible="false" Width="400px">
                                        <div class="alinhaDir">
                                            <asp:Image ID="ImageConfirmaCoordenadas" runat="server" ImageUrl="~/images/exclamarion32.png" />
                                        </div>
                                        <div style="padding-top: 14px;">
                                            <asp:Label ID="LabelCoordenasErro" runat="server" Text="" Font-Bold="true" ForeColor="#CC0000"></asp:Label>
                                            <asp:Label ID="LabelCoordenadasOk" runat="server" Text="" Font-Bold="true" ForeColor="#099409"></asp:Label>
                                        </div>
                                    </asp:Panel>
                                </div>
                                <div class="limpaDir">
                                </div>
                            </div>
                            <%--<div id="direitaDados" style="float: left; width: 550px;"> --%>
                            <div id="direitaDados" style="float: left;">
                                <%--GOOGLE MAPS--%>
                                <%--<div style="margin: 0px 0px; width: 550px; border: solid 1px #000;">--%>
                                    <div style="margin: 0px 0px; border: solid 1px #000;">
                                    <%--<artem:GoogleMap ID="mapa" Width="550" Height="400px" runat="server">
                                    </artem:GoogleMap>--%>
                                    <maps:GMap ID="mapa" runat="server" Key="AIzaSyC9D8SWWpI1csCBdiDAe3xfdOS3oh2bcNw" />
                                </div>
                                <%--FIM GOOGLE MAPS--%>
                            </div>
                            <div class="limpaDir">
                            </div>
                        </div>
                    </asp:Panel>
                    <%--Fim PanelCoordenadasArvore--%>
                </div>
                <%--Fim Div abaCoordenadasArvore--%>
                <%--ABA CADASTRAR / ATUALIZAR ENTORNO DA ARVORE--%>
                <div id="abaEntornoArvore">
                    <asp:Panel ID="PanelEntornoArvore" runat="server">
                        <div class="alinhaDir">
                            <asp:Image ID="Image5" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPeq.PNG" />
                            <asp:Label ID="Label4" runat="server" EnableViewState="False" Font-Bold="True" Text="Entorno da �rvore"></asp:Label>
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--Local da Arvore--%>
                        <div class="nomecampos">
                            Local da �rvore:
                        </div>
                        <div class="txtcampos">
                            <asp:DropDownList ID="ddlLocalArvore" runat="server" CssClass="bordas" Width="250"
                                DataTextField="descLocalEntorno" DataValueField="codLocalEntorno">
                            </asp:DropDownList>
                            *
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--Pavimento--%>
                        <div class="nomecampos">
                            Pavimento:
                        </div>
                        <div class="txtcampos">
                            <asp:DropDownList ID="ddlPavimento" runat="server" CssClass="bordas" Width="250"
                                DataTextField="descPavimento" DataValueField="codPavimento">
                            </asp:DropDownList>
                            *
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--Participa��o--%>
                        <div class="nomecampos">
                            Participa��o:
                        </div>
                        <div class="txtcampos">
                            <asp:DropDownList ID="ddlParticipacao" runat="server" CssClass="bordas" Width="250"
                                DataTextField="descParticipacao" DataValueField="codParticipacao">
                            </asp:DropDownList>
                            *
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--Largura do Passeio--%>
                        <div class="nomecampos">
                            Largura do Passeio:
                        </div>
                        <div class="txtcampos">
                            <asp:TextBox ID="txtLarguraPasseio" runat="server" CssClass="bordas" Text="" Width="180px"></asp:TextBox>
                            * (Em metros)
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--Largura da Rua--%>
                        <div class="nomecampos">
                            Largura da Rua:
                        </div>
                        <div class="txtcampos">
                            <asp:TextBox ID="txtLarguraRua" runat="server" CssClass="bordas" Text="" Width="180px"></asp:TextBox>
                            * (Em metros)
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--Bot�es Salvar e Cancelar Dados Arvore--%>
                        <div class="centroAbas">
                            <asp:Button ID="btEntornoSalvar" runat="server" CssClass="botoesAba" Text="Salvar"
                                OnClick="btEntornoSalvar_Click" Width="100px" />
                            <asp:Button ID="btEntornoCancelar" runat="server" CssClass="botoesAba" Text="Cancelar"
                                OnClick="btEntornoCancelar_Click" Width="100px" />
                        </div>
                        <div class="limpaDir">
                        </div>
                        <div class="centroAbas">
                            <%--Painel confirma��o Entorno da �rvore--%>
                            <asp:Panel ID="PanelConfirmaEntornoArvore" runat="server" Visible="false" Width="400px">
                                <div class="alinhaDir">
                                    <asp:Image ID="ImageConfirmaEntorno" runat="server" ImageUrl="~/images/exclamarion32.png" />
                                </div>
                                <div style="padding-top: 14px;">
                                    <asp:Label ID="LabelEntornoArvoreErro" runat="server" Text="" Font-Bold="true" ForeColor="#CC0000"></asp:Label>
                                    <asp:Label ID="LabelEntornoArvoreOk" runat="server" Text="" Font-Bold="true" ForeColor="#099409"></asp:Label>
                                </div>
                            </asp:Panel>
                        </div>
                        <div class="limpaDir">
                        </div>
                    </asp:Panel>
                    <%--Fim PanelEntornoArvore--%>
                </div>
                <%--Fim Div abaEntornoArvore--%>
                <%--ABA CADASTRAR / ATUALIZAR INTERFERENCIAS DA ARVORE--%>
                <div id="abaInterferenciasArvore">
                    <asp:Panel ID="PanelInterferenciasArvore" runat="server">
                        <div class="alinhaDir">
                            <asp:Image ID="Image12" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPeq.PNG" />
                            <asp:Label ID="Label12" runat="server" EnableViewState="False" Font-Bold="True" Text="Interfer�ncias da �rvore"></asp:Label>
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--Ilumina��o--%>
                        <div class="nomecampos">
                            Ilumina��o:
                        </div>
                        <div class="txtcampos">
                            <asp:DropDownList ID="ddlIluminacao" runat="server" CssClass="bordas" Width="250"
                                DataTextField="descIluminacao" DataValueField="codIluminacao">
                            </asp:DropDownList>
                            *
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--Muro Edifica��o--%>
                        <div class="nomecampos">
                            Muro Edifica��o:
                        </div>
                        <div class="txtcampos">
                            <asp:DropDownList ID="ddlMuroEdificacao" runat="server" CssClass="bordas" Width="250"
                                DataTextField="descMuroEdificacao" DataValueField="codMuroEdificacao">
                            </asp:DropDownList>
                            *
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--Posteamento--%>
                        <div class="nomecampos">
                            Posteamento:
                        </div>
                        <div class="txtcampos">
                            <asp:DropDownList ID="ddlPosteamento" runat="server" CssClass="bordas" Width="250"
                                DataTextField="descPosteamento" DataValueField="codPosteamento">
                            </asp:DropDownList>
                            *
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--Raiz no Pavimento--%>
                        <div class="nomecampos">
                            Raiz no Pavimento:
                        </div>
                        <div class="txtcampos">
                            <asp:DropDownList ID="ddlRaizPavimento" runat="server" CssClass="bordas" Width="250"
                                DataTextField="descRaizPavimento" DataValueField="codRaizPavimento">
                            </asp:DropDownList>
                            *
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--Sinaliza��o--%>
                        <div class="nomecampos">
                            Sinaliza��o:
                        </div>
                        <div class="txtcampos">
                            <asp:DropDownList ID="ddlSinalizacao" runat="server" CssClass="bordas" Width="250"
                                DataTextField="descSinalizacao" DataValueField="codSinalizacao">
                            </asp:DropDownList>
                            *
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--Situacao da Fia��o--%>
                        <div class="nomecampos">
                            Situa��o da Fia��o:
                        </div>
                        <div class="txtcampos">
                            <asp:DropDownList ID="ddlSituacaoFiacao" runat="server" CssClass="bordas" Width="250"
                                DataTextField="descSituacaoFiacao" DataValueField="codSituacaoFiacao">
                            </asp:DropDownList>
                            *
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--Tipo da Fia��o--%>
                        <div class="nomecampos">
                            Tipo da Fia��o:
                        </div>
                        <div class="txtcampos">
                            <asp:DropDownList ID="ddlTipoFiacao" runat="server" CssClass="bordas" Width="250"
                                DataTextField="descTipoFiacao" DataValueField="codTipoFiacao">
                            </asp:DropDownList>
                            *
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--Tr�fego--%>
                        <div class="nomecampos">
                            Tr�fego:
                        </div>
                        <div class="txtcampos">
                            <asp:DropDownList ID="ddlTrafego" runat="server" CssClass="bordas" Width="250" DataTextField="descTrafego"
                                DataValueField="codTrafego">
                            </asp:DropDownList>
                            *
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--Bot�es Salvar e Cancelar Interferencias da Arvore--%>
                        <div class="centroAbas">
                            <asp:Button ID="btInterferenciasSalvar" runat="server" CssClass="botoesAba" Text="Salvar"
                                OnClick="btInterferenciasSalvar_Click" Width="100px" />
                            <asp:Button ID="btInterferenciasCancelar" runat="server" CssClass="botoesAba" Text="Cancelar"
                                OnClick="btInterferenciasCancelar_Click" Width="100px" />
                        </div>
                        <div class="limpaDir">
                        </div>
                        <div class="centroAbas">
                            <%--Painel confirma��o Interferencias da �rvore--%>
                            <asp:Panel ID="PanelConfirmaInterferencias" runat="server" Visible="false" Width="400px">
                                <div class="alinhaDir">
                                    <asp:Image ID="ImageInterferenciaConfirma" runat="server" ImageUrl="~/images/exclamarion32.png" />
                                </div>
                                <div style="padding-top: 14px;">
                                    <asp:Label ID="LabelInterferenciaErro" runat="server" Text="" Font-Bold="true" ForeColor="#CC0000"></asp:Label>
                                    <asp:Label ID="LabelInterferenciaOk" runat="server" Font-Bold="True" ForeColor="#099409"></asp:Label>
                                </div>
                            </asp:Panel>
                        </div>
                        <div class="limpaDir">
                        </div>
                    </asp:Panel>
                    <%--Fim PanelInterferenciasArvore--%>
                </div>
                <%--Fim Div abaInterferenciaArvore--%>
                <%--ABA CADASTRAR / ATUALIZAR IMAGEM DA ARVORE--%>
                <div id="abaImagemArvore">
                    <%--Painel Imagem arvore--%>
                    <asp:Panel ID="PanelImagemArvore" runat="server">
                        <div class="foto">
                            <asp:Image ID="ImageArvore" runat="server" Height="150px" ImageUrl="~/fotos/arvores/semFotoArvore.png"
                                Width="200px" />
                        </div>
                        <div style="margin: 10px 0 10px 10px; cursor: pointer">
                            <asp:Button ID="btAlterarFoto" runat="server" CssClass="botoesAba" Text="Alterar Imagem"
                                Width="180px" OnClick="btAlterarFoto_Click" />
                        </div>
                        <br />
                        <asp:Panel ID="PanelUpload" runat="server">
                            <asp:FileUpload ID="FileUploadFoto" runat="server" />
                            <asp:Label ID="LabelErroUploadFoto" runat="server" ForeColor="#CC0000" Font-Bold="true"
                                Visible="false" Text="Erro!!!"></asp:Label>
                            <div style="padding-top: 5px">
                                <%--Bot�o Enviar e Cancelar--%>
                                <asp:Button ID="btEnviarUpload" runat="server" CssClass="botoesAba" Text="Salvar Imagem"
                                    Width="125px" OnClick="btEnviarUpload_Click" />
                                <asp:Button ID="btCancelarUpload" runat="server" CssClass="botoesAba" Text="Cancelar"
                                    Width="100px" OnClick="btCancelarUpload_Click" />
                            </div>
                        </asp:Panel>
                        <div class="limpaDir">
                        </div>
                    </asp:Panel>
                </div>
                <%--Fim Div abaImagemArvore--%>
            </div>
        </asp:Panel>
        <%--Fim do Panel PanelAdminArvore--%>
    </div>
    <%--Fim Div Abas--%>
    <script type="text/javascript">
        $(document).ready(function () {
            var map = new GMap2(document.getElementById("ctl00_ContentPlaceHolder1_mapa"));
            map.addControl(new GLargeMapControl());
            map.addControl(new GMapTypeControl());
            map.setCenter(new GLatLng(-20.72137287504534, -46.60919524002075), 15);

            GEvent.addListener(map, "click", function (overlay, point) {
                if (overlay) {
                    map.removeOverlay(overlay);
                } else {
                    map.addOverlay(new GMarker(point));
                    $(".lat").val(point.lat());
                    $(".log").val(point.lng());
                }
            });
        });
    </script>
</asp:Content>
