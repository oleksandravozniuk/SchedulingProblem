#pragma checksum "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\RandomAlgo3.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "183b7083557427915b5479a805601135ee84d536"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Determined_RandomAlgo3), @"mvc.1.0.view", @"/Views/Determined/RandomAlgo3.cshtml")]
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
#line 1 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\_ViewImports.cshtml"
using SchedulingProblem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\RandomAlgo3.cshtml"
using SchedulingProblem.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"183b7083557427915b5479a805601135ee84d536", @"/Views/Determined/RandomAlgo3.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b71f1671594f310e474116b4a313fc4b267a6aba", @"/Views/_ViewImports.cshtml")]
    public class Views_Determined_RandomAlgo3 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RandomInputViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<br />\r\n<table class=\"table\">\r\n    <div>\r\n");
#nullable restore
#line 8 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\RandomAlgo3.cshtml"
         foreach (var operation in Model.Algo3.operations)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td><p>");
#nullable restore
#line 11 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\RandomAlgo3.cshtml"
                  Write(operation.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p></td>\r\n                <td><p>");
#nullable restore
#line 12 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\RandomAlgo3.cshtml"
                  Write(operation.Deadline);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p></td>\r\n                <td><p>");
#nullable restore
#line 13 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\RandomAlgo3.cshtml"
                  Write(operation.Penalty);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p></td>\r\n            </tr>\r\n");
#nullable restore
#line 15 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\RandomAlgo3.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RandomInputViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
