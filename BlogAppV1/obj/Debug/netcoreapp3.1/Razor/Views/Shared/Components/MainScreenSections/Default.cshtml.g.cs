#pragma checksum "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\MainScreenSections\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "978605b16b1fce39e333faf2e93240de40264245"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_MainScreenSections_Default), @"mvc.1.0.view", @"/Views/Shared/Components/MainScreenSections/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"978605b16b1fce39e333faf2e93240de40264245", @"/Views/Shared/Components/MainScreenSections/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d47380d248ae2e2cef88ad5332e82f9bd9f68e41", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_MainScreenSections_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BlogAppV1.ViewModels.SectionVms.MainScreenSectionRow>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Section", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SectionDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PostWith", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\MainScreenSections\Default.cshtml"
 foreach(var sect in Model.DetailedSections)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-4 m-3 card\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "978605b16b1fce39e333faf2e93240de402642454773", async() => {
                WriteLiteral("\r\n            <h3 class=\"text-dark d-flex justify-content-center\">\r\n                ");
#nullable restore
#line 9 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\MainScreenSections\Default.cshtml"
           Write(sect.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </h3>\r\n        ");
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
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-sectId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 7 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\MainScreenSections\Default.cshtml"
                                                                      WriteLiteral(sect.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sectId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-sectId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sectId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        <hr />\r\n");
#nullable restore
#line 13 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\MainScreenSections\Default.cshtml"
         if(sect.PhotoId != null && sect.PhotoId != 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <img");
            BeginWriteAttribute("src", " src=\"", 468, "\"", 538, 1);
#nullable restore
#line 15 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\MainScreenSections\Default.cshtml"
WriteAttributeValue("", 474, Url.Action("GetPhoto", "Media", new { photoId = sect.PhotoId }), 474, 64, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" \r\n                 class=\"card-img card-img-top\" />\r\n");
#nullable restore
#line 17 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\MainScreenSections\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\MainScreenSections\Default.cshtml"
         foreach(var post in sect.Posts)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"mb-3 shadow-lg p-2\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "978605b16b1fce39e333faf2e93240de402642458887", async() => {
                WriteLiteral("\r\n                    <h4 class=\"text-dark d-flex justify-content-center\">\r\n                        ");
#nullable restore
#line 23 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\MainScreenSections\Default.cshtml"
                   Write(post.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </h4>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-postId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 21 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\MainScreenSections\Default.cshtml"
                                                                     WriteLiteral(post.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["postId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-postId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["postId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                <hr />\r\n                <p class=\"text-secondary\">\r\n                    ");
#nullable restore
#line 28 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\MainScreenSections\Default.cshtml"
               Write(post.Body);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </p>\r\n                <hr />\r\n                <div>\r\n                    <ul class=\"list-group list-group-horizontal list-unstyled small float-left border-0\">\r\n                        ");
#nullable restore
#line 33 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\MainScreenSections\Default.cshtml"
                   Write(await Component.InvokeAsync("PostReactsWidget",
                                    new { postId = post.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </ul>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 38 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\MainScreenSections\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
#nullable restore
#line 40 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\MainScreenSections\Default.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BlogAppV1.ViewModels.SectionVms.MainScreenSectionRow> Html { get; private set; }
    }
}
#pragma warning restore 1591
