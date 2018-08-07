using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Tasks
{
    public abstract class Task
    {
        public string Name { get; set; }
        public double Priority { get; set; }
        public double Sevirity { get; set; }
        private double dufficulty;
        public bool IsFixed { get; set; }
    }
}
