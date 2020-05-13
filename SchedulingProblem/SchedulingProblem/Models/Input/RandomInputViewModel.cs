using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulingProblem.Models
{
    public class RandomInputViewModel
    {
        public int PenaltyFrom { get; set; }

        public int PenaltyTo { get; set; }

        public int DeadlineFrom { get; set; }

        public int DeadlineTo { get; set; }

        public int NumberOfElements { get; set; }

        public ScheduleViewModel Schedule = new ScheduleViewModel();

        public AlgoGenerator AlgoGenerator = new AlgoGenerator();

        public RandomInputViewModel()
        {
            if(Schedule.operations.Count==0 && NumberOfElements==0)
            {
                Schedule = MakeSchedule();
            }
        }

       

        public ScheduleViewModel MakeSchedule()
        {
            ScheduleViewModel schedule = new ScheduleViewModel();
            var rand = new Random();

            for(int i=0;i<NumberOfElements;i++)
            {
                var deadline = rand.Next(PenaltyFrom, PenaltyTo);
                var penalty = rand.Next(DeadlineFrom, DeadlineTo);

                schedule.operations.Add(new OperationViewModel() { Id = i+1, Deadline = deadline, Penalty = penalty});
            }

            return schedule;
        }

       
    }
}
