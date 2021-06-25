<%@ Page Language="C#" MasterPageFile="~/admin/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="ANTconsultaSituacaoArvores.aspx.cs" Inherits="admin_consultaSituacaoArvores"
    Title="CV - Consulta Situação Árvores" %>

<%--<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>--%>
<%@ Register Assembly="System.Web.DataVisualization,  Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
   
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
                    Text="Quantidade de Árvores Saudáveis, Doentes e Mortas"></asp:Label>
            </div>
            <div class="botoesDireita">
                <asp:HyperLink ID="HyperLinkImprimir" runat="server" Target="_blank" NavigateUrl="~/admin/imprimirConsArvore.aspx"
                    Font-Bold="True" Font-Size="11pt" ForeColor="#056D00">Imprimir Consulta</asp:HyperLink>
            </div>
            <div class="limpaDir">
            </div>
            <div class="alinhaDir">
                <asp:Image ID="ImageInformacao" runat="server" EnableViewState="false" ToolTip="Informação no cadastro de Ações"
                    ImageUrl="~/images/information32.PNG" />
            </div>
            <div class="alinhaDir" style="padding-top: 14px;">
                <asp:Label ID="LabelAjuda" runat="server" EnableViewState="False" ForeColor="#099409"
                    Font-Size="14px" Font-Bold="True" Text="Para Imprimir a Consulta clique no Link 'Imprimir Consulta' no canto superior direito."></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <div style="margin-left: -8px;">
                <hr />
            </div>
        </asp:Panel>
        <div class="limpaDir">
        </div>
        <br />
        <div style="background-color: #f5f5f5; text-align: center; width: 100%">
            <asp:Chart ID="ChartPizza" runat="server" Height="390px" Width="692px" Palette="None"
                ImageType="Png" BorderDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom"
                BorderWidth="0" BackColor="#D3DFF0" BorderColor="White" BorderlineWidth="0" ToolTip="Quantidade de Árvores Saudáveis, Doentes e Mortas"
                PaletteCustomColors="Green; Yellow; Red">
                <Legends>
                    <asp:Legend IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"
                        Title="Legenda:">
                        <Position Height="28.508997" Width="20.3270626" X="76.1534042" Y="62.70889" />
                    </asp:Legend>
                </Legends>
                <BorderSkin PageColor="Transparent" SkinStyle="Raised" />
                <Titles>
                    <asp:Title BackImageAlignment="Bottom" Font="Microsoft Sans Serif, 14pt, style=Bold"
                        Name="Title1" Text="Quantidade de Árvores Saudáveis, Doentes, Feridas e Mortas">
                    </asp:Title>
                </Titles>
                <Series>
                    <asp:Series ChartArea="ChartAreaPizza" Legend="Default" Name="SeriesPizza" ChartType="Pie">
                        <Points>
                            <asp:DataPoint XValue="1" YValues="20" Label="" LegendText="Saudáveis" LegendToolTip="Quantidade de Árvores Saudáveis"
                                MapAreaAttributes="" ToolTip="Quantidade de Árvores Saudáveis" Url="" />
                            <asp:DataPoint XValue="2" YValues="10" Label="" LegendText="Doentes" LegendToolTip="Quantidade de Árvores Doentes"
                                MapAreaAttributes="" ToolTip="Quantidade de Árvores Doentes" Url="" />
                            <asp:DataPoint XValue="3" YValues="10" Label="" LegendText="Feridas" LegendToolTip="Quantidade de Árvores Feridas"
                                MapAreaAttributes="" ToolTip="Quantidade de Árvores Mortas" Url="" />
                            <asp:DataPoint XValue="4" YValues="10" Label="" LegendText="Mortas" LegendToolTip="Quantidade de Árvores Mortas"
                                MapAreaAttributes="" ToolTip="Quantidade de Árvores Mortas" Url="" />
                        </Points>
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartAreaPizza" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                        BackColor="#D3DFF0" ShadowColor="Transparent" BackGradientStyle="TopBottom">
                        <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                            WallWidth="0" IsClustered="False"></Area3DStyle>
                        <AxisY LineColor="64, 64, 64, 64">
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                        </AxisY>
                        <AxisX LineColor="64, 64, 64, 64">
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>
        <br />
    </div>
</asp:Content>
