#pragma checksum "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\ScheduleInput.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "82290b62bf82e9864f362d8528bb778292cbb8d9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Determined_ScheduleInput), @"mvc.1.0.view", @"/Views/Determined/ScheduleInput.cshtml")]
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
#line 1 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\ScheduleInput.cshtml"
using SchedulingProblem.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82290b62bf82e9864f362d8528bb778292cbb8d9", @"/Views/Determined/ScheduleInput.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b71f1671594f310e474116b4a313fc4b267a6aba", @"/Views/_ViewImports.cshtml")]
    public class Views_Determined_ScheduleInput : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<OperationViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\ScheduleInput.cshtml"
  
    ViewData["Title"] = "ScheduleInput";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 8 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\ScheduleInput.cshtml"
 using (Html.BeginForm("ScheduleInput", "Determined", FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col\">\r\n           Deadline\r\n        </div>\r\n        <div class=\"col\">\r\n           Penalty\r\n        </div>\r\n    </div>\r\n    <div style=\"overflow-y:scroll; overflow-x:hidden; height:350px;\">\r\n");
#nullable restore
#line 19 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\ScheduleInput.cshtml"
         for (var i = 0; i < Model.Count(); i++)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"row\">\r\n                <div class=\"col\">\r\n                    ");
#nullable restore
#line 24 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\ScheduleInput.cshtml"
               Write(Html.TextBoxFor(x => Model[i].Deadline, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col\">\r\n                    ");
#nullable restore
#line 27 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\ScheduleInput.cshtml"
               Write(Html.TextBoxFor(x => Model[i].Penalty, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 30 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\ScheduleInput.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
            WriteLiteral("    <input type=\"submit\" value=\"Save\" class=\"btn btn-primary\" />\r\n");
#nullable restore
#line 36 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\ScheduleInput.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<OperationViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
