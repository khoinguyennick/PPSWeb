#pragma checksum "T:\cloud_prj\PorfilioWeb\PPSystem\Views\Project\Add.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eeb1b817c2c864dbc73b2df1c8a5e76ca3b39ecd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Project_Add), @"mvc.1.0.view", @"/Views/Project/Add.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Project/Add.cshtml", typeof(AspNetCore.Views_Project_Add))]
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
#line 1 "T:\cloud_prj\PorfilioWeb\PPSystem\Views\_ViewImports.cshtml"
using PPSystem;

#line default
#line hidden
#line 2 "T:\cloud_prj\PorfilioWeb\PPSystem\Views\_ViewImports.cshtml"
using PPSystem.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eeb1b817c2c864dbc73b2df1c8a5e76ca3b39ecd", @"/Views/Project/Add.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e89b489de0a6f712e4f7ab877fb2c90e741f4842", @"/Views/_ViewImports.cshtml")]
    public class Views_Project_Add : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 1236, true);
            WriteLiteral(@"<div class=""main-panel"">
    <div class=""content"">
        <div class=""page-inner"">
            <div class=""page-header"">
                <h4 class=""page-title"">PPSystem</h4>
                <ul class=""breadcrumbs"">
                    <li class=""nav-home"">
                        <a href=""#"">
                            <i class=""flaticon-home""></i>
                        </a>
                    </li>
                    <li class=""separator"">
                        <i class=""flaticon-right-arrow""></i>
                    </li>
                    <li class=""nav-item"">
                        <a href=""#"">Project</a>
                    </li>
                    <li class=""separator"">
                        <i class=""flaticon-right-arrow""></i>
                    </li>
                    <li class=""nav-item"">
                        <a href=""#"">Add Project</a>
                    </li>
                </ul>
            </div>
            <div class=""row"">
                <div cl");
            WriteLiteral("ass=\"col-md-12\">\r\n                    <div class=\"card\">\r\n                        <div class=\"card-header\">\r\n                            <div class=\"card-title\">Add Project</div>\r\n                        </div>\r\n");
            EndContext();
#line 32 "T:\cloud_prj\PorfilioWeb\PPSystem\Views\Project\Add.cshtml"
                         using (Html.BeginForm("AddProject", "Project", FormMethod.Post))
                        {

#line default
#line hidden
            BeginContext(1354, 49, true);
            WriteLiteral("                            <p style=\"color:red\">");
            EndContext();
            BeginContext(1404, 15, false);
#line 34 "T:\cloud_prj\PorfilioWeb\PPSystem\Views\Project\Add.cshtml"
                                            Write(ViewBag.message);

#line default
#line hidden
            EndContext();
            BeginContext(1419, 1915, true);
            WriteLiteral(@"</p>
                            <div class=""card-body"">
                                <div class=""row"">
                                    <div class=""col-md-6 col-lg-4"">
                                        <div class=""form-group"">
                                            <label for=""email2"">Project Id</label>
                                            <input type=""text"" class=""form-control"" id=""projectId"" name=""projectId"" placeholder=""Project ID"">
                                        </div>
                                        <div class=""form-group"">
                                            <label for=""email2"">Project Name</label>
                                            <input type=""text"" class=""form-control"" id=""description"" name=""description"" placeholder=""Project Name"">
                                        </div>
                                        <div class=""form-group"">
                                            <label for=""email2"">Start Date</label>
     ");
            WriteLiteral(@"                                       <input type=""date"" class=""form-control"" id=""startDate"" name=""startDate"" placeholder=""Start Date"">
                                        </div>
                                        <div class=""form-group"">
                                            <label for=""email2"">End Date</label>
                                            <input type=""date"" class=""form-control"" id=""endDate"" name=""endDate"" placeholder=""End Date"">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class=""card-action"">
                                <button class=""btn btn-success"">Submit</button>
                                <button class=""btn btn-danger"">Cancel</button>
                            </div>
");
            EndContext();
#line 61 "T:\cloud_prj\PorfilioWeb\PPSystem\Views\Project\Add.cshtml"
                        }

#line default
#line hidden
            BeginContext(3361, 1118, true);
            WriteLiteral(@"                    </div>
                </div>
            </div>
        </div>
    </div>
    <footer class=""footer"">
        <div class=""container-fluid"">
            <nav class=""pull-left"">
                <ul class=""nav"">
                    <li class=""nav-item"">
                        <a class=""nav-link"" href=""https://www.themekita.com"">
                            ThemeKita
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link"" href=""#"">
                            Help
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link"" href=""#"">
                            Licenses
                        </a>
                    </li>
                </ul>
            </nav>
            <div class=""copyright ml-auto"">
                2018, made with <i class=""fa fa-heart heart text-danger""></i> by <a href=""https:/");
            WriteLiteral("/www.themekita.com\">ThemeKita</a>\r\n            </div>\r\n        </div>\r\n    </footer>\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
