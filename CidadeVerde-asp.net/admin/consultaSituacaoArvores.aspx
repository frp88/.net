<%@ Page Language="C#" MasterPageFile="~/admin/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="consultaSituacaoArvores.aspx.cs" Inherits="admin_consultaSituacaoArvores"
    Title="CV - Consulta Situação Árvores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="conteudo">
        <div style="background-color: #f5f5f5; margin: -10px -10px -10px -10px;">
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
                        Text="Quantidade de Árvores Saudáveis, Doentes, Injuriadas e Mortas"></asp:Label>
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
                <div class="botoesDireita">
                    <asp:HyperLink ID="HyperLinkImprimir" runat="server" Target="_blank" NavigateUrl="~/admin/imprimirConsArvore.aspx"
                        Font-Bold="True" Font-Size="11pt" ForeColor="#056D00">Imprimir Consulta</asp:HyperLink>
                </div>
                <div class="limpaDir">
                </div>
                <hr />
            </asp:Panel>
            <div class="limpaDir">
            </div>
            <br />
        </div>
        <div style="background-color: #f5f5f5; text-align: center; margin: -10px -10px 0 -10px;
            padding: 10px 0 10px 0;">
            <asp:Chart ID="ChartPizza" runat="server" Height="390px" Width="690px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)"
                BorderDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2px" BackColor="211, 223, 240"
                BorderColor="#1A3B69" AlternateText="Situações das Árvores" BorderlineColor=""
                BackImageAlignment="Top">
                <Legends>
                    <asp:Legend BackColor="64, 165, 191, 228" Name="LegendArvores" Alignment="Center"
                        Title="Legenda:">
                    </asp:Legend>
                </Legends>
                <BorderSkin SkinStyle="Emboss" PageColor="246, 246, 246"></BorderSkin>
                <Titles>
                    <asp:Title Font="Microsoft Sans Serif, 14pt, style=Bold" Name="Title1" Text="Quantidade de Árvores Saudáveis, Doentes, Injuriadas e Mortas">
                    </asp:Title>
                </Titles>
                <Series>
                    <asp:Series Name="Sites" BorderColor="180, 26, 59, 105" ChartArea="ChartAreaUsuarios"
                        ChartType="Pie" Legend="LegendArvores" ToolTip="#VALX - #VALY usuários" XValueMember="key"
                        YValueMembers="value" LegendToolTip="#VALX - #VALY usuários" Label=" " LegendText="#VALX"
                        Palette="BrightPastel">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartAreaUsuarios" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                        BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent"
                        BackGradientStyle="TopBottom">
                        <AxisY2 Enabled="True">
                        </AxisY2>
                        <Area3DStyle Rotation="10" Perspective="10" Inclination="50" IsRightAngleAxes="False"
                            WallWidth="0" IsClustered="False" Enable3D="True" LightStyle="Realistic"></Area3DStyle>
                        <AxisY LineColor="64, 64, 64, 64">
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                        </AxisY>
                        <AxisX LineColor="64, 64, 64, 64" Interval="1">
                            <MajorTickMark Interval="1" />
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>
    </div>
</asp:Content>
