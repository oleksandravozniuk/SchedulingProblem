using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchedulingProblem.Models;

namespace SchedulingProblem.Controllers
{
    public class UndeterminedController : Controller
    {
        private IWebHostEnvironment Environment;

        public UndeterminedController(IWebHostEnvironment _environment)
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
                return View("Error", "You have selected nothing");
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
                return View("Error", "You have selected nothing");

            }
        }

        [HttpGet]
        public IActionResult RandomInput(RandomInputViewModel randomInputView)
        {
            randomInputView.Schedule.Add(new ScheduleViewModel());
            return View("RandomInput", randomInputView);
        }

        [HttpPost]
        public IActionResult RandomInput(RandomInputViewModel configuration, [FromQuery] string myMethod = null)
        {
            if (configuration.DeadlineFrom <= 0 || configuration.DeadlineTo <= 0 || configuration.PenaltyFrom <= 0 ||
               configuration.PenaltyTo <= 0 || configuration.NumberOfElements <= 0 || configuration.NumberOfPenalties <= 0 ||
                configuration.DeadlineFrom.GetType() != typeof(int) || configuration.DeadlineTo.GetType()!=typeof(int) ||
                    configuration.PenaltyFrom.GetType()!=typeof(int) || configuration.PenaltyTo.GetType() != typeof(int) ||
                        configuration.NumberOfElements.GetType()!=typeof(int) || configuration.NumberOfPenalties.GetType()!=typeof(int) || 
                        configuration.DeadlineFrom > configuration.DeadlineTo ||
                            configuration.PenaltyFrom > configuration.PenaltyTo || configuration.NumberOfElements > 10000 || configuration.NumberOfPenalties > 100)
            {
                return View("Error", "All values must not be 0 or negative or not integer, also min bound of random value must be greater than max bound and number of elements must be lesser than 10000 and the number of schedules must be lesser than 100");

            }
            configuration.Schedule = configuration.MakeSchedule();


            return View("RandomInput", configuration);
        }

        [HttpGet]
        public ActionResult FileInput(FileInputViewModel fileInput)
        {
            fileInput.Schedule.Add(new ScheduleViewModel());
            fileInput.NumberOfPenalties = 0;
            return View(fileInput);
        }

        [HttpPost]
        public ActionResult FileInput(IFormFile postedFile, int numOfPenalties)
        {
            if(postedFile==null)
            {
                return View("Error", "You have not chosen a file");
            }
            if(numOfPenalties<=0 || numOfPenalties.GetType()!=typeof(int))
            {
                return View("Error", "The number of schedules cannot be 0 or negative or not integer");
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
                            catch (Exception ex)
                            {
                                return View("Error", "All values must not be 0 or negative or not integer");
                            }
                        }
                    }
                }
            }
            FileInputViewModel fileInput = new FileInputViewModel();
           

            for(int j=0;j<numOfPenalties;j++)
            {
                fileInput.Schedule.Add(new ScheduleViewModel());
                int id = 1;
                for (int i = 0; i < list.Count; i += numOfPenalties+1)
                {
                    fileInput.Schedule[j].operations.Add(new OperationViewModel() { Id = id++, Deadline = list[i], Penalty = list[i + (j+1)] });
                }
            }

            fileInput.NumberOfPenalties = numOfPenalties;

           

            return View(fileInput);
        }


        [HttpGet]
        public IActionResult NumInput()
        {
            return View("NumInput");
        }

        [HttpPost]
        public IActionResult NumInput(int numOfElements, int numOfPenalties)
        {
            if (numOfPenalties <= 0 || numOfElements<=0 || numOfPenalties.GetType()!=typeof(int) || numOfElements.GetType()!=typeof(int) ||
                numOfElements > 10000 || numOfPenalties > 100)
            {
                return View("Error", "The number of schedules and elements cannot be 0 or negative or not integer and the max bound of elements count is 10000 and the max bound of schedules is 100");
            }
            ManualInputViewModel manual = new ManualInputViewModel
            {
                NumberOfElements = numOfElements,
                NumberOfPenalties = numOfPenalties,
                Schedule = new List<ScheduleViewModel>()
            };

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
              
                Schedule = schedules
            };

            for (int i = 0; i < manual.NumberOfElements * (manual.NumberOfPenalties + 1); i++)
            {
                manualInput.manualList.Add(0);
            }

            manualInput.manualList.Add(manual.NumberOfElements);
            manualInput.manualList.Add(manual.NumberOfPenalties);

            return View("ManualInput", manualInput);
        }

        [HttpPost]
        public IActionResult ScheduleInput(List<int> list, [FromQuery] string myMethod = null)
        {
            for(int i=0;i<list.Count;i++)
            {
                if(list[i]<=0 || list[i].GetType()!=typeof(int))
                    return View("Error", "Cells cannot be 0 or negative or integer");
            }

            int numOfElements = list[list.Count - 2];
            int numOfPenalties = list[list.Count - 1];

            ManualInputViewModel manualInput = new ManualInputViewModel
            {
                NumberOfElements = numOfElements,
                NumberOfPenalties = numOfPenalties,
                Schedule = new List<ScheduleViewModel>(),
                manualList = list
            };

          //  manual.Schedule.Add(new ScheduleViewModel() { operations = operations });

            for (int j = 0; j < numOfPenalties; j++)
            {
                manualInput.Schedule.Add(new ScheduleViewModel());
                int id = 1;
                for (int i = 0; i < list.Count-2; i += numOfPenalties + 1)
                {
                    manualInput.Schedule[j].operations.Add(new OperationViewModel() { Id = id++, Deadline = list[i], Penalty = list[i + (j + 1)] });
                }
            }

            return View("ManualInput", manualInput);
        }

    }
}