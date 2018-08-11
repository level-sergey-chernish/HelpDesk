using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using HelpDesk;

namespace HelpDesk
{
    public abstract class Task
    {
        internal string Name { get; set; }
        internal double Priority { get; set; }
        internal double Severity { get; set; }
        internal double difficulty;
        internal bool IsFixed = false;
        private double Difficulty
        {
            get => difficulty;
            set => difficulty = TaskDifficulty();
        }
        /// <summary>
        /// Count difficulty of task. (Priority * Severity)
        /// </summary>
        /// <returns> Returns double Difficulty </returns>
        internal double TaskDifficulty()
        {
           return _TaskDifficulty();
        }
        private double _TaskDifficulty()
        {
            return Difficulty = Priority * Severity;
        }
        /// <summary>
        /// Indicates Task fixed or not, and if it's not fixed - substracts 1 point of difficulty.
        /// Then check fix again.
        /// </summary>
        /// <returns> Returns Boolean meaning IsFixed </returns>
        public bool Fixed()
        {
            if (IsFixed)
            {
                Console.WriteLine($"{Name} is fixed!");
                return IsFixed;
            }
            bool tryFix;
            Random rnd = new Random();
            Thread.Sleep(50);
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