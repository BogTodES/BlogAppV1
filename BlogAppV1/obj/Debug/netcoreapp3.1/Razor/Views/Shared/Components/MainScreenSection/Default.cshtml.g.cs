#pragma checksum "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\MainScreenSection\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8e51133f4139d94eb5664e6ec95e889b702f809f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_MainScreenSection_Default), @"mvc.1.0.view", @"/Views/Shared/Components/MainScreenSection/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e51133f4139d94eb5664e6ec95e889b702f809f", @"/Views/Shared/Components/MainScreenSection/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d47380d248ae2e2cef88ad5332e82f9bd9f68e41", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_MainScreenSection_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BlogAppV1.ViewModels.BlogStuff.SmallSectionVm>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("<div class=\"border border-danger\">\r\n    <div>\r\n        <h2 class=\"text-center\">\r\n            ");
#nullable restore
#line 7 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\MainScreenSection\Default.cshtml"
       Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </h2>\r\n    </div>\r\n    <hr />\r\n");
#nullable restore
#line 11 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\MainScreenSection\Default.cshtml"
     foreach(var post in Model.Posts)
    {            

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"border border-info m-2 p-2\">\r\n            <h3 class=\"text-capitalize\">\r\n                ");
#nullable restore
#line 15 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\MainScreenSection\Default.cshtml"
           Write(post.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </h3>\r\n            <p class=\"text-muted\">\r\n                ");
#nullable restore
#line 18 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\MainScreenSection\Default.cshtml"
           Write(post.Body);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </p>\r\n        </div>\r\n");
#nullable restore
#line 21 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\MainScreenSection\Default.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BlogAppV1.ViewModels.BlogStuff.SmallSectionVm> Html { get; private set; }
    }
}
#pragma warning restore 1591
