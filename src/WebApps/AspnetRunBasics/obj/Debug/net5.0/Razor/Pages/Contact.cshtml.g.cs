#pragma checksum "C:\Users\majaham\source\repos\AspnetMicroservices\src\WebApps\AspnetRunBasics\Pages\Contact.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c7b86f50b3512a7628296e14ff287002ee6f5bc6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspnetRunBasics.Pages.Pages_Contact), @"mvc.1.0.razor-page", @"/Pages/Contact.cshtml")]
namespace AspnetRunBasics.Pages
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
#line 1 "C:\Users\majaham\source\repos\AspnetMicroservices\src\WebApps\AspnetRunBasics\Pages\_ViewImports.cshtml"
using AspnetRunBasics;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\majaham\source\repos\AspnetMicroservices\src\WebApps\AspnetRunBasics\Pages\_ViewImports.cshtml"
using AspnetRunBasics.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7b86f50b3512a7628296e14ff287002ee6f5bc6", @"/Pages/Contact.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24e7173edc2935479c2083bac8eedf6c2cbc617d", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Contact : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\majaham\source\repos\AspnetMicroservices\src\WebApps\AspnetRunBasics\Pages\Contact.cshtml"
  
    ViewData["Title"] = "Contact";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""jumbotron text-center"">
    <div class=""container"">
        <h1 class=""jumbotron-heading"">E-COMMERCE CONTACT</h1>
        <p class=""lead text-muted mb-0"">Contact Page build with Bootstrap 4 !</p>
    </div>
</section>
<div class=""container"">
    <div class=""row"">
        <div class=""col"">
            <nav aria-label=""breadcrumb"">
                <ol class=""breadcrumb"">
                    <li class=""breadcrumb-item""><a href=""index.html"">Home</a></li>
                    <li class=""breadcrumb-item active"" aria-current=""page"">Contact</li>
                </ol>
            </nav>
        </div>
    </div>
</div>
<div class=""container"">
    <div class=""row"">
        <div class=""col"">
            <div class=""card"">
                <div class=""card-header bg-primary text-white"">
                    <i class=""fa fa-envelope""></i> Contact us.
                </div>
                <div class=""card-body"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c7b86f50b3512a7628296e14ff287002ee6f5bc64500", async() => {
                WriteLiteral(@"
                        <div class=""form-group"">
                            <label for=""name"">Name</label>
                            <input type=""text"" class=""form-control"" id=""name"" aria-describedby=""emailHelp"" placeholder=""Enter name"" required>
                        </div>
                        <div class=""form-group"">
                            <label for=""email"">Email address</label>
                            <input type=""email"" class=""form-control"" id=""email"" aria-describedby=""emailHelp"" placeholder=""Enter email"" required>
                            <small id=""emailHelp"" class=""form-text text-muted"">We'll never share your email with anyone else.</small>
                        </div>
                        <div class=""form-group"">
                            <label for=""message"">Message</label>
                            <textarea class=""form-control"" id=""message"" rows=""6"" required></textarea>
                        </div>
                        <div class=""mx-auto"">
                     ");
                WriteLiteral("       <button type=\"submit\" class=\"btn btn-primary text-right\">Submit</button>\n                        </div>\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
            </div>
        </div>
        <div class=""col-12 col-sm-4"">
            <div class=""card bg-light mb-3"">
                <div class=""card-header bg-success text-white text-uppercase""><i class=""fa fa-home""></i> Address</div>
                <div class=""card-body"">
                    <p>3 rue des Champs Elysées</p>
                    <p>75008 PARIS</p>
                    <p>France</p>
                    <p>Email : email@example.com</p>
                    <p>Tel. +33 12 56 11 51 84</p>

                </div>

            </div>
        </div>
    </div>
</div>


");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AspnetRunBasics.ContactModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AspnetRunBasics.ContactModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AspnetRunBasics.ContactModel>)PageContext?.ViewData;
        public AspnetRunBasics.ContactModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
