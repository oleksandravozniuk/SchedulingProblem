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
                    DeadlineTo = 10000,
                    NumberOfElements = i,
                    NumberOfPenalties = 1
                };
                List<int> algo1 = new List<int>();
                List<int> algo2 = new List<int>();
                List<int> algo3 = new List<int>();
                List<int> algo4 = new List<int>();
                for(int j =0;j<10;j++)
                {

                    algo1.Add(randomInput.AlgoGenerator.MakeAlgo1(randomInput.MakeSchedule().First()).SummmaryPenalty);
                    algo2.Add(randomInput.AlgoGenerator.MakeAlgo2(randomInput.MakeSchedule().First()).SummmaryPenalty);
                    algo3.Add(randomInput.AlgoGenerator.MakeAlgo3(randomInput.MakeSchedule().First()).SummmaryPenalty);
                    algo4.Add(randomInput.AlgoGenerator.MakeAlgo4(randomInput.MakeSchedule().First()).SummmaryPenalty);
                   
                }

                Precision precision = new Precision()
                {
                    Step = i,
                    Greedy1 = algo1.Average(),
                    Greedy2 = algo2.Average(),
                    Greedy3 = algo3.Average(),
                    Greedy4 = algo4.Average(),
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
                    Greedy1 = CountAlgoTime(1,i),
                    Greedy2 = CountAlgoTime(2,i),
                    Greedy3 = CountAlgoTime(3,i),
                    Greedy4 = CountAlgoTime(4,i)
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
                    Greedy1 = CountAlgoTime(1, i),
                    Greedy2 = 0,
                    Greedy3 = 0,
                    Greedy4 = 0
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
                    Greedy1 = 0,
                    Greedy2 = CountAlgoTime(2, i),
                    Greedy3 = 0,
                    Greedy4 = 0
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
                    Greedy1 = 0,
                    Greedy2 = 0,
                    Greedy3 = CountAlgoTime(3, i),
                    Greedy4 = 0
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
                    Greedy1 = 0,
                    Greedy2 = 0,
                    Greedy3 = 0,
                    Greedy4 = CountAlgoTime(4, i)
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
                case 1:
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            _ = randomInput.AlgoGenerator.MakeAlgo1(randomInput.MakeSchedule().First());
                        }
                        break;
                    } 
                case 2:
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            _ = randomInput.AlgoGenerator.MakeAlgo2(randomInput.MakeSchedule().First());
                        }
                        break;
                    }
                case 3:
                    {
                        {
                            for (int i = 0; i < 10; i++)
                            {
                                _ = randomInput.AlgoGenerator.MakeAlgo3(randomInput.MakeSchedule().First());
                            }
                            break;
                        }
                    }
                case 4:
                    {
                        {
                            for (int i = 0; i < 10; i++)
                            {
                                _ = randomInput.AlgoGenerator.MakeAlgo4(randomInput.MakeSchedule().First());
                            }
                            break;
                        }
                    }
            }

            DateTime moment2 = DateTime.Now;//time after running

            TimeSpan diff = moment2.Subtract(moment1);//diff between first and second times

            return diff.TotalMilliseconds;
        }

        [HttpGet]
        [Route("Undetermined")]
        public JsonResult Undetermined()
        {
            List<Undetermined> undetermineds = new List<Undetermined>();

            for (int i = 2; i < 100; i += 1)
            {
                
                RandomInputViewModel randomInput = new RandomInputViewModel()
                {
                    PenaltyFrom = 1,
                    PenaltyTo = 10000,
                    DeadlineFrom = 1,
                    DeadlineTo = 90,
                    NumberOfElements = 90,
                    NumberOfPenalties = i
                };

                double percents;
                List<int> list = new List<int>();
                for (int k = 1;k<10;k++)
                {
                    int summaryPenaltyCount = 0;
                    
                    

                    for (int j = 0; j < 100; j++)
                    {

                        UndeterminedResultViewModel undeterminedResult = randomInput.AlgoGenerator.Answer(randomInput.MakeSchedule());

                        if (undeterminedResult.ResultSchedules.Last() == i)
                        {
                            summaryPenaltyCount++;
                        }

                        

                    }
                    list.Add(summaryPenaltyCount);

                }

                percents = list.Average();

                Undetermined undetermined = new Undetermined()
                {
                    Step = i,
                    Percents = percents
                };

                undetermineds.Add(undetermined);
            }

            return Json(undetermineds);
        }

        [HttpGet]
        [Route("Undetermined2")]
        public JsonResult Undetermined2()
        {
            List<Undetermined> undetermineds = new List<Undetermined>();

            for (int i = 1; i < 30; i += 1)
            {

                RandomInputViewModel randomInput = new RandomInputViewModel()
                {
                    PenaltyFrom = 1,
                    PenaltyTo = 10000,
                    DeadlineFrom = 1,
                    DeadlineTo = 30,
                    NumberOfElements = i,
                    NumberOfPenalties = 10
                };

                double percents;
                List<int> list = new List<int>();
                for (int k = 1; k < 10; k++)
                {
                    int summaryPenaltyCount = 0;



                    for (int j = 0; j < 100; j++)
                    {

                        UndeterminedResultViewModel undeterminedResult = randomInput.AlgoGenerator.Answer(randomInput.MakeSchedule());

                        if (undeterminedResult.ResultSchedules.Last() == 10)
                        {
                            summaryPenaltyCount++;
                        }



                    }
                    list.Add(summaryPenaltyCount);

                }

                percents = list.Average();

                Undetermined undetermined = new Undetermined()
                {
                    Step = i,
                    Percents = percents
                };

                undetermineds.Add(undetermined);
            }

            return Json(undetermineds);
        }


        [HttpGet]
        [Route("UndeterminedTime")]
        public JsonResult UndeterminedTime()
        {
            List<Undetermined> undetermineds = new List<Undetermined>();

            for (int i = 1; i < 50; i += 1)
            {

                RandomInputViewModel randomInput = new RandomInputViewModel()
                {
                    PenaltyFrom = 1,
                    PenaltyTo = 10000,
                    DeadlineFrom = 1,
                    DeadlineTo = 90,
                    NumberOfElements = 90,
                    NumberOfPenalties = i
                };

                DateTime moment1;
                DateTime moment2;
                double diff = 0;

                for (int j = 0; j < 100; j++)
                {
                    moment1 = DateTime.Now;//first time
                    _ = randomInput.AlgoGenerator.Answer(randomInput.MakeSchedule());
                    moment2 = DateTime.Now;//time after running

                    diff += moment2.Subtract(moment1).TotalMilliseconds;//diff between first and second times
                    
                }
                
                Undetermined undetermined = new Undetermined()
                {
                    Step = i,
                    Percents = diff
                };

                undetermineds.Add(undetermined);
            }

            return Json(undetermineds);
        }
    }

}
