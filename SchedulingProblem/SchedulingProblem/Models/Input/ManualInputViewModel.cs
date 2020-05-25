using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulingProblem.Models
{
    public class ManualInputViewModel
    {
        public int NumberOfElements { get; set; }

        public List<ScheduleViewModel> Schedule = new List<ScheduleViewModel>();

        public AlgoGenerator AlgoGenerator = new AlgoGenerator();

        public List<int> manualList = new List<int>();

        public int NumberOfPenalties { get; set; }
    }
}
