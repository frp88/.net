<%@ Page Language="C#" MasterPageFile="~/admin/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="cadastroInterferencias.aspx.cs" Inherits="admin_cadastroInterferencias"
    Title="Administrar Tipos de Interfer�ncias" %>

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
        <asp:Panel ID="panelInicio" runat="server" Visible="false">
            <div class="alinhaDir">
                <asp:Image ID="Image1" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                    Height="12px" Width="20px" />
                <asp:Label ID="Label01" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                    Text="Administrar Tipos de Interfer�ncias"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <div class="alinhaDir">
                <asp:Image ID="ImageAjuda" runat="server" EnableViewState="false" ToolTip="Informa��es para realiza��o de Cadastros de Tipos de Interfer�ncias"
                    ImageUrl="~/images/information32.png" />
            </div>
            <div class="alinhaDir" style="padding-top: 14px;">
                <asp:Label ID="LabelAjuda" runat="server" EnableViewState="False" ForeColor="#099409"
                    Font-Size="14px" Font-Bold="True" Text="Para realizar o cadastro de interfer�ncias clique no cadastro desejado abaixo."></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
        </asp:Panel>
        <br />
        <%--ABA CADASTRO / ATUALIZA��O DE ILUMINA��O--%>
        <div onclick="javascript: $('#divIluminacao').toggle('slow');" class="abas">
            <div style="padding: 3px 5px 0 5px; float: left">
                <%--   <asp:Image ID="ImageIluminacao" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />--%>
            </div>
            <asp:Label ID="LabelIluminacao" runat="server" Text="Ilumina��o" EnableViewState="false"></asp:Label>
        </div>
        <div id="divIluminacao" style="display: none;">
            <asp:Panel ID="PanelIluminacaoCad" runat="server" Visible="true">
                <div class="alinhaDir">
                    <asp:Image ID="Image2" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                        Height="12px" Width="20px" />
                    <asp:Label ID="Label2" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                        Text=" Administrar Ilumina��o"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir">
                    <asp:Image ID="Image3" runat="server" EnableViewState="false" ToolTip=" Informa��es para realiza��o de Cadastro de Ilumina��o"
                        ImageUrl="~/images/information32.png" />
                </div>
                <div class="alinhaDir" style="padding-top: 14px;">
                    <asp:Label ID="Label3" runat="server" EnableViewState="False" ForeColor="#099409"
                        Font-Size="14px" Font-Bold="True" Text=" Digite a ilumina��o e clique em 'Salvar'. Para editar uma ilumina��o clique em 'Editar' da Lista de Ilumina��es."></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image5" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="LabelIluminacaoTitulo" runat="server" EnableViewState="False" Font-Bold="True"
                        Text=" Cadastro de Ilumina��o:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <%--Descri��o da Ilumina��o--%>
                <div class="nomecampos">
                    Ilumina��o:
                </div>
                <div class="txtcampos">
                    <asp:TextBox ID="txtIluminacao" runat="server" CssClass="bordas" Text="" Width="250px"></asp:TextBox>
                </div>
                <div class="limpaDir">
                </div>
                <%--Bot�es Salvar e Cancelar Ilumina��o--%>
                <div class="botoesCentro">
                    <asp:Button ID="btIluminacaoSalvar" runat="server" CssClass="botoes" Text="Salvar"
                        OnClick="btIluminacaoSalvar_Click" />
                    <asp:Button ID="btIluminacaoCancelar" runat="server" CssClass="botoes" Text="Cancelar"
                        OnClick="btIluminacaoCancelar_Click" />
                </div>
                <div class="limpaDir">
                </div>
                <div class="botoesCentro">
                    <asp:Panel ID="PanelIluminacaoConfirma" runat="server" Visible="false">
                        <div class="alinhaDir" style="margin-left: -30px;">
                            <asp:Image ID="ImageIluminacaoConfirma" runat="server" ImageUrl="~/images/confirmation32.png" />
                        </div>
                        <div style="padding-top: 14px; width: 300px;">
                            <asp:Label ID="LabelIluminacaoErro" runat="server" Text="" Font-Bold="true" ForeColor="#CC0000"></asp:Label>
                            <asp:Label ID="LabelIluminacaoOk" runat="server" Text="" Font-Bold="true" ForeColor="#099409"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image4" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label9" runat="server" EnableViewState="False" Font-Bold="True" Text=" Lista de Ilumina��es:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-left: 30px;">
                    <asp:GridView ID="GridViewIluminacao" runat="server" BackColor="White" AutoGenerateColumns="False"
                        BorderColor="#0D5600" Width="400px" HorizontalAlign="Center" CellPadding="2"
                        AllowPaging="True" BorderStyle="Double" BorderWidth="3px" GridLines="Vertical"
                        OnRowDataBound="GridViewIluminacao_RowDataBound" OnPageIndexChanging="GridViewIluminacao_PageIndexChanging"
                        OnRowCommand="GridViewIluminacao_RowCommand">
                        <RowStyle BackColor="#ffffff" />
                        <Columns>
                            <asp:BoundField DataField="codIluminacao" SortExpression="codIluminacao" HeaderText="codIluminacao">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descIluminacao" SortExpression="descIluminacao" HeaderText="Ilumina��o">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Link" CommandName="editarIluminacao" Text='<img alt="" title="Editar Ilumina��o" src="../images/editar.png" style="border: 0px" />'>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Link" CommandName="excluirIluminacao" Text='<img alt="" title="Excluir Ilumina��o" src="../images/excluir.png" style="border: 0px" />'>
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
                                            Nenhuma Ilumina��o Encontrada.
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
        </div>
        <%--FIM ABA CADASTRO / ATUALIZA��O DE ILUMINA��O--%>
        <div style="height: 3px;">
        </div>
        <%--ABA CADASTRO / ATUALIZA��O DE MURO EDIFICA��O--%>
        <div onclick="javascript: $('#divMuro').toggle('slow');" class="abas">
            <div style="padding: 3px 5px 0 5px; float: left">
                <%--<asp:Image ID="Image6" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />--%>
            </div>
            <asp:Label ID="Label4" runat="server" Text="Muro Edifica��o" EnableViewState="false"></asp:Label>
        </div>
        <div id="divMuro" style="display: none;">
            <asp:Panel ID="PanelMuro" runat="server" Visible="true">
                <div class="alinhaDir">
                    <asp:Image ID="Image7" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                        Height="12px" Width="20px" />
                    <asp:Label ID="Label5" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                        Text=" Administrar Muro Edifica��o"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir">
                    <asp:Image ID="Image8" runat="server" EnableViewState="false" ToolTip=" Informa��es para realiza��o de Cadastro de Muro Edifica��o"
                        ImageUrl="~/images/information32.png" />
                </div>
                <div class="alinhaDir" style="padding-top: 14px;">
                    <asp:Label ID="Label6" runat="server" EnableViewState="False" ForeColor="#099409"
                        Font-Size="14px" Font-Bold="True" Text=" Digite o Muro Edifica��o e clique em 'Salvar'. Para edit�-lo clique em 'Editar' da Lista de Muro Edifica��o."></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image9" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label7" runat="server" EnableViewState="False" Font-Bold="True" Text="Cadastro de Muro Edifica��o:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <%--Descri��o da Muro Edifica��o--%>
                <div class="nomecampos">
                    Muro Edifica��o:
                </div>
                <div class="txtcampos">
                    <asp:TextBox ID="txtMuro" runat="server" CssClass="bordas" Text="" Width="250px"></asp:TextBox>
                </div>
                <div class="limpaDir">
                </div>
                <%--Bot�es Salvar e Cancelar Muro Edifica��o--%>
                <div class="botoesCentro">
                    <asp:Button ID="btMuroSalvar" runat="server" CssClass="botoes" Text="Salvar" OnClick="btMuroSalvar_Click" />
                    <asp:Button ID="btMuroCancelar" runat="server" CssClass="botoes" Text="Cancelar"
                        OnClick="btMuroCancelar_Click" />
                </div>
                <div class="limpaDir">
                </div>
                <div class="botoesCentro">
                    <asp:Panel ID="PanelMuroConfirma" runat="server" Visible="false">
                        <div class="alinhaDir" style="margin-left: -30px;">
                            <asp:Image ID="ImageMuroConfirma" runat="server" ImageUrl="~/images/confirmation32.png" />
                        </div>
                        <div style="padding-top: 14px; width: 300px;">
                            <asp:Label ID="LabelMuroErro" runat="server" Text="" Font-Bold="true" ForeColor="#CC0000"></asp:Label>
                            <asp:Label ID="LabelMuroOk" runat="server" Text="" Font-Bold="true" ForeColor="#099409"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image11" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label11" runat="server" EnableViewState="False" Font-Bold="True" Text=" Lista de Muro Edifica��o:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-left: 30px;">
                    <asp:GridView ID="GridViewMuro" runat="server" BackColor="White" AutoGenerateColumns="False"
                        BorderColor="#0D5600" Width="400px" HorizontalAlign="Center" CellPadding="2"
                        AllowPaging="True" BorderStyle="Double" BorderWidth="3px" GridLines="Vertical"
                        OnPageIndexChanging="GridViewMuro_PageIndexChanging" OnRowCommand="GridViewMuro_RowCommand"
                        OnRowDataBound="GridViewMuro_RowDataBound">
                        <RowStyle BackColor="#ffffff" />
                        <Columns>
                            <asp:BoundField DataField="codMuroEdificacao" SortExpression="codMuroEdificacao"
                                HeaderText="codMuroEdificacao">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descMuroEdificacao" SortExpression="descMuroEdificacao"
                                HeaderText="Muro Edifica��o">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Link" CommandName="editarMuro" Text='<img alt="" title="Editar Muro Edifica��o" src="../images/editar.png" style="border: 0px" />'>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Link" CommandName="excluirMuro" Text='<img alt="" title="Excluir Muro Edifica��o" src="../images/excluir.png" style="border: 0px" />'>
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
                                            Nenhum Muro Edifica��o Encontrado.
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
        </div>
        <%--FIM ABA CADASTRO / ATUALIZA��O DE MURO EDIFICA��O--%>
        <div style="height: 3px;">
        </div>
        <%--ABA CADASTRO / ATUALIZA��O DE POSTEAMENTO--%>
        <div onclick="javascript: $('#divPosteamento').toggle('slow');" class="abas">
            <div style="padding: 3px 5px 0 5px; float: left">
                <%--       <asp:Image ID="ImagePosteamento" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />--%>
            </div>
            <asp:Label ID="LabelPosteamento" runat="server" Text="Posteamento" EnableViewState="false"></asp:Label>
        </div>
        <div id="divPosteamento" style="display: none;">
            <asp:Panel ID="PanelPosteamentoCad" runat="server" Visible="true">
                <div class="alinhaDir">
                    <asp:Image ID="Image18" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                        Height="12px" Width="20px" />
                    <asp:Label ID="Label24" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                        Text="Administrar Posteamento"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir">
                    <asp:Image ID="Image19" runat="server" EnableViewState="false" ToolTip="Informa��es para realiza��o do Cadastro e Atualiza��o de Posteamento"
                        ImageUrl="~/images/information32.png" />
                </div>
                <div class="alinhaDir" style="padding-top: 14px;">
                    <asp:Label ID="Label25" runat="server" EnableViewState="False" ForeColor="#099409"
                        Font-Size="14px" Font-Bold="True" Text=" Digite o posteanento e clique em 'Salvar'. Para edit�-lo clique 'Editar' da Lista de Posteamento."></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image20" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="LabelPosteamentoTitulo" runat="server" EnableViewState="False" Font-Bold="True"
                        Text=" Cadastro de Grupo de Posteamento:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="nomecampos">
                    Posteamento:
                </div>
                <div class="txtcampos">
                    <asp:TextBox ID="txtPosteamento" runat="server" CssClass="bordas" Text="" Width="300px"></asp:TextBox>
                </div>
                <div class="limpaDir">
                </div>
                <%--Bot�es Salvar e Cancelar Posteamento--%>
                <div class="botoesCentro">
                    <asp:Button ID="btPosteamentoSalvar" runat="server" CssClass="botoes" Text="Salvar"
                        OnClick="btPosteamentoSalvar_Click" />
                    <asp:Button ID="btPosteamentoCancelar" runat="server" CssClass="botoes" Text="Cancelar"
                        OnClick="btPosteamentoCancelar_Click" />
                </div>
                <div class="limpaDir">
                </div>
                <div class="botoesCentro">
                    <asp:Panel ID="PanelPosteamentoConfirma" runat="server" Visible="false">
                        <div class="alinhaDir" style="margin-left: -30px;">
                            <asp:Image ID="ImagePosteamentoConfirma" runat="server" ImageUrl="~/images/confirmation32.png" />
                        </div>
                        <div style="padding-top: 14px; width: 300px">
                            <asp:Label ID="LabelPosteamentoConfirmaErro" runat="server" Text="" Font-Bold="true"
                                ForeColor="#CC0000"></asp:Label>
                            <asp:Label ID="LabelPosteamentoConfirmaOk" runat="server" Text="" Font-Bold="true"
                                ForeColor="#099409"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image22" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label30" runat="server" EnableViewState="False" Font-Bold="True" Text=" Lista de Posteamento:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-left: 30px;">
                    <asp:GridView ID="GridViewPosteamento" runat="server" BackColor="White" AutoGenerateColumns="False"
                        BorderColor="#0D5600" Width="400px" HorizontalAlign="Center" CellPadding="2"
                        AllowPaging="True" BorderStyle="Double" BorderWidth="3px" GridLines="Vertical"
                        OnPageIndexChanging="GridViewPosteamento_PageIndexChanging" OnRowCommand="GridViewPosteamento_RowCommand"
                        OnRowDataBound="GridViewPosteamento_RowDataBound">
                        <RowStyle BackColor="#ffffff" />
                        <Columns>
                            <asp:BoundField DataField="codPosteamento" SortExpression="codPosteamento" HeaderText="codPosteamento">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descPosteamento" SortExpression="descPosteamento" HeaderText="Posteamento">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Link" CommandName="editarPosteamento" Text='<img alt="" title="Editar Posteamento" src="../images/editar.png" style="border: 0px" />'>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Link" CommandName="excluirPosteamento" Text='<img alt="" title="Excluir Posteamento" src="../images/excluir.png" style="border: 0px" />'>
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
                                            Nenhum Posteamento Encontrado.
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
        </div>
        <%--FIM PANEL CADASTRO / ATUALIZA��O DE POSTEAMENTO--%>
        <div style="height: 3px;">
        </div>
        <%--ABA CADASTRO / ATUALIZA��O DE SINALIZA��O--%>
        <div onclick="javascript: $('#divSinalizacao').toggle('slow');" class="abas">
            <div style="padding: 3px 5px 0 5px; float: left">
                <%--       <asp:Image ID="ImageSinalizacao" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />--%>
            </div>
            <asp:Label ID="LabelSinalizacaoTitulo" runat="server" Text="Sinaliza��o" EnableViewState="false"></asp:Label>
        </div>
        <div id="divSinalizacao" style="display: none;">
            <asp:Panel ID="PanelSinalizacao" runat="server" Visible="true">
                <div class="alinhaDir">
                    <asp:Image ID="Image6" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                        Height="12px" Width="20px" />
                    <asp:Label ID="Label15" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                        Text="Administrar Sinaliza��o"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir">
                    <asp:Image ID="Image10" runat="server" EnableViewState="false" ToolTip="Informa��es para realiza��o do Cadastro e Atualiza��o de Sinaliza��o"
                        ImageUrl="~/images/information32.png" />
                </div>
                <div class="alinhaDir" style="padding-top: 14px;">
                    <asp:Label ID="Label17" runat="server" EnableViewState="False" ForeColor="#099409"
                        Font-Size="14px" Font-Bold="True" Text=" Digite a sinaliza��o e clique em 'Salvar'. Para edit�-lo clique 'Editar' da Lista de Sinaliza��o."></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image15" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label18" runat="server" EnableViewState="False" Font-Bold="True" Text=" Cadastro de Sinaliza��o:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="nomecampos">
                    Sinaliza��o:
                </div>
                <div class="txtcampos">
                    <asp:TextBox ID="txtSinalizacao" runat="server" CssClass="bordas" Text="" Width="300px"></asp:TextBox>
                </div>
                <div class="limpaDir">
                </div>
                <%--Bot�es Salvar e Cancelar Sinalizacao--%>
                <div class="botoesCentro">
                    <asp:Button ID="btSinalizacaoSalvar" runat="server" CssClass="botoes" Text="Salvar"
                        OnClick="btSinalizacaoSalvar_Click" />
                    <asp:Button ID="btSinalizacaoCancelar" runat="server" CssClass="botoes" Text="Cancelar"
                        OnClick="btSinalizacaoCancelar_Click" />
                </div>
                <div class="limpaDir">
                </div>
                <div class="botoesCentro">
                    <asp:Panel ID="PanelSinalizacaoConfirma" runat="server" Visible="false">
                        <div class="alinhaDir" style="margin-left: -30px;">
                            <asp:Image ID="ImageSinalizacaoConfirma" runat="server" ImageUrl="~/images/confirmation32.png" />
                        </div>
                        <div style="padding-top: 14px; width: 300px">
                            <asp:Label ID="LabelSinalizacaoErro" runat="server" Text="" Font-Bold="true" ForeColor="#CC0000"></asp:Label>
                            <asp:Label ID="LabelSinalizacaoOk" runat="server" Text="" Font-Bold="true" ForeColor="#099409"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image21" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label21" runat="server" EnableViewState="False" Font-Bold="True" Text=" Lista de Sinaliza��o:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-left: 30px;">
                    <asp:GridView ID="GridViewSinalizacao" runat="server" BackColor="White" AutoGenerateColumns="False"
                        BorderColor="#0D5600" Width="400px" HorizontalAlign="Center" CellPadding="2"
                        AllowPaging="True" BorderStyle="Double" BorderWidth="3px" GridLines="Vertical"
                        OnPageIndexChanging="GridViewSinalizacao_PageIndexChanging" OnRowCommand="GridViewSinalizacao_RowCommand"
                        OnRowDataBound="GridViewSinalizacao_RowDataBound">
                        <RowStyle BackColor="#ffffff" />
                        <Columns>
                            <asp:BoundField DataField="codSinalizacao" SortExpression="codSinalizacao" HeaderText="codSinalizacao">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descSinalizacao" SortExpression="descSinalizacao" HeaderText="Sinaliza��o">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Link" CommandName="editarSinalizacao" Text='<img alt="" title="Editar Sinaliza��o" src="../images/editar.png" style="border: 0px" />'>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Link" CommandName="excluirSinalizacao" Text='<img alt="" title="Excluir Sinaliza��o" src="../images/excluir.png" style="border: 0px" />'>
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
                                            Nenhuna Sinaliza��o Encontrada.
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
        </div>
        <%--FIM PANEL CADASTRO / ATUALIZA��O DE SINALIZA��O--%>
        <div style="height: 3px;">
        </div>
        <%--ABA CADASTRO / ATUALIZA��O DE SITUA��O DA FIA��O--%>
        <div onclick="javascript: $('#divSituacaoFiacao').toggle('slow');" class="abas">
            <div style="padding: 3px 5px 0 5px; float: left">
                <%--       <asp:Image ID="ImageSinalizacao" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />--%>
            </div>
            <asp:Label ID="LabelTituloSituacaoFiacao" runat="server" Text="Situa��o da Fia��o"
                EnableViewState="false"></asp:Label>
        </div>
        <div id="divSituacaoFiacao" style="display: none;">
            <asp:Panel ID="PanelSituacaoFiacao" runat="server" Visible="true">
                <div class="alinhaDir">
                    <asp:Image ID="Image17" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                        Height="12px" Width="20px" />
                    <asp:Label ID="Label19" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                        Text="Administrar Situa��o da Fia��o"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir">
                    <asp:Image ID="Image23" runat="server" EnableViewState="false" ToolTip="Informa��es para realiza��o do Cadastro e Atualiza��o da Situa��o da Fia��o"
                        ImageUrl="~/images/information32.png" />
                </div>
                <div class="alinhaDir" style="padding-top: 14px;">
                    <asp:Label ID="Label20" runat="server" EnableViewState="False" ForeColor="#099409"
                        Font-Size="14px" Font-Bold="True" Text=" Digite a situa��o da fia��o e clique em 'Salvar'. Para edit�-lo clique 'Editar' da Lista de Situa��es da Fia��o."></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image24" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label22" runat="server" EnableViewState="False" Font-Bold="True" Text=" Cadastro da Situa��o da Fia��o:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="nomecampos">
                    Situa��o da Fia��o:
                </div>
                <div class="txtcampos">
                    <asp:TextBox ID="txtSituacaoFiacao" runat="server" CssClass="bordas" Text="" Width="300px"></asp:TextBox>
                </div>
                <div class="limpaDir">
                </div>
                <%--Bot�es Salvar e Cancelar SituacaoFiacao--%>
                <div class="botoesCentro">
                    <asp:Button ID="btSituacaoFiacaoSalvar" runat="server" CssClass="botoes" Text="Salvar"
                        OnClick="btSituacaoFiacaoSalvar_Click" />
                    <asp:Button ID="btSituacaoFiacaoCancelar" runat="server" CssClass="botoes" Text="Cancelar"
                        OnClick="btSituacaoFiacaoCancelar_Click" />
                </div>
                <div class="limpaDir">
                </div>
                <div class="botoesCentro">
                    <asp:Panel ID="PanelSituacaoFiacaoConfirma" runat="server" Visible="false">
                        <div class="alinhaDir" style="margin-left: -30px;">
                            <asp:Image ID="ImageSituacaoFiacaoConfirma" runat="server" ImageUrl="~/images/confirmation32.png" />
                        </div>
                        <div style="padding-top: 14px; width: 300px">
                            <asp:Label ID="LabelSituacaoFiacaoErro" runat="server" Text="" Font-Bold="true" ForeColor="#CC0000"></asp:Label>
                            <asp:Label ID="LabelSituacaoFiacaoOk" runat="server" Text="" Font-Bold="true" ForeColor="#099409"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image26" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label27" runat="server" EnableViewState="False" Font-Bold="True" Text=" Lista de Situa��es de Fia��o:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-left: 30px;">
                    <asp:GridView ID="GridViewSituacaoFiacao" runat="server" BackColor="White" AutoGenerateColumns="False"
                        BorderColor="#0D5600" Width="400px" HorizontalAlign="Center" CellPadding="2"
                        AllowPaging="True" BorderStyle="Double" BorderWidth="3px" GridLines="Vertical"
                        OnPageIndexChanging="GridViewSituacaoFiacao_PageIndexChanging" OnRowCommand="GridViewSituacaoFiacao_RowCommand"
                        OnRowDataBound="GridViewSituacaoFiacao_RowDataBound">
                        <RowStyle BackColor="#ffffff" />
                        <Columns>
                            <asp:BoundField DataField="codSituacaoFiacao" SortExpression="codSituacaoFiacao"
                                HeaderText="codSituacaoFiacao">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descSituacaoFiacao" SortExpression="descSituacaoFiacao"
                                HeaderText="Situa��o da Fia��o">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Link" CommandName="editarSituacaoFiacao" Text='<img alt="" title="Editar Situa��o da Fia��o" src="../images/editar.png" style="border: 0px" />'>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Link" CommandName="excluirSituacaoFiacao" Text='<img alt="" title="Excluir Situa��o da Fia��o" src="../images/excluir.png" style="border: 0px" />'>
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
                                            Nenhuna Situa��o da Fia��o Encontrada.
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
        </div>
        <%--FIM PANEL CADASTRO / ATUALIZA��O DE SITUA��O DA FIA��O--%>
        <div style="height: 3px;">
        </div>
        <%--ABA CADASTRO / ATUALIZA��O DE TIPO DA FIA��O--%>
        <div onclick="javascript: $('#divTipoFiacao').toggle('slow');" class="abas">
            <div style="padding: 3px 5px 0 5px; float: left">
                <%--       <asp:Image ID="ImageSinalizacao" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />--%>
            </div>
            <asp:Label ID="Label14" runat="server" Text="Tipo da Fia��o" EnableViewState="false"></asp:Label>
        </div>
        <div id="divTipoFiacao" style="display: none;">
            <asp:Panel ID="PanelTipoFiacao" runat="server" Visible="true">
                <div class="alinhaDir">
                    <asp:Image ID="Image25" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                        Height="12px" Width="20px" />
                    <asp:Label ID="Label23" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                        Text="Administrar Tipo de Fia��o"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir">
                    <asp:Image ID="Image27" runat="server" EnableViewState="false" ToolTip="Informa��es para realiza��o do Cadastro e Atualiza��o do Tipo de Fia��o"
                        ImageUrl="~/images/information32.png" />
                </div>
                <div class="alinhaDir" style="padding-top: 14px;">
                    <asp:Label ID="Label26" runat="server" EnableViewState="False" ForeColor="#099409"
                        Font-Size="14px" Font-Bold="True" Text=" Digite o tipo de fia��o e clique em 'Salvar'. Para edit�-lo clique 'Editar' da Lista de Tipo de Fia��o."></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image28" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label28" runat="server" EnableViewState="False" Font-Bold="True" Text=" Cadastro do Tipo de Fia��o:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="nomecampos">
                    Tipo de Fia��o:
                </div>
                <div class="txtcampos">
                    <asp:TextBox ID="txtTipoFiacao" runat="server" CssClass="bordas" Text="" Width="300px"></asp:TextBox>
                </div>
                <div class="limpaDir">
                </div>
                <%--Bot�es Salvar e Cancelar TipoFiacao--%>
                <div class="botoesCentro">
                    <asp:Button ID="btTipoFiacaoSalvar" runat="server" CssClass="botoes" Text="Salvar"
                        OnClick="btTipoFiacaoSalvar_Click" />
                    <asp:Button ID="btTipoFiacaoCancelar" runat="server" CssClass="botoes" Text="Cancelar"
                        OnClick="btTipoFiacaoCancelar_Click" />
                </div>
                <div class="limpaDir">
                </div>
                <div class="botoesCentro">
                    <asp:Panel ID="PanelTipoFiacaoConfirma" runat="server" Visible="false">
                        <div class="alinhaDir" style="margin-left: -30px;">
                            <asp:Image ID="ImageTipoFiacaoConfirma" runat="server" ImageUrl="~/images/confirmation32.png" />
                        </div>
                        <div style="padding-top: 14px; width: 300px">
                            <asp:Label ID="LabelTipoFiacaoErro" runat="server" Text="" Font-Bold="true" ForeColor="#CC0000"></asp:Label>
                            <asp:Label ID="LabelTipoFiacaoOk" runat="server" Text="" Font-Bold="true" ForeColor="#099409"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image30" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label32" runat="server" EnableViewState="False" Font-Bold="True" Text=" Lista de Tipos de Fia��o:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-left: 30px;">
                    <asp:GridView ID="GridViewTipoFiacao" runat="server" BackColor="White" AutoGenerateColumns="False"
                        BorderColor="#0D5600" Width="400px" HorizontalAlign="Center" CellPadding="2"
                        AllowPaging="True" BorderStyle="Double" BorderWidth="3px" GridLines="Vertical"
                        OnPageIndexChanging="GridViewTipoFiacao_PageIndexChanging" OnRowCommand="GridViewTipoFiacao_RowCommand"
                        OnRowDataBound="GridViewTipoFiacao_RowDataBound">
                        <RowStyle BackColor="#ffffff" />
                        <Columns>
                            <asp:BoundField DataField="codTipoFiacao" SortExpression="codTipoFiacao" HeaderText="codTipoFiacao">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descTipoFiacao" SortExpression="descTipoFiacao" HeaderText="Tipo da Fia��o">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Link" CommandName="editarTipoFiacao" Text='<img alt="" title="Clique aqui para editar Tipo da Fia��o" src="../images/editar.png" style="border: 0px" />'>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Link" CommandName="excluirTipoFiacao" Text='<img alt="" title="Excluir Tipo da Fia��o" src="../images/excluir.png" style="border: 0px" />'>
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
                                            Nenhum Tipo de Fia��o Encontrado.
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
        </div>
        <%--FIM PANEL CADASTRO / ATUALIZA��O DO TIPO DE FIA��O--%>
        <div style="height: 3px;">
        </div>
        <%--ABA CADASTRO / ATUALIZA��O DE TIPO DE RAIZ NO PAVIMENTO--%>
        <div onclick="javascript: $('#divRaiz').toggle('slow');" class="abas">
            <div style="padding: 3px 5px 0 5px; float: left">
                <%--<asp:Image ID="Image10" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />--%>
            </div>
            <asp:Label ID="Label8" runat="server" Text="Tipo de Raiz no Pavimento" EnableViewState="false"></asp:Label>
        </div>
        <div id="divRaiz" style="display: none;">
            <asp:Panel ID="PanelRaiz" runat="server" Visible="true">
                <div class="alinhaDir">
                    <asp:Image ID="Image12" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                        Height="12px" Width="20px" />
                    <asp:Label ID="Label10" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                        Text="Administrar Tipo de Raiz no Pavimento"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir">
                    <asp:Image ID="Image13" runat="server" EnableViewState="false" ToolTip="Informa��es para realiza��o do Cadastro e Atualiza��o de Tipo de Raiz no Pavimento"
                        ImageUrl="~/images/information32.png" />
                </div>
                <div class="alinhaDir" style="padding-top: 14px;">
                    <asp:Label ID="Label12" runat="server" EnableViewState="False" ForeColor="#099409"
                        Font-Size="14px" Font-Bold="True" Text=" Digite o Tipo de Raiz no Pavimento e clique em 'Salvar'. Para edit�-lo clique 'Editar' da Lista de Raiz no Pavimento."></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image14" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label13" runat="server" EnableViewState="False" Font-Bold="True" Text="Cadastro de Tipo de Raiz no Pavimento:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="nomecampos">
                    Tipo de Raiz no Pavimento:
                </div>
                <div class="txtcampos">
                    <asp:TextBox ID="txtRaiz" runat="server" CssClass="bordas" Text="" Width="300px"></asp:TextBox>
                </div>
                <div class="limpaDir">
                </div>
                <%--Bot�es Salvar e Cancelar Posteamento--%>
                <div class="botoesCentro">
                    <asp:Button ID="btRaizSalvar" runat="server" CssClass="botoes" Text="Salvar" OnClick="btRaizSalvar_Click" />
                    <asp:Button ID="btRaizCancelar" runat="server" CssClass="botoes" Text="Cancelar"
                        OnClick="btRaizCancelar_Click" />
                </div>
                <div class="limpaDir">
                </div>
                <div class="botoesCentro">
                    <asp:Panel ID="PanelRaizConfirma" runat="server" Visible="false">
                        <div class="alinhaDir" style="margin-left: -30px;">
                            <asp:Image ID="ImageRaizConfirma" runat="server" ImageUrl="~/images/confirmation32.png" />
                        </div>
                        <div style="padding-top: 14px; width: 400px">
                            <asp:Label ID="LabelRaizErro" runat="server" Text="" Font-Bold="true" ForeColor="#CC0000"></asp:Label>
                            <asp:Label ID="LabelRaizOk" runat="server" Text="" Font-Bold="true" ForeColor="#099409"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image16" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label16" runat="server" EnableViewState="False" Font-Bold="True" Text=" Lista de Tipos Raizes no Pavimento:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-left: 30px;">
                    <asp:GridView ID="GridViewRaiz" runat="server" BackColor="White" AutoGenerateColumns="False"
                        BorderColor="#0D5600" Width="400px" HorizontalAlign="Center" CellPadding="2"
                        AllowPaging="True" BorderStyle="Double" BorderWidth="3px" GridLines="Vertical"
                        OnPageIndexChanging="GridViewRaiz_PageIndexChanging" OnRowCommand="GridViewRaiz_RowCommand"
                        OnRowDataBound="GridViewRaiz_RowDataBound">
                        <RowStyle BackColor="#ffffff" />
                        <Columns>
                            <asp:BoundField DataField="codRaizPavimento" SortExpression="codRaizPavimento" HeaderText="codRaizPavimento">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descRaizPavimento" SortExpression="descRaizPavimento"
                                HeaderText="Tipo de Raiz no Pavimento">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Link" CommandName="editarRaiz" Text='<img alt="" title="Editar Tipo de Raiz no Pavimento" src="../images/editar.png" style="border: 0px" />'>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Link" CommandName="excluirRaiz" Text='<img alt="" title="Excluir Tipo de Raiz no Pavimento" src="../images/excluir.png" style="border: 0px" />'>
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
                                            Nenhum Tipo de Raiz no Pavimento Encontrado.
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
        </div>
        <%--FIM PANEL CADASTRO / ATUALIZA��O DE TIPO DE RAIZ NO PAVIMENTO--%>
        <div style="height: 3px;">
        </div>
        <%--ABA CADASTRO / ATUALIZA��O DO TRAFEGO--%>
        <div onclick="javascript: $('#divTrafego').toggle('slow');" class="abas">
            <div style="padding: 3px 5px 0 5px; float: left">
                <%--       <asp:Image ID="ImageSinalizacao" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />--%>
            </div>
            <asp:Label ID="LabelTitulodivTrafego" runat="server" Text="Tr�fego" EnableViewState="false"></asp:Label>
        </div>
        <div id="divTrafego" style="display: none;">
            <asp:Panel ID="PanelTrafego" runat="server" Visible="true">
                <div class="alinhaDir">
                    <asp:Image ID="Image29" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                        Height="12px" Width="20px" />
                    <asp:Label ID="Label31" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                        Text="Administrar Tr�fego"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir">
                    <asp:Image ID="Image31" runat="server" EnableViewState="false" ToolTip="Informa��es para realiza��o do Cadastro e Atualiza��o de Tr�fego"
                        ImageUrl="~/images/information32.png" />
                </div>
                <div class="alinhaDir" style="padding-top: 14px;">
                    <asp:Label ID="Label33" runat="server" EnableViewState="False" ForeColor="#099409"
                        Font-Size="14px" Font-Bold="True" Text=" Digite o Tr�fego e clique em 'Salvar'. Para edit�-lo clique 'Editar' da Lista Tr�fegos."></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image32" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label34" runat="server" EnableViewState="False" Font-Bold="True" Text=" Cadastro do Tr�fego:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="nomecampos">
                    Tr�fego:
                </div>
                <div class="txtcampos">
                    <asp:TextBox ID="txtTrafego" runat="server" CssClass="bordas" Text="" Width="300px"></asp:TextBox>
                </div>
                <div class="limpaDir">
                </div>
                <%--Bot�es Salvar e Cancelar Trafego--%>
                <div class="botoesCentro">
                    <asp:Button ID="btTrafegoSalvar" runat="server" CssClass="botoes" Text="Salvar" OnClick="btTrafegoSalvar_Click" />
                    <asp:Button ID="btTrafegoCancelar" runat="server" CssClass="botoes" Text="Cancelar"
                        OnClick="btTrafegoCancelar_Click" />
                </div>
                <div class="limpaDir">
                </div>
                <div class="botoesCentro">
                    <asp:Panel ID="PanelTrafegoConfirma" runat="server" Visible="false">
                        <div class="alinhaDir" style="margin-left: -30px;">
                            <asp:Image ID="ImageTrafegoConfirma" runat="server" ImageUrl="~/images/confirmation32.png" />
                        </div>
                        <div style="padding-top: 14px; width: 300px">
                            <asp:Label ID="LabelTrafegoErro" runat="server" Text="" Font-Bold="true" ForeColor="#CC0000"></asp:Label>
                            <asp:Label ID="LabelTrafegoOk" runat="server" Text="" Font-Bold="true" ForeColor="#099409"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image34" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label37" runat="server" EnableViewState="False" Font-Bold="True" Text=" Lista de Tr�fegos:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-left: 30px;">
                    <asp:GridView ID="GridViewTrafego" runat="server" BackColor="White" AutoGenerateColumns="False"
                        BorderColor="#0D5600" Width="400px" HorizontalAlign="Center" CellPadding="2"
                        AllowPaging="True" BorderStyle="Double" BorderWidth="3px" GridLines="Vertical"
                        OnPageIndexChanging="GridViewTrafego_PageIndexChanging" OnRowCommand="GridViewTrafego_RowCommand"
                        OnRowDataBound="GridViewTrafego_RowDataBound">
                        <RowStyle BackColor="#ffffff" />
                        <Columns>
                            <asp:BoundField DataField="codTrafego" SortExpression="codTrafego" HeaderText="codTrafego">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descTrafego" SortExpression="descTrafego" HeaderText="Tipo de Tr�fego">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Link" CommandName="editarTrafego" Text='<img alt="" title="Clique aqui para editar o Tr�fego" src="../images/editar.png" style="border: 0px" />'>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Link" CommandName="excluirTrafego" Text='<img alt="" title="Excluir Tr�fego" src="../images/excluir.png" style="border: 0px" />'>
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
                                            Nenhum Tr�fego Encontrado.
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
        </div>
        <%--FIM PANEL CADASTRO / ATUALIZA��O DO TIPO DE FIA��O--%>
    </div>
</asp:Content>
