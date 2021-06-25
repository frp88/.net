<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="arvoresGoogleMaps.aspx.cs" Inherits="arvoresGoogleMaps" Title="Cidade Verde - �rvores no Google Maps" %>

<%--<%@ Register Assembly="Artem.GoogleMap" Namespace="Artem.Web.UI.Controls" TagPrefix="artem" %>--%>
<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="maps" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="conteudo">
        <!--CHAMAR PAGINA EM CONSTRU��O DENTRO DESSA PAGINA-->
        <%--<iframe id="AFrame" width="960px" height="535px" frameborder="0" scrolling="no" src="construcao.aspx">
        </iframe>--%>
        <%--<a href="~/contato.aspx" target="_blank">CONTATO</a>--%>
        <p>
            <div class="alinhaDir" style="float: left; padding-right: 10px;">
                <asp:Image ID="Image8" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                <asp:Label ID="Label8" runat="server" EnableViewState="False" Font-Bold="True" Text="Legenda:&nbsp&nbsp&nbsp&nbsp"></asp:Label>
                <asp:Image ID="Image9" runat="server" EnableViewState="false" Height="24px" Width="20px"
                    ImageUrl="~/images/arvoreVerde.PNG" />
                <asp:Label ID="Label9" runat="server" EnableViewState="False" Font-Bold="True" Text="�rvore Saud�vel&nbsp&nbsp&nbsp&nbsp"></asp:Label>
                <asp:Image ID="Image10" runat="server" EnableViewState="false" Height="24px" Width="20px"
                    ImageUrl="~/images/arvoreAzul.PNG" />
                <asp:Label ID="Label10" runat="server" EnableViewState="False" Font-Bold="True" Text="�rvore Doente&nbsp&nbsp&nbsp&nbsp"></asp:Label>
                <asp:Image ID="Image15" runat="server" EnableViewState="false" Height="24px" Width="20px"
                    ImageUrl="~/images/arvoreVermelho.PNG" />
                <asp:Label ID="Label15" runat="server" EnableViewState="False" Font-Bold="True" Text="�rvore Ferida"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
        </p>
        <div style="margin: 0 10px 0 10px; border: solid 1px #000; width: 940px; text-align: left;">
            <%--GOOGLE MAPS--%>
            <%--<artem:GoogleMap ID="gMaps" runat="server">
            </artem:GoogleMap>--%>
            <maps:GMap ID="GoogleMaps" runat="server" Key="aaaaaaaaaaaaaaa" />
            <%--FIM GOOGLE MAPS--%>
        </div>
        <%--<asp:HyperLink ID="HyperLinkContato" NavigateUrl="~/contato.aspx" runat="server"
            Target="_blank">HyperLink</asp:HyperLink>--%>
    </div>
</asp:Content>
