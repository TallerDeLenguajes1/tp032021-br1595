#pragma checksum "C:\tp032021-br1595\Views\Cadete\ModifyCadeteasd.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3e72c4d598d1975c14f1e5a1bdda232b9cb9e5e4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cadete_ModifyCadeteasd), @"mvc.1.0.view", @"/Views/Cadete/ModifyCadeteasd.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e72c4d598d1975c14f1e5a1bdda232b9cb9e5e4", @"/Views/Cadete/ModifyCadeteasd.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5574d18de84bb9703b3ec7e8362b5483adf825e", @"/Views/_ViewImports.cshtml")]
    public class Views_Cadete_ModifyCadeteasd : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EntidadesSistema.CadeteCadeteriasViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Cadete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ModifyForGoodCadete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h3 class=\"display-4\">Modificar Cadete</h3>\r\n</div>\r\n\r\n<div class=\"text-center\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e72c4d598d1975c14f1e5a1bdda232b9cb9e5e44390", async() => {
                WriteLiteral("\r\n        <div class=\"mb-3\">\r\n            <label for=\"Id\" class=\"form-label\">Id</label>\r\n            <input hidden type=\"number\" style=\"text-align:center\" name=\"Id\"");
                BeginWriteAttribute("value", " value=\"", 543, "\"", 570, 1);
                WriteAttributeValue("", 551, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                    PushWriter(__razor_attribute_value_writer);
                                                                                                         
#nullable restore
#line 16 "C:\tp032021-br1595\Views\Cadete\ModifyCadeteasd.cshtml"
                                                                                Write(Model.Cadete.Id);

#line default
#line hidden
#nullable disable
                                                                                                                         
                    PopWriter();
                }
                ), 551, 19, false);
                EndWriteAttribute();
                WriteLiteral("/>\r\n        </div>\r\n        <div class=\"mb-3\">\r\n            <label for=\"nombre\" class=\"form-label\">Nombre</label>\r\n            <input type=\"text\" class=\"form-control\" id=\"nombre\" name=\"Nombre\"");
                BeginWriteAttribute("value", " value=\"", 763, "\"", 794, 1);
                WriteAttributeValue("", 771, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                    PushWriter(__razor_attribute_value_writer);
                                                                                                           
#nullable restore
#line 20 "C:\tp032021-br1595\Views\Cadete\ModifyCadeteasd.cshtml"
                                                                                  Write(Model.Cadete.Nombre);

#line default
#line hidden
#nullable disable
                                                                                                                               
                    PopWriter();
                }
                ), 771, 23, false);
                EndWriteAttribute();
                BeginWriteAttribute("placholder", " placholder=\"", 795, "\"", 831, 1);
                WriteAttributeValue("", 808, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                    PushWriter(__razor_attribute_value_writer);
                                                                                                                                                
#nullable restore
#line 20 "C:\tp032021-br1595\Views\Cadete\ModifyCadeteasd.cshtml"
                                                                                                                       Write(Model.Cadete.Nombre);

#line default
#line hidden
#nullable disable
                                                                                                                                                                    
                    PopWriter();
                }
                ), 808, 23, false);
                EndWriteAttribute();
                WriteLiteral(" style=\"text-align:center\" required>\r\n        </div>\r\n        <div class=\"mb-3\">\r\n            <label for=\"direccion\" class=\"form-label\">Direccion</label>\r\n            <input type=\"text\" class=\"form-control\" id=\"_Direccion\" name=\"Direccion\"");
                BeginWriteAttribute("value", " value=\"", 1071, "\"", 1105, 1);
                WriteAttributeValue("", 1079, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                    PushWriter(__razor_attribute_value_writer);
                                                                                                                  
#nullable restore
#line 24 "C:\tp032021-br1595\Views\Cadete\ModifyCadeteasd.cshtml"
                                                                                         Write(Model.Cadete.Direccion);

#line default
#line hidden
#nullable disable
                                                                                                                                         
                    PopWriter();
                }
                ), 1079, 26, false);
                EndWriteAttribute();
                BeginWriteAttribute("placholder", " placholder=\"", 1106, "\"", 1145, 1);
                WriteAttributeValue("", 1119, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                    PushWriter(__razor_attribute_value_writer);
                                                                                                                                                          
#nullable restore
#line 24 "C:\tp032021-br1595\Views\Cadete\ModifyCadeteasd.cshtml"
                                                                                                                                 Write(Model.Cadete.Direccion);

#line default
#line hidden
#nullable disable
                                                                                                                                                                                 
                    PopWriter();
                }
                ), 1119, 26, false);
                EndWriteAttribute();
                WriteLiteral(" style=\"text-align:center\" required>\r\n        </div>\r\n        <div class=\"mb-3\">\r\n            <label for=\"Telefono\" class=\"form-label\">Telefono</label>\r\n            <input type=\"text\" class=\"form-control\" id=\"Telefono\" name=\"Telefono\"");
                BeginWriteAttribute("value", " value=\"", 1380, "\"", 1413, 1);
                WriteAttributeValue("", 1388, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                    PushWriter(__razor_attribute_value_writer);
                                                                                                               
#nullable restore
#line 28 "C:\tp032021-br1595\Views\Cadete\ModifyCadeteasd.cshtml"
                                                                                      Write(Model.Cadete.Telefono);

#line default
#line hidden
#nullable disable
                                                                                                                                     
                    PopWriter();
                }
                ), 1388, 25, false);
                EndWriteAttribute();
                BeginWriteAttribute("placeholder", " placeholder=\"", 1414, "\"", 1453, 1);
                WriteAttributeValue("", 1428, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                    PushWriter(__razor_attribute_value_writer);
                                                                                                                                                       
#nullable restore
#line 28 "C:\tp032021-br1595\Views\Cadete\ModifyCadeteasd.cshtml"
                                                                                                                              Write(Model.Cadete.Telefono);

#line default
#line hidden
#nullable disable
                                                                                                                                                                             
                    PopWriter();
                }
                ), 1428, 25, false);
                EndWriteAttribute();
                WriteLiteral(" style=\"text-align:center\" required>\r\n        </div>\r\n        <div class=\"mb-3\">\r\n            <label for=\"CadeteriaId\" class=\"form-label\">Código de cadetería actual: ");
#nullable restore
#line 31 "C:\tp032021-br1595\Views\Cadete\ModifyCadeteasd.cshtml"
                                                                               Write(Model.Cadete.CadeteriaId);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n            <select  for=\"CadeteriaId\" class=\"custom-select\" name=\"CadeteriaId\" style=\"text-align:center\">\r\n");
#nullable restore
#line 33 "C:\tp032021-br1595\Views\Cadete\ModifyCadeteasd.cshtml"
                 foreach (var elemento in Model.ListaCadeterias)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e72c4d598d1975c14f1e5a1bdda232b9cb9e5e413300", async() => {
#nullable restore
#line 35 "C:\tp032021-br1595\Views\Cadete\ModifyCadeteasd.cshtml"
                                                     Write(elemento.CadeteriaNombre);

#line default
#line hidden
#nullable disable
                    WriteLiteral(" - ");
#nullable restore
#line 35 "C:\tp032021-br1595\Views\Cadete\ModifyCadeteasd.cshtml"
                                                                                 Write(elemento.CadeteriaID);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 35 "C:\tp032021-br1595\Views\Cadete\ModifyCadeteasd.cshtml"
                       WriteLiteral(elemento.CadeteriaID);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 36 "C:\tp032021-br1595\Views\Cadete\ModifyCadeteasd.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </select>\r\n        </div>\r\n        <button type=\"submit\" class=\"btn btn-primary\">Enviar</button>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EntidadesSistema.CadeteCadeteriasViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
