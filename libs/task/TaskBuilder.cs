﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Issues
{
    public static class IssueBuilder
    {
        /// <summary>
        /// Minimal value of initial difficulty of issue
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
        /// Minimal value of initial difficulty of issue
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
        public static IssueTask CreateIssueTask(string issueName, int issueDifficulty, Issue.IssueTypes issueType)
        {
            return new IssueTask(issueName: issueName, issueDifficulty: issueDifficulty, issueType: issueType);
        }

        /// <summary>
        /// Constructor of IssueBug
        /// </summary>
        public static IssueBug CreateIssueBug(string issueName, int issueDifficulty, Issue.IssueTypes issueType)
        {
            return new IssueBug(issueName: issueName, issueDifficulty: issueDifficulty, issueType: issueType);
        }

        //Constructor of IssueTechnicalDept
        public static IssueTechnicalDept CreateIssueTechnicalDept(string issueName, int issueDifficulty, Issue.IssueTypes issueType)
        {
            return new IssueTechnicalDept(issueName, issueDifficulty, issueType);
        }
    }
}
