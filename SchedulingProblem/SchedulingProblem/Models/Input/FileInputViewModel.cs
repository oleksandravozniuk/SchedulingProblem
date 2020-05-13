using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulingProblem.Models
{
    public class FileInputViewModel
    {
        public ScheduleViewModel Schedule = new ScheduleViewModel();

        public AlgoGenerator AlgoGenerator = new AlgoGenerator();
    }
}
