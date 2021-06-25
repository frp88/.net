<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="arborizacaoUrbana.aspx.cs" Inherits="arborizacaoUrbana" Title="Cidade Verde - Arborização Urbana" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="conteudo">
        <div id="verEspecies">
            <asp:Panel ID="panelVerEspecies" runat="server">
                <div class="alinhaDir" style="margin-top: 20px;">
                    <asp:Image ID="Image1" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                        Height="12px" Width="20px" />
                    <asp:Label ID="Label01" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                        Text="Espécies Recomendadas e Não Recomendadas para a Arborização Urbana"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir">
                    <asp:Image ID="ImageAjuda" runat="server" EnableViewState="false" ToolTip="Informações sobre a visualização das Espécies Recomendadas / Espécies Não Recomendadas para a Arborização Urbana."
                        ImageUrl="~/images/information32.png" />
                </div>
                <div class="alinhaDir" style="padding-top: 14px;">
                    <asp:Label ID="LabelAjuda" runat="server" EnableViewState="False" ForeColor="#099409"
                        Font-Size="14px" Font-Bold="True" Text="Clique nas Abas abaixo para visualizar as Espécies Recomendadas / Espécies Não Recomendadas"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div style="margin-left: -10px; margin-right: -10px;">
                    <hr />
                </div>
            </asp:Panel>
        </div>
        <div id="adminEspecie" style="margin-bottom: 3px;">
            <asp:Panel ID="PanelAdminEspecie" runat="server">
                <div id="abas">
                    <%--TITULOS DE ABAS--%>
                    <ul>
                        <li>&nbsp;</li>
                        <li><a href="#abaEspecieRecomendada"><span>Espécies Recomendadas</span></a></li>
                        <li><a href="#abaEspecieNaoRecomendadaa"><span>Espécies Não Recomendadas</span></a></li>
                    </ul>
                    <%--ABA Espécies RECOMENDADAS--%>
                    <div id="abaEspecieRecomendada">
                        <asp:Panel ID="PanelEspeciesRecomendadas" runat="server" Visible="true">
                            <div class="alinhaDir">
                                <asp:Image ID="Image3" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPeq.PNG" />
                                <asp:Label ID="Label2" runat="server" EnableViewState="False" Font-Size="12px" Font-Bold="True"
                                    Text="Espécies Recomendadas"></asp:Label>
                            </div>
                            <div class="limpaDir">
                            </div>
                            <br />
                            <asp:GridView ID="GridViewEspeciesRecomendadas" runat="server" BackColor="White"
                                AutoGenerateColumns="False" Width="100%" HorizontalAlign="Center" GridLines="Both"
                                CellPadding="5" OnRowDataBound="GridViewEspeciesRecomendadas_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="codEspecie" SortExpression="codEspecie" HeaderText="codEspecie">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nImagem" SortExpression="nImagem" HeaderText="nImagem">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Imagem">
                                        <ItemTemplate>
                                            <asp:Image ID="ImageEspecie" runat="server" CssClass="screenshot" Height="90px" Width="120px" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="nomePopular" SortExpression="nomePopular" HeaderText="Nome Popular">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="sNomeCientifico" SortExpression="sNomeCientifico" HeaderText="Nome Científico">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nAlturaMedia" SortExpression="nAlturaMedia" HeaderText="Altura Média">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="codGenero" SortExpression="codGenero" HeaderText="codGenero">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="descGenero" SortExpression="descGenero" HeaderText="Gênero">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="sClima" SortExpression="sClima" HeaderText="Clima">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="sObs" SortExpression="sObs" HeaderText="Observações">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
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
                                <HeaderStyle BackColor="#099409" ForeColor="White" />
                                <PagerStyle BackColor="#099409" ForeColor="White" Height="20px" />
                            </asp:GridView>
                            <div class="limpaDir">
                            </div>
                        </asp:Panel>
                    </div>
                    <%--FIM Espécies RECOMENDADAS--%>
                    <%--ABA Espécies NÃO RECOMENDADAS--%>
                    <div id="abaEspecieNaoRecomendadaa">
                        <asp:Panel ID="PanelEspecieNaoRecomendada" runat="server" Visible="true">
                            <div class="alinhaDir">
                                <asp:Image ID="Image4" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPeq.PNG" />
                                <asp:Label ID="Label3" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="12px"
                                    Text="Espécies Não Recomendadas"></asp:Label>
                            </div>
                            <div class="limpaDir">
                            </div>
                            <br />
                            <asp:GridView ID="GridViewEspeciesNaoRecomendadas" runat="server" BackColor="White"
                                AutoGenerateColumns="False" Width="100%" HorizontalAlign="Center" GridLines="Both"
                                CellPadding="5" OnRowDataBound="GridViewEspeciesNaoRecomendadas_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="codEspecie" SortExpression="codEspecie" HeaderText="codEspecie">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nImagem" SortExpression="nImagem" HeaderText="nImagem">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Imagem">
                                        <ItemTemplate>
                                            <asp:Image ID="ImageEspecie" runat="server" CssClass="screenshot" Height="90" Width="120" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="nomePopular" SortExpression="nomePopular" HeaderText="Nome Popular">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="sNomeCientifico" SortExpression="sNomeCientifico" HeaderText="Nome Científico">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nAlturaMedia" SortExpression="nAlturaMedia" HeaderText="Altura Média">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="codGenero" SortExpression="codGenero" HeaderText="codGenero">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="descGenero" SortExpression="descGenero" HeaderText="Gênero">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="sClima" SortExpression="sClima" HeaderText="Clima">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="sObs" SortExpression="sObs" HeaderText="Observações">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
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
                                <HeaderStyle BackColor="#099409" ForeColor="White" />
                                <PagerStyle BackColor="#099409" ForeColor="White" Height="20px" />
                            </asp:GridView>
                            <div class="limpaDir">
                            </div>
                        </asp:Panel>
                        <%--Fim PanelEspecieNaoRecomendada--%>
                        <div class="limpaDir">
                        </div>
                    </div>
                </div>
                <%--FIM ABA Espécies NÃO RECOMENDADAS--%>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
