<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="parceiros.aspx.cs" Inherits="parceiros" Title="Cidade Verde - Arborização Urbana" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="conteudo">
        <div class="alinhaDir" style="margin-top: 20px;">
            <asp:Image ID="Image1" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                Height="12px" Width="20px" />
            <asp:Label ID="Label01" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                Text="Abaixo nos Parceiros que contribuiram para o desenvolvimento desse sistema."></asp:Label>
        </div>
        <div class="limpaDir">
        </div>
        <div class="alinhaDir">
            <asp:Image ID="ImageAjuda" runat="server" EnableViewState="false" ToolTip="Informações sobre os Parceiros."
                ImageUrl="~/images/information32.png" />
        </div>
        <div class="alinhaDir" style="padding-top: 14px;">
            <asp:Label ID="LabelAjuda" runat="server" EnableViewState="False" ForeColor="#099409"
                Font-Size="14px" Font-Bold="True" Text="Abaixo nos Parceiros que contribuiram para o desenvolvimento desse sistema."></asp:Label>
        </div>
        <div class="limpaDir">
        </div>
        <div style="margin-left: -10px; margin-right: -10px;">
            <hr />
        </div>
        <div class="alinhaDir">
            <a href="http://www.fespmg.edu.br" target="_blank">
                <img src="fotos/parceiros/Fesp.jpg" style="border: #099409 1px solid;" alt="FESP - Fundação de Ensino Superior de Passos" />
            </a>
            <br />
            <a href="http://www.ibama.gov.br/" target="_blank">
                <img src="fotos/parceiros/Ibama.jpg" alt="IBAMA - Instituto Brasileiro do Meio Ambiente e dos Recursos Naturais Renováveis" />
            </a>
            <br />
            <a href="http://www.bancoreal.com.br/" target="_blank">
                <img src="fotos/parceiros/BancoReal.jpg" alt="Banco Real" />
            </a>
            <br />
        </div>
        <div class="alinhaDir">
            <a href="http://www.virtech.com.br" target="_blank">
                <img src="fotos/parceiros/Virtech.jpg" alt="Virtech Soluções Web" />
            </a>
            <br />
            <a href="http://www.boticario.com.br/" target="_blank">
                <img src="fotos/parceiros/Boticario.jpg" alt="O Boticário" />
            </a>
            <br />
            <a href="http://www.boticario.com.br" target="_blank">
                <img src="fotos/parceiros/CocaCola.jpg" alt="Coca-Cola" />
            </a>
        </div>
        <div class="limpaDir">
        </div>
    </div>
</asp:Content>
