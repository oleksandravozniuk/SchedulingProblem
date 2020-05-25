#pragma checksum "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\ManualInput.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3cdfe47119ad9453347c0b71f63a348bc663a509"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Determined_ManualInput), @"mvc.1.0.view", @"/Views/Determined/ManualInput.cshtml")]
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
#line 3 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\ManualInput.cshtml"
using SchedulingProblem.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3cdfe47119ad9453347c0b71f63a348bc663a509", @"/Views/Determined/ManualInput.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b71f1671594f310e474116b4a313fc4b267a6aba", @"/Views/_ViewImports.cshtml")]
    public class Views_Determined_ManualInput : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ManualInputViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 5 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\ManualInput.cshtml"
  
    ViewData["Title"] = "ManualInput";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<div style=""width:100%;padding: 30px;"">
    <div style=""width:50%; height:600px;float: left ; padding: 50px; background-color: #BCC6CC; display: inline-block;border-radius:10px;"">
        <h3>Manual Input</h3>
        <br />

        Number of elements: ");
#nullable restore
#line 16 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\ManualInput.cshtml"
                       Write(Model.Schedule[0].operations.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        ");
#nullable restore
#line 18 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\ManualInput.cshtml"
   Write(await Html.PartialAsync("~/Views/Determined/ScheduleInput.cshtml", Model.Schedule[0].operations));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"







    </div>

    <div style=""width:50%;padding: 50px; float: right; display: inline-block; height: 600px;background-color: #E5E4E2;border-radius: 10px;"">
        <h3>Manual Output</h3>
        <br />
       
        <div style=""overflow-y:scroll; overflow-x:hidden; height:440px; "">
            ");
#nullable restore
#line 33 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\ManualInput.cshtml"
       Write(await Html.PartialAsync("~/Views/AlgoOutputs/ScheduleOutput.cshtml", Model.Schedule[0]));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </div>

    </div>


</div>
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />

<div class=""container"">
    <br />
    <br />
    <hr />
    <h2 style=""padding:10px;text-align:center"">Solutions</h2>
    <hr />
    <br />

    <div class=""row"">
        <div class=""col-sm"">
            <h3>Algorithm 1</h3>
            <p>Упорядкувати роботи по незростанню штрафів</p>
            <br />
           
            <div style=""overflow-y:scroll; overflow-x:hidden; height:440px; "">
                ");
#nullable restore
#line 78 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\ManualInput.cshtml"
           Write(await Html.PartialAsync("~/Views/AlgoOutputs/ScheduleOutput.cshtml", Model.AlgoGenerator.MakeAlgo1(Model.Schedule[0])));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
        </div>
        <div class=""col-sm"">
            <h3>Algorithm 2</h3>
            <p>Упорядкувати роботи по неспаданню директивних строків</p>
            <br />
           
            <div style=""overflow-y:scroll; overflow-x:hidden; height:440px; "">
                ");
#nullable restore
#line 87 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\ManualInput.cshtml"
           Write(await Html.PartialAsync("~/Views/AlgoOutputs/ScheduleOutput.cshtml", Model.AlgoGenerator.MakeAlgo2(Model.Schedule[0])));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
        </div>
    </div>
    <br />
    <br />
    <div class=""row"">
        <div class=""col-sm"">
            <h3>Algorithm 3</h3>
            <p>Упорядкувати роботи по принципу: спочатку обираємо ті роботи, директивний строк яких на наступному кроці завершується, інакше упорядковуємо роботи по незростанню штрафів</p>
            <br />
           
            <div style=""overflow-y:scroll; overflow-x:hidden; height:440px; "">
                ");
#nullable restore
#line 100 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\ManualInput.cshtml"
           Write(await Html.PartialAsync("~/Views/AlgoOutputs/ScheduleOutput.cshtml", Model.AlgoGenerator.MakeAlgo3(Model.Schedule[0])));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
        </div>
        <div class=""col-sm"">
            <h3>Algorithm 4</h3>
            <p>Упорядкувати роботи по незростанню відношень штрафів до дедлайнів</p>
            <br />
           
            <div style=""overflow-y:scroll; overflow-x:hidden; height:440px; "">
                ");
#nullable restore
#line 109 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\ManualInput.cshtml"
           Write(await Html.PartialAsync("~/Views/AlgoOutputs/ScheduleOutput.cshtml", Model.AlgoGenerator.MakeAlgo4(Model.Schedule[0])));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n    </div>\r\n</div>\r\n\r\n");
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
