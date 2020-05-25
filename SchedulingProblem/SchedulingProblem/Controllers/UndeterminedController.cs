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

        public int Penalties { get; set; }
        public int Elements { get; set; }

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
                return RedirectToAction("Error");
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
        public IActionResult RandomInput(RandomInputViewModel randomInputView)
        {
            randomInputView.Schedule.Add(new ScheduleViewModel());
            return View("RandomInput", randomInputView);
        }

        [HttpPost]
        public IActionResult RandomInput(RandomInputViewModel configuration, [FromQuery] string myMethod = null)
        {
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
                            list.Add(Convert.ToInt32(item));
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
            ManualInputViewModel manual = new ManualInputViewModel
            {
                NumberOfElements = numOfElements,
                NumberOfPenalties = numOfPenalties,
                Schedule = new List<ScheduleViewModel>()
            };

            //for(int i=0;i<numOfPenalties;i++)
            //{
            //    manual.Schedule.Add(new ScheduleViewModel());
            //}

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
                NumberOfElements = manual.NumberOfElements,
                NumberOfPenalties = manual.NumberOfPenalties,
                Schedule = schedules
            };

            for (int i = 0; i < manual.NumberOfElements * (manual.NumberOfPenalties + 1); i++)
            {
                manualInput.manualList.Add(0);
            }

            Penalties = manualInput.NumberOfPenalties;
            Elements = manualInput.NumberOfElements;

            return View("ManualInput", manualInput);
        }

        [HttpPost]
        public IActionResult ScheduleInput(List<int> list, [FromQuery] string myMethod = null)
        {
            ManualInputViewModel manualInput = new ManualInputViewModel
            {
                NumberOfElements = Elements,
                NumberOfPenalties = Penalties,
                Schedule = new List<ScheduleViewModel>(),
                manualList = list
            };

          //  manual.Schedule.Add(new ScheduleViewModel() { operations = operations });

            for (int j = 0; j < Penalties; j++)
            {
                manualInput.Schedule.Add(new ScheduleViewModel());
                int id = 1;
                for (int i = 0; i < list.Count; i += Penalties + 1)
                {
                    manualInput.Schedule[j].operations.Add(new OperationViewModel() { Id = id++, Deadline = list[i], Penalty = list[i + (j + 1)] });
                }
            }

            return View("ManualInput", manualInput);
        }

    }
}