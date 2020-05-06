using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulingProblem.Models
{
    public class OperationViewModel
    {
        public string Id { get; set; }
        public int Deadline { get; set; }
        public int Penalty { get; set; }

    }
}
