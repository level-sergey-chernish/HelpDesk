using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk;

namespace HelpDesk
{
    public static class Static
    {   

        /// <summary>
        /// Count summary difficulty of all tasks and 
        /// tells is it possible to solve this ammount of task
        /// in 30 itterations
        /// </summary>
        /// <param name="tasks"></param>
        /// <returns>Boolean meaning depends of solution </returns>
        public static bool CheckDif(List<HelpDesk.Task> tasks)
        {
            bool canDecide;
            double counter = 0;
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].Difficulty >0)
                {
                    counter += tasks[i].Difficulty;
                }
            }
            if (counter > 30)
            {
                Console.WriteLine("Sorry, there is too much tasks. Program couldn't solve it");
                return canDecide = false;
            }
            else
            {
                return canDecide = true;
            }
        }
        //public static bool IsValueDouble(string input)
        //{
        //    if (double.TryParse(input, result))
        //    {
        //        return true;
        //    }
        //    else
        //        return false;
        //}
    }
}
