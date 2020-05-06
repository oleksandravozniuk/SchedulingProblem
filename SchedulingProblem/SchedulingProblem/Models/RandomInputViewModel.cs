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

        public ScheduleViewModel Schedule
        {
            get
            {
                return MakeSchedule();
            }
        }

        public ScheduleViewModel Algo1
        {
            get
            {
                return MakeAlgo1();
            }
        }

        public ScheduleViewModel Algo2
        {
            get
            {
                return MakeAlgo2();
            }
        }

        public ScheduleViewModel Algo3
        {
            get
            {
                return MakeAlgo3();
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

                schedule.operations.Add(new OperationViewModel() { Id = (i+1).ToString(), Deadline = deadline, Penalty = penalty});
            }

            return schedule;
        }

        public ScheduleViewModel MakeAlgo1()
        {
            ScheduleViewModel schedule = new ScheduleViewModel() { operations = Schedule.operations};
            schedule.operations.OrderByDescending(p => p.Penalty);
            return schedule;
        }

        public ScheduleViewModel MakeAlgo2()
        {
            ScheduleViewModel schedule = new ScheduleViewModel() { operations = Schedule.operations };
            schedule.operations.OrderBy(p => p.Deadline);
            return schedule;
        }

        public ScheduleViewModel MakeAlgo3()
        {
            ScheduleViewModel schedule = new ScheduleViewModel() { operations = Schedule.operations };
            schedule.operations.OrderBy(p => p.Penalty);
            return schedule;
        }
    }
}
