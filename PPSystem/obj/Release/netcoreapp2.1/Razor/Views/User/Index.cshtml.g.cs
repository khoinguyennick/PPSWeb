#pragma checksum "T:\cloud_prj\PorfilioWeb\PPSystem\Views\User\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4a0cb4c1336149c892c817f57c428eb2bbdcd8f1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Index), @"mvc.1.0.view", @"/Views/User/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/User/Index.cshtml", typeof(AspNetCore.Views_User_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a0cb4c1336149c892c817f57c428eb2bbdcd8f1", @"/Views/User/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e89b489de0a6f712e4f7ab877fb2c90e741f4842", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 1992, true);
            WriteLiteral(@"<style>
    #Upload .wrapperr {
        position: relative;
        top: 0;
        margin: auto;
        max-width: 640px;
        padding-top: 60px;
        text-align: center;
    }

    #Upload .container {
        background-color: #f9f9f9;
        padding: 20px;
        border-radius: 10px;
        /*border: 0.5px solid rgba(130, 130, 130, 0.25);*/
        /*box-shadow: 0 2px 3px rgba(0, 0, 0, 0.1),
              0 0 0 1px rgba(0, 0, 0, 0.1);*/
    }

    #Upload h1 {
        color: #130f40;
        font-family: 'Varela Round', sans-serif;
        letter-spacing: -.5px;
        font-weight: 700;
        padding-bottom: 10px;
    }

    #Upload .upload-container {
        background-color: rgb(239, 239, 239);
        border-radius: 6px;
        padding: 10px;
    }

    #Upload .border-container {
        border: 5px dashed rgba(198, 198, 198, 0.65);
        border-radius: 6px;
        padding: 20px;
    }

        #Upload .border-container p {
            color: #");
            WriteLiteral(@"130f40;
            font-weight: 600;
            font-size: 1.1em;
            letter-spacing: -1px;
            margin-top: 30px;
            margin-bottom: 0;
            opacity: 0.65;
        }

    #file-browser {
        text-decoration: none;
        color: rgb(22,42,255);
        border-bottom: 3px dotted rgba(22, 22, 255, 0.85);
    }

        #file-browser:hover {
            color: rgb(0, 0, 255);
            border-bottom: 3px dotted rgba(0, 0, 255, 0.85);
        }

    #Upload .icons {
        color: #95afc0;
        opacity: 0.55;
    }
</style>

<div class=""content"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-md-9"">
                <div class=""card"">
                    <div class=""header"">
                        <h4 class=""title"">Edit Profile</h4>
                    </div>
                    <div class=""content"" style=""margin-left:250px;margin-top:50px"">
");
            EndContext();
#line 76 "T:\cloud_prj\PorfilioWeb\PPSystem\Views\User\Index.cshtml"
                         using (Html.BeginForm("EditProfile", "User", FormMethod.Post))
                        {

#line default
#line hidden
            BeginContext(2108, 346, true);
            WriteLiteral(@"                            <div class=""row"">
                                <div class=""col-md-5"">
                                    <div class=""form-group"">
                                        <label>Email (disabled)</label>
                                        <input type=""text"" class=""form-control"" disabled placeholder=""Email""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2454, "\"", 2481, 1);
#line 82 "T:\cloud_prj\PorfilioWeb\PPSystem\Views\User\Index.cshtml"
WriteAttributeValue("", 2462, ViewBag.User.Email, 2462, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2482, 404, true);
            WriteLiteral(@">
                                    </div>
                                </div>
                                <div class=""col-md-4"">
                                    <div class=""form-group"">
                                        <label>Phone Number</label>
                                        <input name=""phone"" id=""phone"" type=""text"" class=""form-control"" placeholder=""Phone Number""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2886, "\"", 2919, 1);
#line 88 "T:\cloud_prj\PorfilioWeb\PPSystem\Views\User\Index.cshtml"
WriteAttributeValue("", 2894, ViewBag.User.PhoneNumber, 2894, 25, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2920, 486, true);
            WriteLiteral(@">
                                    </div>
                                </div>
                            </div>
                            <div class=""row"">
                                <div class=""col-md-6"">
                                    <div class=""form-group"">
                                        <label>Full Name</label>
                                        <input name=""fullname"" id=""fullname"" type=""text"" class=""form-control"" placeholder=""FullName""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 3406, "\"", 3436, 1);
#line 96 "T:\cloud_prj\PorfilioWeb\PPSystem\Views\User\Index.cshtml"
WriteAttributeValue("", 3414, ViewBag.User.FullName, 3414, 22, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3437, 487, true);
            WriteLiteral(@">
                                    </div>
                                </div>
                            </div>
                            <div class=""row"">
                                <div class=""col-md-12"">
                                    <div class=""form-group"">
                                        <label>Address</label>
                                        <input name=""address"" id=""address"" type=""text"" class=""form-control"" placeholder=""Home Address""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 3924, "\"", 3953, 1);
#line 104 "T:\cloud_prj\PorfilioWeb\PPSystem\Views\User\Index.cshtml"
WriteAttributeValue("", 3932, ViewBag.User.Address, 3932, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3954, 297, true);
            WriteLiteral(@">
                                    </div>
                                </div>
                            </div>
                            <button type=""submit"" class=""btn btn-info btn-fill pull-right"">Update Profile</button>
                            <div class=""clearfix""></div>
");
            EndContext();
#line 110 "T:\cloud_prj\PorfilioWeb\PPSystem\Views\User\Index.cshtml"
                        }

#line default
#line hidden
            BeginContext(4278, 380, true);
            WriteLiteral(@"                    </div>
                </div>
            </div>
            <div class=""col-md-3"">
                <div class=""card card-user"">
                    <div class=""image"" style=""margin-top:70px;display: block;margin-left: auto;margin-right: auto;"">
                        <img id=""UserImage"" class=""fa-align-center"" style=""max-height:250px;max-width:250px""");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 4658, "\"", 4684, 1);
#line 117 "T:\cloud_prj\PorfilioWeb\PPSystem\Views\User\Index.cshtml"
WriteAttributeValue("", 4664, ViewBag.User.Avatar, 4664, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4685, 3102, true);
            WriteLiteral(@" alt=""User Image"" />
                    </div>
                    <hr>
                    <div id=""Upload"" class=""wrapperr"">
                        <div class=""container"">
                            <h1>Upload Avatar</h1>
                            <div class=""upload-container"">
                                <div class=""border-container"">
                                    <div class=""icons fa-4x"">
                                        <i class=""fas fa-file-image"" data-fa-transform=""shrink-3 down-2 left-6 rotate--45""></i>
                                        <i class=""fas fa-file-alt"" data-fa-transform=""shrink-2 up-4""></i>
                                        <i class=""fas fa-file-pdf"" data-fa-transform=""shrink-3 down-2 right-6 rotate-45""></i>
                                    </div>
                                    <input type=""file"" class=""upload"" id=""pictures"" accept=""image/*"" multiple name=""pictures"" style=""opacity:0"" onchange=""uploadFile('pictures');"">
                ");
            WriteLiteral(@"                    <p>
                                        Drag and drop files here, or
                                        <a href=""#"" id=""file-browser"">
                                            browse
                                        </a> your computer.

                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr>
                    <div style=""display: block;margin-left: auto;margin-right: auto;"">
                        <input type=""button"" class=""btn btn-info btn-fill"" height=""50"" width=""50"" id=""file-submit"" name=""file-sumbit"" value=""Upload"" />
                    </div>
                </div>
             
            </div>
        </div>
    </div>
</div>
<script>
    $(document).ready(function () {
        $(""#pictures"").css(""opacity"", ""0"");
        $(""#file-browser"").click(function (e) {
            e.preventDefault();
");
            WriteLiteral(@"            $(""#pictures"").trigger(""click"");
        });

        document.getElementById('pictures').onchange = function (evt) {
            var tgt = evt.target || window.event.srcElement,
                files = tgt.files;

            // FileReader support
            if (FileReader && files && files.length) {
                var fr = new FileReader();
                fr.onload = function () {
                    document.getElementById(""UserImage"").src = fr.result;
                }
                fr.readAsDataURL(files[0]);
            }

        };
    });
        $(function () {
        $('#file-submit').click(function () {
            var formData = new FormData();
            var pictures = $('#pictures')[0];
            formData.append(""pictures"", pictures.files[0]);

            $.ajax({
                url: 'https://projectporfoliosystem20200630144446.azurewebsites.net/api/Account/Image',
                beforeSend: function (xhr) {
                    xhr.setRequestHe");
            WriteLiteral("ader(\'Authorization\', \'Bearer ");
            EndContext();
            BeginContext(7788, 17, false);
#line 184 "T:\cloud_prj\PorfilioWeb\PPSystem\Views\User\Index.cshtml"
                                                             Write(ViewBag.UserToken);

#line default
#line hidden
            EndContext();
            BeginContext(7805, 338, true);
            WriteLiteral(@"');
                },
                type: 'PUT',
                data: formData,
                cache: false,
                contentType: false,
                processData: false,
                success: function (msg) {
                   location.reload();
            }
            });
        });
    });
</script>");
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
