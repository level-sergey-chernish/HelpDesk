using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Issues
{
    public abstract class Issue
    {
        /// <summary>
        /// Get name of Issue
        /// </summary>
        private string _name;

        public string Name {
            get => _name;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _name = value;
                }
                else
                {
                    throw new Exception("Property TaskBuilder.Name can't be empty!");
                }
            }
        }

        /// <summary>
        /// Get priority of Issue. Assigned in inherited classes
        /// </summary>
        public abstract double Priority { get; }

        /// <summary>
        /// Get difficulty of Issue. Deafault range assigned in class IssueBuilder
        /// Can be set from UI
        /// </summary>
        private int _difficulty;

        public int Difficulty
        {
            get => _difficulty;
            set
            {
                if (value < IssueBuilder.DifficultyMin || value > IssueBuilder.DifficultyMax)
                {
                    throw new Exception($"Property TaskBuilder.Difficulty must " +
                        $"be int in range [{IssueBuilder.DifficultyMin} - {IssueBuilder.DifficultyMax}]!");
                }
                _difficulty = value;
            }
        }

        public int ScrumInteration { get; set; } = 0;

        /// <summary>
        /// Get severity of Issue (Severity is total problems)
        /// </summary>

        public double Severity => SeverityCalc();

        /// <summary>
        /// If status true - Issue is resolved, if false - not resolved
        /// </summary>
        public bool IssueStatus => StatusCheck();

        /// <summary>
        /// Issue type (see enum IssueTypes)
        /// </summary>
        public IssueTypes IssueType;

        /// <summary>
        /// Calculation of severity of Issue
        /// </summary>
        /// <returns></returns>
        internal virtual double SeverityCalc()
        {
            return (Difficulty * Priority * (0.1 * Difficulty + 1) - Convert.ToDouble(ScrumInteration));
        }

        /// <summary>
        /// Calculation of Issue resolving
        /// </summary>
        /// <returns></returns>
        internal virtual bool StatusCheck()
        {
            if (Severity <= 0)
            {
                return true;
            }

            return false;
        }

        public enum IssueTypes
        {
            bug,
            task,
            technicalDept
        }

        /// <summary>
        /// Constructor for Issues
        /// </summary>
        /// <param name="issueName">Name of Issue</param>
        /// <param name="issueDifficulty">Difficulty of issue</param>
        /// <param name="issueType">Issue type</param>
        public Issue(string issueName, int issueDifficulty, IssueTypes issueType)
        {
            Name = issueName;
            Difficulty = issueDifficulty;
            IssueType = issueType;
        }

    }
}
