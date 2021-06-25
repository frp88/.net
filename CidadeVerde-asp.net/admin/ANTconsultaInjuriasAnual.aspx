<%@ Page Language="C#" MasterPageFile="~/admin/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="ANTconsultaInjuriasAnual.aspx.cs" Inherits="admin_consultaInjuriasAnual"
    Title="CV - Consulta Injúrias Anual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="background-color: #f5f5f5; text-align: center; width: 100%">
        <br />
        <div style="float: left; padding-left: 200px; padding-top: 2px;">
            <asp:Label ID="LabelAjuda" runat="server" EnableViewState="False" Font-Size="12px"
                Font-Bold="True" Text="Selecione o ano: "></asp:Label>
        </div>
        <div style="float: left; padding-left: 10px;">
            <asp:DropDownList ID="ddlAno" runat="server" CssClass="bordas" Width="60" OnSelectedIndexChanged="ddlAno_SelectedIndexChanged"
                AutoPostBack="True" DataTextField="ano" DataValueField="ano">
                <asp:ListItem Selected="True" Value="2009">2009</asp:ListItem>
                <asp:ListItem Value="2010">2010</asp:ListItem>
                <asp:ListItem Value="2011">2011</asp:ListItem>
            </asp:DropDownList>
        </div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/pensando.gif" />
                <img src="~/images/loading_pequeno.gif" />
                Carregando dados...
            </ProgressTemplate>
        </asp:UpdateProgress>
        <div class="limpaDir">
        </div>
        <br />
        <%--*** FIM DO GRAFICO DE INJÚRIAS ***--%>
        <asp:Chart ID="ChartArvores" runat="server" Height="400px" Width="660px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)"
            BorderDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2px" BackColor="211, 223, 240"
            BorderColor="White" AlternateText="Quantidade Total de Árvores Injuriadas e Recuperadas"
            BorderlineColor="" BackSecondaryColor="White">
            <Legends>
                <asp:Legend BackColor="248, 249, 251" Docking="Bottom" Title="Legenda:" Name="Default"
                    IsTextAutoFit="False" TableStyle="Tall" TitleAlignment="Near">
                </asp:Legend>
            </Legends>
            <BorderSkin SkinStyle="Emboss" PageColor="246, 246, 246"></BorderSkin>
            <Annotations>
                <asp:TextAnnotation Font="Microsoft Sans Serif, 10pt, style=Bold" Name="AnnotationTotalInjurias"
                    Text="" X="68" Y="84">
                </asp:TextAnnotation>
            </Annotations>
            <Titles>
                <asp:Title BackImageAlignment="Bottom" Font="Microsoft Sans Serif, 12pt, style=Bold"
                    Name="TitleTitulo" Text="Quantidade Total de Árvores Injuriadas e Recuperadas  no ano de">
                </asp:Title>
                <asp:Title Docking="Bottom" Font="Microsoft Sans Serif, 10pt, style=Bold" Name="TitleMeses"
                    Text="Meses">
                    <Position Height="6" Width="90.96093" X="5.519537" Y="76.59719" />
                </asp:Title>
                <asp:Title Docking="Left" Font="Microsoft Sans Serif, 10pt, style=Bold" Name="TitleQuantArvores"
                    Text="Quant. de Árvores" TextOrientation="Rotated270">
                    <Position Height="72.81598" Width="2.50235281" X="2.519537" Y="15.4847889" />
                </asp:Title>
            </Titles>
            <Series>
                <asp:Series ChartArea="ChartArea1" Legend="Default" LegendText="Árvores Injuriadas:  #TOTAL"
                    LegendToolTip="Quantidade total de árvores Injuriadas no ano: #TOTAL" Name="Injurias"
                    XValueType="String" Label="#VAL" Color="Orange">
                </asp:Series>
                <asp:Series ChartArea="ChartArea1" Legend="Default" LegendText="Árvores Recuperadas:  #TOTAL"
                    LegendToolTip="Quantidade total de árvores recuperadas no ano: #TOTAL" Name="recuperadas"
                    Label="#VAL" Color="Green">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                    BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
                    <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                        WallWidth="0" IsClustered="False"></Area3DStyle>
                    <AxisY LineColor="64, 64, 64, 64">
                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                        <MajorGrid LineColor="64, 64, 64, 64" />
                    </AxisY>
                    <AxisX LineColor="64, 64, 64, 64">
                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                        <MajorGrid LineColor="64, 64, 64, 64" />
                        <CustomLabels>
                            <asp:CustomLabel FromPosition="2" Text="Jan" />
                            <asp:CustomLabel FromPosition="4" Text="Fev" />
                            <asp:CustomLabel FromPosition="6" Text="Mar" />
                            <asp:CustomLabel FromPosition="8" Text="Abr" />
                            <asp:CustomLabel FromPosition="10" Text="Mai" />
                            <asp:CustomLabel FromPosition="12" Text="Jun" />
                            <asp:CustomLabel FromPosition="14" Text="Jul" />
                            <asp:CustomLabel FromPosition="16" Text="Ago" />
                            <asp:CustomLabel FromPosition="18" Text="Set" />
                            <asp:CustomLabel FromPosition="20" Text="Out" />
                            <asp:CustomLabel FromPosition="22" Text="Nov" />
                            <asp:CustomLabel FromPosition="24" Text="Dez" />
                        </CustomLabels>
                    </AxisX>
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <%--*** FIM DO GRAFICO DE INJURIAS ***--%>
        <br />
    </div>
</asp:Content>
