using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject.Bussiness_Rule;

namespace BussinessObject
{
    public abstract class BusinessObject
    {
        //list of bussiness rule
        List<BusinessRule> Rules = new List<BusinessRule>();
        //list of error
        List<string> errors = new List<string>();

        public List<string> Errors
        {
            get { return errors; }
        }

        protected void addRule(BusinessRule br)
        {
            Rules.Add(br);
        }

        public bool IsValid()
        {
            bool valid = true;
            errors.Clear();
            foreach (var rule in Rules)
            {
                if (!rule.Validate(this))
                {
                    valid = false;
                    errors.Add(rule.Error);
                }
            }
            return valid;
        }
    }
}
