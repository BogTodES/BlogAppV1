#pragma checksum "D:\PROIECTE_VIS_STUD\BlogAppV1\BlogAppV1\Views\Blog\EditableBlogPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a7b7a3025c779949705f8f4c8b867161c2cdddac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blog_EditableBlogPage), @"mvc.1.0.view", @"/Views/Blog/EditableBlogPage.cshtml")]
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
#line 1 "D:\PROIECTE_VIS_STUD\BlogAppV1\BlogAppV1\Views\_ViewImports.cshtml"
using BlogAppV1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\PROIECTE_VIS_STUD\BlogAppV1\BlogAppV1\Views\_ViewImports.cshtml"
using BlogAppV1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a7b7a3025c779949705f8f4c8b867161c2cdddac", @"/Views/Blog/EditableBlogPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d47380d248ae2e2cef88ad5332e82f9bd9f68e41", @"/Views/_ViewImports.cshtml")]
    public class Views_Blog_EditableBlogPage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BlogAppV1.ViewModels.DetailedBlogVm>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a7b7a3025c779949705f8f4c8b867161c2cdddac3300", async() => {
                WriteLiteral("\r\n    <title>Edit ");
#nullable restore
#line 5 "D:\PROIECTE_VIS_STUD\BlogAppV1\BlogAppV1\Views\Blog\EditableBlogPage.cshtml"
           Write(Model.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("</title>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a7b7a3025c779949705f8f4c8b867161c2cdddac4517", async() => {
                WriteLiteral(@"
    <div class=""container justify-content-center"">
        <div class=""row justify-content-center"">
            <div class=""flex-column text-center"">
                <h1 class=""text-capitalize text-center"" id=""title"" contenteditable=""true"">
                    ");
#nullable restore
#line 12 "D:\PROIECTE_VIS_STUD\BlogAppV1\BlogAppV1\Views\Blog\EditableBlogPage.cshtml"
               Write(Model.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </h1>\r\n                <h3 class=\"text-muted font-weight-lighter\">\r\n                    from ");
#nullable restore
#line 15 "D:\PROIECTE_VIS_STUD\BlogAppV1\BlogAppV1\Views\Blog\EditableBlogPage.cshtml"
                    Write(Model.OwnerUsername);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </h3>\r\n            </div>\r\n        </div>\r\n        <div>\r\n            <div class=\"row justify-content-center\" id=\"sectionsContainer\">\r\n");
#nullable restore
#line 21 "D:\PROIECTE_VIS_STUD\BlogAppV1\BlogAppV1\Views\Blog\EditableBlogPage.cshtml"
                 foreach (var sectId in Model.SectionsIds)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <div class=\"col border-info rounded m-3\">\r\n                        ");
#nullable restore
#line 24 "D:\PROIECTE_VIS_STUD\BlogAppV1\BlogAppV1\Views\Blog\EditableBlogPage.cshtml"
                   Write(await Component.InvokeAsync("MainScreenSection", 
                                    new { id = sectId, blogId = Model.BlogId, IsEditable = true }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 27 "D:\PROIECTE_VIS_STUD\BlogAppV1\BlogAppV1\Views\Blog\EditableBlogPage.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </div>\r\n            <button id=\"newSectBut\" class=\"p-2 m-2 border rounded\">\r\n                Add a new section\r\n            </button>\r\n            <button id=\"saveChangesBut\"");
                BeginWriteAttribute("name", " name=\"", 1266, "\"", 1286, 1);
#nullable restore
#line 32 "D:\PROIECTE_VIS_STUD\BlogAppV1\BlogAppV1\Views\Blog\EditableBlogPage.cshtml"
WriteAttributeValue("", 1273, Model.BlogId, 1273, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                Save Changes\r\n            </button>\r\n            <input type=\"hidden\" id=\"saveChangesAction\" \r\n                   data-register-section-url=\"");
#nullable restore
#line 36 "D:\PROIECTE_VIS_STUD\BlogAppV1\BlogAppV1\Views\Blog\EditableBlogPage.cshtml"
                                         Write(Url.Action("AddSection", "Section"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\" \r\n                   data-redirect-to-blog=\"");
#nullable restore
#line 37 "D:\PROIECTE_VIS_STUD\BlogAppV1\BlogAppV1\Views\Blog\EditableBlogPage.cshtml"
                                     Write(Url.Action("ShowBlogWith", "Blog", new { id = Model.BlogId }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\"/>\r\n            <input type=\"hidden\" id=\"saveBlogTitleAction\" data-update-blog-title-url=\"");
#nullable restore
#line 38 "D:\PROIECTE_VIS_STUD\BlogAppV1\BlogAppV1\Views\Blog\EditableBlogPage.cshtml"
                                                                                 Write(Url.Action("UpdateTitle", "Blog"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\" />\r\n        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BlogAppV1.ViewModels.DetailedBlogVm> Html { get; private set; }
    }
}
#pragma warning restore 1591
