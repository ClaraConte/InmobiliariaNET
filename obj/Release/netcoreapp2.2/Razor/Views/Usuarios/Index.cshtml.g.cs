#pragma checksum "C:\Users\Clara Conte\source\repos\Inmobiliaria\Views\Usuarios\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e2f0857a5f44d9ee81e8662f3d03bc9226cc8a2d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuarios_Index), @"mvc.1.0.view", @"/Views/Usuarios/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Usuarios/Index.cshtml", typeof(AspNetCore.Views_Usuarios_Index))]
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
#line 1 "C:\Users\Clara Conte\source\repos\Inmobiliaria\Views\_ViewImports.cshtml"
using Inmobiliaria.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2f0857a5f44d9ee81e8662f3d03bc9226cc8a2d", @"/Views/Usuarios/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc0af1537e70c0df53fddc8070a5110ca45f368d", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuarios_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Inmobiliaria.Models.Usuario>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("icon-action"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "3", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "4", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("estado-disable"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\Clara Conte\source\repos\Inmobiliaria\Views\Usuarios\Index.cshtml"

    ViewData["Title"] = "Usuarios";

#line default
#line hidden
            BeginContext(99, 127, true);
            WriteLiteral("<div class=\"row\">\r\n    <div class=\"col-12 pl-4 pt-4 container-content\">\r\n\r\n        <h2>Usuarios</h2>\r\n        <p>\r\n            ");
            EndContext();
            BeginContext(226, 118, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2f0857a5f44d9ee81e8662f3d03bc9226cc8a2d7207", async() => {
                BeginContext(269, 71, true);
                WriteLiteral("Crear nuevo <i class=\"fas fa-plus-square\"  title=\"Agregar Usuario\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(344, 98, true);
            WriteLiteral("\r\n        </p>\r\n        <div class=\"row\">\r\n            <div class=\"col-11 mt-4\">\r\n                ");
            EndContext();
            BeginContext(442, 899, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2f0857a5f44d9ee81e8662f3d03bc9226cc8a2d8837", async() => {
                BeginContext(487, 239, true);
                WriteLiteral("\r\n                    <span>Seleccione: </span>\r\n\r\n                    <div class=\"form-group mx-sm-3\">\r\n                        <select class=\"mdb-select md-form colorful-select dropdown-primary\" name=\"Tipo\">\r\n                            ");
                EndContext();
                BeginContext(726, 31, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2f0857a5f44d9ee81e8662f3d03bc9226cc8a2d9471", async() => {
                    BeginContext(744, 4, true);
                    WriteLiteral("Tipo");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(757, 30, true);
                WriteLiteral("\r\n                            ");
                EndContext();
                BeginContext(787, 33, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2f0857a5f44d9ee81e8662f3d03bc9226cc8a2d10959", async() => {
                    BeginContext(805, 6, true);
                    WriteLiteral("Nombre");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(820, 30, true);
                WriteLiteral("\r\n                            ");
                EndContext();
                BeginContext(850, 30, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2f0857a5f44d9ee81e8662f3d03bc9226cc8a2d12450", async() => {
                    BeginContext(868, 3, true);
                    WriteLiteral("DNI");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(880, 30, true);
                WriteLiteral("\r\n                            ");
                EndContext();
                BeginContext(910, 32, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2f0857a5f44d9ee81e8662f3d03bc9226cc8a2d13938", async() => {
                    BeginContext(928, 5, true);
                    WriteLiteral("Email");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(942, 198, true);
                WriteLiteral("\r\n                        </select>\r\n                    </div>\r\n                    <div class=\"form-group mx-sm-3\">\r\n                        <input type=\"text\" class=\"form-control\" name=\"Criterio\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1140, "\"", 1165, 1);
#line 27 "C:\Users\Clara Conte\source\repos\Inmobiliaria\Views\Usuarios\Index.cshtml"
WriteAttributeValue("", 1148, ViewBag.Busqueda, 1148, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1166, 168, true);
                WriteLiteral(" id=\"TextSearch\" placeholder=\"buscar .. \">\r\n                    </div>\r\n                    <button type=\"submit\" class=\"btn btn-info\">Buscar</button>\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1341, 56, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        \r\n        ");
            EndContext();
            BeginContext(1397, 3968, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2f0857a5f44d9ee81e8662f3d03bc9226cc8a2d17623", async() => {
                BeginContext(1422, 262, true);
                WriteLiteral(@"
            <div class=""row"">
                <div class=""col-11 mt-4"">

                    <table class=""table"">
                        <thead>
                            <tr>
                                <th>
                                    ");
                EndContext();
                BeginContext(1685, 45, false);
#line 42 "C:\Users\Clara Conte\source\repos\Inmobiliaria\Views\Usuarios\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.IdUsuario));

#line default
#line hidden
                EndContext();
                BeginContext(1730, 115, true);
                WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
                EndContext();
                BeginContext(1846, 49, false);
#line 45 "C:\Users\Clara Conte\source\repos\Inmobiliaria\Views\Usuarios\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.UsuarioNombre));

#line default
#line hidden
                EndContext();
                BeginContext(1895, 115, true);
                WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
                EndContext();
                BeginContext(2011, 51, false);
#line 48 "C:\Users\Clara Conte\source\repos\Inmobiliaria\Views\Usuarios\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.UsuarioApellido));

#line default
#line hidden
                EndContext();
                BeginContext(2062, 115, true);
                WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
                EndContext();
                BeginContext(2178, 46, false);
#line 51 "C:\Users\Clara Conte\source\repos\Inmobiliaria\Views\Usuarios\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.UsuarioDni));

#line default
#line hidden
                EndContext();
                BeginContext(2224, 115, true);
                WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
                EndContext();
                BeginContext(2340, 51, false);
#line 54 "C:\Users\Clara Conte\source\repos\Inmobiliaria\Views\Usuarios\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.UsuarioTelefono));

#line default
#line hidden
                EndContext();
                BeginContext(2391, 115, true);
                WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
                EndContext();
                BeginContext(2507, 48, false);
#line 57 "C:\Users\Clara Conte\source\repos\Inmobiliaria\Views\Usuarios\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.UsuarioEmail));

#line default
#line hidden
                EndContext();
                BeginContext(2555, 115, true);
                WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
                EndContext();
                BeginContext(2671, 40, false);
#line 60 "C:\Users\Clara Conte\source\repos\Inmobiliaria\Views\Usuarios\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.Tipo));

#line default
#line hidden
                EndContext();
                BeginContext(2711, 268, true);
                WriteLiteral(@"
                                </th>
                                <th>
                                    Acciones
                                </th>
                            </tr>
                        </thead>
                        <tbody>

");
                EndContext();
#line 69 "C:\Users\Clara Conte\source\repos\Inmobiliaria\Views\Usuarios\Index.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
                BeginContext(3068, 108, true);
                WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
                EndContext();
                BeginContext(3177, 44, false);
#line 73 "C:\Users\Clara Conte\source\repos\Inmobiliaria\Views\Usuarios\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.IdUsuario));

#line default
#line hidden
                EndContext();
                BeginContext(3221, 115, true);
                WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
                EndContext();
                BeginContext(3337, 48, false);
#line 76 "C:\Users\Clara Conte\source\repos\Inmobiliaria\Views\Usuarios\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.UsuarioNombre));

#line default
#line hidden
                EndContext();
                BeginContext(3385, 115, true);
                WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
                EndContext();
                BeginContext(3501, 50, false);
#line 79 "C:\Users\Clara Conte\source\repos\Inmobiliaria\Views\Usuarios\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.UsuarioApellido));

#line default
#line hidden
                EndContext();
                BeginContext(3551, 115, true);
                WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
                EndContext();
                BeginContext(3667, 45, false);
#line 82 "C:\Users\Clara Conte\source\repos\Inmobiliaria\Views\Usuarios\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.UsuarioDni));

#line default
#line hidden
                EndContext();
                BeginContext(3712, 115, true);
                WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
                EndContext();
                BeginContext(3828, 50, false);
#line 85 "C:\Users\Clara Conte\source\repos\Inmobiliaria\Views\Usuarios\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.UsuarioTelefono));

#line default
#line hidden
                EndContext();
                BeginContext(3878, 116, true);
                WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                     ");
                EndContext();
                BeginContext(3995, 47, false);
#line 88 "C:\Users\Clara Conte\source\repos\Inmobiliaria\Views\Usuarios\Index.cshtml"
                                Write(Html.DisplayFor(modelItem => item.UsuarioEmail));

#line default
#line hidden
                EndContext();
                BeginContext(4042, 115, true);
                WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
                EndContext();
                BeginContext(4158, 54, false);
#line 91 "C:\Users\Clara Conte\source\repos\Inmobiliaria\Views\Usuarios\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Tipo.UsuarioTipoRol));

#line default
#line hidden
                EndContext();
                BeginContext(4212, 115, true);
                WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
                EndContext();
                BeginContext(4327, 124, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2f0857a5f44d9ee81e8662f3d03bc9226cc8a2d26148", async() => {
                    BeginContext(4399, 48, true);
                    WriteLiteral("<i class=\"fas fa-pencil-alt\" title=\"Editar\"></i>");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 94 "C:\Users\Clara Conte\source\repos\Inmobiliaria\Views\Usuarios\Index.cshtml"
                                                           WriteLiteral(item.IdUsuario);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4451, 50, true);
                WriteLiteral("&nbsp;&nbsp;\r\n                                    ");
                EndContext();
                BeginContext(4501, 130, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2f0857a5f44d9ee81e8662f3d03bc9226cc8a2d28803", async() => {
                    BeginContext(4578, 49, true);
                    WriteLiteral("<i class=\"fas fa-trash-alt\" title=\"Eliminar\"></i>");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_9.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 95 "C:\Users\Clara Conte\source\repos\Inmobiliaria\Views\Usuarios\Index.cshtml"
                                                             WriteLiteral(item.IdUsuario);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4631, 76, true);
                WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");
                EndContext();
#line 98 "C:\Users\Clara Conte\source\repos\Inmobiliaria\Views\Usuarios\Index.cshtml"
                            }

#line default
#line hidden
                BeginContext(4738, 28, true);
                WriteLiteral("                            ");
                EndContext();
#line 99 "C:\Users\Clara Conte\source\repos\Inmobiliaria\Views\Usuarios\Index.cshtml"
                             if (ViewBag.Values == 0)
                            {

#line default
#line hidden
                BeginContext(4824, 387, true);
                WriteLiteral(@"                                <tr>
                                    <td colspan=""7"">
                                        <div class=""alert alert-danger"">
                                            No se encontraron resultados para su búsqueda
                                        </div>
                                    </td>
                                </tr>
");
                EndContext();
#line 108 "C:\Users\Clara Conte\source\repos\Inmobiliaria\Views\Usuarios\Index.cshtml"
                            }

#line default
#line hidden
                BeginContext(5242, 116, true);
                WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5365, 22, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Inmobiliaria.Models.Usuario>> Html { get; private set; }
    }
}
#pragma warning restore 1591
