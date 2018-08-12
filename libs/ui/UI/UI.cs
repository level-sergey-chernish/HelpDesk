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
                TextColorer.Alert($"Tasks:{IssueBuilder.TaskIssuesQuantity}     Bugs:Tasks:{IssueBuilder.BugIssuesQuantity}     " +
                    $"Bugs:Tasks:{IssueBuilder.TechnicalDeptsIssuesQuantity}\n");
                TextColorer.Alert(new String('_', 45));

                Console.Write(">>:");
                caseSwitch = Console.ReadLine().ToLower();
                switch (caseSwitch)
                {
                    case "1":
                        Console.Clear();
                        menuExit = true;
                        break;
                    case "2":
                        Console.Clear();
                        menuExit = true;
                        break;
                    case "3":
                        Console.Clear();
                        menuExit = true;
                        break;
                    case "4":
                        Console.Clear();
                        IssueBuilder.ScrumLength = AddScrumLength();
                        menuExit = true;
                        MainMenu();
                        break;
                    case "5":
                        Console.Clear();
                        menuExit = true;
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
                        break;
                }
            } while (!menuExit);
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
    }
}
