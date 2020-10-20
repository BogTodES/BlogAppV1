#pragma checksum "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\FriendsList\FriendsListFloater.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7456f8de1b89e6e0047bf549c7faba58d7e92208"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_FriendsList_FriendsListFloater), @"mvc.1.0.view", @"/Views/Shared/Components/FriendsList/FriendsListFloater.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7456f8de1b89e6e0047bf549c7faba58d7e92208", @"/Views/Shared/Components/FriendsList/FriendsListFloater.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d47380d248ae2e2cef88ad5332e82f9bd9f68e41", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_FriendsList_FriendsListFloater : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BlogAppV1.ViewModels.FriendVms.CombinedFriendsVm>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("dropdown-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "UserInfo", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ProfileOf", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"
<div id=""friendListSelector"" class=""p-2 m-2 mt-0"">
    <div class=""form-check form-check-inline"">
        <input class=""form-check-input"" type=""radio""
               name=""exampleRadios"" id=""rad"" value=""mainFriendsList"" checked>
        <label class=""form-check-label"" for=""exampleRadios1"">
            All
        </label>
    </div>
    <div class=""form-check form-check-inline"">
        <input class=""form-check-input"" type=""radio""
               name=""exampleRadios"" id=""rad"" value=""mainFriendsList"" >
        <label class=""form-check-label"" for=""exampleRadios1"">
            Friends
        </label>
    </div>
    <div class=""form-check form-check-inline"">
        <input class=""form-check-input"" type=""radio""
               name=""exampleRadios"" id=""exampleRadios1"" value=""receivedRequestsList"">
        <label class=""form-check-label"" for=""exampleRadios1"">
            Received
        </label>
    </div>
    <div class=""form-check form-check-inline"">
        <input class=""form-check-input""");
            WriteLiteral(@" type=""radio""
               name=""exampleRadios"" id=""exampleRadios1"" value=""sentRequestsList"">
        <label class=""form-check-label"" for=""exampleRadios1"">
            Sent
        </label>
    </div>
</div>
<div id=""friendListDisplay"" class=""m-2 mt-1 p-2"">
");
#nullable restore
#line 34 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\FriendsList\FriendsListFloater.cshtml"
     if (Model.FriendsList.Any())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span>Friends</span>\r\n");
#nullable restore
#line 37 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\FriendsList\FriendsListFloater.cshtml"
        foreach(var fr in Model.FriendsList)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7456f8de1b89e6e0047bf549c7faba58d7e922086187", async() => {
                WriteLiteral("\r\n            <img alt=\"pz\" />\r\n            <span>\r\n                ");
#nullable restore
#line 43 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\FriendsList\FriendsListFloater.cshtml"
           Write(fr.FriendUsername);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </span>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-username", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 40 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\FriendsList\FriendsListFloater.cshtml"
                                          WriteLiteral(fr.FriendUsername);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["username"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-username", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["username"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 46 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\FriendsList\FriendsListFloater.cshtml"
        } 
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"dropdown-divider\"></div>\r\n");
#nullable restore
#line 49 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\FriendsList\FriendsListFloater.cshtml"
     if (Model.ReceivedRequestsList.Any())
    {   

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span>Pending</span>\r\n");
#nullable restore
#line 52 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\FriendsList\FriendsListFloater.cshtml"
        foreach(var fr in Model.ReceivedRequestsList)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div");
            BeginWriteAttribute("class", " class=\"", 1958, "\"", 1996, 3);
            WriteAttributeValue("", 1966, "dropdown-item", 1966, 13, true);
            WriteAttributeValue(" ", 1979, "req_", 1980, 5, true);
#nullable restore
#line 54 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\FriendsList\FriendsListFloater.cshtml"
WriteAttributeValue("", 1984, fr.SenderId, 1984, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <img alt=\"pz\" />\r\n            <span>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7456f8de1b89e6e0047bf549c7faba58d7e9220810543", async() => {
                WriteLiteral("\r\n                    <img alt=\"pz\" />\r\n                    <span>\r\n                        ");
#nullable restore
#line 61 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\FriendsList\FriendsListFloater.cshtml"
                   Write(fr.SenderUsername);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </span>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-username", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 58 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\FriendsList\FriendsListFloater.cshtml"
                                                  WriteLiteral(fr.SenderUsername);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["username"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-username", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["username"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </span>\r\n            <span class=\"btn-group-sm\">\r\n                <button");
            BeginWriteAttribute("id", " id=\"", 2426, "\"", 2451, 2);
            WriteAttributeValue("", 2431, "confirm_", 2431, 8, true);
#nullable restore
#line 66 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\FriendsList\FriendsListFloater.cshtml"
WriteAttributeValue("", 2439, fr.SenderId, 2439, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" \r\n                        class=\"btn btn-outline-success rounded-circle confirmReq\">\r\n                    C\r\n                </button>\r\n                <button");
            BeginWriteAttribute("id", " id=\"", 2612, "\"", 2634, 2);
            WriteAttributeValue("", 2617, "decl_", 2617, 5, true);
#nullable restore
#line 70 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\FriendsList\FriendsListFloater.cshtml"
WriteAttributeValue("", 2622, fr.SenderId, 2622, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" \r\n                        class=\"btn btn-outline-danger rounded-circle declineReq\">\r\n                    D\r\n                </button>\r\n            </span>\r\n        </div>\r\n");
#nullable restore
#line 76 "D:\miscVisStudProjects\BlogAppV1\BlogAppV1\Views\Shared\Components\FriendsList\FriendsListFloater.cshtml"
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BlogAppV1.ViewModels.FriendVms.CombinedFriendsVm> Html { get; private set; }
    }
}
#pragma warning restore 1591
