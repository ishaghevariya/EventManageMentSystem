#pragma checksum "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "58d823fb32c24c262f6c9625314badf1a0df218e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Admin_AllBookings), @"mvc.1.0.view", @"/Areas/Admin/Views/Admin/AllBookings.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58d823fb32c24c262f6c9625314badf1a0df218e", @"/Areas/Admin/Views/Admin/AllBookings.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42218ab629f0e661b70decfaecaeb9556b7ef511", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Admin_AllBookings : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DataAcessLayer.ViewModel.BookingViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AllBookingDecoration", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("myform"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
  
    Layout = "~/Views/Shared/_AdminLayout.cshtml";
    ViewData["Title"] = "List";
    var data = ViewBag.BookingStatus;

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58d823fb32c24c262f6c9625314badf1a0df218e5819", async() => {
                WriteLiteral(@"
    <meta name=""viewport"" content=""width=device-width"" />
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js"" integrity=""sha512-894YE6QWD5I59HgZOGReFYm4dnWc1Qt5NtvYSaNcOP+u1T9qYdvdihz0PPSiiqn/+/3e7Jo4EaG7TubfWGUrMQ=="" crossorigin=""anonymous"" referrerpolicy=""no-referrer""></script>
    <title>Index</title>
");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58d823fb32c24c262f6c9625314badf1a0df218e7137", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58d823fb32c24c262f6c9625314badf1a0df218e7399", async() => {
                    WriteLiteral("\r\n        <div class=\"card\">\r\n            <div class=\"card-header\">\r\n                <div class=\"pull-left\" style=\"font-weight:bold;font-size:medium\">Booking Detalis</div>\r\n            </div>\r\n");
                    WriteLiteral("\r\n            <table class=\"table\">\r\n                <thead>\r\n                    <tr>\r\n                        <th>\r\n                            ");
#nullable restore
#line 36 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
                       Write(Html.DisplayNameFor(model => model.EventName));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 39 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
                       Write(Html.DisplayNameFor(model => model.NumberOfDays));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 42 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
                       Write(Html.DisplayNameFor(model => model.EventDate));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 45 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
                       Write(Html.DisplayNameFor(model => model.Address));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 48 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
                       Write(Html.DisplayNameFor(model => model.NumberOfPerson));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 51 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
                       Write(Html.DisplayNameFor(model => model.VenuType));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 54 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
                       Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            Decorations Detalis\r\n                        </th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 62 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
                     foreach (var item in Model)
                    {
                        

#line default
#line hidden
#nullable disable
                    WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
#nullable restore
#line 67 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
                           Write(Html.DisplayFor(modelItem => item.EventName));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 70 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
                           Write(Html.DisplayFor(modelItem => item.NumberOfDays));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 73 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
                           Write(Html.DisplayFor(modelItem => item.EventDate));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 76 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Address));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 79 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
                           Write(Html.DisplayFor(modelItem => item.NumberOfPerson));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 82 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
                           Write(Html.DisplayFor(modelItem => item.VenuType));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n");
#nullable restore
#line 85 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
                                 if (item.Status == "Approved")
                                {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                    <button type=\"button\" class=\"btn btn-success\"");
                    BeginWriteAttribute("onclick", " onclick=\"", 3812, "\"", 3837, 3);
                    WriteAttributeValue("", 3822, "getId(", 3822, 6, true);
#nullable restore
#line 87 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
WriteAttributeValue("", 3828, item.Id, 3828, 8, false);

#line default
#line hidden
#nullable disable
                    WriteAttributeValue("", 3836, ")", 3836, 1, true);
                    EndWriteAttribute();
                    WriteLiteral(" data-target=\"#bookingStatus\" data-toggle=\"modal\"");
                    BeginWriteAttribute("value", " value=\"", 3887, "\"", 3907, 1);
#nullable restore
#line 87 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
WriteAttributeValue("", 3895, item.Status, 3895, 12, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(">");
#nullable restore
#line 87 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
                                                                                                                                                                             Write(item.Status);

#line default
#line hidden
#nullable disable
                    WriteLiteral("</button>\r\n");
#nullable restore
#line 88 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 89 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
                                 if (item.Status == "Rejected")
                                {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                    <button type=\"button\" class=\"btn btn-danger\"");
                    BeginWriteAttribute("onclick", " onclick=\"", 4147, "\"", 4172, 3);
                    WriteAttributeValue("", 4157, "getId(", 4157, 6, true);
#nullable restore
#line 91 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
WriteAttributeValue("", 4163, item.Id, 4163, 8, false);

#line default
#line hidden
#nullable disable
                    WriteAttributeValue("", 4171, ")", 4171, 1, true);
                    EndWriteAttribute();
                    WriteLiteral(" data-target=\"#bookingStatus\" data-toggle=\"modal\"");
                    BeginWriteAttribute("value", " value=\"", 4222, "\"", 4242, 1);
#nullable restore
#line 91 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
WriteAttributeValue("", 4230, item.Status, 4230, 12, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(">");
#nullable restore
#line 91 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
                                                                                                                                                                            Write(item.Status);

#line default
#line hidden
#nullable disable
                    WriteLiteral("</button>\r\n");
#nullable restore
#line 92 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 93 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
                                 if (item.Status == "Pendding")
                                {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                    <button type=\"button\" class=\"btn btn-warning\"");
                    BeginWriteAttribute("onclick", " onclick=\"", 4483, "\"", 4508, 3);
                    WriteAttributeValue("", 4493, "getId(", 4493, 6, true);
#nullable restore
#line 95 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
WriteAttributeValue("", 4499, item.Id, 4499, 8, false);

#line default
#line hidden
#nullable disable
                    WriteAttributeValue("", 4507, ")", 4507, 1, true);
                    EndWriteAttribute();
                    WriteLiteral(" data-target=\"#bookingStatus\" data-toggle=\"modal\"");
                    BeginWriteAttribute("value", " value=\"", 4558, "\"", 4578, 1);
#nullable restore
#line 95 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
WriteAttributeValue("", 4566, item.Status, 4566, 12, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(">");
#nullable restore
#line 95 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
                                                                                                                                                                             Write(item.Status);

#line default
#line hidden
#nullable disable
                    WriteLiteral("</button>\r\n");
#nullable restore
#line 96 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
                                }

#line default
#line hidden
#nullable disable
                    WriteLiteral("                            </td>\r\n                            <td>\r\n                                ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58d823fb32c24c262f6c9625314badf1a0df218e19681", async() => {
                        WriteLiteral("Show Decoration");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                    if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                    {
                        throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                    }
                    BeginWriteTagHelperAttribute();
#nullable restore
#line 99 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
                                                                       WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral(@"
                            </td>
                            <td>
                                <div class=""modal"" id=""bookingStatus"" tabindex=""-1"">
                                    <div class=""modal-dialog"">
                                        <div class=""modal-content"">
                                            <div class=""modal-header"">
                                                <h4 class=""modal-title"">Booking Status</h4>
                                                <button class=""close"" data-dismiss=""modal"">&times;</button>
                                            </div>
                                            <div class=""modal-body"">
                                                <div class=""form-group"">
                                                    <label class=""control-label"">Status</label>
                                                    <select class=""form-control"" name=""StatusId"" id=""status"">
                                                        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58d823fb32c24c262f6c9625314badf1a0df218e23209", async() => {
                        WriteLiteral("--Select Status--");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n");
#nullable restore
#line 114 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
                                                         foreach (var i in data)
                                                        {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                                            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58d823fb32c24c262f6c9625314badf1a0df218e24913", async() => {
                        WriteLiteral(" ");
#nullable restore
#line 116 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
                                                                              Write(i.Status);

#line default
#line hidden
#nullable disable
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    BeginWriteTagHelperAttribute();
#nullable restore
#line 116 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
                                                               WriteLiteral(i.Id);

#line default
#line hidden
#nullable disable
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                    __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n");
#nullable restore
#line 117 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
                                                        }

#line default
#line hidden
#nullable disable
                    WriteLiteral(@"                                                    </select>
                                                </div>
                                            </div>
                                            <div class=""modal-footer"">
                                                <input type=""button"" value=""Save"" class=""btn btn-primary"" onclick=""updateStatus()"" />
                                                <button class=""btn btn-danger"" data-dismiss=""modal"">Close</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
");
#nullable restore
#line 130 "C:\isha\EventBookingApp\EventBookingApp\Areas\Admin\Views\Admin\AllBookings.cshtml"
                    }

#line default
#line hidden
#nullable disable
                    WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
   
    <script>
        var bookinid = 0;
        function getId(id) {
            bookinid = id;
            console.log(bookinid);
        }
        function updateStatus() {
            if (bookinid != 0) {
                console.log(""From update:"" + bookinid);
                //var bookingid = document.getElementById(""booking"").value;
                var statusid = document.getElementById(""status"").value;
                //alert(userid + "" status "" + statusid);
                $.ajax({
                    url: ""/Admin/Admin/AllBookings"",
                    type: ""POST"",
                    data: { StatusId: statusid, Id: bookinid },
                    success: (response) => {
                        if (response == ""true"") {
                            window.location = ""/Admin/Admin/AllBookings"";
                        }
                        console.log(response);
                    }
                })
            }
        }
    </script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DataAcessLayer.ViewModel.BookingViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
