using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulingProblem.Models
{
    public class ScheduleViewModel
    {
        public List<OperationViewModel> operations = new List<OperationViewModel>();

        public int SummmaryPenalty 
        {
            get
            {
                return CalculatePenalty();
            }
        }


      private int CalculatePenalty()
        {
            int result = 0;

            for(int i=0;i<operations.Count;i++)
            {
                if(operations[i].Deadline<i+1)
                {
                    result = result + operations[i].Penalty;
                }
            }
            return result;
        }
    }
}
