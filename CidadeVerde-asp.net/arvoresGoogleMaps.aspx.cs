using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Artem.Web.UI.Controls;
using DataSetCidadeVerdeTableAdapters;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Subgurim.Controles;

public partial class arvoresGoogleMaps : System.Web.UI.Page
{
    CidadeVerde cv = new CidadeVerde();
    protected void Page_Load(object sender, EventArgs e)
    {
        //gMaps.ShowMapTypeControl = true;
        //gMaps.ShowScaleControl = true;
        ////Latitude e Longitude da rua 3 de maio (Bloco 9)
        ////String codIdentArvore = "201002080053";
        double latitude = -20.72137287504534; //-20.7213728750453
        double longitude = -46.60919524002075; //-46.6091952400208
        ////Define a posição do inicio do google maps
        //gMaps.Latitude = latitude;
        //gMaps.Longitude = longitude;

        ////Zoom do Google Maps
        //gMaps.Zoom = 15;
        ////Tamanho da área do google maps
        //gMaps.Width = 940;
        //gMaps.Height = 700;
        GoogleMaps.Key = "AIzaSyC9D8SWWpI1csCBdiDAe3xfdOS3oh2bcNw";
        ////Busca Todas Coordenadas Cadastradas das Árvores Vivas

        GoogleMaps.Width = 940;
        GoogleMaps.Height = 700;
        

        // Habilitando o zoom no mapa
        GoogleMaps.enableHookMouseWheelToZoom = true;

        // Definir o tipo do mapa
        // Satellite, Hybrid, Physical, Normal
        GoogleMaps.mapType = GMapType.GTypes.Normal;

        // Define a Latitude e Logitude inicial do Mapa
        // Como moro em Brasília, coloquei o Congresso Nacional
        GLatLng latitudeLongitude = new GLatLng(latitude, longitude);

        // Definimos onde será o ponto inicial do nosso mapa
        // e o numero é o ZOOM inicial
        GoogleMaps.setCenter(latitudeLongitude, 15);

        // Ver imagem para entender quais sao os controles adicionados
        GControl mapType = new GControl(GControl.preBuilt.MapTypeControl);
        GControl overview = new GControl(GControl.preBuilt.GOverviewMapControl);
        //GControl small = new GControl(GControl.preBuilt.SmallMapControl);
        GControl largeZoom = new GControl(GControl.preBuilt.LargeMapControl);
        // GControl contr = new GControl(GControl.extraBuilt.TextualOnClickCoordinatesControl);

        GoogleMaps.addControl(mapType); // Ver imagem
        GoogleMaps.addControl(overview); // Ver imagem
        //  GoogleMaps.addControl(small); // Ver imagem
        GoogleMaps.addControl(largeZoom); // Ver imagem
        //GoogleMaps.addControl(contr);

        DataSetCidadeVerde.tblCoordenadasDataTable dtCoordenadas = cv.buscaCoordenadasByArvoresVivas();
        if (dtCoordenadas != null)
        {
            //GoogleMarker[] ponto = new GoogleMarker[dtCoordenadas.Rows.Count];
            GMarker[] novoPonto = new GMarker[dtCoordenadas.Rows.Count];

            for (int i = 0; i < dtCoordenadas.Rows.Count; i++)
            {
                //Busca Dados da Árvore
                DataSetCidadeVerde.tblArvoreDataTable dtArvore = cv.buscaArvoreByCodArvore(Convert.ToInt32(dtCoordenadas[i]["codArvore"].ToString()));
                //Busca a Localização da Árvore
                DataSetCidadeVerde.tblLocalizacaoDataTable dtLocalizacao = cv.buscaLocalizacaoByCodArvore(Convert.ToInt32(dtCoordenadas[i]["codArvore"].ToString()));
                //Busca o TOP1 dos Nome Popular da Espécie da Árvore
                DataSetCidadeVerde.tblNomeComumDataTable dtNomePopular = cv.buscaNomePopularTOP1ByCodEspecie(dtArvore[0].codEspecie);

                String statusArvore = dtArvore[0].nStatus == 2 ? "Doente" : dtArvore[0].nStatus == 3 ? "Ferida" : dtArvore[0].nStatus == 4 ? "Morta" : "Saudável";
                //String numero = (dtLocalizacao[0].IsnNumeroNull() ? "" : dtLocalizacao[0].nNumero.ToString() + ";");

                //    ponto[i] = new GoogleMarker(Convert.ToDouble(dtCoordenadas[i]["latitude"].ToString()), Convert.ToDouble(dtCoordenadas[i]["longitude"].ToString()));
                GLatLng coordenadas = new GLatLng(Convert.ToDouble(dtCoordenadas[i]["latitude"].ToString()), Convert.ToDouble(dtCoordenadas[i]["longitude"].ToString()));

                GIcon icone = new GIcon();
                icone.iconSize = new GSize(20, 24);
                switch (dtArvore[0].nStatus)
                {
                    //case 2:
                    //    icone.image = "images/arvoreDoenteG.png";
                    //    break;
                    //case 3:
                    //    icone.image = "images/arvoreFeridaG.png";
                    //    break;
                    //default:
                    //    icone.image = "images/icon_nova_arvore.png";//"images/arvoreSaudavelG.png";
                    //    break;
                    case 2:
                        icone.image = "images/arvoreAzul.png";
                        break;
                    case 3:
                        icone.image = "images/arvoreVermelho.png";
                        break;
                    default:
                        icone.image = "images/arvoreVerde.png";//"images/arvoreSaudavelG.png";
                        break;
                }

                novoPonto[i] = new GMarker(coordenadas, icone);
                novoPonto[i].options.title = dtNomePopular[0].descNomeComum + " - Código: " + dtArvore[0].sCodIdentificacao + ". Clique aqui para ver detalhes.";
                //maker.options.clickable = true;
                GoogleMaps.addGMarker(novoPonto[i]);

                GInfoWindow window = new GInfoWindow(novoPonto[i], "<strong>Nome Popular: </strong>" + (dtNomePopular[0].IsdescNomeComumNull() ? "" : dtNomePopular[0].descNomeComum) +
                "<br /><strong>Nome Científico: </strong>" + (dtArvore[0].IssNomeCientificoNull() ? "" : dtArvore[0].sNomeCientifico) +
                "<br /><strong>Código: </strong>" + (dtArvore[0].IssCodIdentificacaoNull() ? "" : dtArvore[0].sCodIdentificacao) +
                "<br /><strong>End.: </strong>" + (dtLocalizacao != null ? ((dtLocalizacao[0].IsdescTipoLogradouroNull() ? "" : dtLocalizacao[0].descTipoLogradouro + " ") +
                (dtLocalizacao[0].IssLogradouroNull() ? "" : dtLocalizacao[0].sLogradouro + ", ") +
                (dtLocalizacao[0].IsnNumeroNull() ? "" : (dtLocalizacao[0].nNumero.ToString() + ", ")) +
                (dtLocalizacao[0].IssBairroNull() ? "" : dtLocalizacao[0].sBairro)) : "") +
                "<br /><strong>Data de Plantio:</strong> " + (dtArvore[0].IsdtPlantioNull() ? "" : dtArvore[0].dtPlantio.ToShortDateString()) + "<br /><strong>Latitude:</strong>&nbsp;&nbsp;&nbsp;&nbsp;" +
                dtCoordenadas[i]["latitude"].ToString() + "<br /><strong>Longitude:</strong> " + dtCoordenadas[i]["longitude"].ToString() +
                (dtArvore[0].IssImagemNull() ? "<br />" : "<center><img src='fotos/arvores/" + dtArvore[0].sCodIdentificacao +
                ".jpg' width='200' height='150'>'</center>") + "<br /><center> <a href='faleConosco.aspx?cod=" + dtArvore[0].sCodIdentificacao +
                "' target='_blank'>Clique aqui para Contato</a></center>");

                GoogleMaps.addInfoWindow(window);

                //ponto[i].Text = "<strong>Nome Popular: </strong>" + (dtNomePopular[0].IsdescNomeComumNull() ? "" : dtNomePopular[0].descNomeComum) +
                //    "<br /><strong>Nome Científico: </strong>" + (dtArvore[0].IssNomeCientificoNull() ? "" : dtArvore[0].sNomeCientifico) +
                //    "<br /><strong>Código: </strong>" + (dtArvore[0].IssCodIdentificacaoNull() ? "" : dtArvore[0].sCodIdentificacao) +
                //    "<br /><strong>End.: </strong>" + (dtLocalizacao != null ? ((dtLocalizacao[0].IsdescTipoLogradouroNull() ? "" : dtLocalizacao[0].descTipoLogradouro + " ") +
                //    (dtLocalizacao[0].IssLogradouroNull() ? "" : dtLocalizacao[0].sLogradouro + ", ") +
                //    (dtLocalizacao[0].IsnNumeroNull() ? "" : (dtLocalizacao[0].nNumero.ToString() + ", ")) +
                //    (dtLocalizacao[0].IssBairroNull() ? "" : dtLocalizacao[0].sBairro)) : "") +
                //    "<br /><strong>Data de Plantio:</strong> " + (dtArvore[0].IsdtPlantioNull() ? "" : dtArvore[0].dtPlantio.ToShortDateString()) + "<br /><strong>Latitude:</strong>&nbsp;&nbsp;&nbsp;&nbsp;" +
                //    dtCoordenadas[i]["latitude"].ToString() + "<br /><strong>Longitude:</strong> " + dtCoordenadas[i]["longitude"].ToString() +
                //    (dtArvore[0].IssImagemNull() ? "<br />" : "<center><img src='fotos/arvores/" + dtArvore[0].sCodIdentificacao +
                //    ".jpg' width='200' height='150'>'</center>") + "<br /><center> <a href='faleConosco.aspx?cod=" + dtArvore[0].sCodIdentificacao +
                //    "' target='_blank'>Clique aqui para Contato</a></center>";

                //Response.Redirect("~/contato.aspx?cod=" + dtArvore[0].sCodIdentificacao);
                //switch (dtArvore[0].nStatus)
                //{
                //    case 2:
                //        ponto[i].IconUrl = "~/images/arvoreDoenteG.png";
                //        break;
                //    case 3:
                //        ponto[i].IconUrl = "~/images/arvoreFeridaG.png";
                //        break;
                //    default:
                //        ponto[i].IconUrl = "~/images/arvoreSaudavelG.png";
                //        break;
                //}
                //ponto[i].Title = dtNomePopular[0].descNomeComum + " - Código: " + dtArvore[0].sCodIdentificacao + ". Clique aqui para ver detalhes.";
                //ponto[i].Clickable = true;
                //gMaps.Markers.Add(ponto[i]);
            }
            GLatLng coor = new GLatLng(Convert.ToDouble(dtCoordenadas[0]["latitude"].ToString()), Convert.ToDouble(dtCoordenadas[0]["longitude"].ToString()));
            List<GLatLng> listaPontos = new List<GLatLng>();
            listaPontos.Add(coor);
            coor = new GLatLng(Convert.ToDouble(dtCoordenadas[1]["latitude"].ToString()), Convert.ToDouble(dtCoordenadas[1]["longitude"].ToString()));
            listaPontos.Add(coor);
            coor = new GLatLng(Convert.ToDouble(dtCoordenadas[2]["latitude"].ToString()), Convert.ToDouble(dtCoordenadas[2]["longitude"].ToString()));
            listaPontos.Add(coor);
            GPolygon p = new GPolygon(listaPontos);
            GoogleMaps.addPolygon(p);
        }
    }
}
