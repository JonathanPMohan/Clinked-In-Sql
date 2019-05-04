using ClinkedInSql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedInSql.Validators
{
    public class InterestRequestValidator
    {
        public bool Validate(CreateInterestRequest requestToValidate)
        {
            return !(string.IsNullOrEmpty(requestToValidate.Name));
        }
    }
}