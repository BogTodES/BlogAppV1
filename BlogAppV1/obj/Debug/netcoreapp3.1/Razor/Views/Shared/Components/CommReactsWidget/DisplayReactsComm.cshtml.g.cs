#pragma checksum "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\CommReactsWidget\DisplayReactsComm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e03f815682369cde425413cc7d9d8b0867ce3102"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_CommReactsWidget_DisplayReactsComm), @"mvc.1.0.view", @"/Views/Shared/Components/CommReactsWidget/DisplayReactsComm.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e03f815682369cde425413cc7d9d8b0867ce3102", @"/Views/Shared/Components/CommReactsWidget/DisplayReactsComm.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d47380d248ae2e2cef88ad5332e82f9bd9f68e41", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_CommReactsWidget_DisplayReactsComm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BlogAppV1.ViewModels.ReactsVms.ReactsAndCommVm>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 5 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\CommReactsWidget\DisplayReactsComm.cshtml"
  
    var reactSet = Model.TypesAndUsers.Select(tu => tu.Type).ToHashSet();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 9 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\CommReactsWidget\DisplayReactsComm.cshtml"
 foreach (var type in reactSet)
{
    

#line default
#line hidden
#nullable disable
            WriteLiteral("    <li");
            BeginWriteAttribute("class", " class=\"", 303, "\"", 332, 2);
            WriteAttributeValue("", 311, "list-group-item", 311, 15, true);
#nullable restore
#line 13 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\CommReactsWidget\DisplayReactsComm.cshtml"
WriteAttributeValue(" ", 326, type, 327, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-comm-id=\"");
#nullable restore
#line 13 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\CommReactsWidget\DisplayReactsComm.cshtml"
                                               Write(Model.CommId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n        ");
#nullable restore
#line 14 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\CommReactsWidget\DisplayReactsComm.cshtml"
   Write(type);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 15 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\CommReactsWidget\DisplayReactsComm.cshtml"
   Write(Model.TypesAndUsers.Where(r => r.Type == type).Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </li>\r\n");
#nullable restore
#line 17 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\CommReactsWidget\DisplayReactsComm.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 19 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\CommReactsWidget\DisplayReactsComm.cshtml"
 if (CurrentUser.IsAuthenticated)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<li>\r\n");
#nullable restore
#line 23 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\CommReactsWidget\DisplayReactsComm.cshtml"
      
        var upr = Model.TypesAndUsers
            .FirstOrDefault(r => r.UserId == int.Parse(CurrentUser.Id));
        if (upr is null)
        {
            

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <button class=""btn btn-secondary dropdown-toggle"" 
                    type=""button"" id=""dropdownMenuButton"" 
                    data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                Like
            </button>
");
#nullable restore
#line 38 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\CommReactsWidget\DisplayReactsComm.cshtml"
        }
        else
        {
            

#line default
#line hidden
#nullable disable
            WriteLiteral("            <button");
            BeginWriteAttribute("id", " id=\"", 1284, "\"", 1302, 1);
#nullable restore
#line 42 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\CommReactsWidget\DisplayReactsComm.cshtml"
WriteAttributeValue("", 1289, Model.CommId, 1289, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn-info small liked reactButComm\">\r\n                ");
#nullable restore
#line 43 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\CommReactsWidget\DisplayReactsComm.cshtml"
           Write(upr.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </button>\r\n");
#nullable restore
#line 45 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\CommReactsWidget\DisplayReactsComm.cshtml"
        }

        

#line default
#line hidden
#nullable disable
            WriteLiteral("        <input type=\"hidden\" id=\"commData\"\r\n               data-comm-url-add=\"");
#nullable restore
#line 49 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\CommReactsWidget\DisplayReactsComm.cshtml"
                             Write(Url.Action("ReactToComm", "Reactions"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\r\n               data-comm-url-remove=\"");
#nullable restore
#line 50 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\CommReactsWidget\DisplayReactsComm.cshtml"
                                Write(Url.Action("RemoveReactFromComm", "Reactions"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n");
            WriteLiteral("</li>\r\n");
#nullable restore
#line 53 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\CommReactsWidget\DisplayReactsComm.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BlogAppV1.ViewModels.ReactsVms.ReactsAndCommVm> Html { get; private set; }
    }
}
#pragma warning restore 1591
