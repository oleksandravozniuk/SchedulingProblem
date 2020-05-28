using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchedulingProblem.Models;

namespace SchedulingProblem.Controllers
{
    public class DeterminedController : Controller
    {
        private IWebHostEnvironment Environment;

        public DeterminedController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }

        [HttpGet]
        public IActionResult DataReaderConfig()
        {
            ConfigurationViewModel con = new ConfigurationViewModel();
            return View(con);
        }

        [HttpPost]
        public IActionResult DataReaderConfig(ConfigurationViewModel configuration)
        {
            if (string.IsNullOrEmpty(configuration.SelectedInputType))
            {
                return View("Error", "You have selected nothing" );
            }
            else
            {
                var randomView = new RandomInputViewModel();
                var fileView = new FileInputViewModel();

                var k = configuration.SelectedInputType;
                switch (k)
                {
                    case "Random": return RedirectToAction("RandomInput", randomView);
                    case "Manually": return RedirectToAction("NumInput", fileView);
                    case "FromFile": return RedirectToAction("FileInput", fileView);
                    default:
                        break;
                }
                return RedirectToAction("Error");

            }
        }

        [HttpGet]
        [Produces("application/json")]
        // [Route("api/RandomInput")]
        public IActionResult RandomInput(RandomInputViewModel randomInputView)
        {
            randomInputView.Schedule.Add(new ScheduleViewModel());
            //return Ok(randomInputView);
            return View("RandomInput", randomInputView);
        }

        [HttpPost]
        // [HttpPost("FromBody")]
        [Produces("application/json")]
        // [Route("api/RandomInput")]
        public IActionResult RandomInput(RandomInputViewModel configuration, [FromQuery] string myMethod = null)
        {
            if(configuration.DeadlineFrom<=0 || configuration.DeadlineTo<=0 || configuration.PenaltyFrom<=0 || 
                configuration.PenaltyTo<=0 || configuration.NumberOfElements<=0 ||
                configuration.DeadlineFrom.GetType() != typeof(int) || configuration.DeadlineTo.GetType() != typeof(int) ||
                    configuration.PenaltyFrom.GetType() != typeof(int) || configuration.PenaltyTo.GetType() != typeof(int) ||
                        configuration.NumberOfElements.GetType() != typeof(int) || configuration.DeadlineFrom>configuration.DeadlineTo ||
                            configuration.PenaltyFrom>configuration.PenaltyTo)
            {
                return View("Error", "All values must not be 0 or negative or not integer, also min bound of random value must be greater than max bound");
            }
            configuration.NumberOfPenalties = 1;
            configuration.Schedule = configuration.MakeSchedule();
           

            return View("RandomInput", configuration);
        }

        [HttpGet]
        public ActionResult FileInput(FileInputViewModel fileInput)
        {
            fileInput.Schedule.Add(new ScheduleViewModel());
            return View(fileInput);
        }

        [HttpPost]
        public ActionResult FileInput(IFormFile postedFile)
        {
            if (postedFile == null)
            {
                return View("Error", "You have not chosen a file");
            }

            _ = this.Environment.WebRootPath;
            _ = this.Environment.ContentRootPath;

            string path = Path.Combine(this.Environment.WebRootPath, "UploadedFiles");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fileName = Path.GetFileName(postedFile.FileName);
            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                postedFile.CopyTo(stream);
                string uploadedFile = fileName;

                ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
            }

            List<int> list = new List<int>();
            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Open))
            {
                using (TextReader sr = new StreamReader(stream, Encoding.UTF8))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] arr = line.Trim().Split(',', ' ');
                        foreach (var item in arr)
                        {
                            try
                                {
                                list.Add(Convert.ToInt32(item));
                                }
                            catch(Exception ex)
                            {
                                return View("Error", "All values must not be 0 or negative or not integer");
                            }

                           
                        }
                    }
                }
            }
            FileInputViewModel fileInput = new FileInputViewModel();
            fileInput.Schedule.Add(new ScheduleViewModel());
            int id = 1;
            for (int i = 0; i < list.Count; i += 2)
            {
                fileInput.Schedule[0].operations.Add(new OperationViewModel() { Id = id++, Deadline = list[i], Penalty = list[i + 1] });
            }

            return View(fileInput);
        }


        [HttpGet]
        public IActionResult NumInput()
        {
            return View("NumInput");
        }

        [HttpPost]
        public IActionResult NumInput(int numOfElements)
        {
            if (numOfElements <= 0 || numOfElements.GetType()!=typeof(int))
            {
                return View("Error", "The number of schedules cannot be 0 or negative or not integer");
            }
            ManualInputViewModel manual = new ManualInputViewModel
            {
                NumberOfElements = numOfElements,
                Schedule = new List<ScheduleViewModel>()
            };

            manual.Schedule.Add(new ScheduleViewModel());

            return RedirectToAction("ManualInput", manual);

        }


        [HttpGet]
        public IActionResult ManualInput(ManualInputViewModel manual)
        {

            List<OperationViewModel> operations = new List<OperationViewModel>();

            for (int i = 0; i < manual.NumberOfElements; i++)
            {
                operations.Add(new OperationViewModel());
            }

            List<ScheduleViewModel> schedules = new List<ScheduleViewModel>();
            schedules.Add(new ScheduleViewModel() { operations = operations });

            ManualInputViewModel manualInput = new ManualInputViewModel()
            {
                NumberOfElements = operations.Count(),
                Schedule = schedules
            };
            return View("ManualInput", manualInput);
        }

        [HttpPost]
        public IActionResult ScheduleInput(List<OperationViewModel> operations, [FromQuery] string myMethod = null)
        {
            for(int i=0;i<operations.Count;i++)
            {
                if(operations[i].Deadline<=0 || operations[i].Penalty<=0 || operations[i].Deadline.GetType()!=typeof(int) || operations[i].Penalty.GetType()!=typeof(int))
                        return View("Error", "Deadlines or Penalties cannot be 0 or negative or not integer");

                operations[i].Id = i + 1;

            }
            ManualInputViewModel manual = new ManualInputViewModel
            {
                NumberOfElements = operations.Count,
                Schedule = new List<ScheduleViewModel>()
            };

            manual.Schedule.Add(new ScheduleViewModel() { operations = operations });


            return View("ManualInput", manual);
        }

    }
}
