#pragma checksum "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookingDecoration.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "379efa55ebeb96494be907e4ff26220204a0d786"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Admin_AllBookingDecoration), @"mvc.1.0.view", @"/Areas/Admin/Views/Admin/AllBookingDecoration.cshtml")]
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
#line 1 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\_ViewImports.cshtml"
using EventBookingApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\_ViewImports.cshtml"
using EventBookingApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"379efa55ebeb96494be907e4ff26220204a0d786", @"/Areas/Admin/Views/Admin/AllBookingDecoration.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42218ab629f0e661b70decfaecaeb9556b7ef511", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Admin_AllBookingDecoration : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DataAcessLayer.ViewModel.BookingDetalisViewModel>>
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
#line 2 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookingDecoration.cshtml"
  
    Layout = "~/Views/Shared/_AdminLayout.cshtml";
    ViewData["Title"] = "List";

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "379efa55ebeb96494be907e4ff26220204a0d7863693", async() => {
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "379efa55ebeb96494be907e4ff26220204a0d7864724", async() => {
                WriteLiteral("\r\n    <div class=\"card\">\r\n        <div class=\"card-header\">\r\n            <div class=\"pull-left\" style=\"font-weight:bold;font-size:medium\">Decorations</div>\r\n            <div style=\"float:right\">\r\n                <a");
                BeginWriteAttribute("href", " href=\'", 483, "\'", 524, 1);
#nullable restore
#line 16 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookingDecoration.cshtml"
WriteAttributeValue("", 490, Url.Action("AllBookings","Admin"), 490, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"btn btn-primary float-right\"><i class=\"fa fa-arrow-circle-left\"></i></a>\r\n            </div>\r\n        </div>\r\n        <table class=\"table\">\r\n            <thead>\r\n                <tr>\r\n                    <th>\r\n                        ");
#nullable restore
#line 23 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookingDecoration.cshtml"
                   Write(Html.DisplayNameFor(model => model.EquipmentType));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 26 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookingDecoration.cshtml"
                   Write(Html.DisplayNameFor(model => model.FlowerType));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 29 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookingDecoration.cshtml"
                   Write(Html.DisplayNameFor(model => model.FoodType));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 34 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookingDecoration.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 38 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookingDecoration.cshtml"
                       Write(Html.DisplayFor(modelItem => item.EquipmentType));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 41 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookingDecoration.cshtml"
                       Write(Html.DisplayFor(modelItem => item.FlowerType));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 44 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookingDecoration.cshtml"
                       Write(Html.DisplayFor(modelItem => item.FoodType));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 47 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookingDecoration.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");
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
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DataAcessLayer.ViewModel.BookingDetalisViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
