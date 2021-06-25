<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="faleConosco.aspx.cs" Inherits="faleConosco" Title="Cidade Verde - Fale Conosco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="conteudo">
        <div class="texto" style="padding-left: 50px;">
            <p>
                <asp:Image ID="Image1" runat="server" EnableViewState="false" ImageUrl="~/images/setaDir.PNG"
                    Height="12px" Width="20px" />
                <asp:Label ID="Label6" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="14px"
                    Text="Para esclarecimento de dúvidas, dicas, sugestões e reclamações entre em contato conosco."></asp:Label>
            </p>
            <asp:Label ID="Label3" runat="server" Text="Nome"></asp:Label><br />
            <asp:TextBox ID="txtNomeRemetente" CssClass="bordas" runat="server" Width="400px"></asp:TextBox>
            <span style="color: Red">*</span>
            <asp:RequiredFieldValidator ID="rfvNomeRemetente" runat="server" ErrorMessage="Campo Obrigatório"
                ControlToValidate="txtNomeRemetente"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="LabelEmailRemetente" runat="server" Text="E-mail"></asp:Label><br />
            <asp:TextBox ID="txtEmailRemetente" CssClass="bordas" runat="server" Width="400px"></asp:TextBox>
            <span style="color: Red">*</span>
            <asp:RequiredFieldValidator ID="rfvEmailRemetente" runat="server" ErrorMessage="Campo Obrigatório"
                ControlToValidate="txtEmailRemetente"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator CssClass="volta" ID="rfvValidaEmail" runat="server"
                ErrorMessage="E-mail Inválido" ControlToValidate="txtEmailRemetente" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Código da Árvore"></asp:Label><br />
            <asp:TextBox ID="txtArvore" CssClass="bordas" runat="server" Width="400px"></asp:TextBox>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Assunto"></asp:Label><br />
            <asp:TextBox ID="txtAssunto" runat="server" CssClass="bordas" Width="400px"></asp:TextBox>
            <span style="color: Red">*</span>
            <asp:RequiredFieldValidator ID="rfvAssunto" runat="server" ErrorMessage="Campo Obrigatório"
                ControlToValidate="txtAssunto"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Mensagem"></asp:Label><br />
            <asp:TextBox ID="txtMensagem" runat="server" CssClass="bordas" TextMode="MultiLine"
                Font-Size="12px" Font-Names="Verdana" Height="140px" Width="400px"></asp:TextBox>
            <span style="color: Red">*</span>
            <asp:RequiredFieldValidator ID="rfvMensagem" runat="server" ErrorMessage="Campo Obrigatório"
                ControlToValidate="txtMensagem"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Enviar Arquivo"></asp:Label><br />
            <asp:FileUpload ID="FileUploadArquivo" runat="server" />
            <br />
            <p>
                <asp:Button ID="btEnviar" runat="server" CssClass="botoes" Text="Enviar" OnClick="btEnviar_Click"
                    Width="100px" />
                <asp:Button ID="btLimpar" runat="server" CssClass="botoes" Text="Limpar" Width="100px"
                    OnClick="btLimpar_Click" /></p>
            <asp:Panel ID="PanelConfirma" runat="server" Visible="false">
                <div class="alinhaDir">
                    <asp:Image ID="ImageConfirma" runat="server" ImageUrl="~/images/confirmation32.png" />
                </div>
                <div style="padding-top: 14px;">
                    <asp:Label ID="LabelConfirma" runat="server" Text="" ForeColor="#099409" Font-Bold="true"></asp:Label>
                    <asp:Label ID="LabelErro" runat="server" Text="" ForeColor="#CC0000" Font-Bold="true"></asp:Label>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
