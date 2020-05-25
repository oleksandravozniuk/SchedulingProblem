using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulingProblem.Models
{
    public class FileInputViewModel
    {
        public List<ScheduleViewModel> Schedule = new List<ScheduleViewModel>();

        public AlgoGenerator AlgoGenerator = new AlgoGenerator();
        public int NumberOfPenalties { get; set; }
    }
}
