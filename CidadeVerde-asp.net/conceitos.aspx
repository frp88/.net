<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="conceitos.aspx.cs" Inherits="conceitos" Title="Cidade Verde - Conceitos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="conteudo">
        <div class="texto">
            <%-- <div>
                <asp:HyperLink ID="HyperLinkVerArvores" CssClass="tituloLinks" runat="server">Ver Árvores</asp:HyperLink>
            </div>--%>
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
            <p>
                A arborização urbana é muito importante, principalmente nos grandes centros urbanos,
                trazendo vários benefícios, como melhoria na qualidade de vida da população, pois
                proporciona melhores condições ao ambiente como purificação do ar, melhoria do clima,
                absorção de parte dos raios solares, sombreamento, abrigo à fauna, diminuição da
                poluição sonora e do vento, entre outros. Devido a tais importâncias, deve-se considerar
                a criação e manutenção dessas áreas arborizadas. O planejamento da arborização urbana,
                o conhecimento das características e condições do ambiente urbano são requisitos
                indispensáveis para o sucesso da arborização devido grande volume de informações,
                condições dos locais, espaço físico disponível e características das espécies a
                utilizar.
            </p>
            <p>
                Para o desenvolvimento do projeto foram necessárias fundamentações teóricas, como
                Arborização Urbana, Georeferenciamento, Geoprocessamento e SIG, com o intuito de
                adquirir maior conhecimento teórico e técnico para resolução de dúvidas.</p>
            <p>
                Esse projeto consiste na continuidade da Elaboração de um Sistema de Controle de
                Arborização das Vias Públicas de Passos (SILVA, SILVA, 2009).</p>
            <p>
                Projeto de Conclusão de Curso, desenvolvido na cidade de Passos-MG, abortando fundamentações
                teóricas como SIG, Conceito de Cartografia, Sistemas de Coordenadas.</p>
            <p>
                <strong>2.1 Arborização</strong></p>
            Urbana Entende-se por arborização urbana todos os elementos vegetais de porte arbóreo
            existentes nas cidades. Nesse contexto, árvores plantadas em calçadas fazem parte
            da arborização urbana. O termo Arborização Urbana é conceituado por Grey e Deneke
            (1978) como conjunto de terras públicas e particulares, com cobertura arbórea, que
            uma cidade apresenta. Entretanto, Milano (1990) considerando esse conceito restrito,
            por referir-se apenas às espécies arbóreas, admite como Arborização Urbana, outras
            áreas que, independente do porte da vegetação urbana, apresentam-se predominantemente,
            naturais e não ocupadas. A arborização urbana é muito importante para melhor qualidade
            de vida, principalmente nos grandes centros urbanos. As árvores exercem função ecológica,
            no sentido de melhoria do ambiente urbano, e estética, no sentido de embelezamento
            das vias públicas, consequentemente da cidade. Segundo Guzzo (2009) a arborização
            urbana contribui diretamente na melhoria da qualidade do ambiente urbano, tais como:
             Purificação do ar pela fixação de poeiras e gases tóxicos e pela reciclagem de
            gases através dos mecanismos fotossintéticos;  Melhoria do clima da cidade, devido
            à retenção de umidade do solo e do ar e pela geração de sombra, evitando que os
            raios solares sobrevenham diretamente sobre as pessoas;  Redução na velocidade
            do vento;  Influência no balanço hídrico, favorecendo a infiltração da água no
            solo e provocando evapo-transpiração mais lenta;  Abrigo à fauna, propiciando uma
            variedade maior de espécies, consequentemente influenciando positivamente para um
            maior equilíbrio das cadeias alimentares e diminuição de pragas e agentes vetores
            de doenças; e  Amortecer a propagação do som, resultando na redução do nível de
            ruídos. 2.2 Georreferenciamento Consiste em referenciar as coordenadas de uma imagem
            ou um mapa ou qualquer outra forma de informação geográfica num dado sistema de
            referência. Georreferenciamento no português brasileiro, georreferenciação no português
            europeu, este processo inicia-se com o levantamento das coordenadas de pontos da
            imagem ou do mapa pertencentes ao sistema no qual se deseja georreferenciar. Esses
            pontos são conhecidos como pontos de controle. Pontos de controle são locais estratégicos
            que proporcionam um aspecto físico facilmente identificável como intersecções de
            estradas e de rios, represas, topos de montanha, pistas de aeroportos, rodoviárias,
            edifícios elevados, entre outros (CARTILHA, 2009). A aquisição das coordenadas dos
            pontos de controle pode ser realizada em campo, realizadas a partir de levantamentos
            topográficos, como GPS – Sistema de Posicionamento Global. Pode-se também obter
            por meio de mesas digitalizadoras, imagens e mapas georreferenciados. 2.3 Geoprocessamento
            Geoprocessamento é o conjunto de ciências, tecnologias e técnicas empregadas na
            aquisição, armazenamento, gerenciamento, manipulação, cruzamento, exibição, documentação
            e distribuição de dados e informações geográficas (CAMARA, 1996). Consiste no processamento
            informatizado de dados georreferenciados. Utiliza programas de computador que permitem
            o uso de informações cartográficas (mapas, cartas topográficas e plantas) e informações
            a que se possa associar coordenadas desses mapas, cartas ou plantas, baseando em
            técnicas matemáticas e computacionais para o tratamento da informação geográfica.
            Segundo Alexandra (2009) o geoprocessamento influencia as áreas de Cartografia,
            Análise de Recursos Naturais, Transportes, Comunicações, Energia e Planejamento
            Urbano e Regional. 2.3.1 Componentes do Geoprocessamento Para se realizar o geoprocessamento
            são necessários cinco componentes, que serão descritos em seguida (GEOPROCESSAMENTO,
            2005):  Dados geográficos: são constituídos principalmente por pixels, linhas,
            pontos e polígonos. Utilizados para representar graficamente elementos da superfície
            terrestre, tais como: drenagem, sistema viário, relevo, vegetação, limite político,
            entre outros;  Equipamentos: as aplicações de geoprocessamento, geralmente necessitam
            de uma grande quantidade e diversidade de equipamentos como, satélites, PGS, computadores,
            etc.;  Recursos Humanos: constituído por especialistas e pesquisadores responsáveis
            pela geração das informações geográficas necessárias para o processo de gestão;
             Programas Computacionais: atualmente todas as etapas do geoprocessamento: entrada,
            processamento e saída de informações são auxiliados por programas computacionais;
             Métodos de Trabalhos e/ou Aplicativos: consiste na formulação de métodos de trabalhos
            ou na materialização computacional de tais métodos através dos aplicativos. 2.3.2
            Tipos de Sistemas de Geoprocessamento Segundo Rodrigues (1990) os sistemas de geoprocessamento
            podem ser, simplificadamente, classificados em:  Sistemas Aplicativos: são sistemas
            computacionais voltados para a representação espacial e para a realização de tarefas
            de projeto, mapeamento, extração de dados, etc.;  Sistemas de Informação: são sistemas
            voltados para a coleta, armazenamento, recuperação, manipulação e apresentação de
            informações espaciais e sobre o contínuo espacial;  Sistemas Especialistas: são
            sistemas computacionais que empregam o conhecimento na solução de problemas que
            normalmente demandariam a inteligência humana. 2.4 Sistemas de Informação Geográfica
            (SIG) Um Sistema de Informação Geográfica (SIG ou GIS - Geographic Information System,
            em inglês) é um sistema computacional de procedimentos utilizados para armazenar
            e manipular dados georreferenciados, auxiliando à tomada de decisão num ambiente
            de respostas a problemas. Possui um conjunto de ferramentas poderosas para coletar,
            armazenar, recuperar, transformar e visualizar dados geográficos sobre o mundo real,
            facilitando a análise, gestão ou representação do espaço e dos fenômenos que nele
            ocorrem (RECKZIEGEL, 2009). Um SIG pode ser utilizado como ferramenta para produção
            de mapas, suporte para análise espacial de fenômenos e como banco de dados geográficos,
            com funções de armazenamento e recuperação de informação espacial. Segundo Ferrari
            (1997) o SIG insere e integra informações espaciais coletadas de dados cartográficos,
            cadastros de imagens adquiridas por satélites e combina as várias informações através
            de mecanismos de manipulação e análise, bem como para consultar e visualizar o conteúdo
            da base de dados georreferenciados. Em um SIG são realizadas operações elementares
            de adição, remoção, atualização e seleção dos dados. O processo de visualização
            ou análise de informação espacial requer, basicamente, que sejam selecionados dados
            existentes no SIG. 2.4.1 Estrutura Geral de um SIG Segundo Camara (1996) um SIG
            tem os seguintes componentes:  Interface com usuário;  Entrada e integração de
            dados;  Funções de consulta e análise espacial;  Visualização e plotagem (localizar
            a posição);  Armazenamento e recuperação de dados (organizados sob a forma de um
            banco de dados geográficos). A Figura 1 ilustra o relacionamento dos principais
            componentes de um SIG.
        </div>
    </div>
</asp:Content>
