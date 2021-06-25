<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="inicio.aspx.cs" Inherits="inicio" Title="Cidade Verde - Página Inicial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="conteudo">
        <div class="texto">
            <p>
                <%--SLIDES DAS IMAGENS DO CIDADE VERDE--%>
                <link href="css/slide.css" rel="stylesheet" type="text/css" />

                <script type="text/javascript" src="jquery/jqueryslide.js"></script>

                <script type="text/javascript" src="jquery/slideshow.js"></script>

                <script type="text/javascript" src="jquery/slide.js"></script>

                <div class="jm-slidewrap" id="jm-slide-1258839829148865494573912539" style="visibility: hidden;">
                    <div class="jm-slide-main-wrap">
                        <div class="jm-slide-main">
                            <div class="jm-slide-item">
                                <img src="fotos/PracaMatriz.jpg" />
                            </div>
                            <div class="jm-slide-item">
                                <img src="fotos/GeraldoSilvaMaia.jpg" />
                            </div>
                            <div class="jm-slide-item">
                                <img src="fotos/AvenidadaModa.jpg" />
                            </div>
                            <div class="jm-slide-item">
                                <img src="fotos/Fesp.jpg" />
                            </div>
                            <div class="jm-slide-item">
                                <img src="fotos/ChafarizRosario.jpg" />
                            </div>
                            <div class="jm-slide-item">
                                <img src="fotos/RotatoriaFesp.jpg" />
                            </div>
                            <div class="jm-slide-item">
                                <img src="fotos/Terminal.jpg" />
                            </div>
                            <div class="jm-slide-item">
                                <img src="fotos/ArvoredeSantaBarbara.jpg" />
                            </div>
                        </div>
                    </div>
                    <div class="jm-slide-mask">
                    </div>
                    <div class="jm-slide-thumbs-wrap">
                        <div class="jm-slide-thumbs">
                            <div class="jm-slide-thumb">
                                <img src="fotos/miniPracaMatriz.jpg" />
                            </div>
                            <div class="jm-slide-thumb">
                                <img src="fotos/miniGeraldoSilvaMaia.jpg" />
                            </div>
                            <div class="jm-slide-thumb">
                                <img src="fotos/miniAvenidadaModa.jpg" />
                            </div>
                            <div class="jm-slide-thumb">
                                <img src="fotos/miniFesp.jpg" />
                            </div>
                            <div class="jm-slide-thumb">
                                <img src="fotos/miniChafarizRosario.jpg" />
                            </div>
                            <div class="jm-slide-thumb">
                                <img src="fotos/miniRotatoriaFesp.jpg" />
                            </div>
                            <div class="jm-slide-thumb">
                                <img src="fotos/miniTerminal.jpg" />
                            </div>
                            <div class="jm-slide-thumb">
                                <img src="fotos/miniArvoredeSantaBarbara.jpg" />
                            </div>
                        </div>
                        <div class="jm-slide-thumbs-mask">
                            <span class="jm-slide-thumbs-mask-left">&nbsp;</span><span class="jm-slide-thumbs-mask-center">&nbsp;</span><span
                                class="jm-slide-thumbs-mask-right">&nbsp;</span></div>
                        <p class="jm-slide-thumbs-handles">
                            <span>&nbsp;</span> <span>&nbsp;</span> <span>&nbsp;</span> <span>&nbsp;</span><span>&nbsp;</span><span>&nbsp;</span><span>&nbsp;</span><span>&nbsp;</span>
                        </p>
                    </div>
                </div>
            </p>
            <%-- FIM DOS SLIDES DAS IMAGENS DO SIDADE VERDE--%>
            <p>
                O site <a style="color: #099409; font-weight: bold; text-decoration: none;" href="inicio.aspx">
                    Cidade Verde</a> foi desenvolvido no intuito de disponibilizar a população diversas
                informações sobre arborização urbana, visualização de árvores cadastras no sistema,
                espécies recomendadas ou não para arborização urbana, conceitos sobre o assunto,
                solicitações de serviço, dicas e informações através do fale conosco.
            </p>
            <p>
                <strong>Entre o topo do site e a galeria de fotos encontra-se o menu do site para acesso
                    as outras páginas do site. Abaixo estão descritas as funcionalidades de cada página:</strong>
            </p>
            <p>
                <li>A página <a style="color: #099409; font-weight: bold; text-decoration: none;"
                    href="arvoresGoogleMaps.aspx" target="_blank">Árvores no Google Maps</a> está integrada
                    com o site
                    <%--<a style="color: #099409; font-weight: bold; text-decoration: none;" href="http://maps.google.com.br/"
                        target="_blank">Google Maps</a>--%>
                    Google Maps onde está disponibilizado a visualização das árvores cadastradas no
                    sistema e obtenção de suas informações tais como nome popular, nome científico,
                    endereço, data de plantio e coordenadas geográficas. Cada arvorezinha no mapa representa
                    uma árvore cadastrada no sistema. As cores representam a situação atual da árvore.
                    Caso queira visualizar os detalhes da árvore, clique arvorezinha. Assim que clicar
                    na arvorezinha, aparecerá um balão contendo as informações da árvore. Caso for cadastrado
                    uma imagem da árvore ela será mostrada. Abaixo da imagem da árvore terá um link
                    para entrar em contato com os administradores do sistema, referenciando diretamente
                    a árvore visualizada, solicitando poda ou conservação da mesma, contribuindo para
                    o controle de arborização urbana.</li>
            </p>
            <p>
                <li>A página <a style="color: #099409; font-weight: bold; text-decoration: none;"
                    href="arborizacaoUrbana.aspx" target="_blank">Arborização Urbana</a> possui duas
                    abas. A aba das Espécies Recomendadas são as espécies recomendadas para o plantio
                    urbano. A aba das Espécies Não Recomendadas são as espécies não recomendadas para
                    o plantio urbano.</li>
            </p>
            <p>
                <li>A página <a style="color: #099409; font-weight: bold; text-decoration: none;"
                    href="conceitos.aspx" target="_blank">Conceitos</a> contém diversos conceitos sobre
                    Arborização, Arborização Urbana, Geogrocessamento, Georreferenciamento e Coordenadas
                    Geográficas, entre outros.</li>
            </p>
            <p>
                <li>A página <a style="color: #099409; font-weight: bold; text-decoration: none;"
                    href="faleConosco.aspx" target="_blank">Fale Conosco</a> o usuário poderá entrar
                    em contato com os administradores do site, solicitando poda ou conservação de uma
                    determinada árvore, entre outros serviços. Dicas, reclamações e sugestões poderão
                    ser enviadas também.</li>
            </p>
            <p>
                <li>Para administrar as informações é necessário efetuar o login no sistema. <a style="color: #099409;
                    font-weight: bold; text-decoration: none;" href="login.aspx" target="_blank">Clique
                    aqui</a> para efetuar o login...</li>
            </p>
            <br />
            <%-- <div>
                <asp:HyperLink ID="HyperLinkParceiros" CssClass="tituloLinks" runat="server">Clique para ver nossos parceiros</asp:HyperLink>
            </div>--%>
        </div>
    </div>
</asp:Content>
