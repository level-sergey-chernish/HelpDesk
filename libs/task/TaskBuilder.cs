using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Issues
{
    public static class IssueBuilder
    {
        /// <summary>
        /// Overall attempts for resolving of the all Issues.
        /// Eq. Scrum length. Can't be <= 0
        /// Default is 30
        /// </summary>
        private static int _scrumLength = 30;

        public static int ScrumLength
        {
            get => _scrumLength;

            set
            {
                if (int.TryParse(Convert.ToString(value), out int isInt) && 
                    value >= 1)

                {
                    _scrumLength = value;
                }
                else
                {
                    throw new Exception("Property IssueBuilder.Complexity must be " +
                        "int in range [1 - 2,147,483,647]!");
                }
            }
        }

        /// <summary>
        /// Overall severity of all Issues
        /// </summary>
        public static double Complexity
        {
            get => ComplexityCalc();
        }

        private static double ComplexityCalc()
        {
            double complexity = 0;
            for (var i = 0; i < IssueTasksList.Count; i++)
            {
                complexity += IssueTasksList.ElementAt(i).Severity;
            }
            for (var i = 0; i < IssueBugsList.Count; i++)
            {
                complexity += IssueBugsList.ElementAt(i).Severity;
            }
            for (var i = 0; i < IssueTechnicalDeptsList.Count; i++)
            {
                complexity += IssueTechnicalDeptsList.ElementAt(i).Severity;
            }
            return complexity;
        }

        /// <summary>
        /// Overall number of all Issues
        /// </summary>
        public static int TotalIssuesQuantity
        {
            get => TotalIssuesCalc();
        }

        /// <summary>
        /// Number of Issues like Task
        /// </summary>
        public static int TaskIssuesQuantity
        {
            get => IssueTasksCount();
        }

        /// <summary>
        /// Number of Issues like Bug
        /// </summary>
        public static int BugIssuesQuantity
        {
            get => IssueBugsCount();
        }

        /// <summary>
        /// Number of Issues like Technical Dept
        /// </summary>
        public static int TechnicalDeptsIssuesQuantity
        {
            get => IssueTechnicalDeptsCount();
        }

        /// <summary>
        /// Overall number of Task Issues
        /// </summary>
        /// <returns></returns>
        private static int TotalIssuesCalc()
        {
             return ( IssueTasksCount() + IssueBugsCount() + IssueTechnicalDeptsCount() );
        }

        /// <summary>
        /// Overall number of issue of type task
        /// </summary>
        /// <returns></returns>
        private static int IssueTasksCount()
        {
             return IssueTasksList.Count;
        }

        /// <summary>
        /// Overall number of issue of type bug
        /// </summary>
        /// <returns></returns>
        private static int IssueBugsCount()
        {
             return IssueBugsList.Count;
        }

        /// <summary>
        /// Overall number of issue of type TechnicalDeptCount
        /// </summary>
        /// <returns></returns>
        private static int IssueTechnicalDeptsCount()
        {
             return IssueTechnicalDeptsList.Count;
        }

        /// <summary>
        /// Closed issues - issues which have severity <=0
        /// after scrum
        /// </summary>
        /// <returns></returns>
        public static int ClosedIssues()
        {
            int closedIssues = 0;
           
            for (var i = 0; i < IssueTasksList.Count; i++)
            {
                if (IssueTasksList.Count == 0)
                {
                    break;
                }
                else
                {
                    if (IssueTasksList.ElementAt(i).IssueStatus)
                    {
                        closedIssues++;
                    }
                }
            }
            for (var i = 0; i < IssueBugsList.Count; i++)
            {
                if (IssueBugsList.ElementAt(i).IssueStatus)
                {
                    closedIssues++;
                }
            }
            for (var i = 0; i < IssueTechnicalDeptsList.Count; i++)
            {
                if (IssueTechnicalDeptsList.ElementAt(i).IssueStatus)
                {
                    closedIssues++;
                }
            }
            return closedIssues;
        }

        int k = Issues.Sever

        /// <summary>
        /// Check if scrum possible. If overall severities
        /// (Complexity) > Scrum length - return negative
        /// </summary>
        /// <returns></returns>
        public static bool IsScrumPossible()
        {
            if(Complexity > Convert.ToDouble(ScrumLength))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Make some artificial curved hands:
        /// if true - intteration of scrum not complete
        /// </summary>
        /// <returns></returns>
        public static bool ScrumCycleDeffect()
        {
            int isDefect;
            Thread.Sleep(50);
            Random rnd = new Random();
            isDefect = rnd.Next(1, 3);
            if (isDefect <= 2)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Minimal value of initial difficulty of issue.
        /// Default value is 1
        /// </summary>
        private static int _difficultyMin = 1;
        
        public static int DifficultyMin
        {
            get => _difficultyMin;

            set
            {
                if (int.TryParse(Convert.ToString(value), out int isInt))
                {
                    _difficultyMin = value;
                }
                else
                {
                    throw new Exception("Property IssueBuilder.DifficultyMin must be int!");
                }
            }
        }

        /// <summary>
        /// Minimal value of initial difficulty of issue.
        /// Deafult value is 5
        /// </summary>
        private static int _difficultyMax = 5;
        
        public static int DifficultyMax
        {
            get => _difficultyMax;

            set
            {
                if (int.TryParse(Convert.ToString(value), out int isInt) &&
                    value > DifficultyMin)
                {
                    _difficultyMax = value;
                }
                else
                {
                    throw new Exception("Property IssueBuilder.DifficultyMax must be " +
                        "int and > IssueBuilder.DifficultyMin!");
                }
            }
        }

        /// <summary>
        /// List of all IssueTask
        /// </summary>
        public static List<IssueTask> IssueTasksList = new List<IssueTask>();

        /// <summary>
        /// List of all IssueBug
        /// </summary>
        public static List<IssueBug> IssueBugsList = new List<IssueBug>();

        /// <summary>
        /// List of all TechnicalDept
        /// </summary>
        public static List<IssueTechnicalDept> IssueTechnicalDeptsList = new List<IssueTechnicalDept>();

        /// <summary>
        /// Contructor of IssueTask
        /// </summary>
        public static IssueTask CreateIssueTask(string issueName, int issueDifficulty, 
            Issue.IssueTypes issueType)
        {
            return new IssueTask(issueName: issueName, issueDifficulty: issueDifficulty, issueType: issueType);
        }

        /// <summary>
        /// Constructor of IssueBug
        /// </summary>
        public static IssueBug CreateIssueBug(string issueName, int issueDifficulty, 
            Issue.IssueTypes issueType)
        {
            return new IssueBug(issueName: issueName, issueDifficulty: issueDifficulty, issueType: issueType);
        }

        //Constructor of IssueTechnicalDept
        public static IssueTechnicalDept CreateIssueTechnicalDept(string issueName, 
            int issueDifficulty, Issue.IssueTypes issueType)
        {
            return new IssueTechnicalDept(issueName, issueDifficulty, issueType);
        }


    }
}
