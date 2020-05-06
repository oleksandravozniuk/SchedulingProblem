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
        private readonly ILogger<DeterminedController> _logger;

        public DeterminedController(ILogger<DeterminedController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Determined()
        {
            ConfigurationViewModel company = new ConfigurationViewModel();
            return View(company);
        }

        [HttpPost]
        public IActionResult Determined(ConfigurationViewModel configuration)
        {
            if (string.IsNullOrEmpty(configuration.SelectedInputType))
            {
                return RedirectToAction("Error");
            }
            else
            {
                var k = configuration.SelectedInputType;
                switch (k)
                {
                    case "Random": return RedirectToAction("RandomInput", new RandomInputViewModel());
                    case "Manually": return RedirectToAction("RandomInput");
                    case "FromFile": return RedirectToAction("RandomInput");
                }
                return RedirectToAction("Error");
                // return "You have chosen to input data" + configuration.SelectedInputType;
            }
        }


        [HttpGet]
        public IActionResult RandomOutput(RandomInputViewModel randomInputView)
        {
            return PartialView("RandomOutput", randomInputView);
        }

        [HttpGet]
        public IActionResult RandomAlgo1(RandomInputViewModel randomInputView)
        {
            return PartialView("RandomAlgo1", randomInputView);
        }


        [HttpGet]
        public IActionResult RandomAlgo2(RandomInputViewModel randomInputView)
        {
            return PartialView("RandomAlgo2", randomInputView);
        }


        [HttpGet]
        public IActionResult RandomAlgo3(RandomInputViewModel randomInputView)
        {
            return PartialView("RandomAlgo3", randomInputView);
        }

        [HttpGet]
        public IActionResult RandomInput(RandomInputViewModel randomInputView)
        {
            return View("RandomInput", randomInputView);
        }

        [HttpPost]
        public IActionResult RandomInput(RandomInputViewModel configuration, [FromQuery] string myMethod = null)
        {
            //if (configuration.NumberOfElements==0 || configuration.NumberOfElements*(-1) == configuration.NumberOfElements)
            //{
            //    return RedirectToAction("Error");
            //}
            //else
            //{
            if (myMethod == "Update")
                return View("RandomInput", configuration);
            else
                return PartialView("RandomOutput",configuration);
                // return "You have chosen to input data" + configuration.SelectedInputType;
            //}
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
