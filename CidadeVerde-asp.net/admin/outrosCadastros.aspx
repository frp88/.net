<%@ Page Language="C#" MasterPageFile="~/admin/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="outrosCadastros.aspx.cs" Inherits="admin_outrosCadastros" Title="CV - Outros Cadastros" %>

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
        <asp:Panel ID="panelInicio" runat="server" Visible="true">
            <div class="alinhaDir">
                <asp:Image ID="Image1" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                    Height="12px" Width="20px" />
                <asp:Label ID="Label01" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                    Text="Outros Cadastros"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
            <div class="alinhaDir">
                <asp:Image ID="ImageAjuda" runat="server" EnableViewState="false" ToolTip="Informações para realização de Outros Cadastros"
                    ImageUrl="~/images/information32.png" />
            </div>
            <div class="alinhaDir" style="padding-top: 14px;">
                <asp:Label ID="LabelAjuda" runat="server" EnableViewState="False" ForeColor="#099409"
                    Font-Size="14px" Font-Bold="True" Text="Para realizar outros cadastros clique abaixo no Tipo de Cadastro desejado"></asp:Label>
            </div>
            <div class="limpaDir">
            </div>
        </asp:Panel>
        <%--PANEL CADASTRO / ATUALIZAÇÃO DE FAMÍLIA--%>
        <div onclick="javascript: $('#divFamilia').toggle('slow');" class="abas">
            <div style="padding: 3px 5px 0 5px; float: left">
                <%--      <asp:Image ID="ImageIluminacao" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />--%>
            </div>
            <asp:Label ID="LabelIluminacao" runat="server" Text="Família" EnableViewState="false"></asp:Label>
        </div>
        <div id="divFamilia" style="display: none;">
            <asp:Panel ID="PanelFamiliaCad" runat="server" Visible="true">
                <div class="alinhaDir">
                    <asp:Image ID="Image2" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                        Height="12px" Width="20px" />
                    <asp:Label ID="Label2" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                        Text=" Administrar Famílias"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir">
                    <asp:Image ID="Image3" runat="server" EnableViewState="false" ToolTip=" Informações para realização de Outros Cadastros"
                        ImageUrl="~/images/information32.png" />
                </div>
                <div class="alinhaDir" style="padding-top: 14px;">
                    <asp:Label ID="Label3" runat="server" EnableViewState="False" ForeColor="#099409"
                        Font-Size="14px" Font-Bold="True" Text=" Digite a família e clique em 'Salvar'. Para editar uma família clique na imagem 'Editar' da Lista de Família."></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div style="margin-left: -8px;">
                    <hr />
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image5" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="LabelFamiliaTitulo" runat="server" EnableViewState="False" Font-Bold="True"
                        Text=" Cadastro de Família:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <%--Descrição da Familia--%>
                <div class="nomecampos">
                    Família:
                </div>
                <div class="txtcampos">
                    <asp:TextBox ID="txtFamilia" runat="server" CssClass="bordas" Text="" Width="250px"></asp:TextBox>
                </div>
                <div class="limpaDir">
                </div>
                <%--Botões Salvar e Cancelar Familia--%>
                <div class="botoesCentro">
                    <asp:Button ID="btFamiliaSalvar" runat="server" CssClass="botoes" Text="Salvar" OnClick="btFamiliaSalvar_Click" />
                    <asp:Button ID="btFamiliaCancelar" runat="server" CssClass="botoes" Text="Cancelar"
                        OnClick="btFamiliaCancelar_Click" />
                </div>
                <div class="limpaDir">
                </div>
                <div class="botoesCentro">
                    <asp:Panel ID="PanelFamiliaConfirma" runat="server" Visible="false">
                        <div class="alinhaDir" style="margin-left: -30px;">
                            <asp:Image ID="ImageFamliaConfirma" runat="server" ImageUrl="~/images/confirmation32.png" />
                        </div>
                        <div style="padding-top: 14px; width: 300px;">
                            <asp:Label ID="LabelFamiliaErro" runat="server" Text="" Font-Bold="true" ForeColor="#CC0000"></asp:Label>
                            <asp:Label ID="LabelFamiliaOk" runat="server" Text="" Font-Bold="true" ForeColor="#099409"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <div class="limpaDir">
                </div>
                <div style="margin-left: -8px;">
                    <hr />
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image4" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label9" runat="server" EnableViewState="False" Font-Bold="True" Text=" Lista de Famílias:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-left: 30px;">
                    <asp:GridView ID="GridViewFamilias" runat="server" BackColor="White" AutoGenerateColumns="False"
                        BorderColor="#0D5600" Width="400px" HorizontalAlign="Center" CellPadding="2"
                        AllowPaging="True" BorderStyle="Double" BorderWidth="3px" GridLines="Vertical"
                        OnRowDataBound="GridViewFamilias_RowDataBound" OnPageIndexChanging="GridViewFamilias_PageIndexChanging"
                        OnRowCommand="GridViewFamilias_RowCommand">
                        <RowStyle BackColor="#ffffff" />
                        <Columns>
                            <asp:BoundField DataField="codFamilia" SortExpression="codFamilia" HeaderText="codFamilia">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descFamilia" SortExpression="descFamilia" HeaderText="Família">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Link" CommandName="editarFamilia" Text='<img alt="" title="Editar Família" src="../images/editar.png" style="border: 0px" />'>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Link" CommandName="excluirFamilia" Text='<img alt="" title="Excluir Família" src="../images/excluir.png" style="border: 0px" />'>
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
                                            Nenhuma Família Encontrada.
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
        <%--FIM PANEL CADASTRO / ATUALIZAÇÃO DE FAMÍLIA--%>
        <div style="height: 3px;">
        </div>
        <%--PANEL CADASTRO / ATUALIZAÇÃO DE FORMA DA COPA--%>
        <div onclick="javascript: $('#divFormaCopa').toggle('slow');" class="abas">
            <div style="padding: 3px 5px 0 5px; float: left">
                <%--      <asp:Image ID="ImageIluminacao" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />--%>
            </div>
            <asp:Label ID="Label45" runat="server" Text="Forma da Copa" EnableViewState="false"></asp:Label>
        </div>
        <div id="divFormaCopa" style="display: none;">
            <asp:Panel ID="PanelFormaCopaCad" runat="server" Visible="true">
                <div class="alinhaDir">
                    <asp:Image ID="Image6" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                        Height="12px" Width="20px" />
                    <asp:Label ID="Label46" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                        Text=" Administrar Formas da Copa"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir">
                    <asp:Image ID="Image46" runat="server" EnableViewState="false" ToolTip=" Informações para realização de Cadastros de Formas da Copa"
                        ImageUrl="~/images/information32.png" />
                </div>
                <div class="alinhaDir" style="padding-top: 14px;">
                    <asp:Label ID="Label47" runat="server" EnableViewState="False" ForeColor="#099409"
                        Font-Size="14px" Font-Bold="True" Text=" Digite a Forma da Copa e clique em 'Salvar'. Para editá-la clique na imagem 'Editar' da Lista de Formas da Copa."></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div style="margin-left: -8px;">
                    <hr />
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image48" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label48" runat="server" EnableViewState="False" Font-Bold="True" Text=" Cadastro de Formas de Copa:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <%--Descrição da Forma da Copa--%>
                <div class="nomecampos">
                    Forma da Copa:
                </div>
                <div class="txtcampos">
                    <asp:TextBox ID="txtFormaCopa" runat="server" CssClass="bordas" Text="" Width="250px"></asp:TextBox>
                </div>
                <div class="limpaDir">
                </div>
                <%--Botões Salvar e Cancelar Forma da Copa--%>
                <div class="botoesCentro">
                    <asp:Button ID="btFormaCopaSalvar" runat="server" CssClass="botoes" Text="Salvar"
                        OnClick="btFormaCopaSalvar_Click" />
                    <asp:Button ID="btFormaCopaCancelar" runat="server" CssClass="botoes" Text="Cancelar"
                        OnClick="btFormaCopaCancelar_Click" />
                </div>
                <div class="limpaDir">
                </div>
                <div class="botoesCentro">
                    <asp:Panel ID="PanelFormaCopaConfirma" runat="server" Visible="false">
                        <div class="alinhaDir" style="margin-left: -30px;">
                            <asp:Image ID="ImageFormaCopaConfirma" runat="server" ImageUrl="~/images/confirmation32.png" />
                        </div>
                        <div style="padding-top: 14px; width: 300px;">
                            <asp:Label ID="LabelFormaCopaErro" runat="server" Text="" Font-Bold="true" ForeColor="#CC0000"></asp:Label>
                            <asp:Label ID="LabelFormaCopaOk" runat="server" Text="" Font-Bold="true" ForeColor="#099409"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <div class="limpaDir">
                </div>
                <div style="margin-left: -8px;">
                    <hr />
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image50" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label51" runat="server" EnableViewState="False" Font-Bold="True" Text=" Lista de Formas da Copa:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-left: 30px;">
                    <asp:GridView ID="GridViewFormaCopa" runat="server" BackColor="White" AutoGenerateColumns="False"
                        BorderColor="#0D5600" Width="400px" HorizontalAlign="Center" CellPadding="2"
                        AllowPaging="True" BorderStyle="Double" BorderWidth="3px" GridLines="Vertical"
                        OnRowDataBound="GridViewFormaCopa_RowDataBound" OnPageIndexChanging="GridViewFormaCopa_PageIndexChanging"
                        OnRowCommand="GridViewFormaCopa_RowCommand">
                        <RowStyle BackColor="#ffffff" />
                        <Columns>
                            <asp:BoundField DataField="codFormaCopa" SortExpression="codFormaCopa" HeaderText="codFormaCopa">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descFormaCopa" SortExpression="descFormaCopa" HeaderText="Forma da Copa">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Link" CommandName="editarFormaCopa" Text='<img alt="" title="Editar Forma da Copa" src="../images/editar.png" style="border: 0px" />'>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Link" CommandName="excluirFormaCopa" Text='<img alt="" title="Excluir Forma da Copa" src="../images/excluir.png" style="border: 0px" />'>
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
                                            Nenhuma Forma da Copa Encontrada.
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
        <%--FIM PANEL CADASTRO / ATUALIZAÇÃO DE FORMA DA COPA--%>
        <div style="height: 3px;">
        </div>
        <%--PANEL CADASTRO / ATUALIZAÇÃO DE GÊNERO--%>
        <div onclick="javascript: $('#divGenero').toggle('slow');" class="abas">
            <div style="padding: 3px 5px 0 5px; float: left">
                <%-- <asp:Image ID="Image46" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />--%>
            </div>
            <asp:Label ID="Label34" runat="server" Text="Gênero" EnableViewState="false"></asp:Label>
        </div>
        <div id="divGenero" style="display: none;">
            <asp:Panel ID="PanelGeneroCad" runat="server" Visible="true">
                <div class="alinhaDir">
                    <asp:Image ID="Image8" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                        Height="12px" Width="20px" />
                    <asp:Label ID="Label10" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                        Text=" Administrar Gêneros"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir">
                    <asp:Image ID="Image9" runat="server" EnableViewState="false" ToolTip="Informações para realização do Cadastro de Gênero"
                        ImageUrl="~/images/information32.png" />
                </div>
                <div class="alinhaDir" style="padding-top: 14px;">
                    <asp:Label ID="Label11" runat="server" EnableViewState="False" ForeColor="#099409"
                        Font-Size="14px" Font-Bold="True" Text=" Digite o gênero e clique em 'Salvar'. Para editar um gênero clique na imagem 'Editar' da Lista de Gênero."></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div style="margin-left: -8px;">
                    <hr />
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image10" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="LabelGeneroTitulo" runat="server" EnableViewState="False" Font-Bold="True"
                        Text=" Cadastro de Gênero:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <%--Familias--%>
                <div class="nomecampos">
                    Família:
                </div>
                <div class="txtcampos">
                    <asp:DropDownList ID="ddlFamilia" runat="server" CssClass="bordas" Width="250" AutoPostBack="True"
                        DataTextField="descFamilia" DataValueField="codFamilia" OnSelectedIndexChanged="ddlFamilia_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="0">Selecione uma família</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="limpaDir">
                </div>
                <%--Descrição do Genero--%>
                <div class="nomecampos">
                    Gênero:
                </div>
                <div class="txtcampos">
                    <asp:TextBox ID="txtGenero" runat="server" CssClass="bordas" Text="" Width="250px"></asp:TextBox>
                </div>
                <div class="limpaDir">
                </div>
                <%--Botões Salvar e Cancelar Genero--%>
                <div class="botoesCentro">
                    <asp:Button ID="btGeneroSalvar" runat="server" CssClass="botoes" Text="Salvar" OnClick="btGeneroSalvar_Click" />
                    <asp:Button ID="btGeneroCancelar" runat="server" CssClass="botoes" Text="Cancelar"
                        OnClick="btGeneroCancelar_Click" />
                </div>
                <div class="limpaDir">
                </div>
                <div class="botoesCentro">
                    <asp:Panel ID="PanelGeneroConfirma" runat="server" Visible="false">
                        <div class="alinhaDir" style="margin-left: -30px;">
                            <asp:Image ID="ImageGeneroConfirma" runat="server" ImageUrl="~/images/confirmation32.png" />
                        </div>
                        <div style="padding-top: 14px; width: 300px;">
                            <asp:Label ID="LabelGeneroErro" runat="server" Text="" Font-Bold="true" ForeColor="#CC0000"></asp:Label>
                            <asp:Label ID="LabelGeneroOk" runat="server" Text="" Font-Bold="true" ForeColor="#099409"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <div class="limpaDir">
                </div>
                <div style="margin-left: -8px;">
                    <hr />
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image12" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label16" runat="server" EnableViewState="False" Font-Bold="True" Text=" Lista de Gêneros:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-left: 30px;">
                    <asp:GridView ID="GridViewGeneros" runat="server" BackColor="White" AutoGenerateColumns="False"
                        BorderColor="#0D5600" Width="500px" HorizontalAlign="Center" CellPadding="2"
                        AllowPaging="True" BorderStyle="Double" BorderWidth="3px" GridLines="Vertical"
                        OnPageIndexChanging="GridViewGeneros_PageIndexChanging" OnRowCommand="GridViewGeneros_RowCommand"
                        OnRowDataBound="GridViewGeneros_RowDataBound">
                        <RowStyle BackColor="#ffffff" />
                        <Columns>
                            <asp:BoundField DataField="codGenero" SortExpression="codGenero" HeaderText="codGenero">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descGenero" SortExpression="descGenero" HeaderText="Gênero">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="codFamilia" SortExpression="codFamilia" HeaderText="codFamilia">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descFamilia" SortExpression="descFamilia" HeaderText="Família">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Link" CommandName="editarGenero" Text='<img alt="" title="Editar Gênero" src="../images/editar.png" style="border: 0px" />'>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Link" CommandName="excluirGenero" Text='<img alt="" title="Excluir Gênero" src="../images/excluir.png" style="border: 0px" />'>
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
                                            Nenhum Gênero Encontrado.
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
        <%--FIM PANEL CADASTRO / ATUALIZAÇÃO DE GÊNERO--%>
        <div style="height: 3px;">
        </div>
        <%--PANEL CADASTRO / ATUALIZAÇÃO DE PARASITAS--%>
        <div onclick="javascript: $('#divParasitas').toggle('slow');" class="abas">
            <div style="padding: 3px 5px 0 5px; float: left">
                <%--   <asp:Image ID="Image48" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />--%>
            </div>
            <asp:Label ID="Label36" runat="server" Text="Parasitas" EnableViewState="false"></asp:Label>
        </div>
        <div id="divParasitas" style="display: none;">
            <asp:Panel ID="PanelParasitasCad" runat="server" Visible="true">
                <div class="alinhaDir">
                    <asp:Image ID="Image13" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                        Height="12px" Width="20px" />
                    <asp:Label ID="Label17" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                        Text="Administrar Parasitas"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir">
                    <asp:Image ID="Image14" runat="server" EnableViewState="false" ToolTip="Informações para realização do cadastro de Parasitas"
                        ImageUrl="~/images/information32.png" />
                </div>
                <div class="alinhaDir" style="padding-top: 14px;">
                    <asp:Label ID="Label18" runat="server" EnableViewState="False" ForeColor="#099409"
                        Font-Size="14px" Font-Bold="True" Text=" Digite o parasita e clique em 'Salvar'. Para editar um parasita clique na imagem 'Editar' da Lista de Parasita."></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div style="margin-left: -8px;">
                    <hr />
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image15" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="LabelParasitaTitulo" runat="server" EnableViewState="False" Font-Bold="True"
                        Text=" Cadastro de Parasitas:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <%--Descrição do Parasita--%>
                <div class="nomecampos">
                    Parasita:
                </div>
                <div class="txtcampos">
                    <asp:TextBox ID="txtParasita" runat="server" CssClass="bordas" Text="" Width="300px"></asp:TextBox>
                </div>
                <div class="limpaDir">
                </div>
                <%--Botões Salvar e Cancelar Parasita--%>
                <div class="botoesCentro">
                    <asp:Button ID="btParasitaSalvar" runat="server" CssClass="botoes" Text="Salvar"
                        OnClick="btParasitaSalvar_Click" />
                    <asp:Button ID="btParasitaCancelar" runat="server" CssClass="botoes" Text="Cancelar"
                        OnClick="btParasitaCancelar_Click" />
                </div>
                <div class="limpaDir">
                </div>
                <div class="botoesCentro">
                    <asp:Panel ID="PanelParasitaConfirma" runat="server" Visible="false">
                        <div class="alinhaDir" style="margin-left: -30px;">
                            <asp:Image ID="ImageParasitaConfirma" runat="server" ImageUrl="~/images/confirmation32.png" />
                        </div>
                        <div style="padding-top: 14px; width: 300px;">
                            <asp:Label ID="LabelParasitaErro" runat="server" Text="" Font-Bold="true" ForeColor="#CC0000"></asp:Label>
                            <asp:Label ID="LabelParasitaOk" runat="server" Text="" Font-Bold="true" ForeColor="#099409"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <div class="limpaDir">
                </div>
                <div style="margin-left: -8px;">
                    <hr />
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image17" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label23" runat="server" EnableViewState="False" Font-Bold="True" Text=" Lista de Parasitas:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-left: 30px;">
                    <asp:GridView ID="GridViewParasitas" runat="server" BackColor="White" AutoGenerateColumns="False"
                        BorderColor="#0D5600" Width="400px" HorizontalAlign="Center" CellPadding="2"
                        AllowPaging="True" BorderStyle="Double" BorderWidth="3px" GridLines="Vertical"
                        OnPageIndexChanging="GridViewParasitas_PageIndexChanging" OnRowCommand="GridViewParasitas_RowCommand"
                        OnRowDataBound="GridViewParasitas_RowDataBound">
                        <RowStyle BackColor="#ffffff" />
                        <Columns>
                            <asp:BoundField DataField="codParasita" SortExpression="codParasita" HeaderText="codParasita">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descParasita" SortExpression="descParasita" HeaderText="Parasita">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Link" CommandName="editarParasita" Text='<img alt="" title="Editar Parasita" src="../images/editar.png" style="border: 0px" />'>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Link" CommandName="excluirParasita" Text='<img alt="" title="Excluir Parasita" src="../images/excluir.png" style="border: 0px" />'>
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
                                            Nenhum Parasita Encontrado.
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
        <%--FIM PANEL CADASTRO / ATUALIZAÇÃO DE PARASITA--%>
        <div style="height: 3px;">
        </div>
        <%--PANEL CADASTRO / ATUALIZAÇÃO DE GRUPO DE PARASITA--%>
        <div onclick="javascript: $('#divGrupoParasitas').toggle('slow');" class="abas">
            <div style="padding: 3px 5px 0 5px; float: left">
                <%--   <asp:Image ID="Image49" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />--%>
            </div>
            <asp:Label ID="Label37" runat="server" Text="Grupo de Parasitas" EnableViewState="false"></asp:Label>
        </div>
        <div id="divGrupoParasitas" style="display: none;">
            <asp:Panel ID="PanelGrupoParasitaCad" runat="server" Visible="true">
                <div class="alinhaDir">
                    <asp:Image ID="Image18" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                        Height="12px" Width="20px" />
                    <asp:Label ID="Label24" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                        Text="Administrar Grupo de Parasitas"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir">
                    <asp:Image ID="Image19" runat="server" EnableViewState="false" ToolTip="Informações para realização do Cadastro e Atualização de Grupo de Parasitas"
                        ImageUrl="~/images/information32.png" />
                </div>
                <div class="alinhaDir" style="padding-top: 14px;">
                    <asp:Label ID="Label25" runat="server" EnableViewState="False" ForeColor="#099409"
                        Font-Size="14px" Font-Bold="True" Text=" Digite o grupo parasita e clique em 'Salvar'. Para editá-lo clique na imagem 'Editar' da Lista de Grupo de Parasita."></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div style="margin-left: -8px;">
                    <hr />
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image20" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="LabelGrupoParasitaTitulo" runat="server" EnableViewState="False" Font-Bold="True"
                        Text=" Cadastro de Grupo de Parasita:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="nomecampos">
                    Desc. Grupo de Parasita:
                </div>
                <div class="txtcampos">
                    <asp:TextBox ID="txtGrupoParasita" runat="server" CssClass="bordas" Text="" Width="300px"></asp:TextBox>
                </div>
                <div class="limpaDir">
                </div>
                <%--Botões Salvar e Cancelar Grupo de Parasitas--%>
                <div class="botoesCentro">
                    <asp:Button ID="btGrupoParasitaSalvar" runat="server" CssClass="botoes" Text="Salvar"
                        OnClick="btGrupoParasitaSalvar_Click" />
                    <asp:Button ID="btGrupoParasitaCancelar" runat="server" CssClass="botoes" Text="Cancelar"
                        OnClick="btGrupoParasitaCancelar_Click" />
                </div>
                <div class="limpaDir">
                </div>
                <div class="botoesCentro">
                    <asp:Panel ID="PanelGrupoParasitaConfirma" runat="server" Visible="false">
                        <div class="alinhaDir" style="margin-left: -30px;">
                            <asp:Image ID="ImageGrupoParasitaConfirma" runat="server" ImageUrl="~/images/confirmation32.png" />
                        </div>
                        <div style="padding-top: 14px; width: 300px">
                            <asp:Label ID="LabelGrupoParasitaConfirmaErro" runat="server" Text="" Font-Bold="true"
                                ForeColor="#CC0000"></asp:Label>
                            <asp:Label ID="LabelGrupoParasitaConfirmaOk" runat="server" Text="" Font-Bold="true"
                                ForeColor="#099409"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <div class="limpaDir">
                </div>
                <div style="margin-left: -8px;">
                    <hr />
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image22" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label30" runat="server" EnableViewState="False" Font-Bold="True" Text=" Lista de Grupo de Parasitas:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-left: 30px;">
                    <asp:GridView ID="GridViewGrupoParasitas" runat="server" BackColor="White" AutoGenerateColumns="False"
                        BorderColor="#0D5600" Width="400px" HorizontalAlign="Center" CellPadding="2"
                        AllowPaging="True" BorderStyle="Double" BorderWidth="3px" GridLines="Vertical"
                        OnPageIndexChanging="GridViewGrupoParasitas_PageIndexChanging" OnRowCommand="GridViewGrupoParasitas_RowCommand"
                        OnRowDataBound="GridViewGrupoParasitas_RowDataBound">
                        <RowStyle BackColor="#ffffff" />
                        <Columns>
                            <asp:BoundField DataField="codGrupoParasita" SortExpression="codGrupoParasita" HeaderText="codGrupoParasita">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descGrupoParasita" SortExpression="descGrupoParasita"
                                HeaderText="Grupo de Parasita">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Link" CommandName="editarGrupoParasita" Text='<img alt="" title="Editar Grupo de Parasita" src="../images/editar.png" style="border: 0px" />'>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Link" CommandName="excluirGrupoParasita" Text='<img alt="" title="Excluir Grupo de Parasita" src="../images/excluir.png" style="border: 0px" />'>
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
                                            Nenhum Grupo de Parasita Encontrado.
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
        <%--FIM PANEL CADASTRO / ATUALIZAÇÃO DO GRUPO DE PARASITA--%>
        <div style="height: 3px;">
        </div>
        <%--PANEL CADASTRO / ATUALIZAÇÃO DE LOCAL AFETADO--%>
        <div onclick="javascript: $('#divLocalAfetado').toggle('slow');" class="abas">
            <div style="padding: 3px 5px 0 5px; float: left">
                <%-- <asp:Image ID="Image50" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />--%>
            </div>
            <asp:Label ID="Label39" runat="server" Text="Local Afetado" EnableViewState="false"></asp:Label>
        </div>
        <div id="divLocalAfetado" style="display: none;">
            <asp:Panel ID="PanelLocalAfetadoCad" runat="server" Visible="true">
                <div class="alinhaDir">
                    <asp:Image ID="Image7" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                        Height="12px" Width="20px" />
                    <asp:Label ID="Label4" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                        Text="Administrar Local Afetado"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir">
                    <asp:Image ID="Image11" runat="server" EnableViewState="false" ToolTip="Informações para realização do cadastro de Local Afetado"
                        ImageUrl="~/images/information32.png" />
                </div>
                <div class="alinhaDir" style="padding-top: 14px;">
                    <asp:Label ID="Label6" runat="server" EnableViewState="False" ForeColor="#099409"
                        Font-Size="14px" Font-Bold="True" Text=" Digite o local afetado e clique em 'Salvar'. Para editá-lo clique na imagem 'Editar' da Lista de Local Afetado."></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div style="margin-left: -8px;">
                    <hr />
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image16" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="LabelLocalAfetadoTitulo" runat="server" EnableViewState="False" Font-Bold="True"
                        Text=" Cadastro de Local Afetado:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <%--Descrição do Local Afetado--%>
                <div class="nomecampos">
                    Local Afetado:
                </div>
                <div class="txtcampos">
                    <asp:TextBox ID="txtLocalAfetado" runat="server" CssClass="bordas" Text="" Width="300px"></asp:TextBox>
                </div>
                <div class="limpaDir">
                </div>
                <%--Botões Salvar e Cancelar Local Afetado--%>
                <div class="botoesCentro">
                    <asp:Button ID="btLocalAfetadoSalvar" runat="server" CssClass="botoes" Text="Salvar"
                        OnClick="btLocalAfetadoSalvar_Click" />
                    <asp:Button ID="btLocalAfetadoCancelar" runat="server" CssClass="botoes" Text="Cancelar"
                        OnClick="btLocalAfetadoCancelar_Click" />
                </div>
                <div class="limpaDir">
                </div>
                <div class="botoesCentro">
                    <asp:Panel ID="PanelLocalAfetadoConfirma" runat="server" Visible="false">
                        <div class="alinhaDir" style="margin-left: -30px;">
                            <asp:Image ID="ImageLocalAfetadoConfirma" runat="server" ImageUrl="~/images/confirmation32.png" />
                        </div>
                        <div style="padding-top: 14px; width: 300px">
                            <asp:Label ID="LabelLocalAfetadoConfirmaErro" runat="server" Text="" Font-Bold="true"
                                ForeColor="#CC0000"></asp:Label>
                            <asp:Label ID="LabelLocalAfetadoConfirmaOk" runat="server" Text="" Font-Bold="true"
                                ForeColor="#099409"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <div class="limpaDir">
                </div>
                <div style="margin-left: -8px;">
                    <hr />
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image23" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label13" runat="server" EnableViewState="False" Font-Bold="True" Text=" Lista de Local Afetado:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-left: 30px;">
                    <asp:GridView ID="GridViewLocalAfetado" runat="server" BackColor="White" AutoGenerateColumns="False"
                        BorderColor="#0D5600" Width="400px" HorizontalAlign="Center" CellPadding="2"
                        AllowPaging="True" BorderStyle="Double" BorderWidth="3px" GridLines="Vertical"
                        OnPageIndexChanging="GridViewLocalAfetado_PageIndexChanging" OnRowCommand="GridViewLocalAfetado_RowCommand"
                        OnRowDataBound="GridViewLocalAfetado_RowDataBound">
                        <RowStyle BackColor="#ffffff" />
                        <Columns>
                            <asp:BoundField DataField="codLocalAfetado" SortExpression="codLocalAfetado" HeaderText="codLocalAfetado">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descLocalAfetado" SortExpression="descLocalAfetado" HeaderText="Local Afetado">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Link" CommandName="editarLocalAfetado" Text='<img alt="" title="Editar Local Afetado" src="../images/editar.png" style="border: 0px" />'>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Link" CommandName="excluirLocalAfetado" Text='<img alt="" title="Excluir Local Afetado" src="../images/excluir.png" style="border: 0px" />'>
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
                                            Nenhum Local Afetado Encontrado.
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
        <%--FIM PANEL CADASTRO / ATUALIZAÇÃO DE LOCAL AFETADO--%>
        <div style="height: 3px;">
        </div>
        <%--PANEL CADASTRO / ATUALIZAÇÃO DE INTENSIDADE--%>
        <div onclick="javascript: $('#divIntensidade').toggle('slow');" class="abas">
            <div style="padding: 3px 5px 0 5px; float: left">
                <%--      <asp:Image ID="Image51" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />--%>
            </div>
            <asp:Label ID="Label40" runat="server" Text="Intensidade" EnableViewState="false"></asp:Label>
        </div>
        <div id="divIntensidade" style="display: none;">
            <asp:Panel ID="PanelIntensidadeCad" runat="server" Visible="true">
                <div class="alinhaDir">
                    <asp:Image ID="Image21" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                        Height="12px" Width="20px" />
                    <asp:Label ID="Label7" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                        Text="Administrar Intensidades"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir">
                    <asp:Image ID="Image24" runat="server" EnableViewState="false" ToolTip="Informações para realização do cadastro de Intensidade"
                        ImageUrl="~/images/information32.png" />
                </div>
                <div class="alinhaDir" style="padding-top: 14px;">
                    <asp:Label ID="Label8" runat="server" EnableViewState="False" ForeColor="#099409"
                        Font-Size="14px" Font-Bold="True" Text=" Digite a intensidade e clique em 'Salvar'. Para editá-la clique na imagem 'Editar' da Lista de Intensidade."></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div style="margin-left: -8px;">
                    <hr />
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image25" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="LabelIntensidadeTitulo" runat="server" EnableViewState="False" Font-Bold="True"
                        Text=" Cadastro de Intensidade:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <%--Descrição da Intensidade--%>
                <div class="nomecampos">
                    Intensidade:
                </div>
                <div class="txtcampos">
                    <asp:TextBox ID="txtIntensidade" runat="server" CssClass="bordas" Text="" Width="300px"></asp:TextBox>
                </div>
                <div class="limpaDir">
                </div>
                <%--Botões Salvar e Cancelar Intensidade--%>
                <div class="botoesCentro">
                    <asp:Button ID="btIntensidadeSalvar" runat="server" CssClass="botoes" Text="Salvar"
                        OnClick="btIntensidadeSalvar_Click" />
                    <asp:Button ID="btIntensidadeCancelar" runat="server" CssClass="botoes" Text="Cancelar"
                        OnClick="btIntensidadeCancelar_Click" />
                </div>
                <div class="limpaDir">
                </div>
                <div class="botoesCentro">
                    <asp:Panel ID="PanelIntensidadeConfirma" runat="server" Visible="false">
                        <div class="alinhaDir" style="margin-left: -30px;">
                            <asp:Image ID="ImageIntensidadeConfirma" runat="server" ImageUrl="~/images/confirmation32.png" />
                        </div>
                        <div style="padding-top: 14px; width: 300px;">
                            <asp:Label ID="LabelIntensidadeConfirmaErro" runat="server" Text="" Font-Bold="true"
                                ForeColor="#CC0000"></asp:Label>
                            <asp:Label ID="LabelIntensidadeConfirmaOk" runat="server" Text="" Font-Bold="true"
                                ForeColor="#099409"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <div class="limpaDir">
                </div>
                <div style="margin-left: -8px;">
                    <hr />
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image27" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label19" runat="server" EnableViewState="False" Font-Bold="True" Text=" Lista de Intensidades:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-left: 30px;">
                    <asp:GridView ID="GridViewIntensidade" runat="server" BackColor="White" AutoGenerateColumns="False"
                        BorderColor="#0D5600" Width="400px" HorizontalAlign="Center" CellPadding="2"
                        AllowPaging="True" BorderStyle="Double" BorderWidth="3px" GridLines="Vertical"
                        OnPageIndexChanging="GridViewIntensidade_PageIndexChanging" OnRowCommand="GridViewIntensidade_RowCommand"
                        OnRowDataBound="GridViewIntensidade_RowDataBound">
                        <RowStyle BackColor="#ffffff" />
                        <Columns>
                            <asp:BoundField DataField="codIntensidade" SortExpression="codIntensidade" HeaderText="codIntensidade">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descIntensidade" SortExpression="descIntensidade" HeaderText="Intensidade">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Link" CommandName="editarIntensidade" Text='<img alt="" title="Editar Intensidade" src="../images/editar.png" style="border: 0px" />'>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Link" CommandName="excluirIntensidade" Text='<img alt="" title="Excluir Intensidade" src="../images/excluir.png" style="border: 0px" />'>
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
                                            Nenhuma Intensidade Encontrada.
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
        <%--FIM PANEL CADASTRO / ATUALIZAÇÃO DE INTENSIDADE--%>
        <div style="height: 3px;">
        </div>
        <%--PANEL CADASTRO / ATUALIZAÇÃO DE AÇÃO RECOMENDADA--%>
        <div onclick="javascript: $('#divAcaoRec').toggle('slow');" class="abas">
            <div style="padding: 3px 5px 0 5px; float: left">
                <%--       <asp:Image ID="Image52" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />--%>
            </div>
            <asp:Label ID="Label41" runat="server" Text="Ação Recomendada" EnableViewState="false"></asp:Label>
        </div>
        <div id="divAcaoRec" style="display: none;">
            <asp:Panel ID="PanelAcaoRecCad" runat="server" Visible="true">
                <div class="alinhaDir">
                    <asp:Image ID="Image26" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                        Height="12px" Width="20px" />
                    <asp:Label ID="Label12" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                        Text="Administrar Ações Recomendadas"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir">
                    <asp:Image ID="Image28" runat="server" EnableViewState="false" ToolTip="Informações para realização do cadastro de Ação Recomendada"
                        ImageUrl="~/images/information32.png" />
                </div>
                <div class="alinhaDir" style="padding-top: 14px;">
                    <asp:Label ID="Label14" runat="server" EnableViewState="False" ForeColor="#099409"
                        Font-Size="14px" Font-Bold="True" Text=" Digite a ação recomendada e clique em 'Salvar'. Para editá-la clique na imagem 'Editar' da Lista de Ações Rec."></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div style="margin-left: -8px;">
                    <hr />
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image29" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="LabelAcaoRecTitulo" runat="server" EnableViewState="False" Font-Bold="True"
                        Text=" Cadastro de Ação Recomendada:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <%--Descrição da Ação Recomendada--%>
                <div class="nomecampos">
                    Ação Recomendada:
                </div>
                <div class="txtcampos">
                    <asp:TextBox ID="txtAcaoRec" runat="server" CssClass="bordas" Text="" Width="300px"></asp:TextBox>
                </div>
                <div class="limpaDir">
                </div>
                <%--Botões Salvar e Cancelar Intensidade--%>
                <div class="botoesCentro">
                    <asp:Button ID="btAcaoRecSalvar" runat="server" CssClass="botoes" Text="Salvar" OnClick="btAcaoRecSalvar_Click" />
                    <asp:Button ID="btAcaoRecCancelar" runat="server" CssClass="botoes" Text="Cancelar"
                        OnClick="btAcaoRecCancelar_Click" />
                </div>
                <div class="limpaDir">
                </div>
                <div class="botoesCentro">
                    <asp:Panel ID="PanelAcaoRecConfirma" runat="server" Visible="false">
                        <div class="alinhaDir" style="margin-left: -30px;">
                            <asp:Image ID="ImageAcaoRecConfirma" runat="server" ImageUrl="~/images/confirmation32.png" />
                        </div>
                        <div style="padding-top: 14px; width: 400px">
                            <asp:Label ID="LabelAcaoRecConfirmaErro" runat="server" Text="" Font-Bold="true"
                                ForeColor="#CC0000"></asp:Label>
                            <asp:Label ID="LabelAcaoRecConfirmaOk" runat="server" Text="" Font-Bold="true" ForeColor="#099409"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <div class="limpaDir">
                </div>
                <div style="margin-left: -8px;">
                    <hr />
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image31" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label22" runat="server" EnableViewState="False" Font-Bold="True" Text=" Lista de Ações Recomendadas:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-left: 30px;">
                    <asp:GridView ID="GridViewAcaoRecomendada" runat="server" BackColor="White" AutoGenerateColumns="False"
                        BorderColor="#0D5600" Width="400px" HorizontalAlign="Center" CellPadding="2"
                        AllowPaging="True" BorderStyle="Double" BorderWidth="3px" GridLines="Vertical"
                        OnPageIndexChanging="GridViewAcaoRecomendada_PageIndexChanging" OnRowCommand="GridViewAcaoRecomendada_RowCommand"
                        OnRowDataBound="GridViewAcaoRecomendada_RowDataBound">
                        <RowStyle BackColor="#ffffff" />
                        <Columns>
                            <asp:BoundField DataField="codAcaoRecomendada" SortExpression="codAcaoRecomendada"
                                HeaderText="codAcaoRecomendada">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descAcaoRecomendada" SortExpression="descAcaoRecomendada"
                                HeaderText="Ação Recomendada">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Link" CommandName="editarAcaoRec" Text='<img alt="" title="Editar Ação Recomendada" src="../images/editar.png" style="border: 0px" />'>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Link" CommandName="excluirAcaoRec" Text='<img alt="" title="Excluir Ação Recomendada" src="../images/excluir.png" style="border: 0px" />'>
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
                                            Nenhuma Ação Recomendada Encontrada.
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
        <%--FIM PANEL CADASTRO / ATUALIZAÇÃO DE AÇÃO RECOMENDADA--%>
        <div style="height: 3px;">
        </div>
        <%--PANEL CADASTRO / ATUALIZAÇÃO DE LOCAL ENTORNO--%>
        <div onclick="javascript: $('#divEntorno').toggle('slow');" class="abas">
            <div style="padding: 3px 5px 0 5px; float: left">
                <%--  <asp:Image ID="Image53" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />--%>
            </div>
            <asp:Label ID="Label42" runat="server" Text="Entorno da Árvore" EnableViewState="false"></asp:Label>
        </div>
        <div id="divEntorno" style="display: none;">
            <asp:Panel ID="PanelLocalEntornoCad" runat="server" Visible="true">
                <div class="alinhaDir">
                    <asp:Image ID="Image30" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                        Height="12px" Width="20px" />
                    <asp:Label ID="Label15" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                        Text="Administrar Tipo  de Entorno da Árvore"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir">
                    <asp:Image ID="Image32" runat="server" EnableViewState="false" ToolTip="Informações para realização do cadastro do local da árvore"
                        ImageUrl="~/images/information32.png" />
                </div>
                <div class="alinhaDir" style="padding-top: 14px;">
                    <asp:Label ID="Label20" runat="server" EnableViewState="False" ForeColor="#099409"
                        Font-Size="14px" Font-Bold="True" Text=" Digite o Tipo de Entorno da árvore e clique em 'Salvar'. Para editar um local clique na imagem 'Editar' da Lista de Locais."></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div style="margin-left: -8px;">
                    <hr />
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image33" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="LabelLocalEntornoTitulo" runat="server" EnableViewState="False" Font-Bold="True"
                        Text=" Cadastro do Local da Árvore:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <%--Descrição do Local do Entorno da Árvore--%>
                <div class="nomecampos">
                    Local Entorno:
                </div>
                <div class="txtcampos">
                    <asp:TextBox ID="txtLocalEntorno" runat="server" CssClass="bordas" Text="" Width="300px"></asp:TextBox>
                </div>
                <div class="limpaDir">
                </div>
                <%--Botões Salvar e Cancelar Local do Entorno da Árvore--%>
                <div class="botoesCentro">
                    <asp:Button ID="btLocalEntornoSalvar" runat="server" CssClass="botoes" Text="Salvar"
                        OnClick="btLocalEntornoSalvar_Click" />
                    <asp:Button ID="btLocalEntornoCancelar" runat="server" CssClass="botoes" Text="Cancelar"
                        OnClick="btLocalEntornoCancelar_Click" />
                </div>
                <div class="limpaDir">
                </div>
                <div class="botoesCentro">
                    <asp:Panel ID="PanelLocalEntornoConfirma" runat="server" Visible="false">
                        <div class="alinhaDir" style="margin-left: -30px;">
                            <asp:Image ID="ImageLocalEntornoConfirma" runat="server" ImageUrl="~/images/confirmation32.png" />
                        </div>
                        <div style="padding-top: 14px; width: 300px">
                            <asp:Label ID="LabelLocalEntornoErro" runat="server" Text="" Font-Bold="true" ForeColor="#CC0000"></asp:Label>
                            <asp:Label ID="LabelLocalEntornoOk" runat="server" Text="" Font-Bold="true" ForeColor="#099409"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <div class="limpaDir">
                </div>
                <div style="margin-left: -8px;">
                    <hr />
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image35" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label28" runat="server" EnableViewState="False" Font-Bold="True" Text=" Lista de Locais:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-left: 30px;">
                    <asp:GridView ID="GridViewLocalEntorno" runat="server" BackColor="White" AutoGenerateColumns="False"
                        BorderColor="#0D5600" Width="400px" HorizontalAlign="Center" CellPadding="2"
                        AllowPaging="True" BorderStyle="Double" BorderWidth="3px" GridLines="Vertical"
                        OnPageIndexChanging="GridViewLocalEntorno_PageIndexChanging" OnRowCommand="GridViewLocalEntorno_RowCommand"
                        OnRowDataBound="GridViewLocalEntorno_RowDataBound">
                        <RowStyle BackColor="#ffffff" />
                        <Columns>
                            <asp:BoundField DataField="codLocalEntorno" SortExpression="codLocalEntorno" HeaderText="codLocalEntorno">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descLocalEntorno" SortExpression="descLocalEntorno" HeaderText="Local">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Link" CommandName="editarLocalEntorno" Text='<img alt="" title="Editar Local Entorno" src="../images/editar.png" style="border: 0px" />'>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Link" CommandName="excluirLocalEntorno" Text='<img alt="" title="Excluir Local Entorno" src="../images/excluir.png" style="border: 0px" />'>
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
                                            Nenhuma Local Encontrado.
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
        <%--FIM PANEL CADASTRO / ATUALIZAÇÃO DE LOCAL ENTORNO--%>
        <div style="height: 3px;">
        </div>
        <%--PANEL CADASTRO / ATUALIZAÇÃO DE PARTICIPAÇÃO--%>
        <div onclick="javascript: $('#divParticipacao').toggle('slow');" class="abas">
            <div style="padding: 3px 5px 0 5px; float: left">
                <%--    <asp:Image ID="Image54" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />--%>
            </div>
            <asp:Label ID="Label43" runat="server" Text="Participação" EnableViewState="false"></asp:Label>
        </div>
        <div id="divParticipacao" style="display: none;">
            <asp:Panel ID="PanelParticipacaoCad" runat="server" Visible="true">
                <div class="alinhaDir">
                    <asp:Image ID="Image34" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                        Height="12px" Width="20px" />
                    <asp:Label ID="Label21" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                        Text="Administrar Participação"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir">
                    <asp:Image ID="Image36" runat="server" EnableViewState="false" ToolTip="Informações para realização do cadastro de participação"
                        ImageUrl="~/images/information32.png" />
                </div>
                <div class="alinhaDir" style="padding-top: 14px;">
                    <asp:Label ID="Label26" runat="server" EnableViewState="False" ForeColor="#099409"
                        Font-Size="14px" Font-Bold="True" Text=" Digite a participação e clique em 'Salvar'. Para editá-la clique na imagem 'Editar' da Lista de Paticipações."></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div style="margin-left: -8px;">
                    <hr />
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image37" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="LabelParticipacaoTitulo" runat="server" EnableViewState="False" Font-Bold="True"
                        Text=" Cadastro de Participação:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <%--Descrição da Participação--%>
                <div class="nomecampos">
                    Participação:
                </div>
                <div class="txtcampos">
                    <asp:TextBox ID="txtParcipacao" runat="server" CssClass="bordas" Text="" Width="300px"></asp:TextBox>
                </div>
                <div class="limpaDir">
                </div>
                <%--Botões Salvar e Cancelar Participação--%>
                <div class="botoesCentro">
                    <asp:Button ID="btParticipacaoSalvar" runat="server" CssClass="botoes" Text="Salvar"
                        OnClick="btParticipacaoSalvar_Click" />
                    <asp:Button ID="btParticipacaoCancelar" runat="server" CssClass="botoes" Text="Cancelar"
                        OnClick="btParticipacaoCancelar_Click" />
                </div>
                <div class="limpaDir">
                </div>
                <div class="botoesCentro">
                    <asp:Panel ID="PanelParticipacaoConfirma" runat="server" Visible="false">
                        <div class="alinhaDir" style="margin-left: -30px;">
                            <asp:Image ID="ImageParticipacaoConfirma" runat="server" ImageUrl="~/images/confirmation32.png" />
                        </div>
                        <div style="padding-top: 14px; width: 300px">
                            <asp:Label ID="LabelParticipacaoConfirmaErro" runat="server" Text="" Font-Bold="true"
                                ForeColor="#CC0000"></asp:Label>
                            <asp:Label ID="LabelParticipacaoConfirmaOk" runat="server" Text="" Font-Bold="true"
                                ForeColor="#099409"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <div class="limpaDir">
                </div>
                <div style="margin-left: -8px;">
                    <hr />
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image39" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label32" runat="server" EnableViewState="False" Font-Bold="True" Text=" Lista de Participações:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-left: 30px;">
                    <asp:GridView ID="GridViewParticipacao" runat="server" BackColor="White" AutoGenerateColumns="False"
                        BorderColor="#0D5600" Width="400px" HorizontalAlign="Center" CellPadding="2"
                        AllowPaging="True" BorderStyle="Double" BorderWidth="3px" GridLines="Vertical"
                        OnPageIndexChanging="GridViewParticipacao_PageIndexChanging" OnRowCommand="GridViewParticipacao_RowCommand"
                        OnRowDataBound="GridViewParticipacao_RowDataBound">
                        <RowStyle BackColor="#ffffff" />
                        <Columns>
                            <asp:BoundField DataField="codParticipacao" SortExpression="codParticipacao" HeaderText="codParticipacao">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descParticipacao" SortExpression="descParticipacao" HeaderText="Participação">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Link" CommandName="editarParticipacao" Text='<img alt="" title="Editar Participação" src="../images/editar.png" style="border: 0px" />'>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Link" CommandName="excluirParticipacao" Text='<img alt="" title="Excluir Participação" src="../images/excluir.png" style="border: 0px" />'>
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
                                            Nenhuma Participação Encontrada.
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
        <%--FIM PANEL CADASTRO / ATUALIZAÇÃO DE PARTICIPACAO--%>
        <div style="height: 3px;">
        </div>
        <%--PANEL CADASTRO / ATUALIZAÇÃO DE PAVIMENTO--%>
        <div onclick="javascript: $('#divPavimento').toggle('slow');" class="abas">
            <div style="padding: 3px 5px 0 5px; float: left">
                <%--    <asp:Image ID="Image55" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />--%>
            </div>
            <asp:Label ID="Label44" runat="server" Text="Pavimento" EnableViewState="false"></asp:Label>
        </div>
        <div id="divPavimento" style="display: none;">
            <asp:Panel ID="PanelPavimentoCad" runat="server" Visible="true">
                <div class="alinhaDir">
                    <asp:Image ID="Image38" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                        Height="12px" Width="20px" />
                    <asp:Label ID="Label27" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                        Text="Administrar Pavimento"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir">
                    <asp:Image ID="Image40" runat="server" EnableViewState="false" ToolTip="Informações para realização do cadastro de pavimento"
                        ImageUrl="~/images/information32.png" />
                </div>
                <div class="alinhaDir" style="padding-top: 14px;">
                    <asp:Label ID="Label29" runat="server" EnableViewState="False" ForeColor="#099409"
                        Font-Size="14px" Font-Bold="True" Text=" Digite o pavimento e clique em 'Salvar'. Para editá-lo clique na imagem 'Editar' da Lista de Pavimentos."></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div style="margin-left: -8px;">
                    <hr />
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image41" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="LabelPavimentoTitulo" runat="server" EnableViewState="False" Font-Bold="True"
                        Text=" Cadastro de Pavimento:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <%--Descrição do Pavimento--%>
                <div class="nomecampos">
                    Pavimento:
                </div>
                <div class="txtcampos">
                    <asp:TextBox ID="txtPavimento" runat="server" CssClass="bordas" Text="" Width="300px"></asp:TextBox>
                </div>
                <div class="limpaDir">
                </div>
                <%--Botões Salvar e Cancelar Pavimento--%>
                <div class="botoesCentro">
                    <asp:Button ID="btPavimentoSalvar" runat="server" CssClass="botoes" Text="Salvar"
                        OnClick="btPavimentoSalvar_Click" />
                    <asp:Button ID="btPavimentoCancelar" runat="server" CssClass="botoes" Text="Cancelar"
                        OnClick="btPavimentoCancelar_Click" />
                </div>
                <div class="limpaDir">
                </div>
                <div class="botoesCentro">
                    <asp:Panel ID="PanelPavimentoConfirma" runat="server" Visible="false">
                        <div class="alinhaDir" style="margin-left: -30px;">
                            <asp:Image ID="ImagePavimentoConfirma" runat="server" ImageUrl="~/images/confirmation32.png" />
                        </div>
                        <div style="padding-top: 14px; width: 300px">
                            <asp:Label ID="LabelPavimentoConfirmaErro" runat="server" Text="" Font-Bold="true"
                                ForeColor="#CC0000"></asp:Label>
                            <asp:Label ID="LabelPavimentoConfirmaOk" runat="server" Text="" Font-Bold="true"
                                ForeColor="#099409"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <div class="limpaDir">
                </div>
                <div style="margin-left: -8px;">
                    <hr />
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image43" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label35" runat="server" EnableViewState="False" Font-Bold="True" Text=" Lista de Pavimentos:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-left: 30px;">
                    <asp:GridView ID="GridViewPavimento" runat="server" BackColor="White" AutoGenerateColumns="False"
                        BorderColor="#0D5600" Width="400px" HorizontalAlign="Center" CellPadding="2"
                        AllowPaging="True" BorderStyle="Double" BorderWidth="3px" GridLines="Vertical"
                        OnPageIndexChanging="GridViewPavimento_PageIndexChanging" OnRowCommand="GridViewPavimento_RowCommand"
                        OnRowDataBound="GridViewPavimento_RowDataBound">
                        <RowStyle BackColor="#ffffff" />
                        <Columns>
                            <asp:BoundField DataField="codPavimento" SortExpression="codPavimento" HeaderText="codPavimento">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descPavimento" SortExpression="descPavimento" HeaderText="Pavimento">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Link" CommandName="editarPavimento" Text='<img alt="" title="Editar Pavimento" src="../images/editar.png" style="border: 0px" />'>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Link" CommandName="excluirPavimento" Text='<img alt="" title="Excluir Pavimento" src="../images/excluir.png" style="border: 0px" />'>
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
                                            Nenhum Pavimento Encontrado.
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
        <%--FIM PANEL CADASTRO / ATUALIZAÇÃO DE PAVIMENTO--%>
        <div style="height: 3px;">
        </div>
        <%--PANEL CADASTRO / ATUALIZAÇÃO DE LOGRADOURO--%>
        <div onclick="javascript: $('#divTipoLogradouro').toggle('slow');" class="abas">
            <div style="padding: 3px 5px 0 5px; float: left">
                <%--  <asp:Image ID="Image6" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG" />--%>
            </div>
            <asp:Label ID="Label5" runat="server" Text="Tipo de Logradouro" EnableViewState="false"></asp:Label>
        </div>
        <div id="divTipoLogradouro" style="display: none;">
            <asp:Panel ID="PanelTipoLogradouroCad" runat="server" Visible="true">
                <div class="alinhaDir">
                    <asp:Image ID="Image42" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                        Height="12px" Width="20px" />
                    <asp:Label ID="Label31" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                        Text="Administrar Tipo de Logradouro"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir">
                    <asp:Image ID="Image44" runat="server" EnableViewState="false" ToolTip="Informações para realização do cadastro de tipo de logradouro"
                        ImageUrl="~/images/information32.png" />
                </div>
                <div class="alinhaDir" style="padding-top: 14px;">
                    <asp:Label ID="Label33" runat="server" EnableViewState="False" ForeColor="#099409"
                        Font-Size="14px" Font-Bold="True" Text=" Digite o tipo de logradouro e clique em 'Salvar'. Para editá-lo clique na imagem 'Editar' da Lista de Logradouros."></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div style="margin-left: -8px;">
                    <hr />
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image45" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="LabelTipoLogradouroTitulo" runat="server" EnableViewState="False"
                        Font-Bold="True" Text=" Cadastro de Tipo de Logradouro:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <%--Descrição do Tipo de Logradouro--%>
                <div class="nomecampos">
                    Tipo de Logradouro:
                </div>
                <div class="txtcampos">
                    <asp:TextBox ID="txtTipoLogradouro" runat="server" CssClass="bordas" Text="" Width="300px"></asp:TextBox>
                </div>
                <div class="limpaDir">
                </div>
                <%--Botões Salvar e Cancelar Tipo de Logradouro--%>
                <div class="botoesCentro">
                    <asp:Button ID="btTipoLogradouroSalvar" runat="server" CssClass="botoes" Text="Salvar"
                        OnClick="btTipoLogradouroSalvar_Click" />
                    <asp:Button ID="btTipoLogradouroCancelar" runat="server" CssClass="botoes" Text="Cancelar"
                        OnClick="btTipoLogradouroCancelar_Click" />
                </div>
                <div class="limpaDir">
                </div>
                <div class="botoesCentro">
                    <asp:Panel ID="PanelTipoLogradouroConfirma" runat="server" Visible="false">
                        <div class="alinhaDir" style="margin-left: -30px;">
                            <asp:Image ID="ImageTipoLogradouroConfirma" runat="server" ImageUrl="~/images/confirmation32.png" />
                        </div>
                        <div style="padding-top: 14px; width: 400px">
                            <asp:Label ID="LabelTipoLogradouroConfirmaErro" runat="server" Text="" Font-Bold="true"
                                ForeColor="#CC0000"></asp:Label>
                            <asp:Label ID="LabelTipoLogradouroConfirmaOk" runat="server" Text="" Font-Bold="true"
                                ForeColor="#099409"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <div class="limpaDir">
                </div>
                <div style="margin-left: -8px;">
                    <hr />
                </div>
                <div class="alinhaDir" style="padding-top: 18px;">
                    <asp:Image ID="Image47" runat="server" EnableViewState="false" ImageUrl="~/images/setaDirPEq.PNG" />
                    <asp:Label ID="Label38" runat="server" EnableViewState="False" Font-Bold="True" Text=" Lista de Tipos de Logradouros:"></asp:Label>
                </div>
                <div class="limpaDir">
                </div>
                <div class="alinhaDir" style="padding-left: 30px;">
                    <asp:GridView ID="GridViewTipoLogradouro" runat="server" BackColor="White" AutoGenerateColumns="False"
                        BorderColor="#0D5600" Width="400px" HorizontalAlign="Center" CellPadding="2"
                        AllowPaging="True" BorderStyle="Double" BorderWidth="3px" GridLines="Vertical"
                        OnPageIndexChanging="GridViewTipoLogradouro_PageIndexChanging" OnRowCommand="GridViewTipoLogradouro_RowCommand"
                        OnRowDataBound="GridViewTipoLogradouro_RowDataBound">
                        <RowStyle BackColor="#ffffff" />
                        <Columns>
                            <asp:BoundField DataField="codTipoLogradouro" SortExpression="codTipoLogradouro"
                                HeaderText="codTipoLogradouro">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descTipoLogradouro" SortExpression="descTipoLogradouro"
                                HeaderText="Tipo de Logradouro">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Link" CommandName="editarTipoLogradouro" Text='<img alt="" title="Editar Tipo de Logradouro" src="../images/editar.png" style="border: 0px" />'>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Link" CommandName="excluirTipoLogradouro" Text='<img alt="" title="Excluir Tipo de Logradouro" src="../images/excluir.png" style="border: 0px" />'>
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
                                            Nenhum Tipo de Logradouro Encontrado.
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
        <%--FIM PANEL CADASTRO / ATUALIZAÇÃO DE TIPO DE LOGRADOURO--%>
    </div>
</asp:Content>
