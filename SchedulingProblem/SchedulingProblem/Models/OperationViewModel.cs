using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulingProblem.Models
{
    public class OperationViewModel
    {
        public int Id { get; set; }
        public int Deadline { get; set; } = 1;
        public int Penalty { get; set; }

        public OperationViewModel()
        {

        }

    }
}
