#pragma checksum "D:\shopApp\shopApp.WEBUI\Views\User\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c87299879c1876ee7cb64b7692f672d9eb3ed864"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_List), @"mvc.1.0.view", @"/Views/User/List.cshtml")]
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
#line 2 "D:\shopApp\shopApp.WEBUI\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c87299879c1876ee7cb64b7692f672d9eb3ed864", @"/Views/User/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2bdb6016d59e9006192554863393d2bd52acc67", @"/Views/_ViewImports.cshtml")]
    public class Views_User_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<shopApp.WEBUI.Models.User>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\shopApp\shopApp.WEBUI\Views\User\List.cshtml"
  
    ViewData["Title"] = "List";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    <table>\r\n        <tr>\r\n            <th>Id:</th>\r\n            <th>User Name:</th>\r\n            <th>E-mail:</th>\r\n        </tr>\r\n");
#nullable restore
#line 14 "D:\shopApp\shopApp.WEBUI\Views\User\List.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\r\n        <td>");
#nullable restore
#line 17 "D:\shopApp\shopApp.WEBUI\Views\User\List.cshtml"
       Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 18 "D:\shopApp\shopApp.WEBUI\Views\User\List.cshtml"
       Write(item.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 19 "D:\shopApp\shopApp.WEBUI\Views\User\List.cshtml"
       Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td><a");
            BeginWriteAttribute("href", " href=\"", 380, "\"", 427, 1);
#nullable restore
#line 20 "D:\shopApp\shopApp.WEBUI\Views\User\List.cshtml"
WriteAttributeValue("", 387, Url.Action("Update",new {id = item.Id}), 387, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><input type=\"button\" value=\"Update\"/></a></td>\r\n        <td><a");
            BeginWriteAttribute("href", " href=\"", 491, "\"", 538, 1);
#nullable restore
#line 21 "D:\shopApp\shopApp.WEBUI\Views\User\List.cshtml"
WriteAttributeValue("", 498, Url.Action("Delete",new {id = item.Id}), 498, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><input type=\"button\" value=\"Delete\" /></a></td>\r\n    </tr>\r\n");
#nullable restore
#line 23 "D:\shopApp\shopApp.WEBUI\Views\User\List.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </table>\r\n<button type=\"button\" onclick=\"window.location.href=\'/User/Logout\'\">Logout</button>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<shopApp.WEBUI.Models.User>> Html { get; private set; }
    }
}
#pragma warning restore 1591
