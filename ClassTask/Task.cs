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
        private double difficulty;
        internal bool IsFixed = false;
        //шкала от 1 до 5, влияет на плановую длительность исполнения.Если 1 - не меняется, 2 - 20%, 3 - 30% и т.д.)       

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
            return (difficulty = Priority * GetSeverity());
        }
        /// Count Severity of the task. (Severity + %)
        private double CalculateSeverity()
        {
            if (Severity > 1 && Severity < 6)
            {
                Severity += (Severity * 10 / 100 * Severity);
            }
            return Severity;
        }
        public double GetSeverity()
        {
            return CalculateSeverity();
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

            Random rnd = new Random();
            Thread.Sleep(50);
            bool tryFix = Convert.ToBoolean(rnd.Next(0, 1));

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