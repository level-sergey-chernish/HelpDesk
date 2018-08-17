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
                        DeleteIssues();
                        menuExit = true;
                        MainMenu();
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
                        IssueBuilder.DifficultyMax = ChangeDifMax();
                        IssueBuilder.DifficultyMin = ChangeDifMin();
                        menuExit = true;
                        MainMenu();
                        break;
                    case "6":
                        Console.Clear();
                        StartScrum();
                        menuExit = true;
                        MainMenu();
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

        private static int ChangeDifMax()
        {
            string difficultyMax;
            do
            {
                Console.Clear();
                TextColorer.MenuChoise("Please, input value of Maximum" +
                    "(value must be int and be in range [1 - 2,147,483,647]) \n" +
                    $"And bigger than {IssueBuilder.DifficultyMin}");
                Console.Write(">>:");
                difficultyMax = Console.ReadLine();
                if (int.TryParse(Convert.ToString(difficultyMax), out int isInt) && isInt >= 1
                    && isInt > IssueBuilder.DifficultyMin)

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
        private static int ChangeDifMin()
        {
            string difficultyMin;
            do
            {
                Console.Clear();
                TextColorer.MenuChoise("Please, input value of Minimum" +
                    "(value must be int and be in range [1 - 2,147,483,647] \n)" +
                    $"And lower than {IssueBuilder.DifficultyMax}");
                Console.Write(">>:");
                difficultyMin = Console.ReadLine();
                if (int.TryParse(Convert.ToString(difficultyMin), out int isInt) && isInt >= 1
                    && isInt < IssueBuilder.DifficultyMax)

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
            Console.Clear();
            if (IssueBuilder.IssueTasksList.Count == 0 && IssueBuilder.IssueBugsList.Count == 0
                && IssueBuilder.IssueTechnicalDeptsList.Count == 0)
            {
                Console.Clear();
                TextColorer.ListEmpty("There is no any Issues yet. You can back in main menu and add it!");
            }
            else
            {
                if (IssueBuilder.IssueTasksList.Count > 0)
                {
                    for (int i = 0; i < IssueBuilder.IssueTasksList.Count; i++)
                    {
                        TextColorer.Notify(new String('=', 35));
                        Console.WriteLine();
                        TextColorer.Notify($"Name of task is {IssueBuilder.IssueTasksList[i].Name}");
                        TextColorer.Notify($"Difficulty of this task is {IssueBuilder.IssueTasksList[i].Difficulty}");
                        Console.WriteLine();
                        TextColorer.Notify(new String('=', 35));
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
                        TextColorer.Notify(new String('=', 35));
                        Console.WriteLine();
                        TextColorer.Notify($"Name of bug is {IssueBuilder.IssueBugsList[i].Name}");
                        TextColorer.Notify($"Difficulty of this bug is {IssueBuilder.IssueBugsList[i].Difficulty}");
                        Console.WriteLine();
                        TextColorer.Notify(new String('=', 35));
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
                        Console.WriteLine();
                        TextColorer.Notify($"Name of technical Dept is {IssueBuilder.IssueTechnicalDeptsList[i].Name}");
                        TextColorer.Notify($"Difficulty of this Technical dept is {IssueBuilder.IssueTechnicalDeptsList[i].Difficulty}");
                        Console.WriteLine();
                        TextColorer.Notify(new String('=', 35));
                    }
                }
                else
                {
                    TextColorer.ListEmpty("Looks like there is no Technical Depts yet");

                }
            }
            Console.WriteLine();
            TextColorer.MenuChoise("r - Return to previouse menu");
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

        public static void StartScrum()
        {   if (IssueBuilder.Complexity < IssueBuilder.ScrumLength)
            {
                for (int i = 0; i < IssueBuilder.ScrumLength; i++)
                {                   
                    if (!IssueBuilder.ScrumCycleDeffect())
                    {
                        Console.Clear();
                        TextColorer.Notify("Your Issues is resolving now...");
                        if (IssueBuilder.IssueTasksList.Count > 0)
                        {
                            for (int j = 0; j < IssueBuilder.IssueTasksList.Count; j++)
                            {
                                if (IssueBuilder.IssueTasksList[j].IssueStatus == false)
                                {
                                    TextColorer.Notify("Your Task is resolving now...");
                                    IssueBuilder.IssueTasksList[j].ScrumInteration++;
                                }
                            }
                        }
                        if (IssueBuilder.IssueBugsList.Count > 0)
                        {
                            for (int j = 0; j < IssueBuilder.IssueBugsList.Count; j++)
                            {
                                if (IssueBuilder.IssueBugsList[j].IssueStatus == false)
                                {
                                    TextColorer.Notify("Your Bugs is resolving now...");
                                    IssueBuilder.IssueBugsList[j].ScrumInteration++;
                                }
                            }
                        }
                        if (IssueBuilder.IssueTechnicalDeptsList.Count > 0)
                        {
                            for (int j = 0; j < IssueBuilder.IssueTechnicalDeptsList.Count; j++)
                            {
                                if (IssueBuilder.IssueTechnicalDeptsList[j].IssueStatus == false)
                                {
                                    TextColorer.Notify("Your Techs is resolving now...");
                                    IssueBuilder.IssueTechnicalDeptsList[j].ScrumInteration++;
                                }
                            }
                        }

                    }
                }
            }
            else
            {
                TextColorer.Notify($"Sorry, there is too much tasks. \nProgram can't resolve it for {IssueBuilder.ScrumLength} itterations");
                TextColorer.Notify("You can change scrum duration or delete some issues in main menu");
                TextColorer.Notify("Insert any key to go back in main menu");
                Console.ReadLine();
            }
        }

        private static void DeleteIssues()
        {
            if (IssueBuilder.IssueBugsList.Count == 0 && IssueBuilder.IssueTasksList.Count == 0 &&
                IssueBuilder.IssueTechnicalDeptsList.Count == 0)
            {
                Console.WriteLine("There is nothing to delete. Go back to main menu.");
                Thread.Sleep(500);
                MainMenu();
            }
            else
            {
                Console.WriteLine(new String('=', 40));
                TextColorer.MenuChoise($"What kind of issues do you want to delete?\n\n" +
                    $"To delete some Task press \"1\"\n" +
                    $"To delete some Bug press \"2\"\n" +
                    $"To delete some Technical Dept press \"3\"");
                Console.WriteLine(new String('=', 40));
                TextColorer.Notify("r - Return to previous menu");

                string choise = Console.ReadLine();
                bool mainMenu = false;

                while (!mainMenu)
                {
                    switch (choise)
                    {
                        case "1":
                            mainMenu = true;
                            ShowAllTasksAndDeleteByNumber();
                            DeleteIssues();
                            break;
                        case "2":
                            mainMenu = true;
                            ShowAllBugsAndDeleteByNumber();
                            DeleteIssues();
                            break;
                        case "3":
                            mainMenu = true;
                            ShowAllTechnicalDeptsAndDeleteByNumber();
                            DeleteIssues();
                            break;
                        case "r":
                            mainMenu = true;
                            MainMenu();
                            break;
                        default:
                            TextColorer.Alert("Invalid enter. Please take a look on program's hints");
                            Thread.Sleep(200);
                            DeleteIssues();
                            break;
                    }
                }
            }
        }

        private static void ShowAllTasksAndDeleteByNumber()
        {
            Console.Clear();
            Console.WriteLine(new String('=', 40));
            if (IssueBuilder.IssueTasksList.Count == 0)
            {
                TextColorer.Notify("There is no task to delete");
            }
            else
            {
                for (int i = 0; i < IssueBuilder.IssueTasksList.Count; i++)
                {
                    Console.WriteLine($"Task {IssueBuilder.IssueTasksList[i].Name} with number {i}");
                }
            }
            Console.WriteLine(new String('=', 40));

            bool validEnter = false;
            int numberOfTask = -1;

            while (!validEnter && IssueBuilder.IssueTasksList.Count != 0)
            {
                TextColorer.MenuChoise("Please enter the number of task to delete");
                if (Int32.TryParse(Console.ReadLine(), out int value) && value >= 0 && value < IssueBuilder.IssueTasksList.Count)
                {
                    numberOfTask = value;
                    validEnter = true;
                    IssueBuilder.IssueTasksList.RemoveAt(numberOfTask);
                    Console.WriteLine("Task has been successfully deleted!");
                    Thread.Sleep(600);
                    Console.Clear();
                }
                else
                {
                    TextColorer.Alert("Invalid input!");
                    Thread.Sleep(600);
                }
            }
        }

        private static void ShowAllBugsAndDeleteByNumber()
        {
            Console.Clear();
            Console.WriteLine(new String('=', 40));
            for (int i = 0; i < IssueBuilder.IssueBugsList.Count; i++)
            {
                Console.WriteLine($"Task {IssueBuilder.IssueBugsList[i].Name} with number {i}");
            }
            Console.WriteLine(new String('=', 40));

            bool validEnter = false;
            int numberOfTask = -1;

            while (!validEnter && IssueBuilder.IssueBugsList.Count != 0)
            {
                TextColorer.MenuChoise("Please enter the number of bug to delete");
                if (Int32.TryParse(Console.ReadLine(), out int value) && value >= 0 && value < IssueBuilder.IssueBugsList.Count)
                {
                    numberOfTask = value;
                    validEnter = true;
                    IssueBuilder.IssueBugsList.RemoveAt(numberOfTask);
                    Console.WriteLine("Task has been successfully deleted!");
                    Thread.Sleep(600);
                    Console.Clear();
                }
                else
                {
                    TextColorer.Alert("Invalid input!");
                    Thread.Sleep(600);
                }
            }
        }

        private static void ShowAllTechnicalDeptsAndDeleteByNumber()
        {
            Console.Clear();
            Console.WriteLine(new String('=', 40));
            for (int i = 0; i < IssueBuilder.IssueTechnicalDeptsList.Count; i++)
            {
                Console.WriteLine($"Task {IssueBuilder.IssueTechnicalDeptsList[i].Name} with number {i}");
            }
            Console.WriteLine(new String('=', 40));

            bool validEnter = false;
            int numberOfTask = -1;

            while (!validEnter && IssueBuilder.IssueTechnicalDeptsList.Count != 0)
            {
                TextColorer.MenuChoise("Please enter the number of technical dept to delete");
                if (Int32.TryParse(Console.ReadLine(), out int value) && value >= 0 && value < IssueBuilder.IssueTechnicalDeptsList.Count)
                {
                    numberOfTask = value;
                    validEnter = true;
                    IssueBuilder.IssueTechnicalDeptsList.RemoveAt(numberOfTask);
                    Console.WriteLine("Task has been successfully deleted!");
                    Thread.Sleep(300);
                    Console.Clear();
                }
                else
                {
                    TextColorer.Alert("Invalid input!");
                    Thread.Sleep(600);
                }
            }
        }
    }
}
