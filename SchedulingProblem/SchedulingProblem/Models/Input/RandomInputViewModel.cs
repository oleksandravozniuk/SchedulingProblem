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

        public int NumberOfPenalties { get; set; }

        public List<ScheduleViewModel> Schedule = new List<ScheduleViewModel>();

        public AlgoGenerator AlgoGenerator = new AlgoGenerator();

        public RandomInputViewModel()
        {}

       

        public List<ScheduleViewModel> MakeSchedule()
        {
            List<ScheduleViewModel> schedule = new List<ScheduleViewModel>();
            List<int> deadlines = new List<int>();
            var rand = new Random();

            for (int i=0;i<NumberOfElements;i++)
            {
                deadlines.Add(rand.Next(DeadlineFrom, DeadlineTo));
            }

            for(int j=0;j<NumberOfPenalties;j++)
            {
                schedule.Add(new ScheduleViewModel());

                for (int i = 0; i < NumberOfElements; i++)
                {
                    var penalty = rand.Next(PenaltyFrom, PenaltyTo);

                    schedule[j].operations.Add(new OperationViewModel() { Id = i + 1, Deadline = deadlines[i], Penalty = penalty });
                }
            }
            
           
            return schedule;
        }

       
    }
}
