using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Issues
{
    public class IssueTask : Issue
    {
        public IssueTask(string issueName, int issueDifficulty, IssueTypes issueType) : 
            base(issueName, issueDifficulty, issueType)
        {

        }

        private readonly double _priority = 1;

        public override double Priority => _priority;

        internal override double SeverityCalc()
        {
            return Difficulty * Priority - Convert.ToDouble(ScrumInteration);
        }
    }

            
}
