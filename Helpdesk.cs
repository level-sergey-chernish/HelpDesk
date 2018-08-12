using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Issues;

namespace HelpDesk
{
    class Helpdesk
    {
        static void Main(string[] args)
        {
            IssueBuilder.IssueBugsList.Add(new IssueBug("SuperMega shit bug", 2, Issue.IssueTypes.bug));
            IssueBuilder.IssueBugsList.Add(new IssueBug("Another one SuperMega shit bug", 5, Issue.IssueTypes.bug));
            IssueBuilder.IssueTasksList.Add(new IssueTask("Create user account", 1, Issue.IssueTypes.task));

            for (var i = 0; i < IssueBuilder.IssueBugsList.Count; i++)
            {
                Console.WriteLine($"TaskName: {IssueBuilder.IssueBugsList.ElementAt(i).Name}");
                Console.WriteLine($"TaskType: {IssueBuilder.IssueBugsList.ElementAt(i).IssueType}");
                Console.WriteLine($"TaskSeverity: {IssueBuilder.IssueBugsList.ElementAt(i).Severity}");
                Console.WriteLine($"Task Complete: {IssueBuilder.IssueBugsList.ElementAt(i).IssueStatus}");
                Console.WriteLine();
            }

            for (var i = 0; i < IssueBuilder.IssueTasksList.Count; i++)
            {
                Console.WriteLine($"TaskName: {IssueBuilder.IssueTasksList.ElementAt(i).Name}");
                Console.WriteLine($"TaskType: {IssueBuilder.IssueTasksList.ElementAt(i).IssueType}");
                Console.WriteLine($"TaskSeverity: {IssueBuilder.IssueTasksList.ElementAt(i).Severity}");
                Console.WriteLine($"Task Complete: {IssueBuilder.IssueTasksList.ElementAt(i).IssueStatus}");
                Console.WriteLine();
            }

            Console.WriteLine(IssueBuilder.IsScrumPossible());



        }
    }
}
