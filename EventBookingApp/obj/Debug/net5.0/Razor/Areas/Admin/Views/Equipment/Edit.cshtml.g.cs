#pragma checksum "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Equipment\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "04d8b2afc49b35119ad2e994b90482e05764ec17"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Equipment_Edit), @"mvc.1.0.view", @"/Areas/Admin/Views/Equipment/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04d8b2afc49b35119ad2e994b90482e05764ec17", @"/Areas/Admin/Views/Equipment/Edit.cshtml")]
    public class Areas_Admin_Views_Equipment_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DataAcessLayer.Equipment>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Equipment\Edit.cshtml"
  
    Layout = "~/Views/Shared/_AdminLayout.cshtml";
    ViewData["Title"] = "Edit";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"card\">\r\n    <div class=\"card-header\">Edit Equipment</div>\r\n    <div class=\"card-body\">\r\n");
#nullable restore
#line 11 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Equipment\Edit.cshtml"
         using (Html.BeginForm("Edit", "Equipment", FormMethod.Post, new { id = "form" }))
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Equipment\Edit.cshtml"
       Write(Html.HiddenFor(m => m.EquipmentId, new { @class = "equipmentid" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"row\">\r\n                <div class=\"col-sm-4\">\r\n                    <div class=\"form-group\">\r\n                        <label class=\"control-label\">EquipmentType</label>\r\n                        ");
#nullable restore
#line 18 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Equipment\Edit.cshtml"
                   Write(Html.TextBoxFor(m => m.EquipmentType, new { @class = "form-control", placeholder = "Enter Equipment Type", @Autocomplete = "off" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"input-group mb-3\">\r\n                    ");
#nullable restore
#line 22 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Equipment\Edit.cshtml"
               Write(Html.ValidationMessageFor(m => m.EquipmentType, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-sm-4\">\r\n                    <div class=\"form-group\">\r\n                        <label class=\"control-label\">EquipmentCost</label>\r\n                        ");
#nullable restore
#line 27 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Equipment\Edit.cshtml"
                   Write(Html.TextBoxFor(m => m.EquipmentCost, new { @class = "form-control", placeholder = "Enter Equipment Cost", @Autocomplete = "off" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"input-group mb-3\">\r\n                    ");
#nullable restore
#line 31 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Equipment\Edit.cshtml"
               Write(Html.ValidationMessageFor(m => m.EquipmentCost, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"card-footer \">\r\n                    <div class=\"fa-pull-right \">\r\n                        <button type=\"submit\" class=\"btn btn-primary\" value=\"save\">Save</button>\r\n                        <a");
            BeginWriteAttribute("href", " href=\'", 1762, "\'", 1801, 1);
#nullable restore
#line 36 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Equipment\Edit.cshtml"
WriteAttributeValue("", 1769, Url.Action("Index","Equipment"), 1769, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\">Close</a>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 40 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Equipment\Edit.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 46 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Equipment\Edit.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DataAcessLayer.Equipment> Html { get; private set; }
    }
}
#pragma warning restore 1591
