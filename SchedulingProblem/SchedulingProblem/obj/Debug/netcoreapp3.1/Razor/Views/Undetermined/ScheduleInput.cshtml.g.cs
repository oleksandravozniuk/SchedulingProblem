#pragma checksum "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Undetermined\ScheduleInput.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8cc9f4522f76799dadd3c286341e6066c7cdeaed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Undetermined_ScheduleInput), @"mvc.1.0.view", @"/Views/Undetermined/ScheduleInput.cshtml")]
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
#line 1 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Undetermined\ScheduleInput.cshtml"
using SchedulingProblem.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8cc9f4522f76799dadd3c286341e6066c7cdeaed", @"/Views/Undetermined/ScheduleInput.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b71f1671594f310e474116b4a313fc4b267a6aba", @"/Views/_ViewImports.cshtml")]
    public class Views_Undetermined_ScheduleInput : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ManualInputViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Undetermined\ScheduleInput.cshtml"
  
    ViewData["Title"] = "ScheduleInput";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 8 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Undetermined\ScheduleInput.cshtml"
 using (Html.BeginForm("ScheduleInput", "Undetermined", FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col\">\r\n            Deadline\r\n        </div>\r\n        <div class=\"col\">\r\n            Penalty\r\n        </div>\r\n    </div>\r\n    <div style=\"overflow-y:auto; overflow-x:auto; height:350px;\">\r\n\r\n\r\n");
#nullable restore
#line 21 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Undetermined\ScheduleInput.cshtml"
         for (int i = 0, k = 0; i < Model.NumberOfElements; i++)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"row\">\r\n");
#nullable restore
#line 25 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Undetermined\ScheduleInput.cshtml"
                 for (int j = 0; j < Model.NumberOfPenalties + 1; j++, k++)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col\">\r\n                        ");
#nullable restore
#line 28 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Undetermined\ScheduleInput.cshtml"
                   Write(Html.TextBoxFor(x => Model.manualList[k], new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 30 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Undetermined\ScheduleInput.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n");
#nullable restore
#line 32 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Undetermined\ScheduleInput.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
#nullable restore
#line 34 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Undetermined\ScheduleInput.cshtml"
   Write(Html.HiddenFor(m => m.manualList, new { @class="form-control"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n\r\n        ");
#nullable restore
#line 36 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Undetermined\ScheduleInput.cshtml"
   Write(Html.HiddenFor(m => m.NumberOfElements));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n\r\n        ");
#nullable restore
#line 38 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Undetermined\ScheduleInput.cshtml"
   Write(Html.HiddenFor(m => m.NumberOfPenalties));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n\r\n    </div>\r\n");
            WriteLiteral("    <input type=\"submit\" value=\"Save\" class=\"btn btn-primary\" />\r\n");
#nullable restore
#line 44 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Undetermined\ScheduleInput.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ManualInputViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
