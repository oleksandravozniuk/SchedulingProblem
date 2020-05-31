#pragma checksum "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Statistics\Time.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1df1e8c778bfc8a12ecd0b45f20278d09986ee0e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Statistics_Time), @"mvc.1.0.view", @"/Views/Statistics/Time.cshtml")]
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
#line 2 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\_ViewImports.cshtml"
using SchedulingProblem.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1df1e8c778bfc8a12ecd0b45f20278d09986ee0e", @"/Views/Statistics/Time.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b71f1671594f310e474116b4a313fc4b267a6aba", @"/Views/_ViewImports.cshtml")]
    public class Views_Statistics_Time : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<script type=""text/javascript"" src=""https://www.gstatic.com/charts/loader.js""></script>
<div id=""chart2_div""></div>
<script type=""text/javascript"">


    google.charts.load('current', {
        packages: ['corechart', 'bar']
    });
    google.charts.setOnLoadCallback(LoadData);

    function LoadData() {
        $.ajax({

            url: '");
#nullable restore
#line 14 "C:\Users\Oleksandra\Desktop\SchedulingProblem\SchedulingProblem\SchedulingProblem\Views\Statistics\Time.cshtml"
             Write(Url.Action("Time","Statistics"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
            dataType: ""json"",
            type: ""GET"",
            error: function(xhr, status, error) {
                var err = eval(""("" + xhr.responseText + "")"");
                toastr.error(err.message);
            },
            success: function(data) {
                PopulationChart2(data);
                return false;
            }
        });
        return false;
    }

    function PopulationChart2(data) {
        var dataArray = [
            ['Step', 'Algo1', 'Algo2', 'Algo3', 'Algo4']
        ];
        $.each(data, function(i, item) {
            dataArray.push([item.step, item.algo1, item.algo2, item.algo3, item.algo4]);
        });
        var data = google.visualization.arrayToDataTable(dataArray);
        var options = {
            title: 'Ratio of number of works to time of execution',
            chartArea: {
                width: '50%'
            },
            colors: ['#b0120a', '#7b1fa2', '#ffab91', '#d95f02'],
            hAxis: {
            ");
            WriteLiteral(@"    title: 'Number of works',
                minValue: 0
            },
            vAxis: {
                title: 'Time Execution (ms)'
            }
        };
        var chart = new google.visualization.LineChart(document.getElementById('chart2_div'));

        chart.draw(data, options);
        return false;
    }
</script>

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
