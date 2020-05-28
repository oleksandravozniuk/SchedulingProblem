using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulingProblem.Models
{
    public class AlgoGenerator
    {
        public AlgoGenerator()
        {

        }
        public ScheduleViewModel MakeAlgo1(ScheduleViewModel schedule)
        {
            var o = schedule.operations.OrderByDescending(p => p.Penalty);
            var s = new ScheduleViewModel()
            {
                operations = o.ToList()
            };
            return s;
        }

        public ScheduleViewModel MakeAlgo2(ScheduleViewModel schedule)
        {
            var o = schedule.operations.OrderBy(p => p.Deadline);
            var s = new ScheduleViewModel()
            {
                operations = o.ToList()
            };
            return s;
        }

        public ScheduleViewModel MakeAlgo3(ScheduleViewModel schedule)
        {

            var operations = new List<OperationViewModel>();
            var operationsByPenaltyDescending = schedule.operations.OrderByDescending(p => p.Penalty).ToList();
            var operationsByDeadlineAscending = schedule.operations.OrderBy(d => d.Deadline).ToList();

            int i = 0;
            while(operations.Count!=schedule.operations.Count)
            {
                if (operationsByDeadlineAscending.Count != 0 && operationsByDeadlineAscending.First().Deadline==i+1)
                {
                    operations.Add(operationsByDeadlineAscending.First());

                    if(operationsByPenaltyDescending.Count!=0)
                    {
                        operationsByPenaltyDescending.Remove(operationsByDeadlineAscending.First());
                    }
                    
                  
                        while (operationsByDeadlineAscending.Count!=0 && operationsByDeadlineAscending.First().Deadline == i + 1)
                        { 
                            operationsByDeadlineAscending.Remove(operationsByDeadlineAscending.First());
                        }
                 
                }
                else
                {
                    if(operationsByPenaltyDescending.Count!=0)
                    {
                        operations.Add(operationsByPenaltyDescending.First());
                    }

                    if(operationsByDeadlineAscending.Count!=0)
                    {
                        operationsByDeadlineAscending.Remove(operationsByPenaltyDescending.First());
                    }
                    if(operationsByPenaltyDescending.Count!=0)
                    {
                        operationsByPenaltyDescending.Remove(operationsByPenaltyDescending.First());
                    }
                }
                i++;
               
            }
            var s = new ScheduleViewModel()
            {
                operations = operations.ToList()
            };
            return s;
        }

        public ScheduleViewModel MakeAlgo4(ScheduleViewModel schedule)
        {
            var o = schedule.operations.OrderByDescending(p => (double)(p.Penalty/p.Deadline));
           // var o = schedule.operations.OrderBy(p => p.Deadline);
            var s = new ScheduleViewModel()
            {
                operations = o.ToList()
            };
            return s;
        }

        public List<ScheduleViewModel> SummaryScheduleResult(List<ScheduleViewModel> schedules)
        {
            List<int> summaryPenalties = new List<int>();
            
            for(int i=0;i<schedules[0].operations.Count;i++)
            {
                int penalty = 0;
                for(int j=0;j<schedules.Count;j++)
                {
                    penalty += FindPenaltyByOperationId(schedules[j], i+1);
                }
                summaryPenalties.Add(penalty);
            }

            List<int> deadlines = new List<int>();
            List<OperationViewModel> operations = new List<OperationViewModel>();
            operations = schedules[0].operations;
            operations.OrderBy(p => p.Id);

            for(int i=0;i<operations.Count;i++)
            {
                deadlines.Add(operations[i].Deadline);
            }

            List<OperationViewModel> startOperations = new List<OperationViewModel>();
            for(int i=0;i<operations.Count;i++)
            {
                startOperations.Add(new OperationViewModel
                {
                    Id = i+1,
                    Penalty = summaryPenalties[i],
                    Deadline = deadlines[i]
                });
            }

            ScheduleViewModel startSunnarySchedule = new ScheduleViewModel()
            {
                operations = startOperations
            };

            List<ScheduleViewModel> resultSchedules = new List<ScheduleViewModel>();
            resultSchedules.Add(MakeAlgo1(startSunnarySchedule));
            resultSchedules.Add(MakeAlgo2(startSunnarySchedule));
            resultSchedules.Add(MakeAlgo3(startSunnarySchedule));
            resultSchedules.Add(MakeAlgo4(startSunnarySchedule));

            return resultSchedules;
        }

        public int FindPenaltyByOperationId(ScheduleViewModel schedule, int id)
        {
            for(int i=0;i<schedule.operations.Count;i++)
            {
                if(id == schedule.operations[i].Id)
                {
                    return schedule.operations[i].Penalty;
                }
            }
            return 0;
        }

        public List<ScheduleViewModel> BestSchedules(List<ScheduleViewModel> schedules)
        {
            List<ScheduleViewModel> bestSchedules = new List<ScheduleViewModel>();

            for(int i=0;i<schedules.Count;i++)
            {
                List<ScheduleViewModel> resultSchedule = new List<ScheduleViewModel>();
                resultSchedule.Add(MakeAlgo1(schedules[i]));
                resultSchedule.Add(MakeAlgo2(schedules[i]));
                resultSchedule.Add(MakeAlgo3(schedules[i]));
                resultSchedule.Add(MakeAlgo4(schedules[i]));
                bestSchedules.Add(resultSchedule.OrderBy(p => p.SummmaryPenalty).First());
            }

            var summarySchedule = SummaryScheduleResult(schedules);
            bestSchedules.Add(summarySchedule.OrderBy(p => p.SummmaryPenalty).First());

            return bestSchedules;

        }

        public List<List<int>> Deltas(List<ScheduleViewModel> bestSchedules)
        {
            List<int> sumPenalties = new List<int>();
            for(int i=0;i<bestSchedules.Count;i++)
            {
                sumPenalties.Add(bestSchedules[i].SummmaryPenalty);
            }

            List<List<int>> deltas = new List<List<int>>();

            List<List<int>> penalties = new List<List<int>>();

            for(int i=0;i<bestSchedules.Count-1;i++)
            {
                penalties.Add(GetPenaltiesFromSchedule(bestSchedules[i]));
            }

            for(int i=0;i<bestSchedules.Count;i++)
            {
                deltas.Add(GetDeltasList(bestSchedules[i], penalties, sumPenalties)); 
            }

            return deltas;
        }

        public List<int> GetPenaltiesFromSchedule(ScheduleViewModel schedule)
        {
            List<int> penalties = new List<int>();


            ScheduleViewModel scheduleView = new ScheduleViewModel()
            {
                operations = schedule.operations.OrderBy(p => p.Id).ToList()
            };


            for(int i=0;i<scheduleView.operations.Count;i++)
            {
                penalties.Add(scheduleView.operations[i].Penalty);

            }

            return penalties;
        }

        public List<int> GetDeltasList(ScheduleViewModel schedule, List<List<int>> penalties, List<int> sumPenalties)
        {
            List<int> deltas = new List<int>();

         
            if(schedule.operations.Count!=0 && penalties.First().First()!=0)
            {
                for (int i = 0; i < penalties.Count; i++)
                {
                    for (int j = 0; j < schedule.operations.Count; j++)
                    {
                        schedule.operations.Where(p => p.Id == j + 1).First().Penalty = penalties[i][j];
                    }
                    deltas.Add(schedule.SummmaryPenalty - sumPenalties[i]);
                }


                int sum = 0;
                for (int i = 0; i < penalties.Count; i++)
                {
                    sum += deltas[i];
                }

                deltas.Add(sum);

            }
            return deltas;
        }

        //public List<ScheduleViewModel> Answer(List<List<int>> deltas, List<ScheduleViewModel> bestSchedules)
        //{
        //    List<int> indexes = new List<int>();
        //    List<ScheduleViewModel> schedules = new List<ScheduleViewModel>();

        //    if (deltas.First().Count!=0)
        //    {
        //        int min = deltas.First()[deltas.First().Count - 1];

        //        for (int i = 0; i < deltas.Count; i++)
        //        {
        //            if(deltas[i][deltas.First().Count - 1]<=min)
        //            {
        //                min = deltas[i][deltas.First().Count - 1];
        //            }
        //        }

        //        for (int i = 0; i < deltas.Count; i++)
        //        {
        //            if (deltas[i][deltas.First().Count - 1] == min)
        //            {
        //                indexes.Add(i);
        //            }
        //        }

        //        for(int i=0;i<indexes.Count;i++)
        //        {
        //            schedules.Add(bestSchedules[indexes[i]]);
        //        }

        //    }
        //    return schedules;
        //}
    }
}
