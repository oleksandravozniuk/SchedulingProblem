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

    }
}
