using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchedulingProblem.Models;
using SchedulingProblem.Models.Statistics;

namespace SchedulingProblem.Controllers.Statistics
{
    public class StatisticsController : Controller
    {
        public IActionResult Index()
        {
            return View("Statistics");
        }

        [HttpGet]
        [Route("Precision")]
        public JsonResult Precision()
        {
            List<Precision> precisions = new List<Precision>();

            for (int i=0;i<10000;i+=100)
            {
                RandomInputViewModel randomInput = new RandomInputViewModel()
                {
                    PenaltyFrom = 1,
                    PenaltyTo = 10000,
                    DeadlineFrom = 1,
                    DeadlineTo = 1000,
                    NumberOfElements = i,
                    NumberOfPenalties = 1
                };

                Precision precision = new Precision()
                {
                    Step = i,
                    Algo1 = randomInput.AlgoGenerator.MakeAlgo1(randomInput.MakeSchedule().First()).SummmaryPenalty,
                    Algo2 = randomInput.AlgoGenerator.MakeAlgo2(randomInput.MakeSchedule().First()).SummmaryPenalty,
                    Algo3 = randomInput.AlgoGenerator.MakeAlgo3(randomInput.MakeSchedule().First()).SummmaryPenalty,
                    Algo4 = randomInput.AlgoGenerator.MakeAlgo4(randomInput.MakeSchedule().First()).SummmaryPenalty,
                };
                precisions.Add(precision);
            }
           
           
            return Json(precisions);
        }

        [HttpGet]
        [Route("Time")]
        public JsonResult Time()
        {
            List<Precision> times = new List<Precision>();

            for (int i = 0; i < 10000; i += 100)
            {
                Precision time = new Precision()
                {
                    Step = i,
                    Algo1 = CountAlgoTime(1,i),
                    Algo2 = CountAlgoTime(2,i),
                    Algo3 = CountAlgoTime(3,i),
                    Algo4 = CountAlgoTime(4,i)
                };
                times.Add(time);
            }
            return Json(times);
        }

        [HttpGet]
        [Route("Time1")]
        public JsonResult Time1()
        {
            List<Precision> times = new List<Precision>();

            for (int i = 0; i < 10000; i += 100)
            {
                Precision time = new Precision()
                {
                    Step = i,
                    Algo1 = CountAlgoTime(1, i),
                    Algo2 = 0,
                    Algo3 = 0,
                    Algo4 = 0
                };
                times.Add(time);
            }
            return Json(times);
        }

        [HttpGet]
        [Route("Time2")]
        public JsonResult Time2()
        {
            List<Precision> times = new List<Precision>();

            for (int i = 0; i < 10000; i += 100)
            {


                Precision time = new Precision()
                {
                    Step = i,
                    Algo1 = 0,
                    Algo2 = CountAlgoTime(2, i),
                    Algo3 = 0,
                    Algo4 = 0
                };
                times.Add(time);
            }
            return Json(times);
        }

        [HttpGet]
        [Route("Time3")]
        public JsonResult Time3()
        {
            List<Precision> times = new List<Precision>();

            for (int i = 0; i < 10000; i += 100)
            {


                Precision time = new Precision()
                {
                    Step = i,
                    Algo1 = 0,
                    Algo2 = 0,
                    Algo3 = CountAlgoTime(3, i),
                    Algo4 = 0
                };
                times.Add(time);
            }
            return Json(times);
        }

        [HttpGet]
        [Route("Time4")]
        public JsonResult Time4()
        {
            List<Precision> times = new List<Precision>();

            for (int i = 0; i < 10000; i += 100)
            {


                Precision time = new Precision()
                {
                    Step = i,
                    Algo1 = 0,
                    Algo2 = 0,
                    Algo3 = 0,
                    Algo4 = CountAlgoTime(4, i)
                };
                times.Add(time);
            }
            return Json(times);
        }

        public double CountAlgoTime(int numOfAlgo, int numOfElements)
        {
            RandomInputViewModel randomInput = new RandomInputViewModel()
            {
                PenaltyFrom = 1,
                PenaltyTo = 10000,
                DeadlineFrom = 1,
                DeadlineTo = 10000,
                NumberOfElements = numOfElements,
                NumberOfPenalties = 1
            };

            DateTime moment1 = DateTime.Now;//first time
            
            switch(numOfAlgo)
            {
                case 1: _ = randomInput.AlgoGenerator.MakeAlgo1(randomInput.MakeSchedule().First());break;
                case 2: _ = randomInput.AlgoGenerator.MakeAlgo2(randomInput.MakeSchedule().First()); break;
                case 3: _ = randomInput.AlgoGenerator.MakeAlgo3(randomInput.MakeSchedule().First()); break;
                case 4: _ = randomInput.AlgoGenerator.MakeAlgo4(randomInput.MakeSchedule().First()); break;
            }

            DateTime moment2 = DateTime.Now;//time after running

            TimeSpan diff = moment2.Subtract(moment1);//diff between first and second times

            return diff.TotalMilliseconds;
        }
    }
}