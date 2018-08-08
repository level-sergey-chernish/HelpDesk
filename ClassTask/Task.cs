using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ClassTask
{
    public abstract class Task
    {
        public string Name { get; set; }
        public double Priority { get; set; }
        public double Severity { get; set; }
        public double difficulty;
        public bool IsFixed { get; set; }
        public double Difficulty
        {
            get
            {
                return difficulty;
            }
            set
            {
                difficulty = TaskDifficulty();
            }
        }
        public double TaskDifficulty()
        {
            return Difficulty = Priority * Severity;
        }

        public bool Fixed()
        {
            if (IsFixed)
            {
                Console.WriteLine($"{Name} is fixed!");
                return IsFixed;
            }
            bool tryFix;
            Random rnd = new Random();
            Thread.Sleep(350);
            tryFix = Convert.ToBoolean(rnd.Next(0, 1));

            if (tryFix)
            {
                Difficulty--;
                if (Difficulty <= 0)
                {
                    Console.WriteLine($"{Name} is fixed!");
                    return IsFixed = true;
                }
                else
                {
                    return IsFixed;
                }
            }
            else
            {
                Console.WriteLine($"Program can't solve {Name} at this time");
                return IsFixed;
            }
        }
    }
}