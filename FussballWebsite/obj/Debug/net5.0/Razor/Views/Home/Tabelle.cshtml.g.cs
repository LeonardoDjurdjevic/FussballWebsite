#pragma checksum "C:\SWP\SWP-Vogt\FussballWebsite\FussballWebsite\Views\Home\Tabelle.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f13881ccd54a43d687a3c767c4975ee775f14354"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Tabelle), @"mvc.1.0.view", @"/Views/Home/Tabelle.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\SWP\SWP-Vogt\FussballWebsite\FussballWebsite\Views\_ViewImports.cshtml"
using Fussball_Website;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\SWP\SWP-Vogt\FussballWebsite\FussballWebsite\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f13881ccd54a43d687a3c767c4975ee775f14354", @"/Views/Home/Tabelle.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d9a068f9b3bb0cc4d6455f47fdca7a9d4889d1bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Tabelle : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\SWP\SWP-Vogt\FussballWebsite\FussballWebsite\Views\Home\Tabelle.cshtml"
  
    ViewData["Title"] = "Tabelle";

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\SWP\SWP-Vogt\FussballWebsite\FussballWebsite\Views\Home\Tabelle.cshtml"
 switch (@Context.Session.GetInt32("liga")) {
    case 0:

#line default
#line hidden
#nullable disable
            WriteLiteral("        <iframe src=\"https://www.transfermarkt.at/premier-league/startseite/wettbewerb/GB1\"></iframe>\r\n");
#nullable restore
#line 7 "C:\SWP\SWP-Vogt\FussballWebsite\FussballWebsite\Views\Home\Tabelle.cshtml"
        break;
    case 1:

#line default
#line hidden
#nullable disable
            WriteLiteral("        <iframe src=\"https://www.transfermarkt.at/laliga/startseite/wettbewerb/ES1\"></iframe>\r\n");
#nullable restore
#line 10 "C:\SWP\SWP-Vogt\FussballWebsite\FussballWebsite\Views\Home\Tabelle.cshtml"
        break;
    case 2:

#line default
#line hidden
#nullable disable
            WriteLiteral("        <iframe src=\"https://www.transfermarkt.at/serie-a/startseite/wettbewerb/IT1\"></iframe>\r\n");
#nullable restore
#line 13 "C:\SWP\SWP-Vogt\FussballWebsite\FussballWebsite\Views\Home\Tabelle.cshtml"
        break;
    case 3:

#line default
#line hidden
#nullable disable
            WriteLiteral("        <iframe src=\"https://www.transfermarkt.at/bundesliga/startseite/wettbewerb/L1\"></iframe>\r\n");
#nullable restore
#line 16 "C:\SWP\SWP-Vogt\FussballWebsite\FussballWebsite\Views\Home\Tabelle.cshtml"
        break; 
    case 4:

#line default
#line hidden
#nullable disable
            WriteLiteral("        <iframe src=\"https://www.transfermarkt.at/ligue-1/startseite/wettbewerb/FR1\"></iframe>\r\n");
#nullable restore
#line 19 "C:\SWP\SWP-Vogt\FussballWebsite\FussballWebsite\Views\Home\Tabelle.cshtml"
        break;
    default:

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p style=\"position: absolute; top: 500px; left: 500px; font-size: 40px;\">Keine Liga angegeben oder nicht eingeloggt!</p>\r\n");
#nullable restore
#line 22 "C:\SWP\SWP-Vogt\FussballWebsite\FussballWebsite\Views\Home\Tabelle.cshtml"
        break;
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    \r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591