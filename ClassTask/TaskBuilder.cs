using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk;

namespace HelpDesk
{
    public static class TaskBuilder
    {
        public static Task CreateTask(TaskType taskType)
        {
            switch (taskType)
            {
                case TaskType.Bug:
                    return new Bug();

                case TaskType.Feature:
                    return new Feature();

                case TaskType.Technical:
                    return new Technical();

                default:
                    return null;
            }
        }
    }
}
