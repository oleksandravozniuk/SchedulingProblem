using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchedulingProblem.Models;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using System.Text;

namespace SchedulingProblem.Controllers
{
    public class DataReaderController : Controller
    {
        private IWebHostEnvironment Environment;

        public DataReaderController(IWebHostEnvironment _environment)
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
                    case "Manually": return RedirectToAction("NumInput",fileView);
                    case "FromFile": return RedirectToAction("FileInput",fileView);
                    default:
                        break;
                }
                return RedirectToAction("Error");

            }
        }

        [HttpGet]
        public IActionResult RandomInput(RandomInputViewModel randomInputView)
        {
            return View("RandomInput", randomInputView);
        }

        [HttpPost]
        public IActionResult RandomInput(RandomInputViewModel configuration, [FromQuery] string myMethod = null)
        {

            RandomInputViewModel inputViewModel = new RandomInputViewModel()
            {
                PenaltyFrom = configuration.PenaltyFrom,
                PenaltyTo = configuration.PenaltyTo,
                DeadlineFrom = configuration.DeadlineFrom,
                DeadlineTo = configuration.DeadlineTo,
                NumberOfElements = configuration.NumberOfElements,
                Schedule = configuration.MakeSchedule()
            };



            if (myMethod == "Update")
                return View("RandomInput", inputViewModel);
            else
                return View("RandomInput", inputViewModel);
        }

        [HttpGet]
        public ActionResult FileInput(FileInputViewModel fileInput)
        {
        
            return View(fileInput);
        }

        [HttpPost]
        public ActionResult FileInput(IFormFile postedFile)
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
                            string[] arr = line.Trim().Split(',',' ');
                            foreach (var item in arr)
                            {
                                list.Add(Convert.ToInt32(item));
                            }
                        }
                    }
                }
                FileInputViewModel fileInput = new FileInputViewModel();
                int id = 1;
                for (int i=0;i<list.Count;i+=2)
                {
                    fileInput.Schedule.operations.Add(new OperationViewModel() { Id = id, Deadline = list[i], Penalty = list[i + 1]});
                }

            return View(fileInput);
        }


        [HttpGet]
        public IActionResult NumInput(ManualInputViewModel manual)
        {
            return View("NumInput", manual);
        }

        [HttpPost]
        public IActionResult NumInput(ManualInputViewModel manual, [FromQuery] string myMethod = null)
        {
            if (myMethod == "OK")
            {
                for (int i = 0; i < manual.NumberOfElements; i++)
                {
                    manual.Schedule.operations.Add(new OperationViewModel());
                }
                return View("ManualInput", manual);
            }
               
            else
                return View("ManualInput", manual);
        }

        [HttpGet]
        public IActionResult ManualInput(ManualInputViewModel manual)
        {          
            return View("ManualInput", manual);
        }

        [HttpPost]
        public IActionResult ManualInput(ManualInputViewModel manual, [FromQuery] string myMethod = null)
        {

            if (myMethod == "OK")
                return View("ManualInput", manual);
            else
                return View("ManualInput", manual);
        }
    }
}

   
