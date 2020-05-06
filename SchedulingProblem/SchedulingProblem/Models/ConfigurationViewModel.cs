using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulingProblem.Models
{
    public class ConfigurationViewModel
    {
        public List<string> InputTypes
        {
            get
            {
                List<string> ListInputTypes = new List<string>()
                {
                    "Random",
                    "Manually",
                    "FromFile"
                };
                return ListInputTypes;
            }
        }

        public string SelectedInputType { get; set; }

        public int NumberOfElements { get; set; }
    }
}
