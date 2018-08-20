using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Issues
{
    public class IssueTechnicalDept : Issue
    {
        public IssueTechnicalDept(string issueName, int issueDifficulty, IssueTypes issueType) :
            base(issueName, issueDifficulty, issueType)
        {

        }

        private readonly double _priority = 0.5;

        public override double Priority => _priority;
    }
}
