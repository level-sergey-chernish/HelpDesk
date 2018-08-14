using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Issues;
using UI;

namespace UI
{
    public class UserInterface
    {
        public static void MainMenu()
        {
            bool menuExit = false;
            string caseSwitch;
            Console.Clear();
            do
            {
                TextColorer.MenuHeader("HELPDESK SYSTEM (Bug Tracking)");
                TextColorer.Notify("Choose Your action:");
                TextColorer.MenuChoise("1 - Add issue");
                TextColorer.MenuChoise("2 - Delete issue");
                TextColorer.MenuChoise("3 - List of issues");
                TextColorer.MenuChoise($"4 - Change scrum duration (now is {IssueBuilder.ScrumLength})");
                TextColorer.MenuChoise($"5 - Change difficulty range (default [{IssueBuilder.DifficultyMin} - {IssueBuilder.DifficultyMax}])");
                TextColorer.MenuChoise("6 - Start scrum\n");
                TextColorer.MenuChoise("q - Exit");

                TextColorer.Alert(new String('_', 45));
                TextColorer.Alert($"Total issues:{IssueBuilder.TotalIssuesQuantity}     ToDo Complexivity is:{IssueBuilder.Complexity}\n");
                TextColorer.Alert($"Tasks:{IssueBuilder.TaskIssuesQuantity}     Bugs:{IssueBuilder.BugIssuesQuantity}     " +
                    $"Technical Depts:{IssueBuilder.TechnicalDeptsIssuesQuantity}\n");
                TextColorer.Alert($"ClosedIssues:{IssueBuilder.ClosedIssues()}");


                TextColorer.Alert(new String('_', 45));

                Console.Write(">>:");
                caseSwitch = Console.ReadLine().ToLower();
                switch (caseSwitch)
                {
                    case "1":
                        Console.Clear();
                        AddIssue();
                        menuExit = true;
                        break;
                    case "2":
                        Console.Clear();
                        menuExit = true;
                        break;
                    case "3":
                        Console.Clear();
                        ShowIssues();
                        menuExit = true;
                        MainMenu();
                        break;
                    case "4":
                        Console.Clear();
                        IssueBuilder.ScrumLength = AddScrumLength();
                        menuExit = true;
                        MainMenu();
                        break;
                    case "5":
                        Console.Clear();
                        IssueBuilder.DifficultyMax = AddDifRange();
                        menuExit = true;
                        MainMenu();
                        break;
                    case "6":
                        Console.Clear();
                        menuExit = true;
                        break;
                    case "q":
                        menuExit = true;
                        break;
                    default:
                        Console.Clear();
                        menuExit = true;
                        TextColorer.Alert("WHAT?! - Have You been reading menu, bastard?! ");
                        Thread.Sleep(200);
                        MainMenu();
                        break;
                }
            } while (!menuExit);
        }

        public static void AddIssue()
        {
            bool menuExit = false;
            string caseSwitch;
            Console.Clear();
            do
            {
                TextColorer.MenuHeader("HELPDESK SYSTEM (Bug Tracking)");
                TextColorer.Notify("Choose Your action:");
                TextColorer.MenuChoise("1 - Add Task");
                TextColorer.MenuChoise("2 - Add Bug");
                TextColorer.MenuChoise("3 - Add Technical Dept\n");
                TextColorer.MenuChoise("r - Return to previous menu");

                TextColorer.Alert(new String('_', 45));
                TextColorer.Alert($"Total issues:{IssueBuilder.TotalIssuesQuantity}     ToDo Complexivity:{IssueBuilder.Complexity}\n");
                TextColorer.Alert($"Tasks:{IssueBuilder.TaskIssuesQuantity}     Bugs:{IssueBuilder.BugIssuesQuantity}     " +
                    $"Technical Depts:{IssueBuilder.TechnicalDeptsIssuesQuantity}\n");
                TextColorer.Alert(new String('_', 45));

                Console.Write(">>:");
                caseSwitch = Console.ReadLine().ToLower();
                switch (caseSwitch)
                {
                    case "1":
                        Console.Clear();
                        AddTask(Name(), Difficulty());
                        menuExit = true;
                        AddIssue();
                        break;
                    case "2":
                        Console.Clear();
                        AddBug(Name(), Difficulty());
                        menuExit = true;
                        AddIssue();
                        break;
                    case "3":
                        Console.Clear();
                        AddTechnicalDept(Name(), Difficulty());
                        menuExit = true;
                        AddIssue();
                        break;
                    case "r":
                        menuExit = true;
                        MainMenu();
                        break;
                    default:
                        Console.Clear();
                        menuExit = true;
                        TextColorer.Alert("WHAT?! - Have You been reading menu, bastard?! ");
                        Thread.Sleep(200);
                        AddIssue();
                        break;
                }
            } while (!menuExit);
        }

        private static void AddTask(string str, int num)
        {
            IssueBuilder.IssueTasksList.Add(new IssueTask(str, num, Issues.Issue.IssueTypes.task));
        }

        private static void AddBug(string str, int num)
        {
            IssueBuilder.IssueBugsList.Add(new IssueBug(str, num, Issues.Issue.IssueTypes.bug));
        }

        private static void AddTechnicalDept(string str, int num)
        {
            IssueBuilder.IssueTechnicalDeptsList.Add(new IssueTechnicalDept(str, num, Issues.Issue.IssueTypes.technicalDept));
        }

        private static string Name()
        {
            do
            {
                Console.Clear();
                TextColorer.MenuChoise("Please, name of Task " +
                    "(value must be not empty)");
                Console.Write(">>:");
                string name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                {
                    return name;
                }
                else
                {
                    TextColorer.Alert("WHAT?! - Have You been reading menu, bastard?! ");
                    Thread.Sleep(200);
                }
            } while (true);
        }

        private static int Difficulty()
        {
            do
            {
                Console.Clear();
                TextColorer.MenuChoise($"Please, add difficulty of Issue " +
                    $"(value must be in range [{IssueBuilder.DifficultyMin} - {IssueBuilder.DifficultyMax}])");
                Console.Write(">>:");
                if (int.TryParse(Convert.ToString(Console.ReadLine()), out int isInt) && 
                    isInt >= IssueBuilder.DifficultyMin &&
                    isInt <= IssueBuilder.DifficultyMax)
                {
                    return isInt;
                }
                else
                {
                    TextColorer.Alert("WHAT?! - Have You been reading menu, bastard?! ");
                    Thread.Sleep(200);
                }
            } while (true);
        }

        private static int AddScrumLength()
        {
            string scrumLength;
            do
            {
                Console.Clear();
                TextColorer.MenuChoise("Please, input value of Scrum Length " +
                    "(value must be int and be in range [1 - 2,147,483,647])");
                Console.Write(">>:");
                scrumLength = Console.ReadLine();
                if (int.TryParse(Convert.ToString(scrumLength), out int isInt) && isInt >= 1)

                {
                    return isInt;
                }
                else
                {
                    TextColorer.Alert("WHAT?! - Have You been reading menu, bastard?! ");
                    Thread.Sleep(200);
                }
            } while (true) ;
            
        }

        private static int AddDifRange()
        {
            string difficultyMax;
            do
            {
                Console.Clear();
                TextColorer.MenuChoise("Please, input value of Difficulty Range " +
                    "(value must be int and be in range [1 - 2,147,483,647])");
                Console.Write(">>:");
                difficultyMax = Console.ReadLine();
                if (int.TryParse(Convert.ToString(difficultyMax), out int isInt) && isInt >= 1)

                {
                    return isInt;
                }
                else
                {
                    TextColorer.Alert("WHAT?! - Have You been reading menu, bastard?! ");
                    Thread.Sleep(200);
                }
            } while (true);
        }

        private static void ShowIssues()
        {
            if ( IssueBuilder.IssueTasksList.Count == 0 && IssueBuilder.IssueBugsList.Count == 0
                && IssueBuilder.IssueTechnicalDeptsList.Count == 0 )
            {
                TextColorer.ListEmpty("There is no any Issues yet. You can back in main menu and add it!");
                Console.ReadLine();
            }
            else
            {
                if (IssueBuilder.IssueTasksList.Count > 0)
                {
                    for (int i = 0; i < IssueBuilder.IssueTasksList.Count; i++)
                    {
                        Console.WriteLine(new String('=', 35));
                        Console.WriteLine();
                        Console.WriteLine($"Name of task is {IssueBuilder.IssueTasksList[i].Name}");
                        Console.WriteLine($"Difficulty of this task is {IssueBuilder.IssueTasksList[i].Difficulty}");
                        Console.WriteLine();
                        Console.WriteLine(new String('=', 35));
                    }
                }
                else
                {
                    TextColorer.ListEmpty("Looks like there is no Tasks yet");
                }
                if (IssueBuilder.IssueBugsList.Count > 0)
                {
                    for (int i = 0; i < IssueBuilder.IssueBugsList.Count; i++)
                    {
                        Console.WriteLine(new String('=', 35));
                        Console.WriteLine($"Name of bug is {IssueBuilder.IssueBugsList[i].Name}");
                        Console.WriteLine($"Difficulty of this bug is {IssueBuilder.IssueBugsList[i].Difficulty}");
                        Console.WriteLine(new String('=', 35));
                    }
                }
                else
                {
                    TextColorer.ListEmpty("Looks like there is no Bugs yet");
                }
                if (IssueBuilder.IssueTechnicalDeptsList.Count > 0)
                {
                    for (int i = 0; i < IssueBuilder.IssueTechnicalDeptsList.Count; i++)
                    {
                        TextColorer.Notify(new String('=', 35));
                        Console.WriteLine($"Name of technical Dept is {IssueBuilder.IssueTechnicalDeptsList[i].Name}");
                        Console.WriteLine($"Difficulty of this Technical dept is {IssueBuilder.IssueTechnicalDeptsList[i].Difficulty}");
                        Console.WriteLine("============================");
                    }
                }
                else
                {
                    TextColorer.ListEmpty("Looks like there is no Technical Depts yet");

                }
            }
            TextColorer.Notify("r - Return to previouse menu");
            string switching = Console.ReadLine()?.ToLower();
            bool menuExit = false;
            do
            {
                switch (switching)
                {
                    case "r":
                        menuExit = true;
                        MainMenu();
                        break;
                    default:
                        menuExit = true;
                        TextColorer.Alert("WHAT?! - Have You been reading menu, bastard?! ");
                        Thread.Sleep(200);
                        ShowIssues();
                        break;

                }
            } while (!menuExit);
        }
    }
}
