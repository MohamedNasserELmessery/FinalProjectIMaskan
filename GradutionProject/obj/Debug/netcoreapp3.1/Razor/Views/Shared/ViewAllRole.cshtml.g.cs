#pragma checksum "C:\Users\Alrowad\GradutionProject-master-ُFinal_Edit11\GradutionProject-master-ُFinal_Edit\GradutionProject\Views\Shared\ViewAllRole.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f112752386af58a899cd20ef2afc37675dace2bd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_ViewAllRole), @"mvc.1.0.view", @"/Views/Shared/ViewAllRole.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f112752386af58a899cd20ef2afc37675dace2bd", @"/Views/Shared/ViewAllRole.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7728a3ab0676e126c8d79870230506ca245dc707", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_ViewAllRole : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GradutionProject.ViewModel.CreateRoleViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/site2.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Alrowad\GradutionProject-master-ُFinal_Edit11\GradutionProject-master-ُFinal_Edit\GradutionProject\Views\Shared\ViewAllRole.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<p>\r\n    <a");
            BeginWriteAttribute("onclick", " onclick=\"", 131, "\"", 227, 4);
            WriteAttributeValue("", 141, "showpop(\'", 141, 9, true);
#nullable restore
#line 9 "C:\Users\Alrowad\GradutionProject-master-ُFinal_Edit11\GradutionProject-master-ُFinal_Edit\GradutionProject\Views\Shared\ViewAllRole.cshtml"
WriteAttributeValue("", 150, Url.Action("CreateRole","Roles",null,Context.Request.Scheme), 150, 61, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 211, "\',\'Create", 211, 9, true);
            WriteAttributeValue(" ", 220, "Role\')", 221, 7, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">Create Role</a>\r\n\r\n</p>\r\n<table class=\"table table-bordered table-hover\">\r\n    <thead>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 16 "C:\Users\Alrowad\GradutionProject-master-ُFinal_Edit11\GradutionProject-master-ُFinal_Edit\GradutionProject\Views\Shared\ViewAllRole.cshtml"
         foreach (var item in Model.IdentityRole)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td class=\"text-center\">\r\n                    ");
#nullable restore
#line 20 "C:\Users\Alrowad\GradutionProject-master-ُFinal_Edit11\GradutionProject-master-ُFinal_Edit\GradutionProject\Views\Shared\ViewAllRole.cshtml"
               Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td class=\"text-center\">\r\n");
            WriteLiteral("\r\n                    <button  class=\"btn btn-danger text-dark\"");
            BeginWriteAttribute("onclick", " onclick=\"", 782, "\"", 814, 3);
            WriteAttributeValue("", 792, "Deleterole(\'", 792, 12, true);
#nullable restore
#line 25 "C:\Users\Alrowad\GradutionProject-master-ُFinal_Edit11\GradutionProject-master-ُFinal_Edit\GradutionProject\Views\Shared\ViewAllRole.cshtml"
WriteAttributeValue("", 804, item.Id, 804, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 812, "\')", 812, 2, true);
            EndWriteAttribute();
            WriteLiteral("> Delete </button>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 28 "C:\Users\Alrowad\GradutionProject-master-ُFinal_Edit11\GradutionProject-master-ُFinal_Edit\GradutionProject\Views\Shared\ViewAllRole.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(" \r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f112752386af58a899cd20ef2afc37675dace2bd6766", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GradutionProject.ViewModel.CreateRoleViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
