using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        switch (Request.Url.AbsolutePath.Split('/').Last())
        {
            case "inicio.aspx":
                HyperLinkInicio.CssClass = "selecionado";
                break;
            case "arvoresGoogleMaps.aspx":
                HyperLinkGoogleMaps.CssClass = "selecionado";
                break;
            case "arborizacaoUrbana.aspx":
                HyperLinkArborizacaoUrbana.CssClass = "selecionado";
                break;
            case "conceitos.aspx":
                HyperLinkConceitos.CssClass = "selecionado";
                break;
            case "faleConosco.aspx":
                HyperLinkFaleConosco.CssClass = "selecionado";
                break;
        }
    }
}
