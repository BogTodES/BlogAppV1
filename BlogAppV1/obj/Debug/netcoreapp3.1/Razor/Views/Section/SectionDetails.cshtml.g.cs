#pragma checksum "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Section\SectionDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c302392a598606233330b039ea6f2d93a3808f6a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Section_SectionDetails), @"mvc.1.0.view", @"/Views/Section/SectionDetails.cshtml")]
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
#line 1 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\_ViewImports.cshtml"
using BlogAppV1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\_ViewImports.cshtml"
using BlogAppV1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c302392a598606233330b039ea6f2d93a3808f6a", @"/Views/Section/SectionDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d47380d248ae2e2cef88ad5332e82f9bd9f68e41", @"/Views/_ViewImports.cshtml")]
    public class Views_Section_SectionDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BlogAppV1.ViewModels.SectionVms.DetailedSectionVm>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PostWith", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-decoration-none text-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Section\SectionDetails.cshtml"
   
    ViewData["Title"] = "Section details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c302392a598606233330b039ea6f2d93a3808f6a4711", async() => {
                WriteLiteral("\r\n    <title>\r\n        ");
#nullable restore
#line 12 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Section\SectionDetails.cshtml"
   Write(Model.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    </title>\r\n");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c302392a598606233330b039ea6f2d93a3808f6a5938", async() => {
                WriteLiteral("\r\n    <div class=\"container justify-content-center\">\r\n        <div class=\"row justify-content-center\">\r\n            <div class=\"flex-column text-center\">\r\n                <h1 class=\"text-capitalize text-center\">\r\n                    ");
#nullable restore
#line 20 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Section\SectionDetails.cshtml"
               Write(Model.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </h1>\r\n                <span class=\"clearfix float-right\">\r\n");
#nullable restore
#line 23 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Section\SectionDetails.cshtml"
                     if (CurrentUser.IsAuthenticated)
                        if (int.Parse(CurrentUser.Id) == Model.OwnerId
                            || User.IsInRole("Admin"))
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <button");
                BeginWriteAttribute("id", " id=\"", 859, "\"", 875, 2);
                WriteAttributeValue("", 864, "s_", 864, 2, true);
#nullable restore
#line 27 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Section\SectionDetails.cshtml"
WriteAttributeValue("", 866, Model.Id, 866, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"removeSection btn btn-sm btn-outline-danger\">\r\n                                Delete\r\n                            </button>\r\n");
#nullable restore
#line 30 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Section\SectionDetails.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </span>\r\n            </div>\r\n        </div>\r\n        <div class=\"row justify-content-start\">\r\n");
#nullable restore
#line 35 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Section\SectionDetails.cshtml"
             foreach(var post in Model.Posts)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <div class=\"row card border-danger m-2 p-2 w-100 text-dark\">\r\n                    <div class=\"card-title\">\r\n                        <h3 class=\"text-capitalize card-title\">\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c302392a598606233330b039ea6f2d93a3808f6a8598", async() => {
                    WriteLiteral("\r\n                                ");
#nullable restore
#line 42 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Section\SectionDetails.cshtml"
                           Write(post.Title);

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-postId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 41 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Section\SectionDetails.cshtml"
                                     WriteLiteral(post.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["postId"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-postId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["postId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        </h3>\r\n                        <span class=\"clearfix float-right\">\r\n");
#nullable restore
#line 46 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Section\SectionDetails.cshtml"
                             if (CurrentUser.IsAuthenticated)
                                if (int.Parse(CurrentUser.Id) == Model.OwnerId
                                    || User.IsInRole("Admin"))
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <button");
                BeginWriteAttribute("id", " id=\"", 2031, "\"", 2046, 2);
                WriteAttributeValue("", 2036, "p_", 2036, 2, true);
#nullable restore
#line 50 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Section\SectionDetails.cshtml"
WriteAttributeValue("", 2038, post.Id, 2038, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"removePost btn btn-sm btn-outline-danger\">\r\n                                        Delete\r\n                                    </button>\r\n");
#nullable restore
#line 53 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Section\SectionDetails.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </span>\r\n                        <h6 class=\"card-subtitle text-muted\">\r\n                            posted on ");
#nullable restore
#line 56 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Section\SectionDetails.cshtml"
                                 Write(post.Date.Date.ToShortDateString());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </h6>\r\n                    </div>\r\n                    <hr />\r\n                    <p class=\"card-text text-dark\">\r\n                        ");
#nullable restore
#line 61 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Section\SectionDetails.cshtml"
                   Write(post.Body);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </p>\r\n                </div>\r\n");
#nullable restore
#line 64 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Section\SectionDetails.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Section\SectionDetails.cshtml"
             if(CurrentUser.IsAuthenticated && int.Parse(CurrentUser.Id) == Model.OwnerId)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                <div id=""newShortPost"" class=""card border-danger m-2 p-2 w-100 text-dark"">
                        <div class=""card-title"">
                            <h3 id=""newTitle"" contenteditable=""true"" class=""text-capitalize card-title text-decoration-none border-dark"">
                            </h3>
                        </div>
                        <hr />
                        <textarea id=""newBody"" class=""card-text text-muted text-decoration-none border-dark"" contenteditable=""true"">

                        </textarea>
                        <button id=""addNewPostBut""");
                BeginWriteAttribute("name", " name=\"", 3351, "\"", 3367, 1);
#nullable restore
#line 76 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Section\SectionDetails.cshtml"
WriteAttributeValue("", 3358, Model.Id, 3358, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"btn btn-secondary clearfix w-25 float-right\"\r\n                                >\r\n                            Post It!\r\n                        </button>\r\n                        <input type=\"hidden\" id=\"addNewPostAction\" data-add-new-post-url=\"");
#nullable restore
#line 80 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Section\SectionDetails.cshtml"
                                                                                     Write(Url.Action("AddPost", "Post"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\"/>\r\n                </div>\r\n");
#nullable restore
#line 82 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Section\SectionDetails.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\r\n    </div>\r\n");
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
        public BlogAppV1.Entities.DTOs.CurrentUserDto CurrentUser { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BlogAppV1.ViewModels.SectionVms.DetailedSectionVm> Html { get; private set; }
    }
}
#pragma warning restore 1591
