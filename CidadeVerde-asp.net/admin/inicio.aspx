<%@ Page Language="C#" MasterPageFile="~/admin/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="inicio.aspx.cs" Inherits="admin_inicio" Title="CV - Página Inicial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="conteudo">
        <div style="padding: 20px;">
            <asp:Label ID="LabelUsuario" runat="server" Font-Bold="true" Font-Size="16px" Font-Names="arial, verdana"
                Text=""></asp:Label>
        </div>
        <div style="margin-left: -8px;">
            <hr />
        </div>
        <div class="texto">
            <p>
                A arborização urbana é muito importante, principalmente nos grandes centros urbanos,
                pois proporciona vários benefícios como purificação do ar, melhoria do clima, absorção
                de parte dos raios solares, sombreamento, abrigo à fauna, diminuição da poluição
                sonora, entre outros.</p>
            <p>
                A inexistência de um Sistema de Informações Geográficas (SIG) para controle da arborização
                urbana pode causar muitos problemas, como confronto de árvores inadequadas com equipamentos
                urbanos, entre outros.</p>
            <p>
                Devido tais importâncias e para amenizar tais problemas, deve-se considerar o desenvolvimento
                de SIG. O projeto propôs o desenvolvimento um Sistema de Informação Geográfica Web
                com o intuito de auxiliar o controle e manejo de espécies arbóreas nas vias públicas
                da cidade. Cadastros e gerenciamento das informações arbóreas, visualização de árvores
                georreferenciadas, relatórios para manejo e solicitação de serviços são algumas
                de suas funcionalidades.
            </p>
            <%--<div>
                <asp:HyperLink ID="HyperLinkVerArvores" CssClass="tituloLinks" runat="server">Ver Árvores</asp:HyperLink>
            </div>--%>
            <p>
                A arborização urbana é muito importante, principalmente nos grandes centros urbanos,
                trazendo vários benefícios, como melhoria na qualidade de vida da população, pois
                proporciona melhores condições ao ambiente como purificação do ar, melhoria do clima,
                absorção de parte dos raios solares, sombreamento, abrigo à fauna, diminuição da
                poluição sonora e do vento, entre outros.
            </p>
        </div>
    </div>
</asp:Content>
