#pragma checksum "B:\documents\prog\c#\web\SmartCourses\SmartCourses\SmartCourses\SmartCourses\SmartCourses\Views\Course\Books.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "72e9495561acf47184f76fe2a7a219ee52664f88"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Course_Books), @"mvc.1.0.view", @"/Views/Course/Books.cshtml")]
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
#line 1 "B:\documents\prog\c#\web\SmartCourses\SmartCourses\SmartCourses\SmartCourses\SmartCourses\Views\_ViewImports.cshtml"
using SmartCourses;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "B:\documents\prog\c#\web\SmartCourses\SmartCourses\SmartCourses\SmartCourses\SmartCourses\Views\_ViewImports.cshtml"
using SmartCourses.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"72e9495561acf47184f76fe2a7a219ee52664f88", @"/Views/Course/Books.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7c510046b6c4a825f1ba80e3575710922734ef6", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Course_Books : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Core.Entity.Course>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "B:\documents\prog\c#\web\SmartCourses\SmartCourses\SmartCourses\SmartCourses\SmartCourses\Views\Course\Books.cshtml"
Write(Html.EditorFor(model => model.Books));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Core.Entity.Course> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
