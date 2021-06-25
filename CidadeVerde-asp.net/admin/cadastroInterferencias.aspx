<%@ Page Language="C#" MasterPageFile="~/admin/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="cadastroInterferencias.aspx.cs" Inherits="admin_cadastroInterferencias"
    Title="Administrar Tipos de Interferências" %>

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
                    Text="Administrar Tipos de Interferências"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <div class="alinhaDir">
                <asp:Image ID="ImageAjuda" runat="server" EnableViewState="false" ToolTip="Informações para realização de Cadastros de Tipos de Interferências"
                    ImageUrl="~/images/information32.png" />
            </div>
            <div class="alinhaDir" style="padding-top: 14px;">
                <asp:Label ID="LabelAjuda" runat="server" EnableViewState="False" ForeColor="#099409"
                    Font-Size="14px" Font-Bold="True" Text="Para realizar o cadastro de interferências clique no cadastro desejado abaixo."></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
        </asp:Panel>
        <br />
        <%--ABA CADASTRO / ATUALIZAÇÃO DE ILUMINAÇÃO--%>
        <div onclick="javascript: $('#divIluminacao').toggle('slow');" class="abas">
            <div style="padding: 3px 5px 0 5px; float: left">
                <%--   <asp:Image ID="ImageIluminacao" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />--%>
            </div>
            <asp:Label ID="LabelIluminacao" runat="server" Text="Iluminação" EnableViewState="false"></asp:Label>
        </div>
        <div id="divIluminacao" style="display: none;">
            <asp:Panel ID="PanelIluminacaoCad" runat="server" Visible="true">
                <div class="alinhaDir">
                    <asp:Image ID="Image2" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                        Height="12px" Width="20px" />
                    <asp:Label ID="Label2" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                        Text=" Administrar Iluminação"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir">
                    <asp:Image ID="Image3" runat="server" EnableViewState="false" ToolTip=" Informações para realização de Cadastro de Iluminação"
                        ImageUrl="~/images/information32.png" />
                </div>
                <div class="alinhaDir" style="padding-top: 14px;">
                    <asp:Label ID="Label3" runat="server" EnableViewState="False" ForeColor="#099409"
                        Font-Size="14px" Font-Bold="True" Text=" Digite a iluminação e clique em 'Salvar'. Para editar uma iluminação clique em 'Editar' da Lista de Iluminações."></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image5" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="LabelIluminacaoTitulo" runat="server" EnableViewState="False" Font-Bold="True"
                        Text=" Cadastro de Iluminação:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <%--Descrição da Iluminação--%>
                <div class="nomecampos">
                    Iluminação:
                </div>
                <div class="txtcampos">
                    <asp:TextBox ID="txtIluminacao" runat="server" CssClass="bordas" Text="" Width="250px"></asp:TextBox>
                </div>
                <div class="limpaDir">
                </div>
                <%--Botões Salvar e Cancelar Iluminação--%>
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
                    <asp:Label ID="Label9" runat="server" EnableViewState="False" Font-Bold="True" Text=" Lista de Iluminações:"></asp:Label>
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
                            <asp:BoundField DataField="descIluminacao" SortExpression="descIluminacao" HeaderText="Iluminação">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Link" CommandName="editarIluminacao" Text='<img alt="" title="Editar Iluminação" src="../images/editar.png" style="border: 0px" />'>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Link" CommandName="excluirIluminacao" Text='<img alt="" title="Excluir Iluminação" src="../images/excluir.png" style="border: 0px" />'>
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
                                            Nenhuma Iluminação Encontrada.
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
        <%--FIM ABA CADASTRO / ATUALIZAÇÃO DE ILUMINAÇÃO--%>
        <div style="height: 3px;">
        </div>
        <%--ABA CADASTRO / ATUALIZAÇÃO DE MURO EDIFICAÇÃO--%>
        <div onclick="javascript: $('#divMuro').toggle('slow');" class="abas">
            <div style="padding: 3px 5px 0 5px; float: left">
                <%--<asp:Image ID="Image6" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />--%>
            </div>
            <asp:Label ID="Label4" runat="server" Text="Muro Edificação" EnableViewState="false"></asp:Label>
        </div>
        <div id="divMuro" style="display: none;">
            <asp:Panel ID="PanelMuro" runat="server" Visible="true">
                <div class="alinhaDir">
                    <asp:Image ID="Image7" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                        Height="12px" Width="20px" />
                    <asp:Label ID="Label5" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                        Text=" Administrar Muro Edificação"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir">
                    <asp:Image ID="Image8" runat="server" EnableViewState="false" ToolTip=" Informações para realização de Cadastro de Muro Edificação"
                        ImageUrl="~/images/information32.png" />
                </div>
                <div class="alinhaDir" style="padding-top: 14px;">
                    <asp:Label ID="Label6" runat="server" EnableViewState="False" ForeColor="#099409"
                        Font-Size="14px" Font-Bold="True" Text=" Digite o Muro Edificação e clique em 'Salvar'. Para editá-lo clique em 'Editar' da Lista de Muro Edificação."></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image9" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label7" runat="server" EnableViewState="False" Font-Bold="True" Text="Cadastro de Muro Edificação:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <%--Descrição da Muro Edificação--%>
                <div class="nomecampos">
                    Muro Edificação:
                </div>
                <div class="txtcampos">
                    <asp:TextBox ID="txtMuro" runat="server" CssClass="bordas" Text="" Width="250px"></asp:TextBox>
                </div>
                <div class="limpaDir">
                </div>
                <%--Botões Salvar e Cancelar Muro Edificação--%>
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
                    <asp:Label ID="Label11" runat="server" EnableViewState="False" Font-Bold="True" Text=" Lista de Muro Edificação:"></asp:Label>
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
                                HeaderText="Muro Edificação">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Link" CommandName="editarMuro" Text='<img alt="" title="Editar Muro Edificação" src="../images/editar.png" style="border: 0px" />'>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Link" CommandName="excluirMuro" Text='<img alt="" title="Excluir Muro Edificação" src="../images/excluir.png" style="border: 0px" />'>
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
                                            Nenhum Muro Edificação Encontrado.
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
        <%--FIM ABA CADASTRO / ATUALIZAÇÃO DE MURO EDIFICAÇÃO--%>
        <div style="height: 3px;">
        </div>
        <%--ABA CADASTRO / ATUALIZAÇÃO DE POSTEAMENTO--%>
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
                    <asp:Image ID="Image19" runat="server" EnableViewState="false" ToolTip="Informações para realização do Cadastro e Atualização de Posteamento"
                        ImageUrl="~/images/information32.png" />
                </div>
                <div class="alinhaDir" style="padding-top: 14px;">
                    <asp:Label ID="Label25" runat="server" EnableViewState="False" ForeColor="#099409"
                        Font-Size="14px" Font-Bold="True" Text=" Digite o posteanento e clique em 'Salvar'. Para editá-lo clique 'Editar' da Lista de Posteamento."></asp:Label>
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
                <%--Botões Salvar e Cancelar Posteamento--%>
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
        <%--FIM PANEL CADASTRO / ATUALIZAÇÃO DE POSTEAMENTO--%>
        <div style="height: 3px;">
        </div>
        <%--ABA CADASTRO / ATUALIZAÇÃO DE SINALIZAÇÃO--%>
        <div onclick="javascript: $('#divSinalizacao').toggle('slow');" class="abas">
            <div style="padding: 3px 5px 0 5px; float: left">
                <%--       <asp:Image ID="ImageSinalizacao" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />--%>
            </div>
            <asp:Label ID="LabelSinalizacaoTitulo" runat="server" Text="Sinalização" EnableViewState="false"></asp:Label>
        </div>
        <div id="divSinalizacao" style="display: none;">
            <asp:Panel ID="PanelSinalizacao" runat="server" Visible="true">
                <div class="alinhaDir">
                    <asp:Image ID="Image6" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                        Height="12px" Width="20px" />
                    <asp:Label ID="Label15" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                        Text="Administrar Sinalização"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir">
                    <asp:Image ID="Image10" runat="server" EnableViewState="false" ToolTip="Informações para realização do Cadastro e Atualização de Sinalização"
                        ImageUrl="~/images/information32.png" />
                </div>
                <div class="alinhaDir" style="padding-top: 14px;">
                    <asp:Label ID="Label17" runat="server" EnableViewState="False" ForeColor="#099409"
                        Font-Size="14px" Font-Bold="True" Text=" Digite a sinalização e clique em 'Salvar'. Para editá-lo clique 'Editar' da Lista de Sinalização."></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image15" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label18" runat="server" EnableViewState="False" Font-Bold="True" Text=" Cadastro de Sinalização:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="nomecampos">
                    Sinalização:
                </div>
                <div class="txtcampos">
                    <asp:TextBox ID="txtSinalizacao" runat="server" CssClass="bordas" Text="" Width="300px"></asp:TextBox>
                </div>
                <div class="limpaDir">
                </div>
                <%--Botões Salvar e Cancelar Sinalizacao--%>
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
                    <asp:Label ID="Label21" runat="server" EnableViewState="False" Font-Bold="True" Text=" Lista de Sinalização:"></asp:Label>
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
                            <asp:BoundField DataField="descSinalizacao" SortExpression="descSinalizacao" HeaderText="Sinalização">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Link" CommandName="editarSinalizacao" Text='<img alt="" title="Editar Sinalização" src="../images/editar.png" style="border: 0px" />'>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Link" CommandName="excluirSinalizacao" Text='<img alt="" title="Excluir Sinalização" src="../images/excluir.png" style="border: 0px" />'>
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
                                            Nenhuna Sinalização Encontrada.
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
        <%--FIM PANEL CADASTRO / ATUALIZAÇÃO DE SINALIZAÇÃO--%>
        <div style="height: 3px;">
        </div>
        <%--ABA CADASTRO / ATUALIZAÇÃO DE SITUAÇÃO DA FIAÇÃO--%>
        <div onclick="javascript: $('#divSituacaoFiacao').toggle('slow');" class="abas">
            <div style="padding: 3px 5px 0 5px; float: left">
                <%--       <asp:Image ID="ImageSinalizacao" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />--%>
            </div>
            <asp:Label ID="LabelTituloSituacaoFiacao" runat="server" Text="Situação da Fiação"
                EnableViewState="false"></asp:Label>
        </div>
        <div id="divSituacaoFiacao" style="display: none;">
            <asp:Panel ID="PanelSituacaoFiacao" runat="server" Visible="true">
                <div class="alinhaDir">
                    <asp:Image ID="Image17" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                        Height="12px" Width="20px" />
                    <asp:Label ID="Label19" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                        Text="Administrar Situação da Fiação"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir">
                    <asp:Image ID="Image23" runat="server" EnableViewState="false" ToolTip="Informações para realização do Cadastro e Atualização da Situação da Fiação"
                        ImageUrl="~/images/information32.png" />
                </div>
                <div class="alinhaDir" style="padding-top: 14px;">
                    <asp:Label ID="Label20" runat="server" EnableViewState="False" ForeColor="#099409"
                        Font-Size="14px" Font-Bold="True" Text=" Digite a situação da fiação e clique em 'Salvar'. Para editá-lo clique 'Editar' da Lista de Situações da Fiação."></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image24" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label22" runat="server" EnableViewState="False" Font-Bold="True" Text=" Cadastro da Situação da Fiação:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="nomecampos">
                    Situação da Fiação:
                </div>
                <div class="txtcampos">
                    <asp:TextBox ID="txtSituacaoFiacao" runat="server" CssClass="bordas" Text="" Width="300px"></asp:TextBox>
                </div>
                <div class="limpaDir">
                </div>
                <%--Botões Salvar e Cancelar SituacaoFiacao--%>
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
                    <asp:Label ID="Label27" runat="server" EnableViewState="False" Font-Bold="True" Text=" Lista de Situações de Fiação:"></asp:Label>
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
                                HeaderText="Situação da Fiação">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Link" CommandName="editarSituacaoFiacao" Text='<img alt="" title="Editar Situação da Fiação" src="../images/editar.png" style="border: 0px" />'>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Link" CommandName="excluirSituacaoFiacao" Text='<img alt="" title="Excluir Situação da Fiação" src="../images/excluir.png" style="border: 0px" />'>
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
                                            Nenhuna Situação da Fiação Encontrada.
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
        <%--FIM PANEL CADASTRO / ATUALIZAÇÃO DE SITUAÇÃO DA FIAÇÃO--%>
        <div style="height: 3px;">
        </div>
        <%--ABA CADASTRO / ATUALIZAÇÃO DE TIPO DA FIAÇÃO--%>
        <div onclick="javascript: $('#divTipoFiacao').toggle('slow');" class="abas">
            <div style="padding: 3px 5px 0 5px; float: left">
                <%--       <asp:Image ID="ImageSinalizacao" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />--%>
            </div>
            <asp:Label ID="Label14" runat="server" Text="Tipo da Fiação" EnableViewState="false"></asp:Label>
        </div>
        <div id="divTipoFiacao" style="display: none;">
            <asp:Panel ID="PanelTipoFiacao" runat="server" Visible="true">
                <div class="alinhaDir">
                    <asp:Image ID="Image25" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                        Height="12px" Width="20px" />
                    <asp:Label ID="Label23" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                        Text="Administrar Tipo de Fiação"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir">
                    <asp:Image ID="Image27" runat="server" EnableViewState="false" ToolTip="Informações para realização do Cadastro e Atualização do Tipo de Fiação"
                        ImageUrl="~/images/information32.png" />
                </div>
                <div class="alinhaDir" style="padding-top: 14px;">
                    <asp:Label ID="Label26" runat="server" EnableViewState="False" ForeColor="#099409"
                        Font-Size="14px" Font-Bold="True" Text=" Digite o tipo de fiação e clique em 'Salvar'. Para editá-lo clique 'Editar' da Lista de Tipo de Fiação."></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image28" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label28" runat="server" EnableViewState="False" Font-Bold="True" Text=" Cadastro do Tipo de Fiação:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="nomecampos">
                    Tipo de Fiação:
                </div>
                <div class="txtcampos">
                    <asp:TextBox ID="txtTipoFiacao" runat="server" CssClass="bordas" Text="" Width="300px"></asp:TextBox>
                </div>
                <div class="limpaDir">
                </div>
                <%--Botões Salvar e Cancelar TipoFiacao--%>
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
                    <asp:Label ID="Label32" runat="server" EnableViewState="False" Font-Bold="True" Text=" Lista de Tipos de Fiação:"></asp:Label>
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
                            <asp:BoundField DataField="descTipoFiacao" SortExpression="descTipoFiacao" HeaderText="Tipo da Fiação">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Link" CommandName="editarTipoFiacao" Text='<img alt="" title="Clique aqui para editar Tipo da Fiação" src="../images/editar.png" style="border: 0px" />'>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Link" CommandName="excluirTipoFiacao" Text='<img alt="" title="Excluir Tipo da Fiação" src="../images/excluir.png" style="border: 0px" />'>
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
                                            Nenhum Tipo de Fiação Encontrado.
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
        <%--FIM PANEL CADASTRO / ATUALIZAÇÃO DO TIPO DE FIAÇÃO--%>
        <div style="height: 3px;">
        </div>
        <%--ABA CADASTRO / ATUALIZAÇÃO DE TIPO DE RAIZ NO PAVIMENTO--%>
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
                    <asp:Image ID="Image13" runat="server" EnableViewState="false" ToolTip="Informações para realização do Cadastro e Atualização de Tipo de Raiz no Pavimento"
                        ImageUrl="~/images/information32.png" />
                </div>
                <div class="alinhaDir" style="padding-top: 14px;">
                    <asp:Label ID="Label12" runat="server" EnableViewState="False" ForeColor="#099409"
                        Font-Size="14px" Font-Bold="True" Text=" Digite o Tipo de Raiz no Pavimento e clique em 'Salvar'. Para editá-lo clique 'Editar' da Lista de Raiz no Pavimento."></asp:Label>
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
                <%--Botões Salvar e Cancelar Posteamento--%>
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
        <%--FIM PANEL CADASTRO / ATUALIZAÇÃO DE TIPO DE RAIZ NO PAVIMENTO--%>
        <div style="height: 3px;">
        </div>
        <%--ABA CADASTRO / ATUALIZAÇÃO DO TRAFEGO--%>
        <div onclick="javascript: $('#divTrafego').toggle('slow');" class="abas">
            <div style="padding: 3px 5px 0 5px; float: left">
                <%--       <asp:Image ID="ImageSinalizacao" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />--%>
            </div>
            <asp:Label ID="LabelTitulodivTrafego" runat="server" Text="Tráfego" EnableViewState="false"></asp:Label>
        </div>
        <div id="divTrafego" style="display: none;">
            <asp:Panel ID="PanelTrafego" runat="server" Visible="true">
                <div class="alinhaDir">
                    <asp:Image ID="Image29" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                        Height="12px" Width="20px" />
                    <asp:Label ID="Label31" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                        Text="Administrar Tráfego"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir">
                    <asp:Image ID="Image31" runat="server" EnableViewState="false" ToolTip="Informações para realização do Cadastro e Atualização de Tráfego"
                        ImageUrl="~/images/information32.png" />
                </div>
                <div class="alinhaDir" style="padding-top: 14px;">
                    <asp:Label ID="Label33" runat="server" EnableViewState="False" ForeColor="#099409"
                        Font-Size="14px" Font-Bold="True" Text=" Digite o Tráfego e clique em 'Salvar'. Para editá-lo clique 'Editar' da Lista Tráfegos."></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image32" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label34" runat="server" EnableViewState="False" Font-Bold="True" Text=" Cadastro do Tráfego:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="nomecampos">
                    Tráfego:
                </div>
                <div class="txtcampos">
                    <asp:TextBox ID="txtTrafego" runat="server" CssClass="bordas" Text="" Width="300px"></asp:TextBox>
                </div>
                <div class="limpaDir">
                </div>
                <%--Botões Salvar e Cancelar Trafego--%>
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
                    <asp:Label ID="Label37" runat="server" EnableViewState="False" Font-Bold="True" Text=" Lista de Tráfegos:"></asp:Label>
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
                            <asp:BoundField DataField="descTrafego" SortExpression="descTrafego" HeaderText="Tipo de Tráfego">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Link" CommandName="editarTrafego" Text='<img alt="" title="Clique aqui para editar o Tráfego" src="../images/editar.png" style="border: 0px" />'>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Link" CommandName="excluirTrafego" Text='<img alt="" title="Excluir Tráfego" src="../images/excluir.png" style="border: 0px" />'>
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
                                            Nenhum Tráfego Encontrado.
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
        <%--FIM PANEL CADASTRO / ATUALIZAÇÃO DO TIPO DE FIAÇÃO--%>
    </div>
</asp:Content>
