<%@ Page Language="C#" MasterPageFile="~/admin/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="geoprocessamento.aspx.cs" Inherits="admin_geoprocessamento" Title="CV - Geoprocessamento" %>

<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="conteudo">
        <div class="texto">
            <p>
                <strong><font color="#056D00">Geoprocessamento</font></strong>
                <chart:WebChartViewer ID="WebChartViewer1" runat="server" />
            </p>
        </div>
    </div>
</asp:Content>
