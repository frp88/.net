<%@ Page Language="C#" AutoEventWireup="true" CodeFile="imprimirConsArvore.aspx.cs"
    Inherits="imprimirConsArvore" Title="CV - Imprimir Consulta Árvores" %>

<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CV - Relatório da Quantidade de Árvores Saudáveis, Doentes, Injuriadas e Mortas
    </title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="float: left;">
        <asp:Image ID="Image1" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />
        <asp:Label ID="Label01" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="18px"
            Text="Quantidade de Árvores Saudáveis, Doentes, Injuriadas e Mortas"></asp:Label>
    </div>
    <div style="clear: left;">
    </div>
    <br />
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
    </form>
</body>
</html>
