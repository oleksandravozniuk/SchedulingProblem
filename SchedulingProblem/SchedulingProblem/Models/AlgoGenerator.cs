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

    }
}
