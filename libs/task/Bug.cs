using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Issues
{
    public class IssueBug : Issue
    {
        public IssueBug(string issueName, int issueDifficulty, IssueTypes issueType) :
            base(issueName, issueDifficulty, issueType)
        {


        }

        private readonly double _priority = 2;

        public override double Priority => _priority;
    }
}
