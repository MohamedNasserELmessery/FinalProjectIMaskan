#pragma checksum "C:\Users\Alrowad\GradutionProject-master-ُFinal_Edit11\GradutionProject-master-ُFinal_Edit\GradutionProject\Views\Admin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8f35ee509800c9fab19ebec12629cad372653bd0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Index), @"mvc.1.0.view", @"/Views/Admin/Index.cshtml")]
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
#line 1 "C:\Users\Alrowad\GradutionProject-master-ُFinal_Edit11\GradutionProject-master-ُFinal_Edit\GradutionProject\Views\_ViewImports.cshtml"
using GradutionProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Alrowad\GradutionProject-master-ُFinal_Edit11\GradutionProject-master-ُFinal_Edit\GradutionProject\Views\_ViewImports.cshtml"
using GradutionProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f35ee509800c9fab19ebec12629cad372653bd0", @"/Views/Admin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7728a3ab0676e126c8d79870230506ca245dc707", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/datatables/css/jquery.dataTables.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/jquery.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Alrowad\GradutionProject-master-ُFinal_Edit11\GradutionProject-master-ُFinal_Edit\GradutionProject\Views\Admin\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_NewAdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!-- DataTable -->\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"https://cdn.datatables.net/1.10.21/css/jquery.dataTables.css\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8f35ee509800c9fab19ebec12629cad372653bd04835", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<link rel=""stylesheet"" type=""text/css"" href=""https://cdn.datatables.net/responsive/2.2.5/css/responsive.dataTables.min.css"">


<div class=""app-page-title"">
    <div class=""page-title-wrapper"">
        <div class=""page-title-heading"">
            <div class=""page-title-icon"">
                <i class=""pe-7s-graph1 icon-gradient bg-mean-fruit"">
                </i>
            </div>
            <div>
                Analytics Dashboard
                <div class=""page-title-subheading"">
                    
                </div>
            </div>
        </div>

    </div>
</div>
<div class=""row"">
    <div class=""col-md-6 col-xl-3"">
        <div class=""card mb-3 widget-content bg-midnight-bloom"">
            <div class=""widget-content-wrapper text-white"">
                <div class=""widget-content-left"">
                    <div class=""widget-heading"">Total Posts</div>
");
            WriteLiteral("                </div>\r\n                <div class=\"widget-content-right\">\r\n                    <div class=\"widget-numbers text-white\"><span>");
#nullable restore
#line 39 "C:\Users\Alrowad\GradutionProject-master-ُFinal_Edit11\GradutionProject-master-ُFinal_Edit\GradutionProject\Views\Admin\Index.cshtml"
                                                            Write(ViewBag.PostsNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span></div>
                </div>
            </div>
        </div>
    </div>
    <div class=""col-md-6 col-xl-3"">
        <div class=""card mb-3 widget-content bg-arielle-smile"">
            <div class=""widget-content-wrapper text-white"">
                <div class=""widget-content-left"">
                    <div class=""widget-heading"">Total Users</div>
                </div>
                <div class=""widget-content-right"">
                    <div class=""widget-numbers text-white""><span>");
#nullable restore
#line 51 "C:\Users\Alrowad\GradutionProject-master-ُFinal_Edit11\GradutionProject-master-ُFinal_Edit\GradutionProject\Views\Admin\Index.cshtml"
                                                            Write(ViewBag.UsersNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span></div>
                </div>
            </div>
        </div>
    </div>
    <div class=""col-md-6 col-xl-3"">
        <div class=""card mb-3 widget-content bg-grow-early"">
            <div class=""widget-content-wrapper text-white"">
                <div class=""widget-content-left"">
                    <div class=""widget-heading"">Total Regions</div>
                </div>
                <div class=""widget-content-right"">
                    <div class=""widget-numbers text-white""><span>");
#nullable restore
#line 63 "C:\Users\Alrowad\GradutionProject-master-ُFinal_Edit11\GradutionProject-master-ُFinal_Edit\GradutionProject\Views\Admin\Index.cshtml"
                                                            Write(ViewBag.RegionNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span></div>
                </div>
            </div>
        </div>
    </div>
    <div class="" d-lg-block col-md-6 col-xl-3"">
        <div class=""card mb-3 widget-content bg-premium-dark"">
            <div class=""widget-content-wrapper text-white"">
                <div class=""widget-content-left"">
                    <div class=""widget-heading"">Total Cities</div>
                </div>
                <div class=""widget-content-right"">
                    <div class=""widget-numbers text-warning""><span>");
#nullable restore
#line 75 "C:\Users\Alrowad\GradutionProject-master-ُFinal_Edit11\GradutionProject-master-ُFinal_Edit\GradutionProject\Views\Admin\Index.cshtml"
                                                              Write(ViewBag.CityNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span></div>
                </div>
            </div>
        </div>
    </div>
</div>

<div class=""col-sm-12 "">
    <h3 class=""text-center font-weight-bold border-bottom"" style=""color: #4272d7; width:100%"">Messages</h3>
    <br />
    <table id=""mess"" class=""table  table-bordered table-hover text-center  "" style=""width:100%"">
    </table>
</div>




");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f35ee509800c9fab19ebec12629cad372653bd010473", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    \r\n\r\n");
            }
            );
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