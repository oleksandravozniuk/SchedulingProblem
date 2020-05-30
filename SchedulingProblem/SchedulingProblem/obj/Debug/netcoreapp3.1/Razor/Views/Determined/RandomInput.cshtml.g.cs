#pragma checksum "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\RandomInput.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5833c49bf07ad456787532ae9beed3b611944d7f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Determined_RandomInput), @"mvc.1.0.view", @"/Views/Determined/RandomInput.cshtml")]
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
#line 1 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\RandomInput.cshtml"
using SchedulingProblem.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5833c49bf07ad456787532ae9beed3b611944d7f", @"/Views/Determined/RandomInput.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b71f1671594f310e474116b4a313fc4b267a6aba", @"/Views/_ViewImports.cshtml")]
    public class Views_Determined_RandomInput : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RandomInputViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-myMethod", "Update", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", new global::Microsoft.AspNetCore.Html.HtmlString("Update"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\RandomInput.cshtml"
  
    ViewData["Title"] = "RandomInput";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div style=\"width:100%;padding: 30px;\">\r\n    <div style=\"width:50%; height:600px;float: left ; padding: 50px; background-color: #BCC6CC; display: inline-block;border-radius:10px;\">\r\n        <h3>Random Input</h3>\r\n        <br />\r\n\r\n");
#nullable restore
#line 12 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\RandomInput.cshtml"
         using (Html.BeginForm())
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h6>Input the number of elements</h6>\r\n");
#nullable restore
#line 15 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\RandomInput.cshtml"
       Write(Html.TextBoxFor(m => m.NumberOfElements));

#line default
#line hidden
#nullable disable
            WriteLiteral("            <br />\r\n            <br />\r\n");
            WriteLiteral("            <h5>Input the bounds of random for penalties</h5>\r\n            <h6>From</h6>\r\n");
#nullable restore
#line 21 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\RandomInput.cshtml"
       Write(Html.TextBoxFor(m => m.PenaltyFrom));

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h6>To</h6>\r\n");
#nullable restore
#line 23 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\RandomInput.cshtml"
       Write(Html.TextBoxFor(m => m.PenaltyTo));

#line default
#line hidden
#nullable disable
            WriteLiteral("            <br />\r\n            <br />\r\n");
            WriteLiteral("            <h5>Input the bounds of random for deadlines</h5>\r\n            <h6>From</h6>\r\n");
#nullable restore
#line 30 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\RandomInput.cshtml"
       Write(Html.TextBoxFor(m => m.DeadlineFrom));

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h6>To</h6>\r\n");
#nullable restore
#line 32 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\RandomInput.cshtml"
       Write(Html.TextBoxFor(m => m.DeadlineTo));

#line default
#line hidden
#nullable disable
            WriteLiteral("            <br />\r\n            <br />\r\n");
#nullable restore
#line 36 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\RandomInput.cshtml"
       Write(Html.HiddenFor(m => m.NumberOfPenalties));

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\RandomInput.cshtml"
                                                     ;


#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5833c49bf07ad456787532ae9beed3b611944d7f7471", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-myMethod", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["myMethod"] = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            <br />\r\n");
#nullable restore
#line 40 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\RandomInput.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>

    <div style=""width:50%;padding: 50px; float: right; display: inline-block; height: 600px;background-color: #E5E4E2;border-radius: 10px;"">
        <h3>Random Output</h3>
        <br />
       
        <div style=""overflow-y:scroll; overflow-x:hidden; height:440px; "">
            ");
#nullable restore
#line 48 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\RandomInput.cshtml"
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
#line 93 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\RandomInput.cshtml"
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
#line 102 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\RandomInput.cshtml"
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
#line 115 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\RandomInput.cshtml"
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
#line 124 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\RandomInput.cshtml"
           Write(await Html.PartialAsync("~/Views/AlgoOutputs/ScheduleOutput.cshtml", Model.AlgoGenerator.MakeAlgo4(Model.Schedule[0])));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
        </div>

    </div>
</div>

<div class=""container"">
    <br />
    <br />
    <hr />
    <h2 style=""padding:10px;text-align:center"">Best Schedules</h2>
    <hr />
    <br />

    <div class=""row"">
        <div class=""col-sm"">
            <br />
            <div style=""overflow-y:auto; overflow-x:auto; height:440px;width:460px;display: flex;justify-content: space-between;"">
");
#nullable restore
#line 143 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\RandomInput.cshtml"
                 if (Model.Schedule[0].operations.Count != 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div>\r\n                        ");
#nullable restore
#line 146 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\RandomInput.cshtml"
                   Write(await Html.PartialAsync("~/Views/Determined/Answer.cshtml", Model.AlgoGenerator.BestSchedulesDetermined(Model.Schedule[0])));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 148 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Determined\RandomInput.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                <br />\r\n\r\n            </div>\r\n\r\n        </div>\r\n\r\n    </div>\r\n</div>");
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
