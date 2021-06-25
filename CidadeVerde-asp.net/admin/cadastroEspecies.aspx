<%@ Page Language="C#" MasterPageFile="~/admin/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="cadastroEspecies.aspx.cs" Inherits="admin_cadastroEspecies" Title="CV - Administrar Espécies de Árvores" %>

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
        <asp:Panel ID="panelVerEspecies" runat="server">
            <div class="alinhaDir">
                <asp:Image ID="Image1" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                    Height="12px" Width="20px" />
                <asp:Label ID="Label01" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                    Text="Administrar Espécies"></asp:Label>
            </div>
            <%--Botão PanelCadastrarEspecie e Nomes Populares--%>
            <div class="botoesDireita">
                <asp:Button ID="btPanelCadastrarEspecie" runat="server" CssClass="botoes" Text="Cadastrar Espécie"
                    OnClick="btPanelCadastrarEspecie_Click" />
            </div>
            <div class="botoesDireita">
                <asp:HyperLink ID="HyperLinkImprimir" runat="server" CssClass="botoesDireita" Target="_blank"
                    Font-Bold="True" Font-Size="11pt" ToolTip="Clique no link para Exportar Lista de Espécies para o Excel."
                    ForeColor="#056D00">Exportar Lista para o Excel</asp:HyperLink>
            </div>
            <div class="limpaDir">
            </div>
            <div class="alinhaDir">
                <asp:Image ID="ImageAjuda" runat="server" EnableViewState="false" ToolTip="Informações para o Cadastro de Espécies"
                    ImageUrl="~/images/information32.png" />
            </div>
            <div class="alinhaDir" style="padding-top: 14px;">
                <asp:Label ID="LabelAjuda" runat="server" EnableViewState="False" ForeColor="#099409"
                    Font-Size="14px" Font-Bold="True" Text="Para cadastrar uma Espécie clique no botão Cadastrar Espécie. (Do lado direito da tela)"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <div style="margin-left: -8px;">
                <hr />
            </div>
            <div class="alinhaDir" style="padding-top: 18px;">
                <asp:Image ID="Image9" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                <asp:Label ID="Label6" runat="server" EnableViewState="False" Font-Bold="True" Text="Filtrar Espécie -  Selecione um Tipo de Éspécie digite o Nome Científico da Espécie:"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <div class="alinhaDir" style="margin-top: 5px; margin-right: -10px;">
                <asp:Label ID="Label56" runat="server" EnableViewState="False" Font-Bold="True" Text="Situação:"></asp:Label>
            </div>
            <div class="alinhaDir">
                <asp:RadioButtonList ID="rbRecEspecie" runat="server" AutoPostBack="True" RepeatColumns="3"
                    OnSelectedIndexChanged="rbRecEspecie_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="0">Todas</asp:ListItem>
                    <asp:ListItem Value="1">Recomendadas</asp:ListItem>
                    <asp:ListItem Value="2">Não Recomendadas</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="alinhaDir" style="padding-left: 10px; padding-top: 7px;">
                <strong>Ou Nome Científico:</strong>
                <asp:TextBox ID="txtFitroNomeCientifico" runat="server" CssClass="bordas"></asp:TextBox>
                <asp:Button ID="btFiltrar" runat="server" Text="Filtrar" CssClass="botoes" Height="22px"
                    Width="80px" OnClick="btFiltrar_Click" />
            </div>
            <div class="botoesDireita" style="padding-top: 8px;">
                <asp:Label ID="Label14" runat="server" EnableViewState="False" Font-Bold="True" Text="Mostrar:"></asp:Label>
                <asp:DropDownList ID="ddlMostrarEspecie" runat="server" CssClass="bordas" Width="60"
                    AutoPostBack="True" OnSelectedIndexChanged="ddlMostrarEspecie_SelectedIndexChanged">
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
                <asp:Label ID="Label7" runat="server" EnableViewState="False" Font-Bold="True" Text="Lista de Espécies"></asp:Label>
            </div>
            <div class="alinhaDir" style="float: right; padding-right: 10px;">
                <asp:Image ID="Image10" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                <asp:Label ID="Label8" runat="server" EnableViewState="False" Font-Bold="True" Text="Espécies Recomendadas para Arborização Urbana:"></asp:Label>
                <asp:Image ID="Image11" runat="server" EnableViewState="false" ImageUrl="~/images/positivo.png" />
                <asp:Label ID="Label5" runat="server" EnableViewState="False" Font-Bold="True" Text="Recomendadas"></asp:Label>
                <asp:Image ID="Image12" runat="server" EnableViewState="false" ImageUrl="~/images/negativo.png" />
                <asp:Label ID="Label10" runat="server" EnableViewState="False" Font-Bold="True" Text="Não Recomendadas"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <asp:GridView ID="GridViewEspecies" runat="server" BackColor="White" AutoGenerateColumns="False"
                BorderColor="#0D5600" Width="100%" HorizontalAlign="Center" CellPadding="2" AllowPaging="True"
                BorderStyle="Double" BorderWidth="3px" GridLines="Vertical" OnRowDataBound="GridViewEspecies_RowDataBound"
                OnRowCommand="GridViewEspecies_RowCommand" OnPageIndexChanging="GridViewEspecies_PageIndexChanging"
                AllowSorting="True" OnSorting="GridViewEspecies_Sorting">
                <RowStyle BackColor="#ffffff" />
                <Columns>
                    <asp:BoundField DataField="codEspecie" SortExpression="codEspecie" HeaderText="codEspecie">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nRecArborizacaoUrbana" SortExpression="nRecArborizacaoUrbana"
                        HeaderText="Rec.">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40px" />
                    </asp:BoundField>
                    <%--<asp:TemplateField HeaderText="Rec.">
                        <ItemTemplate>
                            <asp:Image ID="ImageRecEspecie" runat="server" Height="16px" Width="16px" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                    </asp:TemplateField>--%>
                    <asp:BoundField DataField="nRecArborizacaoUrbana" SortExpression="nRecArborizacaoUrbana"
                        HeaderText="Rec.">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="sNomeCientifico" SortExpression="sNomeCientifico" HeaderText="Nome Científico">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="codGenero" SortExpression="codGenero" HeaderText="codGenero">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="descGenero" SortExpression="descGenero" HeaderText="Gênero">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="sClima" SortExpression="sClima" HeaderText="Clima">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="sEpocaFloracao" SortExpression="sEpocaFloracao" HeaderText="Época da Floração">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="descFormaCopa" SortExpression="descFormaCopa" HeaderText="Forma da Copa">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nAlturaMedia" SortExpression="nAlturaMedia" HeaderText="Altura Média">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Link" CommandName="verDetEspecie" Text='<img alt="" title="Clique aqui para Ver Detalhes e / ou Editar a Espécie.Clique também para Visualizar os Nomes Populares da Espécie e / ou Editá-los" src="../images/editar.png" style="border: 0px" />'>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </asp:ButtonField>
                    <asp:ButtonField ButtonType="Link" CommandName="excluirEspecie" Text='<img alt="" title="Clique aqui para Excluir a Espécie." src="../images/excluir.png" style="border: 0px" />'>
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
                                    Nenhuma Espécie Encontrada.
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
        <asp:Panel ID="PanelAdminEspecie" runat="server" Visible="false">
            <div class="alinhaDir">
                <asp:Image ID="Image2" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />
                <asp:Label ID="LabelCadEspecie" runat="server" EnableViewState="False" Font-Bold="True"
                    Font-Size="14px" Text="Administrar Espécie e seus Nomes Populares"></asp:Label>
            </div>
            <%--Botão PanelCadastrarArvore--%>
            <div class="botoesDireita">
                <asp:Button ID="btVoltarTelaListaEspecies" runat="server" CssClass="botoes" Text="Voltar"
                    Width="100px" OnClick="btVoltarTelaListaEspecies_Click" />
            </div>
            <div class="limpaDir">
            </div>
            <div class="alinhaDir">
                <asp:Image ID="ImageInstrucoes" runat="server" EnableViewState="true" ToolTip="Instruções para Cadastro"
                    ImageUrl="~/images/information32.png" />
            </div>
            <div class="alinhaDir" style="padding-top: 14px;">
                <asp:Label ID="LabelInstrucoes" runat="server" ForeColor="#099409" Font-Size="14px"
                    Font-Bold="True" Text="Preencha os Dados da Espécie e clique em &quot;Salvar&quot;. Clique na aba &quot;Nomes Populares&quot; e cadastre os mesmos."></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <br />
            <div id="abas">
                <%--TITULOS DE ABAS--%>
                <ul>
                    <li><a href="#abaDadosEspecie"><span>Dados da Espécie</span></a></li>
                    <li><a href="#abaImagemEspecie"><span>Imagem da Espécie</span></a></li>
                    <li><a href="#abaNomesComuns"><span>Nomes Populares</span></a></li>
                </ul>
                <%--ABA CADASTRAR / ATUALIZAR DADOS DA ARVORE--%>
                <div id="abaDadosEspecie">
                    <asp:Panel ID="PanelDadosEspecie" runat="server" Visible="true">
                        <div class="alinhaDir">
                            <asp:Image ID="Image3" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPeq.PNG" />
                            <asp:Label ID="Label2" runat="server" EnableViewState="False" Font-Size="14px" Font-Bold="True"
                                Text="Cadastro Dados da Espécie"></asp:Label>
                        </div>
                        <div class="limpaDir">
                        </div>
                        <div id="colunasDados">
                            <div id="esquerdaDados" style="float: left; width: 450px">
                                <%--Gênero--%>
                                <div class="nomecamposA">
                                    Gênero:
                                </div>
                                <div class="txtcamposA">
                                    <asp:DropDownList ID="ddlGenero" runat="server" CssClass="bordas" Width="250px" AutoPostBack="True"
                                        DataTextField="descGenero" DataValueField="codGenero" OnSelectedIndexChanged="ddlGenero_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    *
                                </div>
                                <div class="limpaDir">
                                </div>
                                <%--Nome Científico da Espécie--%>
                                <div class="nomecamposA">
                                    Nome Científico:
                                </div>
                                <div class="txtcamposA">
                                    <asp:TextBox ID="txtNomeCientfico" runat="server" CssClass="bordas" Text="" Width="250px"></asp:TextBox>
                                    *
                                </div>
                                <div class="limpaDir">
                                </div>
                                <%--Clima--%>
                                <div class="nomecamposA">
                                    Clima:
                                </div>
                                <div class="txtcamposA">
                                    <asp:TextBox ID="txtClima" runat="server" CssClass="bordas" Text="" Width="250px"></asp:TextBox>
                                    *
                                </div>
                                <div class="limpaDir">
                                </div>
                                <%--Cor da Flor--%>
                                <div class="nomecamposA">
                                    Cor da Flor:
                                </div>
                                <div class="txtcamposA">
                                    <asp:TextBox ID="txtCorFlor" runat="server" CssClass="bordas" Text="" Width="250px"></asp:TextBox>
                                    *
                                </div>
                                <div class="limpaDir">
                                </div>
                                <%--Epoca Floração--%>
                                <div class="nomecamposA">
                                    Época Floração:
                                </div>
                                <div class="txtcamposA">
                                    <asp:TextBox ID="txtEpocaFloracao" runat="server" CssClass="bordas" Text="" Width="250px"></asp:TextBox>
                                    *
                                </div>
                                <div class="limpaDir">
                                </div>
                                <%--Propagação--%>
                                <div class="nomecamposA">
                                    Propagação:
                                </div>
                                <div class="txtcamposA">
                                    <asp:TextBox ID="txtPropagacao" runat="server" CssClass="bordas" Text="" Width="250px"></asp:TextBox>
                                    *
                                </div>
                                <div class="limpaDir">
                                </div>
                                <%--Ogirem--%>
                                <div class="nomecamposA">
                                    Origem:
                                </div>
                                <div class="txtcamposA">
                                    <asp:TextBox ID="txtOrigem" runat="server" CssClass="bordas" Text="" Width="250px"></asp:TextBox>
                                    *
                                </div>
                                <div class="limpaDir">
                                </div>
                            </div>
                            <div id="direitaDados" style="float: left; width: 450px">
                                <%--Altura Media--%>
                                <div class="nomecamposA">
                                    Altura Média:
                                </div>
                                <div class="txtcamposA">
                                    <asp:TextBox ID="txtAlturaMedia" runat="server" CssClass="bordas" Text="" Width="170px"></asp:TextBox>
                                    * (Em metros)
                                </div>
                                <div class="limpaDir">
                                </div>
                                <%--Observação--%>
                                <div class="nomecamposA">
                                    Observação:
                                </div>
                                <div class="txtcamposA">
                                    <asp:TextBox ID="txtObs" runat="server" CssClass="bordas" Text="" TextMode="MultiLine"
                                        Width="250px" Height="80px"></asp:TextBox>
                                </div>
                                <div class="limpaDir">
                                </div>
                                <%--Tipo Raiz--%>
                                <div class="nomecamposA">
                                    Tipo da Raiz:
                                </div>
                                <div class="txtcamposA">
                                    <asp:DropDownList ID="ddlTipoRaiz" runat="server" CssClass="bordas" Width="250" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlTipoRaiz_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="0">Selecione um Tipo de Raiz</asp:ListItem>
                                        <asp:ListItem Value="1">Fasciculadas</asp:ListItem>
                                        <asp:ListItem Value="2">Pivotantes</asp:ListItem>
                                    </asp:DropDownList>
                                    *
                                </div>
                                <div class="limpaDir">
                                </div>
                                <%--Forma da Copa--%>
                                <div class="nomecamposA">
                                    Forma da Copa:
                                </div>
                                <div class="txtcamposA">
                                    <asp:DropDownList ID="ddlFormaCopa" runat="server" DataTextField="descFormaCopa"
                                        DataValueField="codFormaCopa" CssClass="bordas" Width="250" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlFormaCopa_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    *
                                </div>
                                <div class="limpaDir">
                                </div>
                                <%--Recomendada Arborização Urbana--%>
                                <div class="nomecamposA">
                                    Rec. Arboriza. Urbana:
                                </div>
                                <div class="txtcamposA">
                                    <asp:DropDownList ID="ddlRecArborizacaoUrbana" runat="server" CssClass="bordas" Width="100"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlRecArborizacaoUrbana_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="1">Sim</asp:ListItem>
                                        <asp:ListItem Value="2">Não</asp:ListItem>
                                    </asp:DropDownList>
                                    *
                                </div>
                                <div class="limpaDir">
                                </div>
                            </div>
                            <div class="limpaDir">
                            </div>
                        </div>
                        <%--Botão Salvar e Cancelar Dados da Especie--%>
                        <div class="botoesCentroA" style="margin-top: 10px;">
                            <asp:Button ID="btEspecieSalvar" runat="server" CssClass="botoesAba" Text="Salvar"
                                Width="100px" OnClick="btEspecieSalvar_Click" />
                            <asp:Button ID="btEspecieCancelar" runat="server" CssClass="botoesAba" Text="Cancelar"
                                Width="100px" OnClick="btEspecieCancelar_Click" />
                        </div>
                        <div class="limpaDir">
                        </div>
                        <div class="botoesCentroA">
                            <%--painel confirmação dados da especie--%>
                            <asp:Panel ID="PanelConfirmaEspecie" runat="server" Width="400px" Visible="false">
                                <div class="alinhaDir">
                                    <asp:Image ID="ImageConfirmaEspecie" runat="server" ImageUrl="~/images/exclamation32.png" />
                                </div>
                                <div style="padding-top: 14px;">
                                    <asp:Label ID="LabelConfirmaEspecieErro" runat="server" Text="" Font-Bold="true"
                                        ForeColor="#CC0000"></asp:Label>
                                    <asp:Label ID="LabelConfirmaEspecieOk" runat="server" Text="" Font-Bold="true" ForeColor="#099409"></asp:Label>
                                </div>
                            </asp:Panel>
                        </div>
                    </asp:Panel>
                    <%--Fim Panel Dados Especie--%>
                    <div class="limpaDir">
                    </div>
                </div>
                <%--Fim Div abaEspecie--%>
                <%--ABA CADASTRAR / ATUALIZAR IMAGEM DA ESPÉCIE--%>
                <div id="abaImagemEspecie">
                    <%--Painel Imagem Especie--%>
                    <asp:Panel ID="PanelImagemEspecie" runat="server">
                        <div class="foto">
                            <asp:Image ID="ImageEspecie" runat="server" Height="150px" ImageUrl="~/fotos/arvores/semFotoArvore.png"
                                Width="200px" />
                        </div>
                        <div style="margin: 10px 0 10px 10px; cursor: pointer">
                            <asp:Button ID="btAlterarFoto" runat="server" CssClass="botoesAba" Text="Alterar Imagem"
                                Width="180px" OnClick="btAlterarFoto_Click" />
                        </div>
                        <br />
                        <asp:Panel ID="PanelUpload" runat="server" Visible="false">
                            <asp:FileUpload ID="FileUploadFoto" runat="server" />
                            <asp:Label ID="LabelErroUploadFoto" runat="server" ForeColor="#CC0000" Font-Bold="true"
                                Visible="false" Text="Erro!!!"></asp:Label>
                            <div style="padding-top: 5px">
                                <%--Botão Enviar e Cancelar--%>
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
                <%--Fim Div abaImagemEspecie--%>
                <%--ABA CADASTRAR / ATUALIZAR LOCALIZAÇAO DA ESPECIE--%>
                <div id="abaNomesComuns">
                    <asp:Panel ID="PanelNomesComuns" runat="server" Visible="true">
                        <div class="alinhaDir">
                            <asp:Image ID="Image4" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                                Height="12px" Width="20px" />
                            <asp:Label ID="Label3" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                                Text="Administrar Nomes Populares"></asp:Label>
                        </div>
                        <div class="limpaDir">
                        </div>
                        <div class="alinhaDir">
                            <asp:Image ID="Image5" runat="server" EnableViewState="false" ToolTip=" Informações para realização de Cadastro de Nomes Populares"
                                ImageUrl="~/images/information32.png" />
                        </div>
                        <div class="alinhaDir" style="padding-top: 14px;">
                            <asp:Label ID="Label4" runat="server" EnableViewState="False" ForeColor="#099409"
                                Font-Size="14px" Font-Bold="True" Text=" Digite o Nome Popular e clique em 'Salvar'. Para editar clique em 'Editar'."></asp:Label>
                        </div>
                        <div class="limpaDir">
                        </div>
                        <div class="alinhaDir" style="padding-top: 18px;">
                            <asp:Image ID="Image6" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                            <asp:Label ID="LabelNomesComunsTitulo" runat="server" EnableViewState="False" Font-Bold="True"
                                Text=" Cadastro de Nomes Populares:"></asp:Label>
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--Descrição de Nomes Populares--%>
                        <div class="nomecampos">
                            Nome Popular:
                        </div>
                        <div class="txtcampos">
                            <asp:TextBox ID="txtNomePopular" runat="server" CssClass="bordas" Text="" Width="250px"></asp:TextBox>
                        </div>
                        <div class="limpaDir">
                        </div>
                        <%--Botões Salvar e Cancelar Nomes Populares--%>
                        <div class="centroAbas">
                            <asp:Button ID="btSalvarNomePopular" runat="server" CssClass="botoes" Text="Salvar"
                                Width="100px" OnClick="btSalvarNomePopular_Click" />
                            <asp:Button ID="btCancelarNomePopular" runat="server" CssClass="botoes" Text="Cancelar"
                                Width="100px" OnClick="btCancelarNomePopular_Click" />
                        </div>
                        <div class="limpaDir">
                        </div>
                        <div class="centroAbas">
                            <asp:Panel ID="PanelConfirmaNomesComuns" runat="server" Visible="false">
                                <div class="alinhaDir" style="margin-left: -30px;">
                                    <asp:Image ID="ImageConfirmaNomesComuns" runat="server" ImageUrl="~/images/confirmation32.png" />
                                </div>
                                <div style="padding-top: 14px; width: 300px;">
                                    <asp:Label ID="LabelErroNomesComuns" runat="server" Text="" Font-Bold="true" ForeColor="#CC0000"></asp:Label>
                                    <asp:Label ID="LabelOkNomesComuns" runat="server" Text="" Font-Bold="true" ForeColor="#099409"></asp:Label>
                                </div>
                            </asp:Panel>
                        </div>
                        <div class="limpaDir">
                        </div>
                        <div style="margin-left: -8px;">
                            <hr />
                        </div>
                        <div class="alinhaDir" style="padding-top: 18px;">
                            <asp:Image ID="Image8" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                            <asp:Label ID="Label9" runat="server" EnableViewState="False" Font-Bold="True" Text=" Lista de Nomes Populares:"></asp:Label>
                        </div>
                        <div class="limpaDir">
                        </div>
                        <div class="alinhaDir" style="padding-left: 30px;">
                            <asp:GridView ID="GridViewNomesPopulares" runat="server" BackColor="White" AutoGenerateColumns="False"
                                BorderColor="#0D5600" Width="400px" HorizontalAlign="Center" CellPadding="2"
                                AllowPaging="True" BorderStyle="Double" BorderWidth="3px" GridLines="Vertical"
                                OnPageIndexChanging="GridViewNomesPopulares_PageIndexChanging" OnRowCommand="GridViewNomesPopulares_RowCommand"
                                OnRowDataBound="GridViewNomesPopulares_RowDataBound">
                                <%--OnRowDataBound="GridViewNomesComuns_RowDataBound" OnPageIndexChanging="GridViewNomesComuns_PageIndexChanging"
                                OnRowCommand="GridViewNomesComuns_RowCommand">--%>
                                <RowStyle BackColor="#ffffff" />
                                <Columns>
                                    <asp:BoundField DataField="codNomeComum" SortExpression="codNomeComum" HeaderText="codNomeComum">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="descNomeComum" SortExpression="descNomeComum" HeaderText="Nome Popular">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="codEspecie" SortExpression="codEspecie" HeaderText="codEspecie">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:ButtonField ButtonType="Link" CommandName="editarNomePopular" Text='<img alt="" title="Editar Nome Popular" src="../images/editar.png" style="border: 0px" />'>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                                    </asp:ButtonField>
                                    <asp:ButtonField ButtonType="Link" CommandName="excluirNomePopular" Text='<img alt="" title="Excluir Nome Popular" src="../images/excluir.png" style="border: 0px" />'>
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
                                                    Nenhum Nome Popular Encontrado.
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </EmptyDataTemplate>
                                <AlternatingRowStyle BackColor="#d5d5d5" />
                                <HeaderStyle BackColor="#099409" ForeColor="White" />
                                <PagerStyle BackColor="#099409" ForeColor="White" />
                            </asp:GridView>
                        </div>
                        <div class="limpaDir">
                        </div>
                    </asp:Panel>
                    <%--Fim PanelNomesComuns--%>
                    <div class="limpaDir">
                    </div>
                </div>
            </div>
            <%--Fim Div abaNomesComuns--%>
        </asp:Panel>
    </div>
</asp:Content>
