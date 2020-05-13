using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchedulingProblem.Models;

namespace SchedulingProblem.Controllers
{
    public class DeterminedController : Controller
    {


        public DeterminedController()
        {

        }

      


        [HttpGet]
        public IActionResult ScheduleOutput(ScheduleViewModel schedule)
        {
            return PartialView("RandomAlgo", schedule);
        }


       

        public IActionResult Undetermined()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
