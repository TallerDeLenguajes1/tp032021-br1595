#pragma checksum "C:\tp032021-br1595\Views\Cadeteria\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "21df67b8c12fc51c26ffb38ad94dcf6ca92c0de8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cadeteria_Index), @"mvc.1.0.view", @"/Views/Cadeteria/Index.cshtml")]
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
#line 1 "C:\tp032021-br1595\Views\_ViewImports.cshtml"
using tp032021_br1595;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\tp032021-br1595\Views\_ViewImports.cshtml"
using tp032021_br1595.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"21df67b8c12fc51c26ffb38ad94dcf6ca92c0de8", @"/Views/Cadeteria/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5574d18de84bb9703b3ec7e8362b5483adf825e", @"/Views/_ViewImports.cshtml")]
    public class Views_Cadeteria_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<EntidadesSistema.Cadete>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\tp032021-br1595\Views\Cadeteria\Index.cshtml"
  
    ViewData["Title"] = "Pagina de cadeteria";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""text-center"">
    <h1 class=""display-4"">Listado de cadetes</h1>


<table class=""table table-striped"">
    <tr>
        <th>ID</th>
        <th>Dni</th>
        <th>Nombre</th>
        <th>Direccion</th>
        <th>Cantidad de pedidos</th>
    </tr>
");
#nullable restore
#line 20 "C:\tp032021-br1595\Views\Cadeteria\Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\r\n        <td>");
#nullable restore
#line 23 "C:\tp032021-br1595\Views\Cadeteria\Index.cshtml"
       Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 24 "C:\tp032021-br1595\Views\Cadeteria\Index.cshtml"
       Write(item.Dni);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 25 "C:\tp032021-br1595\Views\Cadeteria\Index.cshtml"
       Write(item.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 26 "C:\tp032021-br1595\Views\Cadeteria\Index.cshtml"
       Write(item.Direccion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 27 "C:\tp032021-br1595\Views\Cadeteria\Index.cshtml"
       Write(item.ListadoPedidos.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n");
#nullable restore
#line 29 "C:\tp032021-br1595\Views\Cadeteria\Index.cshtml"
     }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<EntidadesSistema.Cadete>> Html { get; private set; }
    }
}
#pragma warning restore 1591