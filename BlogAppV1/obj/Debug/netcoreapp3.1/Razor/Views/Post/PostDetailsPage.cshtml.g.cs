#pragma checksum "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Post\PostDetailsPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5a429b7a8d4f23503e52f0ddb0652706619eb3cb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Post_PostDetailsPage), @"mvc.1.0.view", @"/Views/Post/PostDetailsPage.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a429b7a8d4f23503e52f0ddb0652706619eb3cb", @"/Views/Post/PostDetailsPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d47380d248ae2e2cef88ad5332e82f9bd9f68e41", @"/Views/_ViewImports.cshtml")]
    public class Views_Post_PostDetailsPage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BlogAppV1.ViewModels.PostVms.PostDetailsVm>
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
#nullable restore
#line 1 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Post\PostDetailsPage.cshtml"
   
    ViewData["Title"] = "PostView";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a429b7a8d4f23503e52f0ddb0652706619eb3cb3546", async() => {
                WriteLiteral("\r\n    <title>");
#nullable restore
#line 10 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Post\PostDetailsPage.cshtml"
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a429b7a8d4f23503e52f0ddb0652706619eb3cb4755", async() => {
                WriteLiteral("\r\n    <div class=\"card border-danger m-2 p-2 mb-0\">\r\n        <div class=\"card-body text-dark\">\r\n            <h2 class=\"text-capitalize card-title\">\r\n                ");
#nullable restore
#line 16 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Post\PostDetailsPage.cshtml"
           Write(Model.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </h2>\r\n            <h6 class=\"card-subtitle\">\r\n                posted on ");
#nullable restore
#line 19 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Post\PostDetailsPage.cshtml"
                     Write(Model.Date.Date.ToShortDateString());

#line default
#line hidden
#nullable disable
                WriteLiteral(" by ");
#nullable restore
#line 19 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Post\PostDetailsPage.cshtml"
                                                             Write(Model.OwnerUsername);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </h6>\r\n            <hr />\r\n            <p class=\"card-text\">\r\n                ");
#nullable restore
#line 23 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Post\PostDetailsPage.cshtml"
           Write(Model.Body);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            </p>
        </div>
    </div>

    <div class=""container justify-content-center"">
        <div id=""commentList"" class=""card border-info w-75"">
            <div class=""card-header"">
                <h5 class=""text-muted"">
                    Comments
                </h5>
            </div>
            <div class=""card-body "">
");
#nullable restore
#line 36 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Post\PostDetailsPage.cshtml"
                 foreach (var comm in Model.Comments)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <div class=\"border-bottom border-dark text-dark\">\r\n                    <h5>\r\n                        ");
#nullable restore
#line 40 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Post\PostDetailsPage.cshtml"
                   Write(comm.CommenterId);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </h5>\r\n");
#nullable restore
#line 42 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Post\PostDetailsPage.cshtml"
                     if (comm.ElapsedTime.TotalSeconds < 60)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <p class=\"text-muted\">\r\n                            ");
#nullable restore
#line 45 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Post\PostDetailsPage.cshtml"
                       Write(comm.ElapsedTime.Seconds);

#line default
#line hidden
#nullable disable
                WriteLiteral(" seconds ago\r\n                        </p>\r\n");
#nullable restore
#line 47 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Post\PostDetailsPage.cshtml"
                    }
                    else if (comm.ElapsedTime.TotalMinutes < 60)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <p class=\"text-muted\">\r\n                            ");
#nullable restore
#line 51 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Post\PostDetailsPage.cshtml"
                       Write(comm.ElapsedTime.Minutes);

#line default
#line hidden
#nullable disable
                WriteLiteral(" mins ago\r\n                        </p>\r\n");
#nullable restore
#line 53 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Post\PostDetailsPage.cshtml"
                    }
                    else if (comm.ElapsedTime.TotalHours < 24)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <p class=\"text-muted\">\r\n                            ");
#nullable restore
#line 57 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Post\PostDetailsPage.cshtml"
                       Write(comm.ElapsedTime.Hours);

#line default
#line hidden
#nullable disable
                WriteLiteral(" hours ago\r\n                        </p>\r\n");
#nullable restore
#line 59 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Post\PostDetailsPage.cshtml"
                    }
                    else if (comm.ElapsedTime.TotalDays < 7)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <p class=\"text-muted\">\r\n                            ");
#nullable restore
#line 63 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Post\PostDetailsPage.cshtml"
                       Write(comm.ElapsedTime.Days);

#line default
#line hidden
#nullable disable
                WriteLiteral(" days ago\r\n                        </p>\r\n");
#nullable restore
#line 65 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Post\PostDetailsPage.cshtml"
                    }
                    else if (comm.ElapsedTime.TotalDays < 31)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <p class=\"text-muted\">\r\n                            ");
#nullable restore
#line 69 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Post\PostDetailsPage.cshtml"
                        Write(comm.ElapsedTime.Days / 7);

#line default
#line hidden
#nullable disable
                WriteLiteral(" weeks ago\r\n                        </p>\r\n");
#nullable restore
#line 71 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Post\PostDetailsPage.cshtml"
                    }
                    else if (comm.ElapsedTime.TotalDays < 365)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <p class=\"text-muted\">\r\n                            ");
#nullable restore
#line 75 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Post\PostDetailsPage.cshtml"
                        Write(comm.ElapsedTime.Days / 30);

#line default
#line hidden
#nullable disable
                WriteLiteral(" months ago\r\n                        </p>\r\n");
#nullable restore
#line 77 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Post\PostDetailsPage.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <p class=\"text-muted\">\r\n                            ");
#nullable restore
#line 81 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Post\PostDetailsPage.cshtml"
                        Write(comm.ElapsedTime.Days / 365);

#line default
#line hidden
#nullable disable
                WriteLiteral(" years ago\r\n                        </p>\r\n");
#nullable restore
#line 83 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Post\PostDetailsPage.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <div class=\"d-block\">\r\n                        <p>\r\n                            ");
#nullable restore
#line 86 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Post\PostDetailsPage.cshtml"
                       Write(comm.Body);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </p>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 90 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Post\PostDetailsPage.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BlogAppV1.ViewModels.PostVms.PostDetailsVm> Html { get; private set; }
    }
}
#pragma warning restore 1591
