#pragma checksum "D:\Jobz\Dilignet\Aplikacija2\PlanerParnicaV2\PlanerParnicaV2\Views\Admin\ListParnice.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c078fdcb89ae5669ef75c7eadc8c2ce2644a7281"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ListParnice), @"mvc.1.0.view", @"/Views/Admin/ListParnice.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/ListParnice.cshtml", typeof(AspNetCore.Views_Admin_ListParnice))]
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
#line 1 "D:\Jobz\Dilignet\Aplikacija2\PlanerParnicaV2\PlanerParnicaV2\Views\_ViewImports.cshtml"
using PlanerParnicaV2;

#line default
#line hidden
#line 2 "D:\Jobz\Dilignet\Aplikacija2\PlanerParnicaV2\PlanerParnicaV2\Views\_ViewImports.cshtml"
using PlanerParnicaV2.Models;

#line default
#line hidden
#line 3 "D:\Jobz\Dilignet\Aplikacija2\PlanerParnicaV2\PlanerParnicaV2\Views\_ViewImports.cshtml"
using PlanerParnicaV2.ViewModels;

#line default
#line hidden
#line 4 "D:\Jobz\Dilignet\Aplikacija2\PlanerParnicaV2\PlanerParnicaV2\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c078fdcb89ae5669ef75c7eadc8c2ce2644a7281", @"/Views/Admin/ListParnice.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9174123ba5cc4c78397c63e8c61e732292c03af3", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_ListParnice : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Parnica>>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\Jobz\Dilignet\Aplikacija2\PlanerParnicaV2\PlanerParnicaV2\Views\Admin\ListParnice.cshtml"
  
    ViewData["Title"] = "SveParnice";

#line default
#line hidden
#line 5 "D:\Jobz\Dilignet\Aplikacija2\PlanerParnicaV2\PlanerParnicaV2\Views\Admin\ListParnice.cshtml"
 if (Model.Any())
{

#line default
#line hidden
            BeginContext(97, 4, true);
            WriteLiteral("    ");
            EndContext();
            BeginContext(101, 40, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ba924954c4764a18b4e583ac60cb09db", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#line 7 "D:\Jobz\Dilignet\Aplikacija2\PlanerParnicaV2\PlanerParnicaV2\Views\Admin\ListParnice.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.All;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(141, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(151, 40, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e345044dbea41f49a6a3591d8b21bd6", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#line 8 "D:\Jobz\Dilignet\Aplikacija2\PlanerParnicaV2\PlanerParnicaV2\Views\Admin\ListParnice.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.All;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(191, 456, true);
            WriteLiteral(@"
        <table style=""width:100%"">
            <tr>
                <th>Identifikator</th>
                <th>Lokacija odrzavanja</th>
                <th>Vreme odrzavanja</th>
                <th>Sudija</th>
                <th>Tip ustanove</th>
                <th>Broj sudnice</th>
                <th>Tuzilac</th>
                <th>Tuzeni</th>
                <th>Napomena</th>
                <th>Tip postupka</th>
            </tr>
");
            EndContext();
#line 22 "D:\Jobz\Dilignet\Aplikacija2\PlanerParnicaV2\PlanerParnicaV2\Views\Admin\ListParnice.cshtml"
             foreach (var parnica in Model)
            {

#line default
#line hidden
            BeginContext(707, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(780, 29, false);
#line 26 "D:\Jobz\Dilignet\Aplikacija2\PlanerParnicaV2\PlanerParnicaV2\Views\Admin\ListParnice.cshtml"
                   Write(parnica.IdentifikatorPostupka);

#line default
#line hidden
            EndContext();
            BeginContext(809, 96, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td class=\"col-md-1\">\r\n                        ");
            EndContext();
            BeginContext(906, 33, false);
#line 29 "D:\Jobz\Dilignet\Aplikacija2\PlanerParnicaV2\PlanerParnicaV2\Views\Admin\ListParnice.cshtml"
                   Write(parnica.LokacijaOdrzavanja.Naslov);

#line default
#line hidden
            EndContext();
            BeginContext(939, 96, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td class=\"col-md-1\">\r\n                        ");
            EndContext();
            BeginContext(1036, 23, false);
#line 32 "D:\Jobz\Dilignet\Aplikacija2\PlanerParnicaV2\PlanerParnicaV2\Views\Admin\ListParnice.cshtml"
                   Write(parnica.VremeOdrzavanja);

#line default
#line hidden
            EndContext();
            BeginContext(1059, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1139, 18, false);
#line 35 "D:\Jobz\Dilignet\Aplikacija2\PlanerParnicaV2\PlanerParnicaV2\Views\Admin\ListParnice.cshtml"
                   Write(parnica.Sudija.Ime);

#line default
#line hidden
            EndContext();
            BeginContext(1157, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1237, 19, false);
#line 38 "D:\Jobz\Dilignet\Aplikacija2\PlanerParnicaV2\PlanerParnicaV2\Views\Admin\ListParnice.cshtml"
                   Write(parnica.TipUstanove);

#line default
#line hidden
            EndContext();
            BeginContext(1256, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1336, 19, false);
#line 41 "D:\Jobz\Dilignet\Aplikacija2\PlanerParnicaV2\PlanerParnicaV2\Views\Admin\ListParnice.cshtml"
                   Write(parnica.BrojSudnice);

#line default
#line hidden
            EndContext();
            BeginContext(1355, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1435, 19, false);
#line 44 "D:\Jobz\Dilignet\Aplikacija2\PlanerParnicaV2\PlanerParnicaV2\Views\Admin\ListParnice.cshtml"
                   Write(parnica.Tuzilac.Ime);

#line default
#line hidden
            EndContext();
            BeginContext(1454, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1534, 18, false);
#line 47 "D:\Jobz\Dilignet\Aplikacija2\PlanerParnicaV2\PlanerParnicaV2\Views\Admin\ListParnice.cshtml"
                   Write(parnica.Tuzeni.Ime);

#line default
#line hidden
            EndContext();
            BeginContext(1552, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1632, 16, false);
#line 50 "D:\Jobz\Dilignet\Aplikacija2\PlanerParnicaV2\PlanerParnicaV2\Views\Admin\ListParnice.cshtml"
                   Write(parnica.Napomena);

#line default
#line hidden
            EndContext();
            BeginContext(1648, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1728, 26, false);
#line 53 "D:\Jobz\Dilignet\Aplikacija2\PlanerParnicaV2\PlanerParnicaV2\Views\Admin\ListParnice.cshtml"
                   Write(parnica.TipPostupka.Naslov);

#line default
#line hidden
            EndContext();
            BeginContext(1754, 72, true);
            WriteLiteral("\r\n                    </td>\r\n                  \r\n                </tr>\r\n");
            EndContext();
#line 57 "D:\Jobz\Dilignet\Aplikacija2\PlanerParnicaV2\PlanerParnicaV2\Views\Admin\ListParnice.cshtml"

            }

#line default
#line hidden
            BeginContext(1843, 18, true);
            WriteLiteral("        </table>\r\n");
            EndContext();
#line 60 "D:\Jobz\Dilignet\Aplikacija2\PlanerParnicaV2\PlanerParnicaV2\Views\Admin\ListParnice.cshtml"
    
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Parnica>> Html { get; private set; }
    }
}
#pragma warning restore 1591